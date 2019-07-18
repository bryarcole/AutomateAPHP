using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSTestCaseAttachments.Data
{
    class TestCaseUrl
    {
        public TestCaseUrl()
        {
            this.Path = new List<string>();
            this.TestCaseName = "";
            this.Urls = new List<Url>();
        }

        public TestCaseUrl(List<string> path, string testCaseName, List<Url> urls)
        {
            this.Path = path;
            this.TestCaseName = testCaseName;
            this.Urls = urls;
        }

        public List<string> Path { get; set; }

        public int TestCaseId { get; set; }

        public string TestCaseName { get; set; }

        public List<Url> Urls { get; set; }

        public void AddUrl(string name, string urlLink, int urlId)
        {
            this.Urls.Add(new Url(name, urlLink, urlId));
        }

        public void PrintUrls()
        {
            foreach(var url in this.Urls)
            {
                Console.Write(url.UrlName);
            }

            Console.WriteLine();
        }
    }
}
