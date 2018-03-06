using Music_Releases.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Music_Releases_Website.Classes
{
    public class RssResult : FileResult
    {
        public string Title { get; set; }
        public List<ExtendedItem> Items { get; set; }

        private Uri currentUrl;

        public RssResult() : base("application/rss+xml") { }

        public RssResult(List<ExtendedItem> items, string title) : this()
        {
            this.Items = items;
            this.Title = title;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            currentUrl = context.HttpContext.Request.Url;
            base.ExecuteResult(context);
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            var items = new List<SyndicationItem>();

            foreach (var item in this.Items)
            {
                string contentString = String.Format("{0} - {1}", item.Artist, item.Title);

                var rssItem = new SyndicationItem();
                TextSyndicationContent titleContent = new TextSyndicationContent(contentString);
                rssItem.Title = titleContent;
                rssItem.Content = titleContent;
                rssItem.Id = "http://" + item.Url;
                rssItem.LastUpdatedTime = item.ReleaseDate;
                rssItem.PublishDate = item.ReleaseDate;
                rssItem.Summary = new TextSyndicationContent(contentString, TextSyndicationContentKind.Plaintext);

                items.Add(rssItem);
            }

            SyndicationFeed feed = new SyndicationFeed(
                this.Title,
                this.Title,
                currentUrl,
                items
            );

            Rss20FeedFormatter formatter = new Rss20FeedFormatter(feed);

            using (XmlWriter writer = XmlWriter.Create(response.Output))
            {
                formatter.WriteTo(writer);
            }
        }
    }
}