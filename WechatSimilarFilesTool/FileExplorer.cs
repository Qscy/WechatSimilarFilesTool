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
            if (iw.ShowDialog() == DialogResult.OK)
            {
                List<WeChatFiles[]> similars = new List<WeChatFiles[]>(InitWindow.similars);    //传入的相似文件
                List<string> Users = new List<string>(InitWindow.Users);    //包含的用户
                List<string> Months = new List<string>(InitWindow.Months);  //包含的月份
                TreeViewLoad(similars, Users, Months);
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
            uiNavMenu1 = Methods.SetTreeViewStyle(uiNavMenu1);  //载入自定义样式
            foreach (TreeNode node in uiNavMenu1.Nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    node.Expand();
                    node.Nodes[0].ExpandAll();   //默认展开
                }
            }
            uiNavMenu1.Refresh();
        }
        private void TreeViewLoad(List<WeChatFiles[]> similars, List<string> Users, List<string> Months)    //在TreeView中加载读取到的数据
        {
            var dic = Methods.MonthsOrder(Months);  //添加用户节点
            foreach (string user in Users)
            {
                uiNavMenu1.Nodes.Add(user, user);
            }
            for (int i = 0; i < Users.Count; i++)   //获取用户月份
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
                var sortMonths = new SortedDictionary<int, string>();   //月份排序
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
                foreach (KeyValuePair<int, string> kvp in sortMonths)   //添加月份节点
                {
                    node.Nodes.Add(kvp.Value, kvp.Value);
                    var nodeMonth = node.Nodes[node.Nodes.IndexOfKey(kvp.Value)];
                    foreach (WeChatFiles[] wcfarry in similars)
                    {
                        foreach (WeChatFiles wcf in wcfarry)
                        {
                            if (wcf.user == Users[i] && wcf.month == kvp.Value)     //添加Tittle
                            {
                                var tittle = $"==============={wcfarry.Length}个文件重复";
                                var nodeTittle = nodeMonth.Nodes.Add("tittle", tittle);
                                long talsize = 0;
                                foreach (WeChatFiles wcf2 in wcfarry)   //添加文件节点及相关信息
                                {
                                    var filenode = nodeTittle.Nodes.Add(wcf2.filename, wcf2.filename);
                                    talsize += wcf2.size;
                                    filenode.ToolTipText = $"文件大小:{Methods.AutoFitFormat(wcf2.size)}\t修改日期：{wcf2.lasteditime} 文件夹：{wcf2.month}";
                                }
                                nodeTittle.Text += $"，共计{Methods.AutoFitFormat(talsize)}===============";
                                nodeTittle.ToolTipText = talsize.ToString();
                                break;
                            }
                        }
                    }
                }
            }
            foreach (TreeNode userNode in uiNavMenu1.Nodes)
            {
                for (int i = 0; i < userNode.Nodes.Count; i++)
                {
                    userNode.Nodes[i] = Methods.ChildNodeOrder(userNode.Nodes[i]);
                    userNode.Nodes[i].Text += $"\t\t（共{userNode.Nodes[i].Nodes.Count}个重复项）";
                    foreach (TreeNode tittleNode in userNode.Nodes[i].Nodes) tittleNode.ToolTipText = "";
                }
            }
        }
        private void FileExplorer_FormClosed(object sender, FormClosedEventArgs e)  //关闭按钮
        {
            Environment.Exit(0);
        }
        private void uiNavMenu1_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)    //显示节点提示
        {
            uiNavMenu1.ShowNodeToolTips = true;
        }
        private void tsmRecycle_Click(object sender, EventArgs e)   //移动到回收站
        {
            var node = uiNavMenu1.SelectedNode;
            var fpath = weChatPath + node.Parent.Parent.Parent.Name + subPath + node.Parent.Parent.Name + "\\" + node.Name;
            FileSystem.DeleteFile(fpath, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
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
        private void uiNavMenu1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)  //TreeView的Node点击事件
        {
            var node = e.Node;
            if (node != null && node.Level == 3 && node.Name != "tittle" && e.Button == MouseButtons.Right)     //显示右键菜单
            {
                contextMenuStrip1.Show(MousePosition);
            }
            else if (node != null && node.Level == 1 && e.Button == MouseButtons.Left)  //左键节点展开
            {
                foreach (TreeNode nd in node.Nodes)
                {
                    nd.ExpandAll();
                }
            }
        }

        private void tsmDelete_MouseHover(object sender, EventArgs e)   //删除选项
        {
            contextMenuStrip1.ShowItemToolTips = true;
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)  //关于窗口
        {
            new about().ShowDialog();
        }

        private void tsmOpen_Click(object sender, EventArgs e)  //打开选项
        {
            var node = uiNavMenu1.SelectedNode;
            var fpath = weChatPath + node.Parent.Parent.Parent.Name + subPath + node.Parent.Parent.Name + "\\" + node.Name;
            System.Diagnostics.Process.Start(fpath);
        }
    }
}
