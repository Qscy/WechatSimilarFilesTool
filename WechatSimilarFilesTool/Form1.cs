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

        private void InitWindow_Shown(object sender, EventArgs e)
        {
            var weChatPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\WeChat Files\\";
            var subPath = "\\FileStorage\\File\\";
            List<WeChatFiles> fileList = new();
            var difo = new DirectoryInfo(weChatPath);
            Dictionary<int, List<WeChatFiles>> similars = new();
            List<byte[]> hashes = new();
            Thread.Sleep(1000);
            label1.Text = "正在获取微信文件路径...";
            label1.Refresh();
            for (int i = 0; i < difo.GetDirectories().Length; i++)
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
            for (int i = 0; i < fileList.Count; i++)
            {
                string path_i = $"{weChatPath}{fileList[i].user}\\{subPath}\\{fileList[i].month}\\{fileList[i].filename}";
                hashes.Add(Methods.ComputeMD5Hash(path_i));
                label1.Text = $"正在统计文件信息...（{i}/{fileList.Count}）";
                label1.Refresh();
            }
            int key = 1;
            for (int i = 0; i < fileList.Count; i++)
            {
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
                        similars.Add(key, files);
                    }
                    label1.Text = $"正在比对文件信息...（{i}/{fileList.Count}）";
                    label1.Refresh();
                }
            }
        }
    }
}