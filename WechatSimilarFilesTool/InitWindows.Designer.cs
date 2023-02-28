using Sunny.UI;
using System.Windows.Forms;

namespace WechatSimilarFilesTool
{
    partial class InitWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(236)))), ((int)(((byte)(134)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label1.Location = new System.Drawing.Point(0, 268);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "正在初始化...";
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(236)))), ((int)(((byte)(134)))));
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Location = new System.Drawing.Point(483, 2);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.RectColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.Size = new System.Drawing.Size(51, 38);
            this.uiSymbolButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton1.Symbol = 61453;
            this.uiSymbolButton1.SymbolSize = 20;
            this.uiSymbolButton1.TabIndex = 1;
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // InitWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WechatSimilarFilesTool.Properties.Resources._20181228081531660;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(536, 301);
            this.Controls.Add(this.uiSymbolButton1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "InitWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.InitWindow_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private UISymbolButton uiSymbolButton1;
    }
}