namespace DUITasks
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
            this.bGetQotDBlocking = new System.Windows.Forms.Button();
            this.lQotD = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.bGetQotDAsync = new System.Windows.Forms.Button();
            this.button2GetQotDAsyncAwait2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bGetQotDBlocking
            // 
            this.bGetQotDBlocking.Location = new System.Drawing.Point(24, 22);
            this.bGetQotDBlocking.Name = "bGetQotDBlocking";
            this.bGetQotDBlocking.Size = new System.Drawing.Size(160, 23);
            this.bGetQotDBlocking.TabIndex = 0;
            this.bGetQotDBlocking.Text = "Get QotD Blocking";
            this.bGetQotDBlocking.UseVisualStyleBackColor = true;
            this.bGetQotDBlocking.Click += new System.EventHandler(this.bGetQotDBlocking_Click);
            // 
            // lQotD
            // 
            this.lQotD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lQotD.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lQotD.Location = new System.Drawing.Point(384, 30);
            this.lQotD.Name = "lQotD";
            this.lQotD.Size = new System.Drawing.Size(523, 175);
            this.lQotD.TabIndex = 1;
            this.lQotD.Text = "...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Get QotD Task";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bGetQotDAsync
            // 
            this.bGetQotDAsync.Location = new System.Drawing.Point(24, 112);
            this.bGetQotDAsync.Name = "bGetQotDAsync";
            this.bGetQotDAsync.Size = new System.Drawing.Size(160, 23);
            this.bGetQotDAsync.TabIndex = 3;
            this.bGetQotDAsync.Text = "Get QotD Async Await";
            this.bGetQotDAsync.UseVisualStyleBackColor = true;
            this.bGetQotDAsync.Click += new System.EventHandler(this.bGetQotDAsync_Click);
            // 
            // button2GetQotDAsyncAwait2
            // 
            this.button2GetQotDAsyncAwait2.Location = new System.Drawing.Point(24, 156);
            this.button2GetQotDAsyncAwait2.Name = "button2GetQotDAsyncAwait2";
            this.button2GetQotDAsyncAwait2.Size = new System.Drawing.Size(160, 23);
            this.button2GetQotDAsyncAwait2.TabIndex = 4;
            this.button2GetQotDAsyncAwait2.Text = "Get QotD Async Await 2";
            this.button2GetQotDAsyncAwait2.UseVisualStyleBackColor = true;
            this.button2GetQotDAsyncAwait2.Click += new System.EventHandler(this.button2GetQotDAsyncAwait2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.button2GetQotDAsyncAwait2);
            this.Controls.Add(this.bGetQotDAsync);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lQotD);
            this.Controls.Add(this.bGetQotDBlocking);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "UI & Tasks";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bGetQotDBlocking;
        private System.Windows.Forms.Label lQotD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bGetQotDAsync;
        private System.Windows.Forms.Button button2GetQotDAsyncAwait2;
    }
}

