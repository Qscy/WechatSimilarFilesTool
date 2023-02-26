using System.ComponentModel;
using System.Windows.Forms;
using WechatSimilarFilesTool;

namespace WinFormsApp3
{
    struct WeChatFiles
    {
        public string user;
        public string month;
        public string filename;

        public WeChatFiles(string name1, string name2, string name3)
        {
            user = name1;
            month = name2;
            filename = name3;
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
        List<byte[]> hashes = new();    //文件哈希表
        List<WeChatFiles> fileList = new();     //文件列表
        List<WeChatFiles[]> similars = new();    //相似文件集合列表
        int threadCount = 0;    //线程数
        private void CompareFileHash(object o)   //比较方法
        {
            int i = (int)o;
            for (int j = i + 1; j < fileList.Count; j++)
            {
                List<WeChatFiles> files = new();
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
        private void GetMD5Hash(object o)
        {
            int i = (int)o;
            string path_i = $"{weChatPath}{fileList[i].user}\\{subPath}\\{fileList[i].month}\\{fileList[i].filename}";
            hashes.Add(Methods.ComputeMD5Hash(path_i));
            threadCount--;

        }
        private void InitWindow_Shown(object sender, EventArgs e)
        {
            label1.Visible = true;      
            var difo = new DirectoryInfo(weChatPath);   
            Thread.Sleep(1000);
            label1.Text = "正在获取微信文件路径...";
            label1.Refresh();
            for (int i = 0; i < difo.GetDirectories().Length; i++)  //获取微信所有文件
            {
                DirectoryInfo sub = difo.GetDirectories()[i];
                if (sub.Name.Contains("wxid_"))
                {
                    var difo2 = new DirectoryInfo($"{weChatPath}{sub.Name}\\{subPath}");
                    for (int j = 0; j < difo2.GetDirectories().Length; j++)
                    {
                        DirectoryInfo sub2 = difo2.GetDirectories()[j];
                        if (sub2.Name.Contains("20") && sub2.Name.Contains('-') && sub2.Name.Length == 7)
                        {
                            var difo3 = new DirectoryInfo($"{weChatPath}{sub.Name}\\{subPath}\\{sub2.Name}\\");
                            for (int k = 0; k < difo3.GetFiles().Length; k++)
                            {
                                FileInfo sub3 = difo3.GetFiles()[k];
                                WeChatFiles wcf = new(sub.Name, sub2.Name, sub3.Name);
                                fileList.Add(wcf);
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
                if(i == fileList.Count-1) while (true) { if (hashes.Count == fileList.Count) break; }   //等待线程执行完毕
            }
            threadCount = 0;
            for (int i = 0; i < fileList.Count-1; i++)    //对比文件哈希值
            {
                while(true)
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
        }
    }
}