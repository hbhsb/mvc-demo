using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaterBll;
using CaterModel;

namespace CaterUI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = textName.Text;
            string pwd = textPwd.Text;
            int type;
            ManagerInfoBll bll=new ManagerInfoBll();
            LoginState login = bll.Login(name, pwd,out type);
            switch (login)
            {
                case LoginState.Ok:
                    FormMain main=new FormMain();
                    main.Tag = type;
                   //将登录窗体隐藏
                   this.Hide();
                    main.Show();
                    break;
                case LoginState.NameError:
                    MessageBox.Show("名字错误");
                    break;
                case LoginState.PwdError:
                    MessageBox.Show("密码错误");
                    break;
            }
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
