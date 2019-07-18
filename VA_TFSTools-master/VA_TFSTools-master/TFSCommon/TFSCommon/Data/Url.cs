namespace TFSCommon.Data
{
    public class Url
    {
        public Url()
        {
            this.UrlName = "";
            this.UrlLink = "";
        }

        public Url(string urlName, string urlLink, int urlId)
        {
            this.UrlName = urlName;
            this.UrlLink = urlLink;
            this.UrlId = urlId;
        }

        public string UrlName { get; set; }

        public string UrlLink { get; set; }

        public int UrlId { get; set; }

    }
}
