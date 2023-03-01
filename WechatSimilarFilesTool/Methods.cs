using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace WechatSimilarFilesTool
{
    public class MyRenderer : ToolStripProfessionalRenderer     //重写右键菜单的背景颜色
    { 
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        { 
            e.Graphics.FillRectangle(new SolidBrush(Color.DimGray), e.AffectedBounds);
        }
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)     //image背景
        {
          Color customColor = Color.DimGray;
            Rectangle affectedBounds = e.AffectedBounds;
            //affectedBounds.Y += 2;
            //affectedBounds.Height -= 4;
            using (SolidBrush brush = new SolidBrush(customColor)) 
            { 
                e.Graphics.FillRectangle(brush, affectedBounds); 
            } 
        }
    }
    internal class Methods
    {
        public static bool MD5HashCompareFile(string p_1,string p_2)    //哈希比较
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            //计算第一个文件的哈希值
            var stream_1 = File.OpenRead(p_1);
            byte[] hashByte_1 = md5.ComputeHash(stream_1);
            stream_1.Close();
            //计算第二个文件的哈希值
            var stream_2 = File.OpenRead(p_2);
            byte[] hashByte_2 = md5.ComputeHash(stream_2);
            stream_2.Close();
            //比较两个哈希值
            if (BitConverter.ToString(hashByte_1) == BitConverter.ToString(hashByte_2))
                return true;
            else
                return false;
        }
        public static bool MD5HashCompareFile(byte[] h_1, string p_2)   //Hash比较
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            //计算第二个文件的哈希值
            var stream_2 = File.OpenRead(p_2);
            byte[] hashByte_2 = md5.ComputeHash(stream_2);
            stream_2.Close();
            //比较两个哈希值
            if (BitConverter.ToString(h_1) == BitConverter.ToString(hashByte_2))
                return true;
            else
                return false;
        }
        public static bool MD5HashCompareFile(byte[] h_1, byte[] h_2)   //Hash比较
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            //比较两个哈希值
            if (BitConverter.ToString(h_1) == BitConverter.ToString(h_2))
                return true;
            else
                return false;
        }
        public static byte[] ComputeMD5Hash(string p)   //Hash计算
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var stream_1 = File.OpenRead(p);
            byte[] hashByte_1 = md5.ComputeHash(stream_1);
            stream_1.Close();
            return hashByte_1;
        }
        public static UINavMenu SetTreeViewStyle(UINavMenu navMenu)     //TreeView的image分类
        {
            navMenu.ShowNodeToolTips = true;
            foreach (TreeNode node in navMenu.Nodes)
            {
                node.ImageIndex= 0;
                node.BackColor = Color.DarkGray;
                foreach(TreeNode nodeChild in node.Nodes)
                {
                    nodeChild.ImageIndex= 1;
                    foreach(TreeNode nodeChChild in nodeChild.Nodes)
                    {
                        if (nodeChChild.Name == "tittle")
                        {
                            nodeChChild.ImageIndex = 7;
                            nodeChChild.NodeFont = new Font("黑体", 10, FontStyle.Bold);
                            nodeChChild.ForeColor = Color.DarkRed;
                        }
                        foreach(TreeNode nodeChChChild in nodeChChild.Nodes)
                        {
                            var fn = nodeChChChild.Name.ToLower();
                            if (fn.Contains(".docx") || fn.Contains(".doc"))
                                nodeChChChild.ImageIndex = 2;
                            else if (fn.Contains(".xls") || fn.Contains(".xlsx"))
                                nodeChChChild.ImageIndex = 3;
                            else if (fn.Contains(".ppt") || fn.Contains(".pptx"))
                                nodeChChChild.ImageIndex = 9;
                            else if (fn.Contains(".pdf"))
                                nodeChChChild.ImageIndex = 4;
                            else if (fn.Contains(".zip") || fn.Contains(".rar") || fn.Contains(".7z"))
                                nodeChChChild.ImageIndex = 5;
                            else if (fn.Contains(".jpg") || fn.Contains(".jpeg") || fn.Contains(".png") || fn.Contains(".bmp") || fn.Contains(".gif"))
                                nodeChChChild.ImageIndex = 6;
                            else if (fn.Contains(".txt") || fn.Contains(".xml"))
                                nodeChChChild.ImageIndex = 10;
                            else if (fn.Contains(".m4v") || fn.Contains(".mp4") || fn.Contains(".mkv") || fn.Contains(".avi") || fn.Contains(".flv"))
                                nodeChChChild.ImageIndex = 11;
                            else
                                nodeChChChild.ImageIndex = 8;
                        }
                    }
                }
            }
            return navMenu;
        }
        public static Dictionary<int, string> MonthsOrder(List<string> list)    //月份排序
        {
            var list2 = new List<string>(list);
            var list3 = new List<int>();
            foreach(string s in list2)
            {
                var s2 = s.Replace("-", "");
                if(!list3.Contains(int.Parse(s2)))list3.Add(int.Parse(s2));
            }
            var arry = list3.ToArray();
            Array.Sort(arry);
            Array.Reverse(arry);
            var dic = new Dictionary<int, string>();
            for(int i = 0; i < arry.Length; i++)
                dic.Add(i, arry[i].ToString());
            return dic;
        }
    }
}
