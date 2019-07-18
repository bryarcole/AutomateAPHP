using System;
using System.Collections.Generic;
using TFSCommon.Data;
using TFSCommon.Common;
using TFSTestCaseAttachments.TFSTools;
using TFSTestCaseAttachments.Data;
using TFSTestCaseAttachments.WebTools;

namespace TFSTestCaseAttachments
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter your Personal Access Token: ");
            //string pat = Console.ReadLine();
            //Console.Write("Enter where you want to save the downloads: ");
            //string saveLocation = Console.ReadLine();

            string pat = "7wwgihgjbgchepkpvn4adotkd7bmt3ewtwsr7u4grny7yisrwe3a";
            string saveLocation = "C:\\TestFolder\\";

            Console.Write("Server IP (will default to http://10.3.28.4/ if left empty): ");
            string server = Console.ReadLine();
            if (server == "")
            {
                server = "http://10.3.28.4/";
            }

            Console.Write("Project Name (will default to 'APHP Virginia' if left empty): ");
            string project = Console.ReadLine();
            if (project == "")
            {
                project = "APHP Virginia";
            }

            Console.Write("Enter the Test Plan ID: ");
            int testPlanId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Test Suite ID: ");
            int testSuiteId = Convert.ToInt32(Console.ReadLine());

            //List<string> toolArgs = new List<string>{ pat, server, project, testPlanId, testSuiteId, saveLocation };

            Properties properties = new Properties();
            properties.PersonalAccessToken = pat;
            properties.Uri = server;
            properties.Project = project;
            properties.TestPlanId = testPlanId;
            properties.TestSuiteId = testSuiteId;
            properties.SaveLocation = saveLocation;


            Attachments attachments = new Attachments(properties);
            List<TestCase> urlList = attachments.GatherLinks();

            properties.BasePath = attachments.BasePath;

            //toolArgs.Add(attachments.BasePath);

            Downloader downloader = new Downloader(properties);
            downloader.DownloadFiles(urlList);
            Console.Write("Files have finished downloading. Please press Enter to exit.");
            Console.ReadLine();
        }
    }
}
