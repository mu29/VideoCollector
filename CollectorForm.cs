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
        Dictionary<String, DownFile> downloadFileList = new Dictionary<String, DownFile>();

        public CollectorForm()
        {
            InitializeComponent();
        }

        private String GetString(char separator, String identifier, String text)
        {
            String[] candidate = text.Split(separator);
            String value = "";

            for (int i = 0; i < candidate.Length; i++)
            {
                if (candidate[i].Contains(identifier))
                {
                    value = candidate[i + 1];
                    break;
                }
            }

            return value;
        }

        private void StartSeek()
        {
            HtmlDocument doc = mWebBrowser.Document;
            String fileName = GetString('>', "video_title", doc.Body.InnerHtml).Replace("</DIV", "");
            String fileUrl = GetString('\'', "hq_video_file", doc.Body.InnerHtml);

            if (!downloadFileList.ContainsKey(fileName))
            {
                DownFile downFile = new DownFile(fileName, fileUrl, this);
                downloadFileList.Add(fileName, downFile);
                downFile.startDownload();
            }
        }

        public void Log(string text)
        {
            textLog.AppendText(text + "\r\n");
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
            StartSeek();
        }
    }
}
