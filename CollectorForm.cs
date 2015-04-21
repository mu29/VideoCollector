using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Collections;

namespace VideoCollector
{
    public partial class CollectorForm : Form
    {
        private Dictionary<String, DownFile> downloadFileList = new Dictionary<String, DownFile>();
        private ArrayList urlList = new ArrayList();
        private String currentUrl = "";

        public CollectorForm()
        {
            InitializeComponent();
        }

        private String GetElement(char separator, String identifier, String text, int index = 1)
        {
            String[] candidate = text.Split(separator);
            String value = "";

            for (int i = 0; i < candidate.Length; i++)
            {
                if (candidate[i].Contains(identifier))
                {
                    value = candidate[i + index];
                    break;
                }
            }

            return value;
        }

        private ArrayList GetElements(char separator, String identifier, String text, int index = 1)
        {
            String[] candidate = text.Split(separator);
            ArrayList value = new ArrayList();

            for (int i = 0; i < candidate.Length; i++)
            {
                if (candidate[i].Contains(identifier))
                {
                    value.Add(candidate[i + index]);
                }
            }

            return value;
        }

        private void StartSeek()
        {
            HtmlDocument doc = mWebBrowser.Document;
            String fileName = GetElement('>', "video_title", doc.Body.InnerHtml).Replace("</DIV", "");
            String fileUrl = GetElement('\'', "hq_video_file", doc.Body.InnerHtml);

            if (!downloadFileList.ContainsKey(fileName))
            {
                mProgressBarCurrent.Value = 0;
                DownFile downFile = new DownFile(fileName, fileUrl, this);
                downloadFileList.Add(fileName, downFile);
                downFile.StartDownload();
            }
        }

        public void DownloadNext()
        {
            urlList.Remove(currentUrl);
            mProgressBarAll.Value += 1;
            if (urlList.Count > 0)
            {
                mWebBrowser.Navigate((String)urlList[0]);
                currentUrl = (String)urlList[0];
            }
            else
            {
                textLog.AppendText("다운로드 완료.");
            }
        }

        public void Log(string text)
        {
            textLog.AppendText(text + "\r\n");
        }

        public void ChangeProgress(int value)
        {
            mProgressBarCurrent.Value = value;
        }

        private void btnCollect_Click(object sender, EventArgs e)
        {
            if (textUrl.Text != "")
            {
                mWebBrowser.Navigate(textUrl.Text);
            }
        }

        private void mWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (mWebBrowser.Url.AbsolutePath.Contains("all_time"))
            {
                HtmlDocument doc = mWebBrowser.Document;
                urlList = GetElements('\"', "title truncatedtitle", doc.Body.InnerHtml, 4);
                mProgressBarAll.Maximum = urlList.Count;
                mWebBrowser.Navigate((String) urlList[0]);
                currentUrl = (String) urlList[0];
            }
            else
            {
                StartSeek();
            }
        }
    }
}
