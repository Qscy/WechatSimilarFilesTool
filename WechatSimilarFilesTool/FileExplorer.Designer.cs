using System.Windows.Forms;

namespace WechatSimilarFilesTool
{
    partial class FileExplorer
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
            this.components = new System.ComponentModel.Container();
            AnimatorNS.Animation animation1 = new AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileExplorer));
            this.animator1 = new AnimatorNS.Animator(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.uiNavMenu1 = new Sunny.UI.UINavMenu();
            this.SuspendLayout();
            // 
            // animator1
            // 
            this.animator1.AnimationType = AnimatorNS.AnimationType.Custom;
            this.animator1.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.animator1.DefaultAnimation = animation1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "用户.png");
            this.imageList1.Images.SetKeyName(1, "日历 .png");
            this.imageList1.Images.SetKeyName(2, "文档-docx_doc.png");
            this.imageList1.Images.SetKeyName(3, "表格-xlxs_xls.png");
            this.imageList1.Images.SetKeyName(4, "PDF.png");
            this.imageList1.Images.SetKeyName(5, "zip.png");
            // 
            // uiNavMenu1
            // 
            this.uiNavMenu1.BackColor = System.Drawing.SystemColors.Control;
            this.uiNavMenu1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.animator1.SetDecoration(this.uiNavMenu1, AnimatorNS.DecorationType.None);
            this.uiNavMenu1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.uiNavMenu1.ExpandSelectFirst = false;
            this.uiNavMenu1.FillColor = System.Drawing.SystemColors.ControlDarkDark;
            this.uiNavMenu1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNavMenu1.ForeColor = System.Drawing.Color.White;
            this.uiNavMenu1.FullRowSelect = true;
            this.uiNavMenu1.ImageIndex = 0;
            this.uiNavMenu1.ImageList = this.imageList1;
            this.uiNavMenu1.ItemHeight = 50;
            this.uiNavMenu1.Location = new System.Drawing.Point(0, 36);
            this.uiNavMenu1.Margin = new System.Windows.Forms.Padding(0);
            this.uiNavMenu1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiNavMenu1.Name = "uiNavMenu1";
            this.uiNavMenu1.SelectedColorGradient = true;
            this.uiNavMenu1.SelectedImageIndex = 0;
            this.uiNavMenu1.ShowLines = false;
            this.uiNavMenu1.ShowOneNode = true;
            this.uiNavMenu1.ShowSecondBackColor = true;
            this.uiNavMenu1.Size = new System.Drawing.Size(715, 842);
            this.uiNavMenu1.Style = Sunny.UI.UIStyle.Custom;
            this.uiNavMenu1.TabIndex = 0;
            this.uiNavMenu1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNavMenu1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FileExplorer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(715, 880);
            this.Controls.Add(this.uiNavMenu1);
            this.animator1.SetDecoration(this, AnimatorNS.DecorationType.None);
            this.ExtendBox = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9.428572F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FileExplorer";
            this.Opacity = 0D;
            this.Padding = new System.Windows.Forms.Padding(2, 36, 2, 2);
            this.ShowDragStretch = true;
            this.ShowRadius = false;
            this.ShowShadow = true;
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "微信相似文件查找清理工具—Qscy";
            this.TitleColor = System.Drawing.Color.DimGray;
            this.TitleFont = new System.Drawing.Font("幼圆", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZoomScaleRect = new System.Drawing.Rectangle(26, 26, 715, 880);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FileExplorer_FormClosed);
            this.Load += new System.EventHandler(this.FileExplorer_Load);
            this.Shown += new System.EventHandler(this.FileExplorer_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        private AnimatorNS.Animator animator1;
        private ImageList imageList1;
        private Sunny.UI.UINavMenu uiNavMenu1;
    }
}