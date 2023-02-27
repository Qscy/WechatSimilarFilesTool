using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WechatSimilarFilesTool
{
    internal class Methods
    {
        public static bool MD5HashCompareFile(string p_1,string p_2)
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
        public static bool MD5HashCompareFile(byte[] h_1, string p_2)
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
        public static bool MD5HashCompareFile(byte[] h_1, byte[] h_2)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            //比较两个哈希值
            if (BitConverter.ToString(h_1) == BitConverter.ToString(h_2))
                return true;
            else
                return false;
        }
        public static byte[] ComputeMD5Hash(string p)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var stream_1 = File.OpenRead(p);
            byte[] hashByte_1 = md5.ComputeHash(stream_1);
            stream_1.Close();
            return hashByte_1;
        }
        public static UINavMenu SetTreeViewStyle(UINavMenu navMenu)
        {
            foreach(TreeNode node in navMenu.Nodes)
            {
                node.ImageIndex= 0;
                node.BackColor = Color.DarkGray;
                foreach(TreeNode nodeChild in node.Nodes)
                {
                    nodeChild.ImageIndex= 1;
                    foreach(TreeNode nodeChChild in nodeChild.Nodes)
                    {
                        var fn = nodeChChild.Name.ToLower();
                        if(fn.Contains(".docx")||fn.Contains(".doc"))
                            nodeChChild.ImageIndex= 2;
                        if(fn.Contains(".xls") || fn.Contains(".xlsx"))
                            nodeChChild.ImageIndex= 3;
                        if (fn.Contains(".pdf"))
                            nodeChChild.ImageIndex = 4;
                        if (fn.Contains(".zip") || fn.Contains(".rar")|| fn.Contains(".7z"))
                            nodeChChild.ImageIndex = 5;
                    }
                }
            }
            return navMenu;
        }
        public static Dictionary<int, string> MonthsOrder(List<string> list)
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
