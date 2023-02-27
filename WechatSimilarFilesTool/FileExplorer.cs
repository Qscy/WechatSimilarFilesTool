using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace WechatSimilarFilesTool
{
    public partial class FileExplorer : UIForm
    {
        public FileExplorer()
        {
            InitializeComponent();
        }
        List<WeChatFiles[]> similars = new List<WeChatFiles[]>(InitWindow.similars);
        List<string> Months = new List<string>(InitWindow.Months);
        List<string> Users = new List<string>(InitWindow.Users);
        private void FileExplorer_Load(object sender, EventArgs e)
        {
            var dic = Methods.MonthsOrder(Months);
            foreach(string user in Users)
            {
                uiNavMenu1.Nodes.Add(user,user);
            }
            for(int i = 0; i < Users.Count; i++)
            {
                var userMonth = new List<string>();
                foreach (WeChatFiles[] wcfList in similars)
                {
                    foreach (WeChatFiles wcf in wcfList)
                    {
                        if(wcf.user == Users[i] && !userMonth.Contains(wcf.month))
                        {
                            userMonth.Add(wcf.month);
                        }
                    }
                }
                var sortMonths = new SortedDictionary<int, string>();
                foreach(string month in userMonth)
                {
                    foreach(KeyValuePair<int,string> kvp in dic)
                    {
                        if (month.Replace("-", "") == kvp.Value)
                            sortMonths.Add(kvp.Key, month);
                    }
                }
                sortMonths.Reverse();
                var node = uiNavMenu1.Nodes[uiNavMenu1.Nodes.IndexOfKey(Users[i])];
                foreach (KeyValuePair<int,string> kvp in sortMonths)
                {
                    node.Nodes.Add(kvp.Value);
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
            uiNavMenu1.Refresh();
        }

        private void FileExplorer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
