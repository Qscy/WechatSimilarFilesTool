using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
