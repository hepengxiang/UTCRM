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
    public partial class FrmPieClickShow : Form
    {
        private OrgMessageBLL BLL;
        /*方法ID：
         1：本类型下听过本机构课的学员
         2：本类型下未听过本机构课的学员
         3：本类型下听过本机构课的学员  学习次数划分
         4：本类型下听过本机构课的学员  学习时长划分

         5：本天听过本机构课的学员
         6：本天未听过本机构课的学员
         7：本天未听了本机构课的学员  学习次数划分
         8：本天未听了本机构课的学员  学习时长划分
             */
        private int _methodID;
        private int _orgTypeID;
        private int _orgID;
        private int _startStudyCount;
        private int _endStudyCount;
        private int _startStudyTime;
        private int _endStudyTime;
        private DateTime _enterTime;
        public FrmPieClickShow()
        {
            InitializeComponent();
            if (BLL == null)
                BLL = new OrgMessageBLL();
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

        public int MethodID
        {
            get
            {
                return _methodID;
            }

            set
            {
                _methodID = value;
            }
        }

        public int StartStudyCount
        {
            get
            {
                return _startStudyCount;
            }

            set
            {
                _startStudyCount = value;
            }
        }

        public int EndStudyCount
        {
            get
            {
                return _endStudyCount;
            }

            set
            {
                _endStudyCount = value;
            }
        }

        public int StartStudyTime
        {
            get
            {
                return _startStudyTime;
            }

            set
            {
                _startStudyTime = value;
            }
        }

        public int EndStudyTime
        {
            get
            {
                return _endStudyTime;
            }

            set
            {
                _endStudyTime = value;
            }
        }

        public DateTime EnterTime
        {
            get
            {
                return _enterTime;
            }

            set
            {
                _enterTime = value;
            }
        }

        private void FrmPieClickShow_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowPostPaint += tools.dataGridView_RowPostPaint;
            try
            {
                DataTable dtSource = new DataTable();
                switch (_methodID)
                {
                    case 1:
                        dtSource = BLL.AnalyzeSelectOrgData(_orgTypeID,_orgID);
                        break;
                    case 2:
                        dtSource = BLL.AnalyzeSelectOrgDataNot(_orgTypeID, _orgID);
                        break;
                    case 3:
                        dtSource = BLL.AnalyzeSelectOrgDataByTime(_orgTypeID, _orgID,_startStudyTime,_endStudyTime);
                        break;
                    case 4:
                        dtSource = BLL.AnalyzeSelectOrgDataByCount(_orgTypeID, _orgID, _startStudyCount, _endStudyCount);
                        break;
                    case 5:
                        dtSource = BLL.AnalyzeSelectOrgDataByDay(_orgTypeID,_orgID,_enterTime);
                        break;
                    case 6:
                        dtSource = BLL.AnalyzeSelectOrgDataByDayNot(_orgTypeID, _orgID, _enterTime);
                        break;
                    case 7:
                        dtSource = BLL.AnalyzeSelectOrgDataByTime(_orgTypeID,OrgID,_startStudyTime,_endStudyTime);
                        break;
                    case 8:
                        dtSource = BLL.AnalyzeSelectOrgDataByCount(_orgTypeID, OrgID, _startStudyCount, _endStudyCount);
                        break;
                    default:
                        break;
                }
                this.dataGridView1.DataSource = dtSource;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
