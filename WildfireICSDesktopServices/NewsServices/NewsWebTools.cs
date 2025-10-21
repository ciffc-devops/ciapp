using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models.NewsModels;

namespace WildfireICSDesktopServices.NewsServices
{
    public static class NewsWebTools
    {
        public static NewsItem newsItemFromWebServiceItem(this ca.icscanada.ciapp.NewsItem webItem)
        {
            NewsItem item = new NewsItem();

            item.ID = webItem.ID;
            item.NewsDate = webItem.NewsDate;
            item.LastUpdatedUTC = webItem.LastUpdatedUTC;
            item.NewsTitle = webItem.NewsTitle;
            item.NewsText = webItem.NewsText;
            item.NewsUrl = webItem.NewsUrl;
            item.Active = webItem.Active;

            return item;
        }
    }
}
