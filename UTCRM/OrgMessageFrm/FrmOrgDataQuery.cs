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
    public partial class FrmOrgDataQuery : Form
    {
        private OrgMessageBLL BLL;
        public FrmOrgDataQuery()
        {
            InitializeComponent();
            if (BLL == null)
            {
                BLL = new OrgMessageBLL();
            }
        }

        private void FrmOrgDataQuery_Load(object sender, EventArgs e)
        {
            try
            {
                this.comboBox1.DropDown += comboBox1_DropDown;
                this.comboBox2.DropDown += ComboBox2_DropDown;
                this.DGVHeard.CellContentDoubleClick += DGVHeard_CellDoubleClick;
                this.DGVHeard.RowPostPaint += tools.dataGridView_RowPostPaint;
                this.DGVDetail.RowPostPaint += tools.dataGridView_RowPostPaint;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                this.comboBox1.DataSource = orgTypeTable;
                
                this.comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboBox2_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBox1.SelectedValue == null || this.comboBox1.Text == "")
                    return;

                DataTable dtOrgTypeTable = BLL.SelectOrgMessage(int.Parse(this.comboBox1.SelectedValue.ToString()));//传入表名称
                if (dtOrgTypeTable.Rows.Count == 0)
                    return;
                this.comboBox2.ValueMember = "OrgID";
                this.comboBox2.DisplayMember = "OrgName";
                this.comboBox2.DataSource = dtOrgTypeTable;

                this.comboBox2.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DGVHeard_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int orgTypeID = int.Parse(this.DGVHeard.Rows[e.RowIndex].Cells["OrgTypeID"].Value.ToString());
                    int orgID = int.Parse(this.DGVHeard.Rows[e.RowIndex].Cells["OrgID"].Value.ToString());
                    int enterBatchID = int.Parse(this.DGVHeard.Rows[e.RowIndex].Cells["EnterBatchID"].Value.ToString());
                    this.DGVDetail.DataSource = BLL.SelectOrgDataDetail(orgTypeID, orgID, enterBatchID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBox2.Text == "" || this.comboBox2.SelectedValue == null
                    || this.comboBox1.Text == "" || this.comboBox1.SelectedValue == null)
                {
                    MessageBox.Show("请选择机构类型和机构名");
                    return;
                }
                int orgTypeID = int.Parse(this.comboBox1.SelectedValue.ToString());
                int orgID = int.Parse(this.comboBox2.SelectedValue.ToString());
                DataTable dtResult = BLL.SelectOrgDataHeard(orgTypeID, orgID);
                this.DGVHeard.DataSource = dtResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
