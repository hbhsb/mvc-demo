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
        public FormManagerInfo()
        {
            InitializeComponent();
        }
        ManagerInfoBll bll = new ManagerInfoBll();

        private void FormManagerInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

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
        }
    }
}
