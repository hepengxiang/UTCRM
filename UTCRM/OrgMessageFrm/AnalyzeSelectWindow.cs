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
    public partial class AnalyzeSelectWindow : Form
    {
        private OrgMessageBLL BLL;
        private int _orgTypeID;
        private string _orgTypeName;
        private int _orgID;
        private string _orgName;
        private string _analyzeType;
        private DateTime _startTime;
        private DateTime _endTime;

        public int OrgTypeID
        {
            get
            {
                return _orgTypeID;
            }

            set
            {
                _orgTypeID = value;
            }
        }

        public string OrgTypeName
        {
            get
            {
                return _orgTypeName;
            }

            set
            {
                _orgTypeName = value;
            }
        }

        public int OrgID
        {
            get
            {
                return _orgID;
            }

            set
            {
                _orgID = value;
            }
        }

        public string OrgName
        {
            get
            {
                return _orgName;
            }

            set
            {
                _orgName = value;
            }
        }

        public string AnalyzeType
        {
            get
            {
                return _analyzeType;
            }

            set
            {
                _analyzeType = value;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }

            set
            {
                _startTime = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }

            set
            {
                _endTime = value;
            }
        }

        public AnalyzeSelectWindow()
        {
            InitializeComponent();
            if (BLL == null)
                BLL = new OrgMessageBLL();
        }

        private void AnalyzeSelectWindow_Load(object sender, EventArgs e)
        {
            try
            {
                cmbOrgType.DropDown += CmbOrgType_DropDown;
                cmbOrgType.SelectedIndexChanged += CmbOrgType_SelectedIndexChanged;
                this.dateTimePicker1.Value = DateTime.Parse(System.DateTime.Now.AddYears(-1).ToShortDateString());
                this.dateTimePicker2.Value = DateTime.Parse(System.DateTime.Now.ToShortDateString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CmbOrgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbOrgType.SelectedValue == null || this.cmbOrgType.Text == "")
                    return;
                DataTable dtOrgTypeTable = BLL.SelectOrgMessage(int.Parse(this.cmbOrgType.SelectedValue.ToString()));//传入表名称
                if (dtOrgTypeTable.Rows.Count == 0)
                    return;
                this.cmbOrgName.ValueMember = "OrgTypeID";
                this.cmbOrgName.DisplayMember = "OrgName";
                this.cmbOrgName.DataSource = dtOrgTypeTable.Copy();

                this.cmbOrgName.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CmbOrgType_DropDown(object sender, EventArgs e)
        {
            try
            {
                DataTable orgTypeTable = BLL.SelectOrgTypeTable();
                if (orgTypeTable.Rows.Count == 0)
                    return;
                this.cmbOrgType.DisplayMember = "OrgTypeName";
                this.cmbOrgType.ValueMember = "OrgTypeID";
                this.cmbOrgType.DataSource = orgTypeTable;

                this.cmbOrgType.SelectedIndex = -1;
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
                if (cmbOrgType.Text == "" || cmbOrgType.SelectedValue == null || cmbAnalyzeType.Text == "")
                {
                    MessageBox.Show("选择信息有遗漏");
                    return;
                }
                try { _orgTypeID = tools.ToInt(this.cmbOrgType.SelectedValue.ToString()); }
                catch { _orgTypeID = 0; }
                _orgTypeName = this.cmbOrgType.Text.ToString();
                try { _orgID = tools.ToInt(this.cmbOrgName.SelectedValue.ToString()); }
                catch { _orgID = 0; }
                _orgName = this.cmbOrgName.Text.ToString();
                _analyzeType = this.cmbAnalyzeType.Text;
                _startTime = this.dateTimePicker1.Value;
                _endTime = this.dateTimePicker2.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
