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
        private CollectorForm mForm;

        public DownFile(String name, String url, CollectorForm form)
        {
            mName = name;
            mName = mName.Replace("/", "+");
            mName += ".mp4";

            mUrl = url;
            mPercentage = 0;
            mForm = form;
        }

        public void StartDownload()
        {
            try
            {
                // 새 스레드에서 시작
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
                    mForm.Log("[시작] " + mName);
                });
            }
            catch { }
        }

        void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                // 다운로드 진행 중 (% 표시)
                mPercentage = (int)(e.BytesReceived * 100 / e.TotalBytesToReceive);
                mForm.BeginInvoke((MethodInvoker)delegate
                {
                    mForm.ChangeProgress(mPercentage);
                });
            }
            catch { }
        }

        void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                // 다운로드 완료
                mForm.BeginInvoke((MethodInvoker)delegate
                {
                    mForm.Log("[완료] " + mName);
                    mForm.DownloadNext();
                });
            }
            catch { }
        }
    }
}
