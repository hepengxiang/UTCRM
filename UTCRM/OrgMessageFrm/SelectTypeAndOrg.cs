using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UTCRM
{
    public partial class SelectTypeAndOrg : Form
    {
        private OrgMessageBLL BLL;
        private DataTable orgTypeTable;
        private string _orginazationTableName;
        private string _studentMessageTableName;
        private string _studentDetailTableName;
        private int _orgID;
        private string _orgName;
        private int _orgTypeID;
        private string _orgTypeName;

        public string OrginazationTableName
        {
            get
            {
                return _orginazationTableName;
            }

            set
            {
                _orginazationTableName = value;
            }
        }

        public string StudentMessageTableName
        {
            get
            {
                return _studentMessageTableName;
            }

            set
            {
                _studentMessageTableName = value;
            }
        }

        public string StudentDetailTableName
        {
            get
            {
                return _studentDetailTableName;
            }

            set
            {
                _studentDetailTableName = value;
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

        public SelectTypeAndOrg()
        {
            InitializeComponent();

            if (BLL == null)
                BLL = new OrgMessageBLL();
        }

        private void SelectTypeAndOrg_Load(object sender, EventArgs e)
        {
            try
            {
                orgTypeTable = BLL.SelectOrgTypeTable();
                if (orgTypeTable.Rows.Count == 0)
                    return;
                this.comboBox1.DisplayMember = "OrgTypeName";
                this.comboBox1.ValueMember = "OrgTypeID";
                this.comboBox1.DataSource = orgTypeTable;
                this.comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
                this.comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedValue == null || this.comboBox1.Text == "" || this.comboBox1.SelectedValue == null)
                return;

            _orginazationTableName = "Orginazation_"+ this.comboBox1.SelectedValue;
            _studentMessageTableName = "StudentMessage_" + this.comboBox1.SelectedValue; 
            _studentDetailTableName = "StudentDetail_" + this.comboBox1.SelectedValue;

            DataTable dtOrgTypeTable = BLL.SelectOrgMessage(int.Parse(this.comboBox1.SelectedValue.ToString()));//传入表名称
            if (dtOrgTypeTable.Rows.Count == 0)
                return;
            this.comboBox2.ValueMember = "OrgID";
            this.comboBox2.DisplayMember = "OrgName";
            this.comboBox2.DataSource = dtOrgTypeTable.Copy();
            
            this.comboBox2.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBox1.Text == "" || this.comboBox2.Text == ""
                    || this.comboBox1.SelectedValue == null || this.comboBox2.SelectedValue == null)
                {
                    MessageBox.Show("请选择机构类型和机构");
                    return;
                }
                _orgTypeID = int.Parse(this.comboBox1.SelectedValue.ToString());
                _orgTypeName = this.comboBox1.Text;
                _orgID = int.Parse(this.comboBox2.SelectedValue.ToString());
                _orgName = this.comboBox2.Text;
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
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        
    }
}
