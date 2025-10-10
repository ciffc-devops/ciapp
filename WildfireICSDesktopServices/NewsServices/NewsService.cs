using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WF_ICS_ClassLibrary.Models.NewsModels;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.EventHandling;

namespace WildfireICSDesktopServices.NewsServices
{
    public class NewsService
    {
        #region Local Save Stuff
        private string _SaveFileName = "newsArchive.xml";
        List<NewsItem> _newsArchive = new List<NewsItem>();
        public List<NewsItem> newsArchive { get { return _newsArchive; } private set => _newsArchive = value; }

        public event NewsEventHandler newsArchiveChanged;
        protected virtual void OnNewsArchiveChanged(NewsEventArgs e)
        {
            NewsEventHandler handler = this.newsArchiveChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public NewsService()
        {
            try
            {
                _newsArchive = GetSavedNews();
            }
            catch
            {
                _newsArchive = new List<NewsItem>();
            }
            serverUpdateService = new ca.icscanada.ciapp.ciapp_webservice();
            serverUpdateService.GetAllNewsItemsCompleted += ServerUpdateService_GetAllNewsItemsCompleted; ;
        }

        public void AddNewNews(List<NewsItem> possiblyNew)
        {
            _newsArchive.AddRange(possiblyNew.Where(o => !_newsArchive.Any(n => n.ID == o.ID)));
            OnNewsArchiveChanged(new NewsEventArgs(null));
            SaveNewsArchive();
        }

        public void UpsertNewsItem(NewsItem item)
        {
            newsArchive = newsArchive.Where(o => o.ID != item.ID).ToList();
            newsArchive.Add(item);
            newsArchive = newsArchive.OrderBy(o => o.NewsDate).ToList();
            OnNewsArchiveChanged(new NewsEventArgs(null));
            SaveNewsArchive();
        }

        public List<NewsItem> GetSavedNews()
        {
            List<NewsItem> news = new List<NewsItem>();

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Globals.DefaultFolderName);
            XmlSerializer mySerializer = new XmlSerializer(typeof(NewsArchive));

            try
            {
                System.IO.Directory.CreateDirectory(path);
                // Create an XmlSerializer for the ApplicationSettings type.

                FileInfo fi = new FileInfo(Path.Combine(path, _SaveFileName));
                // If the config file exists, open it.
                if (fi.Exists)
                {
                    using (FileStream myFileStream = fi.OpenRead())
                    {
                        // Create a new instance of the ApplicationSettings by
                        // deserializing the config file.
                        NewsArchive archive =
                        (NewsArchive)mySerializer.Deserialize(myFileStream);
                        if (archive != null) { news = archive.newsItems; }
                        // Assign the property values to this instance of 
                        // the ApplicationSettings class.
                    }
                }
                else
                {
                }
            }
            catch (Exception)
            {

                throw new Exception("There was an error loading the saved news file");
            }

            return news;
        }

        public bool SaveNewsArchive()
        {


            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Globals.DefaultFolderName);
            Directory.CreateDirectory(path);
            bool saveSuccessful = false;

            NewsArchive archive = new NewsArchive();
            archive.newsItems = newsArchive;

            using (StreamWriter myWriter = new StreamWriter(Path.Combine(path, _SaveFileName), false))
            {
                XmlSerializer mySerializer = null;
                try
                {
                    // Create an XmlSerializer for the 
                    // ApplicationSettings type.
                    mySerializer = new XmlSerializer(typeof(NewsArchive));

                    // Serialize this instance of the ApplicationSettings 
                    // class to the config file.
                    mySerializer.Serialize(myWriter, archive);
                    saveSuccessful = true;
                }
                catch (Exception)
                {
                    saveSuccessful = false;
                    //LgMessageBox.Show(ex.Message);
                }
                finally
                {
                    // If the FileStream is open, close it.
                    if (myWriter != null)
                    {
                        myWriter.Close();
                    }
                }
            }
            return saveSuccessful;
        }


        #endregion

        #region Server Interaction Stuff
        ca.icscanada.ciapp.ciapp_webservice serverUpdateService;

        TaskCompletionSource<bool> GetNewsListComplete = null;


        public List<NewsItem> DownloadNewsListResult { get; private set; } = new List<NewsItem>();


        private void ServerUpdateService_GetAllNewsItemsCompleted(object sender, ca.icscanada.ciapp.GetAllNewsItemsCompletedEventArgs e)
        {
            try
            {
                DownloadNewsListResult = new List<NewsItem>();

                GetNewsListComplete = GetNewsListComplete ?? new TaskCompletionSource<bool>();
                
                foreach (var item in e.Result.Result)
                {
                    DownloadNewsListResult.Add(item.newsItemFromWebServiceItem());
                }
                GetNewsListComplete?.TrySetResult(true);


            }
            catch (Exception)
            {

            }
        }



        public async Task<List<NewsItem>> DownloadNewsList()
        {
            GetNewsListComplete = new TaskCompletionSource<bool>();
            serverUpdateService.GetAllNewsItemsAsync();
            await GetNewsListComplete.Task;
            return DownloadNewsListResult;

        }

        #endregion

    }
}
