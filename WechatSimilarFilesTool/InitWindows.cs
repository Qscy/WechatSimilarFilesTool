using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace WechatSimilarFilesTool
{
    public struct WeChatFiles   //记录文件相关信息
    {
        public string user;
        public string month;
        public string filename;
        public long size;
        public DateTime lasteditime;
        public WeChatFiles(string name1, string name2, string name3, long name4, DateTime name5)
        {
            user = name1;
            month = name2;
            filename = name3;
            size = name4;
            lasteditime = name5;
        }
    }
    public partial class InitWindow : Form
    {
        public InitWindow()
        {
            InitializeComponent();
        }
        string weChatPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\WeChat Files\\";     //微信文件地址
        string subPath = "\\FileStorage\\File\\";  //用户下的地址
        Dictionary<int, byte[]> hashes = new Dictionary<int,byte[]>();    //文件哈希表
        List<WeChatFiles> fileList = new List<WeChatFiles>();     //文件列表
        public static List<WeChatFiles[]> similars = new List<WeChatFiles[]>();    //相似文件集合列表
        public static List<string> Months = new List<string>();
        public static List<string> Users = new List<string>();
        int threadCount = 0;    //线程数
        private void CompareFileHash(object o)   //比较方法
        {
            int i = (int)o;
            List<WeChatFiles> files = new List<WeChatFiles>();
            for (int j = i + 1; j < fileList.Count; j++)
            {
                if (Methods.MD5HashCompareFile(hashes[i], hashes[j]))
                {
                    files.Add(fileList[i]);
                    files.Add(fileList[j]);
                }
                if (j == fileList.Count - 1 && files.Count > 1)
                {
                    similars.Add(files.ToArray());
                }
                threadCount--;
            }
        }
        private void GetMD5Hash(object o)   //获取Hash
        {
            int i = (int)o;
            string path_i = $"{weChatPath}{fileList[i].user}\\{subPath}\\{fileList[i].month}\\{fileList[i].filename}";
            hashes.Add(i,Methods.ComputeMD5Hash(path_i));
            threadCount--;
        }
        private void InitWindow_Shown(object sender, EventArgs e)
        {
            label1.Visible = true;      
            label1.Text = "正在获取微信文件路径...";
            label1.Refresh();
            uiSymbolButton1.Refresh();
            var difo = new DirectoryInfo(weChatPath);   //根路径文件夹信息
            for (int i = 0; i < difo.GetDirectories().Length; i++)  //获取微信所有文件
            {
                DirectoryInfo sub = difo.GetDirectories()[i];
                if (sub.Name.Contains("wxid_"))
                {
                    Users.Add(sub.Name);    //添加用户
                    var difo2 = new DirectoryInfo($"{weChatPath}{sub.Name}\\{subPath}");
                    for (int j = 0; j < difo2.GetDirectories().Length; j++)
                    {
                        DirectoryInfo sub2 = difo2.GetDirectories()[j];
                        if (sub2.Name.Contains("20") && sub2.Name.Contains('-') && sub2.Name.Length == 7)
                        {
                            Months.Add(sub2.Name);  //添加月份
                            var difo3 = new DirectoryInfo($"{weChatPath}{sub.Name}\\{subPath}\\{sub2.Name}\\");
                            for (int k = 0; k < difo3.GetFiles().Length; k++)
                            {
                                FileInfo sub3 = difo3.GetFiles()[k];
                                WeChatFiles wcf = new WeChatFiles(sub.Name, sub2.Name, sub3.Name, sub3.Length, sub3.LastWriteTime);
                                fileList.Add(wcf);  //添加微信文件
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < fileList.Count; i++)    //获取所有文件哈希值
            {
                while (true)
                {
                    if (threadCount < 5) break;
                }
                threadCount++;
                var th = new Thread(new ParameterizedThreadStart(GetMD5Hash));//创建多线程
                th.IsBackground = true;
                th.Start(i);
                label1.Text = $"正在统计文件信息...（{i}/{fileList.Count}）";
                label1.Refresh();
                if(i == fileList.Count-1)   //等待线程执行完毕
                {
                    var time1 =DateTime.Now;
                    while (true)    //判断线程是否完成
                    { 
                        if (hashes.Count == fileList.Count) break;
                        var time2 = DateTime.Now;
                        if (time2.Second -time1.Second > 10)    //错误处理：有时候会堵住
                        {
                            label1.Text = "线程未响应...请重新启动...";
                            return;
                        }
                    }
                }
            }
            threadCount = 0;
            for (int i = 0; i < fileList.Count-1; i++)    //对比文件哈希值
            {
                while(true)     //限制线程数
                {
                    if (threadCount < 5) break;
                }
                threadCount++;
                var th = new Thread(new ParameterizedThreadStart(CompareFileHash));//创建多线程
                th.IsBackground= true;
                th.Start(i); 
                label1.Text = $"正在比对文件信息...（{i}/{fileList.Count}）";
                label1.Refresh();
            }
            while(true) if (threadCount < 0) break;     //判断线程是否全部结束
            label1.Text = "正在加载结果...";
            this.DialogResult= DialogResult.OK;
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)  //关闭按钮
        {
            Environment.Exit(0);
        }
    }
}