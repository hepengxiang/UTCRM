using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UTCRM.OrgMessageFrm
{
    public partial class FrmOrgManager : Form
    {
        private OrgMessageBLL BLL;
        public FrmOrgManager()
        {
            InitializeComponent();

            if (BLL == null)
                BLL = new OrgMessageBLL();
        }
        private void FrmOrgManager_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView_RowPostPaint);
        }

        private void button1_Click(object sender, EventArgs e)//增加
        {
            try
            {
                if (this.comboBox1.Text == ""||this.comboBox1.SelectedValue == null||this.textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("请填写完整信息");
                    return;
                }
                int orgTypeID = int.Parse(this.comboBox1.SelectedValue.ToString());
                string orgName = this.textBox1.Text.Trim();
                string remark = this.textBox2.Text;

                int intResult = BLL.InsertOrgMessage(orgTypeID, orgName, remark);
                if (intResult > 0)
                {
                    MessageBox.Show("增加机构成功!");
                }
                else
                {
                    MessageBox.Show("增加机构失败");
                }
                this.dataGridView1.DataSource = BLL.SelectOrgMessage(orgTypeID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)//删除选中机构
        {
            try
            {
                if (this.dataGridView1.CurrentRow==null)
                {
                    MessageBox.Show("请先选定要删除的行！");
                    return;
                }
                DataGridViewRow dgv = this.dataGridView1.CurrentRow;
                int orgTypeID = int.Parse(dgv.Cells["OrgTypeID"].Value.ToString());
                int orgID = int.Parse(dgv.Cells["OrgID"].Value.ToString());
                if (orgID > 0)
                {
                    bool deleteResult = BLL.DeleteOrgMessage(orgTypeID, orgID);
                    if (deleteResult)
                    {
                        MessageBox.Show("删除成功!");
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
                this.dataGridView1.DataSource = BLL.SelectOrgMessage(orgTypeID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)//修改
        {
            try
            {
                if (this.dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("请先选定要修改的行！");
                    return;
                }
                if (this.textBox1.Text == "")
                {
                    MessageBox.Show("机构名称不能为空");
                    return;
                }
                string orgName = this.textBox1.Text.Trim();
                string remark = this.textBox2.Text;
                DataGridViewRow dgv = this.dataGridView1.CurrentRow;
                int orgTypeID = int.Parse(dgv.Cells["OrgTypeID"].Value.ToString());
                int orgID = int.Parse(dgv.Cells["OrgID"].Value.ToString());
                if (orgID > 0)
                {
                    bool deleteResult = BLL.UpDateOrgMessage(orgTypeID, orgID, orgName, remark);
                    if (deleteResult)
                    {
                        MessageBox.Show("修改成功!");
                    }
                    else
                    {
                        MessageBox.Show("修改失败");
                    }
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
                this.dataGridView1.DataSource = BLL.SelectOrgMessage(orgTypeID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)//查询
        {
            try
            {
                if (this.comboBox1.Text == ""||this.comboBox1.SelectedValue == null)
                {
                    MessageBox.Show("必须先选择需要查询的机构类型");
                    return; ;
                }
                int orgTypeID = int.Parse(this.comboBox1.SelectedValue.ToString());
                DataTable dtResult = BLL.SelectOrgMessage(orgTypeID);
                this.dataGridView1.DataSource = dtResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridViewRow dgvr = this.dataGridView1.CurrentRow;
                    this.comboBox1.SelectedText = dgvr.Cells["OrgTypeName"].Value.ToString();
                    this.comboBox1.SelectedValue = dgvr.Cells["OrgTypeID"].Value.ToString();
                    this.textBox1.Text = dgvr.Cells["OrgName"].Value.ToString();
                    this.textBox2.Text = dgvr.Cells["Remark"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddOrgType aot = new AddOrgType();
            aot.ShowDialog();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            try
            {
                DataTable orgTypeTable = BLL.SelectOrgTypeTable();
                if (orgTypeTable.Rows.Count == 0)
                    return;
                this.comboBox1.DisplayMember = "OrgTypeName";
                this.comboBox1.ValueMember = "OrgTypeID";
                this.comboBox1.DataSource = orgTypeTable.Copy();
                this.comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            this.textBox1.Text = "";
        }
        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush((sender as DataGridView).RowHeadersDefaultCellStyle.ForeColor);
            try
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), (sender as DataGridView).DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
            catch { }
        }

        
    }
}
