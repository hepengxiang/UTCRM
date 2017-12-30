using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UTCRM.OrgMessageFrm
{
    public partial class FrmOrgDataAnalyze : Form
    {
        private OrgMessageBLL BLL;
        public FrmOrgDataAnalyze()
        {
            InitializeComponent();
            if (BLL == null)
                BLL = new OrgMessageBLL();
        }

        private void FrmOrgDataAnalyze_Load(object sender, EventArgs e)
        {
            this.chart1.MouseDown += Chart1_MouseDown;
            this.chart1.MouseMove += Chart1_MouseMove;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AnalyzeSelectWindow asw = new AnalyzeSelectWindow();
                asw.ShowDialog();
                if (asw.DialogResult == DialogResult.OK)
                {
                    while (this.chart1.Series.Count>0)
                    {
                        this.chart1.Series.Clear();
                    }
                    
                    DataSet dsResult = new DataSet();
                    int orgTypeID = asw.OrgTypeID;
                    int orgID = asw.OrgID;
                    string orgTypeName = asw.OrgTypeName;
                    if (orgID != 0)
                    {
                        DataTable dtResult = BLL.AnalyzeSelectOrgNameDateCount(orgTypeID, orgID, DateTime.Now.AddYears(-1), DateTime.Now);
                        dsResult.Tables.Add(dtResult.Copy());
                    }
                    else
                    {
                        dsResult = BLL.AnalyzeSelectOrgNameDateCount(orgTypeID, DateTime.Now.AddYears(-1), DateTime.Now);
                    }

                    foreach (DataTable dt in dsResult.Tables)
                    {
                        if (dt.Rows.Count == 0)
                            continue;
                        string[] typeIDAndOrgID = new string[4];
                        typeIDAndOrgID[0] = orgTypeID.ToString();
                        typeIDAndOrgID[1] = orgTypeName;
                        typeIDAndOrgID[2] = dt.Rows[0][0].ToString();
                        typeIDAndOrgID[3] = dt.Rows[0][1].ToString();
                        Series series = new Series(dt.TableName);
                        series.Tag = typeIDAndOrgID;
                        series.Points.DataBind(dt.AsEnumerable(), "EnterTime", "StudentCount", "");
                        #region -- 线条外观控制属性 --
                        series.BorderWidth = 2;
                        series.MarkerBorderColor = Color.Tomato;
                        series.MarkerBorderWidth = 1;
                        series.MarkerColor = Color.Red;
                        series.MarkerSize = 1;
                        #endregion

                        series.ToolTip = "#VALX,#VAL";

                        series.ChartType = SeriesChartType.Spline;
                        this.chart1.Series.Add(series);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Series enterSeries;
        private Color beforeColor= Color.Black;
        private void Chart1_MouseMove(object sender, MouseEventArgs e)
        {
            
            HitTestResult result = this.chart1.HitTest(e.X, e.Y);
            //当前选中的为曲线
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                if (enterSeries == null && beforeColor == Color.Black)
                {
                    enterSeries = result.Series;
                    beforeColor = enterSeries.Color;
                    enterSeries.Color = Color.Red;
                    this.Cursor = Cursors.Hand;
                }
            }
            else//移出曲线区域
            {
                if (enterSeries != null && beforeColor != Color.Black)
                {
                    enterSeries.Color = beforeColor;
                    enterSeries = null;
                    beforeColor = Color.Black;
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void Chart1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                HitTestResult result = this.chart1.HitTest(e.X, e.Y);
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    DataPoint selectedDataPoint = (DataPoint)result.Object;

                    DateTime dt= DateTime.FromOADate(selectedDataPoint.XValue);

                    Series s = result.Series;
                    string[] typeIDAndOrgID = (string[])s.Tag;
                    AnalyzeOfPie aop = new AnalyzeOfPie();
                    aop.OrgTypeID = int.Parse(typeIDAndOrgID[0]);
                    aop.OrgTypeName = typeIDAndOrgID[1];
                    aop.OrgID = int.Parse(typeIDAndOrgID[2]);
                    aop.OrgName = typeIDAndOrgID[3];
                    aop.ThisDay = DateTime.FromOADate(selectedDataPoint.XValue);
                    aop.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
