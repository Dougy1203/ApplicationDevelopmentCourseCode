
namespace WinFormsNotes
{
    partial class WinFormsStillGood
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
            this.btnHello = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lb = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnHello
            // 
            this.btnHello.Location = new System.Drawing.Point(689, 254);
            this.btnHello.Name = "btnHello";
            this.btnHello.Size = new System.Drawing.Size(188, 58);
            this.btnHello.TabIndex = 0;
            this.btnHello.Text = "Hello";
            this.btnHello.UseVisualStyleBackColor = true;
            this.btnHello.Click += new System.EventHandler(this.btnGoodbye_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(748, 372);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(70, 41);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Info";
            // 
            // lb
            // 
            this.lb.FormattingEnabled = true;
            this.lb.ItemHeight = 41;
            this.lb.Items.AddRange(new object[] {
            "Back to the Future",
            "Harry Potter",
            "Star Wars",
            "Nightmare on Elm Street"});
            this.lb.Location = new System.Drawing.Point(201, 181);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(419, 414);
            this.lb.TabIndex = 2;
            this.lb.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // WinFormsStillGood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1728, 770);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnHello);
            this.Name = "WinFormsStillGood";
            this.Text = "WinFormsStillGood";
            this.Load += new System.EventHandler(this.WinFormsStillGood_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHello;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ListBox lb;
    }
}