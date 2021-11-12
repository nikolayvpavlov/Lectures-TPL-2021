namespace CUIWhyThreads
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bBlocking = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.bThread = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bBlocking
            // 
            this.bBlocking.Location = new System.Drawing.Point(12, 12);
            this.bBlocking.Name = "bBlocking";
            this.bBlocking.Size = new System.Drawing.Size(171, 23);
            this.bBlocking.TabIndex = 0;
            this.bBlocking.Text = "Long Operation";
            this.bBlocking.UseVisualStyleBackColor = true;
            this.bBlocking.Click += new System.EventHandler(this.bBlocking_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(341, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(427, 23);
            this.progressBar.TabIndex = 1;
            // 
            // bThread
            // 
            this.bThread.Location = new System.Drawing.Point(12, 58);
            this.bThread.Name = "bThread";
            this.bThread.Size = new System.Drawing.Size(171, 23);
            this.bThread.TabIndex = 2;
            this.bThread.Text = "Long Op in Thread";
            this.bThread.UseVisualStyleBackColor = true;
            this.bThread.Click += new System.EventHandler(this.bThread_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 304);
            this.Controls.Add(this.bThread);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.bBlocking);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "UI & Threads ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bBlocking;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button bThread;
    }
}

