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
        string weChatPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\WeChat Files\\";     //΢���ļ���ַ
        string subPath = "\\FileStorage\\File\\";  //�û��µĵ�ַ
        List<byte[]> hashes = new();    //�ļ���ϣ��
        List<WeChatFiles> fileList = new();     //�ļ��б�
        List<WeChatFiles[]> similars = new();    //�����ļ������б�
        int threadCount = 0;    //�߳���
        private void CompareFileHash(object o)   //�ȽϷ���
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
            label1.Text = "���ڻ�ȡ΢���ļ�·��...";
            label1.Refresh();
            for (int i = 0; i < difo.GetDirectories().Length; i++)  //��ȡ΢�������ļ�
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
            for (int i = 0; i < fileList.Count; i++)    //��ȡ�����ļ���ϣֵ
            {
                while (true)
                {
                    if (threadCount < 5) break;
                }
                threadCount++;
                var th = new Thread(new ParameterizedThreadStart(GetMD5Hash));//�������߳�
                th.IsBackground = true;
                th.Start(i);
                label1.Text = $"����ͳ���ļ���Ϣ...��{i}/{fileList.Count}��";
                label1.Refresh();
                if(i == fileList.Count-1) while (true) { if (hashes.Count == fileList.Count) break; }   //�ȴ��߳�ִ�����
            }
            threadCount = 0;
            for (int i = 0; i < fileList.Count-1; i++)    //�Ա��ļ���ϣֵ
            {
                while(true)
                {
                    if (threadCount < 5) break;
                }
                threadCount++;
                var th = new Thread(new ParameterizedThreadStart(CompareFileHash));//�������߳�
                th.IsBackground= true;
                th.Start(i); 
                label1.Text = $"���ڱȶ��ļ���Ϣ...��{i}/{fileList.Count}��";
                label1.Refresh();
            }
        }
    }
}