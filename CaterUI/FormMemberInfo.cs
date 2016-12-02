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

namespace CaterUI
{
    public partial class FormMemberInfo : Form
    {
        public FormMemberInfo()
        {
            InitializeComponent();
        }

        private void FormMemberInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        MemberInfoBll bll=new MemberInfoBll();
        private void LoadList()
        {
            Dictionary<string,string>dictionary=new Dictionary<string, string>();
            if (txtNameSearch.Text != "")
            {
                dictionary.Add("mname",txtNameSearch.Text);
            }
            if (txtPhoneSearch.Text != "")
            {
                dictionary.Add("mphone",txtPhoneSearch.Text);
            }

            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = bll.GetList(dictionary);
        }
        /// <summary>
        /// 内容改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            LoadList();
        }
        /// <summary>
        /// 失去焦点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPhoneSearch_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtNameSearch.Text = "";
            txtPhoneSearch.Text = "";
            LoadList();
        }
    }
}
