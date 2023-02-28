namespace WechatSimilarFilesTool
{
    partial class about
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
            this.uiRichTextBox1 = new Sunny.UI.UIRichTextBox();
            this.SuspendLayout();
            // 
            // uiRichTextBox1
            // 
            this.uiRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiRichTextBox1.FillColor = System.Drawing.Color.DimGray;
            this.uiRichTextBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRichTextBox1.Location = new System.Drawing.Point(0, 35);
            this.uiRichTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiRichTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRichTextBox1.Name = "uiRichTextBox1";
            this.uiRichTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.uiRichTextBox1.RectColor = System.Drawing.Color.Transparent;
            this.uiRichTextBox1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiRichTextBox1.ScrollBarBackColor = System.Drawing.SystemColors.Control;
            this.uiRichTextBox1.ShowText = false;
            this.uiRichTextBox1.Size = new System.Drawing.Size(688, 296);
            this.uiRichTextBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiRichTextBox1.TabIndex = 0;
            this.uiRichTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiRichTextBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // about
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(688, 331);
            this.ControlBoxFillHoverColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.uiRichTextBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "about";
            this.RectColor = System.Drawing.Color.DimGray;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ShowRect = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "关于";
            this.TitleColor = System.Drawing.Color.DimGray;
            this.ZoomScaleRect = new System.Drawing.Rectangle(26, 26, 800, 450);
            this.Load += new System.EventHandler(this.about_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIRichTextBox uiRichTextBox1;
    }
}