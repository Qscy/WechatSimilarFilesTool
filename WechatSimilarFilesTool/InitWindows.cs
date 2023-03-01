using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace WechatSimilarFilesTool
{
    public struct WeChatFiles   //��¼�ļ������Ϣ
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
        string weChatPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\WeChat Files\\";     //΢���ļ���ַ
        string subPath = "\\FileStorage\\File\\";  //�û��µĵ�ַ
        Dictionary<int, byte[]> hashes = new Dictionary<int,byte[]>();    //�ļ���ϣ��
        List<WeChatFiles> fileList = new List<WeChatFiles>();     //�ļ��б�
        public static List<WeChatFiles[]> similars = new List<WeChatFiles[]>();    //�����ļ������б�
        public static List<string> Months = new List<string>();
        public static List<string> Users = new List<string>();
        int threadCount = 0;    //�߳���
        private void CompareFileHash(object o)   //�ȽϷ���
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
        private void GetMD5Hash(object o)   //��ȡHash
        {
            int i = (int)o;
            string path_i = $"{weChatPath}{fileList[i].user}\\{subPath}\\{fileList[i].month}\\{fileList[i].filename}";
            hashes.Add(i,Methods.ComputeMD5Hash(path_i));
            threadCount--;
        }
        private void InitWindow_Shown(object sender, EventArgs e)
        {
            label1.Visible = true;      
            label1.Text = "���ڻ�ȡ΢���ļ�·��...";
            label1.Refresh();
            uiSymbolButton1.Refresh();
            var difo = new DirectoryInfo(weChatPath);   //��·���ļ�����Ϣ
            for (int i = 0; i < difo.GetDirectories().Length; i++)  //��ȡ΢�������ļ�
            {
                DirectoryInfo sub = difo.GetDirectories()[i];
                if (sub.Name.Contains("wxid_"))
                {
                    Users.Add(sub.Name);    //����û�
                    var difo2 = new DirectoryInfo($"{weChatPath}{sub.Name}\\{subPath}");
                    for (int j = 0; j < difo2.GetDirectories().Length; j++)
                    {
                        DirectoryInfo sub2 = difo2.GetDirectories()[j];
                        if (sub2.Name.Contains("20") && sub2.Name.Contains('-') && sub2.Name.Length == 7)
                        {
                            Months.Add(sub2.Name);  //����·�
                            var difo3 = new DirectoryInfo($"{weChatPath}{sub.Name}\\{subPath}\\{sub2.Name}\\");
                            for (int k = 0; k < difo3.GetFiles().Length; k++)
                            {
                                FileInfo sub3 = difo3.GetFiles()[k];
                                WeChatFiles wcf = new WeChatFiles(sub.Name, sub2.Name, sub3.Name, sub3.Length, sub3.LastWriteTime);
                                fileList.Add(wcf);  //���΢���ļ�
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
                if(i == fileList.Count-1)   //�ȴ��߳�ִ�����
                {
                    var time1 =DateTime.Now;
                    while (true)    //�ж��߳��Ƿ����
                    { 
                        if (hashes.Count == fileList.Count) break;
                        var time2 = DateTime.Now;
                        if (time2.Second -time1.Second > 10)    //��������ʱ����ס
                        {
                            label1.Text = "�߳�δ��Ӧ...����������...";
                            return;
                        }
                    }
                }
            }
            threadCount = 0;
            for (int i = 0; i < fileList.Count-1; i++)    //�Ա��ļ���ϣֵ
            {
                while(true)     //�����߳���
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
            while(true) if (threadCount < 0) break;     //�ж��߳��Ƿ�ȫ������
            label1.Text = "���ڼ��ؽ��...";
            this.DialogResult= DialogResult.OK;
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)  //�رհ�ť
        {
            Environment.Exit(0);
        }
    }
}