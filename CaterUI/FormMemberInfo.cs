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
    public partial class FormMemberInfo : Form
    {
        public FormMemberInfo()
        {
            InitializeComponent();
        }

        private void FormMemberInfo_Load(object sender, EventArgs e)
        {
            // 加载会员信息
            LoadList();
            //加载分类信息
            LoadTypeList();
        }

        private void LoadTypeList()
        {
            MemberTypeInfoBll mtibll=new MemberTypeInfoBll();
            List<MemberTypeInfo> list = mtibll.GetList();
            ddlType.DataSource = list;
            ddlType.DisplayMember = "mtitle";
            ddlType.ValueMember = "mid";
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            //接收界面的数据
            MemberInfo memberInfo=new MemberInfo()
            {
                MName = txtNameAdd.Text,
                MPhone = txtPhoneAdd.Text,
                MMoney = Convert.ToDecimal(txtMoney.Text),
                MTypeId = Convert.ToInt32(ddlType.SelectedValue)
            };
            if (txtId.Text.Equals("添加时无编号"))
            {
                if (bll.Add(memberInfo))
                {
                    LoadList();

                }
                else
                {
                    MessageBox.Show("失败");
                }
            }
            else
            {
                MessageBox.Show("it need to edit");
            }

        }

        private void Initialize()
        {
            
        }
    }
}
