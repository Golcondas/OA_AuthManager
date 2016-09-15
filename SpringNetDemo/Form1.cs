using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpringNetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IApplicationContext ctx = ContextRegistry.GetContext(); //创建容器.
            IApplicationContext ctx = ContextRegistry.GetContext();//通过读取配置文件,创建容器
            IUserInfoService lister = (IUserInfoService)ctx.GetObject("UserInfoService");//读取配置文件创建的对象
            MessageBox.Show(lister.Message());

        }
    }
}
