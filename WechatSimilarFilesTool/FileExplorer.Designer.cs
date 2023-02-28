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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileExplorer));
            this.uiNavMenu1 = new Sunny.UI.UINavMenu();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRecycle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFindPath = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.uiContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiNavMenu1
            // 
            this.uiNavMenu1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiNavMenu1.BackColor = System.Drawing.SystemColors.Control;
            this.uiNavMenu1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.uiNavMenu1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.uiNavMenu1.ExpandSelectFirst = false;
            this.uiNavMenu1.FillColor = System.Drawing.SystemColors.ControlDarkDark;
            this.uiNavMenu1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNavMenu1.ForeColor = System.Drawing.Color.White;
            this.uiNavMenu1.FullRowSelect = true;
            this.uiNavMenu1.HideSelection = false;
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
            this.uiNavMenu1.ShowPlusMinus = false;
            this.uiNavMenu1.ShowRootLines = false;
            this.uiNavMenu1.ShowSecondBackColor = true;
            this.uiNavMenu1.Size = new System.Drawing.Size(715, 842);
            this.uiNavMenu1.Style = Sunny.UI.UIStyle.Custom;
            this.uiNavMenu1.TabIndex = 0;
            this.uiNavMenu1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNavMenu1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiNavMenu1.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.uiNavMenu1_DrawNode);
            this.uiNavMenu1.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.uiNavMenu1_NodeMouseHover);
            this.uiNavMenu1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.uiNavMenu1_NodeMouseClick);
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
            this.imageList1.Images.SetKeyName(6, "图像.png");
            this.imageList1.Images.SetKeyName(7, "下三角.png");
            this.imageList1.Images.SetKeyName(8, "其他格式文件.png");
            this.imageList1.Images.SetKeyName(9, "ppt.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.DimGray;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpen,
            this.tsmRecycle,
            this.tsmDelete,
            this.tsmFindPath});
            this.contextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(202, 148);
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.DimGray;
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.ShowImageMargin = false;
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(246, 76);
            this.uiContextMenuStrip1.Style = Sunny.UI.UIStyle.Custom;
            this.uiContextMenuStrip1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.关于ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.关于ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(129, 34);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // tsmOpen
            // 
            this.tsmOpen.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsmOpen.Image = global::WechatSimilarFilesTool.Properties.Resources.打开;
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.Size = new System.Drawing.Size(282, 36);
            this.tsmOpen.Text = "打开它";
            this.tsmOpen.Click += new System.EventHandler(this.tsmOpen_Click);
            // 
            // tsmRecycle
            // 
            this.tsmRecycle.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsmRecycle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsmRecycle.Image = ((System.Drawing.Image)(resources.GetObject("tsmRecycle.Image")));
            this.tsmRecycle.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.tsmRecycle.Name = "tsmRecycle";
            this.tsmRecycle.Size = new System.Drawing.Size(282, 36);
            this.tsmRecycle.Text = "扔到回收站";
            this.tsmRecycle.Click += new System.EventHandler(this.tsmRecycle_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsmDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsmDelete.Image = global::WechatSimilarFilesTool.Properties.Resources.删除;
            this.tsmDelete.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(282, 36);
            this.tsmDelete.Text = "扔到虚空";
            this.tsmDelete.ToolTipText = "（永久删除）";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            this.tsmDelete.MouseHover += new System.EventHandler(this.tsmDelete_MouseHover);
            // 
            // tsmFindPath
            // 
            this.tsmFindPath.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsmFindPath.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsmFindPath.Image = ((System.Drawing.Image)(resources.GetObject("tsmFindPath.Image")));
            this.tsmFindPath.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmFindPath.Name = "tsmFindPath";
            this.tsmFindPath.Size = new System.Drawing.Size(282, 36);
            this.tsmFindPath.Text = "找到它在哪";
            this.tsmFindPath.Click += new System.EventHandler(this.tsmFindPath_Click);
            // 
            // FileExplorer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(715, 880);
            this.Controls.Add(this.uiNavMenu1);
            this.ExtendBox = true;
            this.ExtendMenu = this.uiContextMenuStrip1;
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
            this.contextMenuStrip1.ResumeLayout(false);
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ImageList imageList1;
        private Sunny.UI.UINavMenu uiNavMenu1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmRecycle;
        private ToolStripMenuItem tsmDelete;
        private ToolStripMenuItem tsmFindPath;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private ToolStripMenuItem 关于ToolStripMenuItem;
        private ToolStripMenuItem tsmOpen;
    }
}