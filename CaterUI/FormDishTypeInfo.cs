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
    public partial class FormDishTypeInfo : Form
    {
        public FormDishTypeInfo()
        {
            InitializeComponent();
        }

        private int rowIndex;
        DishTypeInfoBll bll=new DishTypeInfoBll();

        private void FormDishTypeInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            //dgvList.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = bll.GetList();
            if (rowIndex > -1)
            {
                dgvList.Rows[rowIndex].Selected = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //根据用户输入构造对象
            DishTypeInfo dishTypeInfo = new DishTypeInfo()
            {
                DTitle = txtTitle.Text
            };
            if (txtId.Text == "添加时无编号")
            {
                if (bll.Add(dishTypeInfo))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("sb");
                }
            }
            else
            {
                dishTypeInfo.DId = int.Parse(txtId.Text);
                if (bll.Update(dishTypeInfo))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("sb");
                }
                
            }
            txtId.Text = "添加时无编号";
            txtTitle.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtTitle.Text = "";
            btnSave.Text = "添加";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult result=MessageBox.Show("Are you sure?", "tip", MessageBoxButtons.OKCancel);
            if (result==DialogResult.Cancel)
            {
                return;
            }
            var row = dgvList.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells[0].Value);
            if (bll.Delete(id))
            {
                LoadList();
            }
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            btnSave.Text = "修改";
            rowIndex = e.RowIndex;
        }
    }
}
