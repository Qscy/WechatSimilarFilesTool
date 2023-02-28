using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Sunny.UI;
using Microsoft.VisualBasic.FileIO;
namespace WechatSimilarFilesTool
{
    public partial class FileExplorer : UIForm
    {
        public FileExplorer()
        {
            InitializeComponent();
        }
        string weChatPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\WeChat Files\\";     //微信文件地址
        string subPath = "\\FileStorage\\File\\";  //用户下的地址
        private void FileExplorer_Load(object sender, EventArgs e)
        {
            this.contextMenuStrip1.Renderer = new MyRenderer();
            var iw = new InitWindow();
            if(iw.ShowDialog()==DialogResult.OK)
            {
                List<WeChatFiles[]> similars = new List<WeChatFiles[]>(InitWindow.similars);    //传入的相似文件
                List<string> Users = new List<string>(InitWindow.Users);    //包含的用户
                List<string> Months = new List<string>(InitWindow.Months);  //包含的月份
                TreeViewLoad(similars,Users,Months);
                while (true)    //来个小动画
                {
                    this.Opacity -= 0.1;
                    Thread.Sleep(25);
                    if (this.Opacity == 0) break;
                }
            }
        }
        private void FileExplorer_Shown(object sender, EventArgs e)
        {
            while (true)    //渐入小动画
            {
                this.Opacity += 0.1;
                Thread.Sleep(25);
                if (this.Opacity == 1) break;
            }
            uiNavMenu1 = Methods.SetTreeViewStyle(uiNavMenu1);
            uiNavMenu1.Nodes[0].Expand();
            uiNavMenu1.Nodes[0].Nodes[0].ExpandAll();
            uiNavMenu1.Refresh();
        }
        private void TreeViewLoad(List<WeChatFiles[]> similars, List<string> Users, List<string> Months)    //在TreeView中加载读取到的数据
        {
            var dic = Methods.MonthsOrder(Months);
            foreach (string user in Users)
            {
                uiNavMenu1.Nodes.Add(user, user);
            }
            for (int i = 0; i < Users.Count; i++)
            {
                var userMonth = new List<string>();
                foreach (WeChatFiles[] wcfList in similars)
                {
                    foreach (WeChatFiles wcf in wcfList)
                    {
                        if (wcf.user == Users[i] && !userMonth.Contains(wcf.month))
                        {
                            userMonth.Add(wcf.month);
                        }
                    }
                }
                var sortMonths = new SortedDictionary<int, string>();
                foreach (string month in userMonth)
                {
                    foreach (KeyValuePair<int, string> kvp in dic)
                    {
                        if (month.Replace("-", "") == kvp.Value)
                            sortMonths.Add(kvp.Key, month);
                    }
                }
                sortMonths.Reverse();
                var node = uiNavMenu1.Nodes[uiNavMenu1.Nodes.IndexOfKey(Users[i])];
                foreach (KeyValuePair<int, string> kvp in sortMonths)
                {
                    node.Nodes.Add(kvp.Value, kvp.Value);
                    var nodeMonth = node.Nodes[node.Nodes.IndexOfKey(kvp.Value)];
                    foreach (WeChatFiles[] wcfarry in similars)
                    {
                        foreach (WeChatFiles wcf in wcfarry)
                        {
                            if (wcf.user == Users[i] && wcf.month == kvp.Value)
                            {
                                var tittle = $"==============={wcfarry.Length}个文件重复===============";
                                var nodeTittle = nodeMonth.Nodes.Add("tittle", tittle);
                                foreach (WeChatFiles wcf2 in wcfarry)
                                {
                                    var filenode = nodeTittle.Nodes.Add(wcf2.filename, wcf2.filename);
                                    var fpath = weChatPath + wcf2.user + subPath + wcf2.month + "\\" + wcf2.filename;
                                    var fi = new FileInfo(fpath);
                                    filenode.ToolTipText = $"修改日期：{fi.LastWriteTime}\t所在文件夹：{fi.Directory.Name}";
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void FileExplorer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void uiNavMenu1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            //var bounds = e.Node.Bounds;
            //if (e.Node.Name == "tittle")
            //{
            //    e.Graphics.DrawRectangle(Color.DarkRed, bounds, true, 2);
            //}
            //else if(e.Node.Level == 2)
            //{
            //    e.Graphics.DrawString(e.Node.ToolTipText, new Font("微软雅黑", 8, FontStyle.Italic), Brushes.DarkRed, e.Bounds.Width/4, e.Bounds.Height * 3 / 2);
            //}
        }

        private void uiNavMenu1_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            uiNavMenu1.ShowNodeToolTips = true;
        }

        private void tsmRecycle_Click(object sender, EventArgs e)   //移动到回收站
        {
            var node = uiNavMenu1.SelectedNode;
            var fpath = weChatPath + node.Parent.Parent.Parent.Name + subPath + node.Parent.Parent.Name + "\\" + node.Name;
            FileSystem.DeleteFile(fpath,Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,RecycleOption.SendToRecycleBin);
            var parent = node.Parent;
            node.Remove();
            if (parent.GetNodeCount(false) < 2) parent.Remove();
            uiNavMenu1.Refresh();
        }
        private void tsmDelete_Click(object sender, EventArgs e)    //永久删除
        {
            var node = uiNavMenu1.SelectedNode;
            var fpath = weChatPath + node.Parent.Parent.Parent.Name + subPath + node.Parent.Parent.Name + "\\" + node.Name;
            File.Delete(fpath);
            var parent = node.Parent;
            node.Remove();
            if (parent.GetNodeCount(false) < 2) parent.Remove();
            uiNavMenu1.Refresh();
        }

        private void tsmFindPath_Click(object sender, EventArgs e)  //打开所在位置
        {
            var node = uiNavMenu1.SelectedNode;
            var fpath = weChatPath + node.Parent.Parent.Parent.Name + subPath + node.Parent.Parent.Name + "\\" + node.Name;
            System.Diagnostics.Process.Start("Explorer", "/select," + fpath);
        }
        private void uiNavMenu1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)  //显示右键菜单
        {
            var node = e.Node;
            if (node != null && node.Level == 3 && node.Name != "tittle" && e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition);
            }
            else if (node != null && node.Level == 1 && e.Button == MouseButtons.Left)
            {
                foreach(TreeNode nd in node.Nodes)
                {
                    nd.ExpandAll();
                }
            }
        }

        private void tsmDelete_MouseHover(object sender, EventArgs e)
        {
            contextMenuStrip1.ShowItemToolTips = true;
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new about().ShowDialog();
        }

        private void tsmOpen_Click(object sender, EventArgs e)
        {
            var node = uiNavMenu1.SelectedNode;
            var fpath = weChatPath + node.Parent.Parent.Parent.Name + subPath + node.Parent.Parent.Name + "\\" + node.Name;
            System.Diagnostics.Process.Start(fpath);
        }
    }
}
