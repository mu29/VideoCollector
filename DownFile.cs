using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Windows.Forms;

namespace VideoCollector
{
    public class DownFile
    {
        private String mName;
        private String mUrl;
        private int mPercentage;
        private Boolean isCompleted;
        private CollectorForm mForm;

        public DownFile(String name, String url, CollectorForm form)
        {
            mName = name;
            mName = mName.Replace("/", "+");
            mName += ".mp4";

            mUrl = url;
            mPercentage = 0;
            isCompleted = false;
            mForm = form;
        }

        public void StartDownload()
        {
            Thread thread = new Thread(() =>
            {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(mUrl), "./" + mName);
            });
            thread.Start();
            mForm.BeginInvoke((MethodInvoker)delegate
            {
                mForm.Log(mName + " 다운로드 시작");
            });
        }

        void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            mPercentage = (int)(e.BytesReceived * 100 / e.TotalBytesToReceive);
        }

        void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            isCompleted = true;
            mForm.BeginInvoke((MethodInvoker)delegate
            {
                mForm.Log(mName + " 다운로드 완료");
                mForm.downloadNext();
            });
        }
    }
}
