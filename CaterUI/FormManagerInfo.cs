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
    public partial class FormManagerInfo : Form
    {
        private FormManagerInfo()
        {
            InitializeComponent();
        }

        private static FormManagerInfo _form;
        public static FormManagerInfo CreateFormManagerInfo()
        {
            if (_form == null)
            {
                _form=new FormManagerInfo();
            }
            return _form;
        }
        ManagerInfoBll bll = new ManagerInfoBll();

        private void FormManagerInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = bll.GetList();
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ManagerInfo miInfo = new ManagerInfo()
                {
                    MName = txtName.Text,
                    MPwd = txtPwd.Text,
                    MType = rb1.Checked ? 1 : 0
                };
            if(txtId.Text.Equals("添加时无编号"))
            {
                #region add
                if (bll.Add(miInfo))
                {
                    LoadList();
                    txtPwd.Text = "";
                    txtName.Text = "";
                    rb2.Checked = true;
                }
                else
                {
                    MessageBox.Show("添加失败，请检查数据");
                } 
                #endregion 
            }
            else
            {
                #region edit

                miInfo.MId = int.Parse(txtId.Text);
                if (bll.Edit(miInfo))
                {
                    LoadList();
                }

                #endregion
            }

            txtName.Text = "";
            txtPwd.Text = "";
            rb2.Checked = true;
            btnSave.Text = "添加";
            txtId.Text = "添加时无编号";
        }

        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex==2)
            {
                e.Value = Convert.ToInt32(e.Value) == 1 ? "经理" : "店员";
            }
        }


        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString(); 
            txtName.Text = row.Cells[1].Value.ToString();
            if (row.Cells[2].Value.ToString().Equals("1"))
            {
                rb1.Checked = true;
            }
            else
            {
                rb2.Checked = true;
            }
            btnSave.Text = "修改";
            txtPwd.Text = "这是原来的密码吗";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtName.Text = "";
            txtPwd.Text = "";
            rb2.Checked = true;
            btnSave.Text = "添加";
        }
        /// <summary>
        /// 删除选中的行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            var rows = dgvList.SelectedRows;
            if (rows.Count>0)
            {
                DialogResult result= MessageBox.Show("确定要删除吗？", "提示",MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                int id = int.Parse(rows[0].Cells[0].Value.ToString());
                if (bll.Remove(id))
                {
                    LoadList();
                }
            }
            else
            {
                MessageBox.Show("请选中要删除的行");
            }
        }

        private void FormManagerInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form = null;
        }

        private void FormManagerInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
