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
    public partial class AddOrgType : Form
    {
        private OrgMessageBLL BLL;
        private int _successID = 0;
        public int SuccessID
        {
            get
            {
                return _successID;
            }

            set
            {
                _successID = value;
            }
        }
        public AddOrgType()
        {
            InitializeComponent();

            if (BLL == null)
                BLL = new OrgMessageBLL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox1.Text.Trim()=="")
                {
                    MessageBox.Show("机构类型不能为空");
                    return;
                }
                DataTable dtCheck = BLL.SelectOrgTypeTable(this.textBox1.Text.Trim());
                if (dtCheck.Rows.Count>0)
                {
                    MessageBox.Show("已存在同名机构类型");
                    return;
                }
                int intResult = BLL.InsertOrgType(this.textBox1.Text.Trim());
                if (intResult>0)
                {
                    MessageBox.Show("添加机构类型成功");
                    _successID = intResult;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添加机构类型失败!");
                    this.DialogResult = DialogResult.No;
                }
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
