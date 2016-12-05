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
    public partial class FormTypeInfo : Form
    {
        public FormTypeInfo()
        {
            InitializeComponent();
        }

        private DialogResult result;
        MemberTypeInfoBll bll = new MemberTypeInfoBll();
        private void FormTypeInfo_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void LoadDate()
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = bll.GetList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MemberTypeInfo memberTypeInfo = new MemberTypeInfo()
            {
                MTitle = txtTitle.Text,
                MDiscount =Convert.ToDecimal(txtDiscount.Text)
            };
            if (txtId.Text.Equals("添加时无编号"))
            {
                if (bll.Add(memberTypeInfo))
                {
                    LoadDate();
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            else
            {
                memberTypeInfo.MId = int.Parse(txtId.Text);
                if (bll.Edit(memberTypeInfo))
                {
                    LoadDate();
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }
            txtId.Text = "添加时无编号";
            txtTitle.Text = "";
            txtDiscount.Text = "";
            btnSave.Text = "添加";
            result = DialogResult.OK;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            txtDiscount.Text = row.Cells[2].Value.ToString();
            btnSave.Text = "修改";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtDiscount.Text = "";
            txtTitle.Text = "";
            btnSave.Text = "添加";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var row=dgvList.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells[0].Value);
            DialogResult result = MessageBox.Show("ays", "tis", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            if (bll.Delete(id))
            {
                LoadDate();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
            result = DialogResult.OK;
        }

        private void FormTypeInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = result;
        }
    }
}
