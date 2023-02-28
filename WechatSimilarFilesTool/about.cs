using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace WechatSimilarFilesTool
{
    public partial class about : UIForm
    {
        public about()
        {
            InitializeComponent();
        }

        private void about_Load(object sender, EventArgs e)
        {
            var text = "作者:Qscy\n项目地址:https://github.com/Qscy/WechatSimilarFilesTool\n仅供学习交流，不得用于商业用途";
            uiRichTextBox1.Text = text;
            uiRichTextBox1.FillColor= Color.White;
        }
    }
}
