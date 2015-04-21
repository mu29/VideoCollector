namespace VideoCollector
{
    partial class CollectorForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.webPanel = new System.Windows.Forms.Panel();
            this.mWebBrowser = new System.Windows.Forms.WebBrowser();
            this.textUrl = new System.Windows.Forms.TextBox();
            this.btnCollect = new System.Windows.Forms.Button();
            this.textLog = new System.Windows.Forms.TextBox();
            this.mProgressBarCurrent = new System.Windows.Forms.ProgressBar();
            this.mProgressBarAll = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.webPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // webPanel
            // 
            this.webPanel.Controls.Add(this.mWebBrowser);
            this.webPanel.Location = new System.Drawing.Point(12, 342);
            this.webPanel.Name = "webPanel";
            this.webPanel.Size = new System.Drawing.Size(349, 58);
            this.webPanel.TabIndex = 1;
            this.webPanel.Visible = false;
            // 
            // mWebBrowser
            // 
            this.mWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.mWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.mWebBrowser.Name = "mWebBrowser";
            this.mWebBrowser.Size = new System.Drawing.Size(349, 58);
            this.mWebBrowser.TabIndex = 0;
            this.mWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.mWebBrowser_DocumentCompleted);
            // 
            // textUrl
            // 
            this.textUrl.Location = new System.Drawing.Point(12, 12);
            this.textUrl.Name = "textUrl";
            this.textUrl.Size = new System.Drawing.Size(268, 21);
            this.textUrl.TabIndex = 2;
            // 
            // btnCollect
            // 
            this.btnCollect.Location = new System.Drawing.Point(286, 10);
            this.btnCollect.Name = "btnCollect";
            this.btnCollect.Size = new System.Drawing.Size(75, 23);
            this.btnCollect.TabIndex = 3;
            this.btnCollect.Text = "수집하기";
            this.btnCollect.UseVisualStyleBackColor = true;
            this.btnCollect.Click += new System.EventHandler(this.btnCollect_Click);
            // 
            // textLog
            // 
            this.textLog.Location = new System.Drawing.Point(12, 39);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.Size = new System.Drawing.Size(349, 162);
            this.textLog.TabIndex = 4;
            // 
            // mProgressBarCurrent
            // 
            this.mProgressBarCurrent.Location = new System.Drawing.Point(45, 208);
            this.mProgressBarCurrent.Name = "mProgressBarCurrent";
            this.mProgressBarCurrent.Size = new System.Drawing.Size(316, 16);
            this.mProgressBarCurrent.TabIndex = 5;
            // 
            // mProgressBarAll
            // 
            this.mProgressBarAll.Location = new System.Drawing.Point(45, 230);
            this.mProgressBarAll.Name = "mProgressBarAll";
            this.mProgressBarAll.Size = new System.Drawing.Size(316, 16);
            this.mProgressBarAll.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "현재";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "전체";
            // 
            // CollectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 257);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mProgressBarAll);
            this.Controls.Add(this.mProgressBarCurrent);
            this.Controls.Add(this.textLog);
            this.Controls.Add(this.btnCollect);
            this.Controls.Add(this.textUrl);
            this.Controls.Add(this.webPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CollectorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VideoCollector";
            this.webPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel webPanel;
        private System.Windows.Forms.WebBrowser mWebBrowser;
        private System.Windows.Forms.TextBox textUrl;
        private System.Windows.Forms.Button btnCollect;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.ProgressBar mProgressBarCurrent;
        private System.Windows.Forms.ProgressBar mProgressBarAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}

