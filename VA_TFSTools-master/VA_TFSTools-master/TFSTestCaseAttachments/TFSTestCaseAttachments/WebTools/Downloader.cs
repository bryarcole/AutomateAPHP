using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System;
using TFSCommon.Common;
using TFSCommon.Network;
using System.Net;
using System.Text;
using TFSCommon.Data;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TFSTestCaseAttachments.WebTools
{
    class Downloader
    {
        private string _saveLocation;
        private string _uri;
        private string _personalAccessToken;
        private string _basePath;

        private List<TestCase> _testCasesMissingAttachments;

        private static HttpClient _client;

        public Downloader(Properties props)
        {
            _saveLocation = props.SaveLocation;
            _uri = props.Uri;
            _personalAccessToken = props.PersonalAccessToken;
            _testCasesMissingAttachments = new List<TestCase>();
            _basePath = props.BasePath;

            HttpClientInitiator initiator = new HttpClientInitiator(_uri, _personalAccessToken);
            _client = initiator.CreateHttpClient();
        }

        public void DownloadFiles(List<TestCase> files)
        {
            foreach (TestCase file in files)
            {
                DownloadFile(file);
            }

            Console.WriteLine("The following Test Cases are missing attachments.");
            foreach (TestCase testCase in _testCasesMissingAttachments)
            {
                Console.WriteLine(testCase.TestCaseName);
            }
            CreateMissingAttachmentsFile();
        }

        private void CreateMissingAttachmentsFile()
        {
            var csv = new StringBuilder();

            List<string> header = new List<string>{ "Folder Path", "Test Case ID", "Test Case Name" };
            csv.AppendLine(CreateCSVRow(header));

            foreach(TestCase missingTestCase in _testCasesMissingAttachments)
            {
                List<string> currTestCaseLine = new List<string>
                {
                    missingTestCase.TestCasePath,
                    missingTestCase.TestCaseId.ToString(),
                    StringTools.StringToCSVCell(missingTestCase.TestCaseName)
                };
                csv.AppendLine(CreateCSVRow(currTestCaseLine));
            }

            File.WriteAllText(_saveLocation + _basePath + "//TestCasesMissingAttachment.csv", csv.ToString());
        }

        private void DownloadFile(TestCase testCase)
        {
            List<string> currFolderPath = testCase.GetTestCasePath();
            currFolderPath.Add(DirectoryTools.CreateValidFolderString(testCase.TestCaseName));
            //currFolderPath.Add(_stringHelper.TrimEndNewLine(url.TestCaseName));
            string folderPath = _saveLocation + GeneratePath(currFolderPath);
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            string truncatedFolderPath = folderPath;
            truncatedFolderPath = r.Replace(truncatedFolderPath, "");
            truncatedFolderPath = Regex.Replace(TruncateFolderName(folderPath, 200),  @"\t|\n|\r", "");
            truncatedFolderPath = Regex.Replace(truncatedFolderPath, @"/", "");
            //Console.WriteLine(WebUtility.HtmlEncode(truncatedFolderPath));
            //Console.WriteLine(truncatedFolderPath.Length);
            DirectoryTools.createDirectory(truncatedFolderPath);

            if (testCase.Urls.Count == 0)
            {
                _testCasesMissingAttachments.Add(testCase);
            }
            else
            {
                foreach (var currUrl in testCase.Urls)
                {

                    Uri urlLink = new Uri(currUrl.UrlLink);
                    string urlName = currUrl.UrlName;

                    string uri = "APHP/_apis/wit/attachments" + currUrl.UrlLink.Substring(currUrl.UrlLink.LastIndexOf('/'));

                    HttpMethod method = new HttpMethod("GET");
                    HttpRequestMessage request = new HttpRequestMessage(method, uri) { };
                    var response = _client.GetAsync(urlLink).Result;
                    response.EnsureSuccessStatusCode();
                    byte[] data = response.Content.ReadAsByteArrayAsync().Result;
                    //Console.WriteLine("Starting File Write");
                    if (Directory.Exists(truncatedFolderPath))
                    {
                        var extension = urlName.Substring(urlName.LastIndexOf("."));
                        string truncatedFolderFileName = TruncateFolderName(truncatedFolderPath + urlName, 260, extension);
                        //Console.WriteLine(truncatedFolderFileName);
                        //Console.WriteLine(truncatedFolderFileName.Length);
                        FileStream fileStream = new FileStream(truncatedFolderFileName,
                        FileMode.Create, FileAccess.Write, FileShare.None);
                        fileStream.SetLength(0);
                        fileStream.Write(data, 0, data.Length);
                        fileStream.Flush(true);
                        fileStream.Close();
                    }

                    Console.WriteLine("Download of {0} has finished.", urlName);
                    //Console.WriteLine(urlLink + "  " + urlName);
                }
            }
        }

        private string GeneratePath(List<string> path)
        {
            return String.Join("\\", path) + "\\";
        }

        private string CreateCSVRow(List<string> row)
        {
            List<string> newRow = new List<string>();
            foreach (string column in row)
            {
                newRow.Add('"' + column + '"');
            }
            return String.Join(",", newRow);
        }

        private string TruncateFolderName(string folderName, int length, string extension=null)
        {
            if (folderName.Length >= length)
            {
                if (extension != null)
                {
                    return folderName.Substring(0, length - extension.Length - 1) + extension;
                }
                else
                {
                    return folderName.Substring(0, length);
                }
            }
            else
            {
                return folderName;
            }
        }
    }
}
