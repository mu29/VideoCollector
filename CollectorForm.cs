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

        // 요소 하나 뽑아오기
        private String GetElement(char separator, String identifier, String text, int index = 1)
        {
            String[] candidate = text.Split(separator);
            String value = "";

            for (int i = 0; i < candidate.Length; i++)
            {
                // identifier가 존재한다면 반환
                if (candidate[i].Contains(identifier))
                {
                    value = candidate[i + index];
                    break;
                }
            }

            return value;
        }

        // 요소 여러 개 뽑아오기
        private ArrayList GetElements(char separator, String identifier, String text, int index = 1)
        {
            String[] candidate = text.Split(separator);
            ArrayList value = new ArrayList();

            for (int i = 0; i < candidate.Length; i++)
            {
                // identifier가 존재한다면 리스트에 넣자
                if (candidate[i].Contains(identifier))
                {
                    value.Add(candidate[i + index]);
                }
            }

            return value;
        }

        // 긁어오기 시작
        private void StartSeek()
        {
            try
            {
                String document = mWebBrowser.Document.Body.InnerHtml;
                String fileName = GetElement('>', "video_title", document).Replace("</DIV", "");
                String fileUrl = GetElement('\'', "hq_video_file", document);

                // 파일이 있다면 다운로드
                if (!downloadFileList.ContainsKey(fileName) && fileName != "")
                {
                    mProgressBarCurrent.Value = 0;
                    DownFile downFile = new DownFile(fileName, fileUrl, this);
                    downloadFileList.Add(fileName, downFile);
                    downFile.StartDownload();
                }
            }
            catch { }
        }
        
        // 다음 파일 다운로드
        public void DownloadNext()
        {
            urlList.Remove(currentUrl);
            mProgressBarAll.Value += 1;
            // 받을 파일이 있다면 이동
            if (urlList.Count > 0)
            {
                mWebBrowser.Navigate((String)urlList[0]);
                currentUrl = (String)urlList[0];
            }
            else
            {
                textLog.AppendText("\n다운로드가 완료되었습니다.");
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
            try
            {
                // 목록 불러오는 중이라면
                if (currentUrl == "")
                {
                    if (mWebBrowser.Url.AbsolutePath.Contains("all_time/2"))
                    {
                        // 두번째 페이지
                        String document = mWebBrowser.Document.Body.InnerHtml;
                        // 목록이 있다면 추가하자
                        if (!document.Contains("No results found"))
                            urlList.AddRange(GetElements('\"', "title truncatedtitle", document, 4));

                        // 파일 다운로드 시작
                        textLog.AppendText(urlList.Count + "개 파일 다운로드를 시작합니다.\r\n\n");
                        // 첫 화부터 시작하자
                        urlList.Reverse();
                        mProgressBarAll.Maximum = urlList.Count;
                        mWebBrowser.Navigate((String)urlList[0]);
                        currentUrl = (String)urlList[0];

                        return;
                    }
                    else if (mWebBrowser.Url.AbsolutePath.Contains("all_time"))
                    {
                        // 첫번째 페이지 목록 넣고
                        String document = mWebBrowser.Document.Body.InnerHtml;
                        urlList = GetElements('\"', "title truncatedtitle", document, 4);
                        // 다음 페이지로 이동
                        mWebBrowser.Navigate(textUrl.Text + "2");

                        return;
                    }
                }

                // 목록 불러오기가 끝났다면 영상 다운로드
                StartSeek();
            }
            catch { }
        }
    }
}
