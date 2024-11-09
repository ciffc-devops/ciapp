using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models.NewsModels;
using WildfireICSDesktopServices;
using WildfireICSDesktopServices.Logging;
using WildfireICSDesktopServices.NewsServices;

namespace Wildfire_ICS_Tests
{
    [TestClass]
    public class NewsTests
    {
        [TestMethod]
        public async Task DownloadNewsTest()
        {
            NetworkService networkService = new NetworkService();
            NewsService newsService = new NewsService();
            bool isConnected = await networkService.CheckForInternetConnectionAsync();
            Assert.IsTrue(isConnected);

            if (isConnected)
            {
                try
                {
                    List<NewsItem> updates = await newsService.DownloadNewsList().ConfigureAwait(false);
                    newsService.AddNewNews(updates);
                    Assert.AreNotEqual(updates.Count, 0, "No news items were downloaded");

                }
                catch (Exception ex)
                {
                   Console.WriteLine(ex.Message);
                    Assert.IsTrue(false, "An exception was thrown while downloading news");
                }
            }
        }
    }
}
