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
    public partial class AnalyzeOfPie : Form
    {
        private int _orgTypeID;
        private string _orgTypeName;
        private int _orgID;
        private string _orgName;
        private DateTime _thisDay = DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
        private OrgMessageBLL BLL;

        private int _allTimeCount1;
        private int _allTimeCount2;
        private int _allTimeCount3;
        private int _allTimeCount4;
        private int _allTimeCount5;
        private int _allStudyCount1;
        private int _allStudyCount2;
        private int _allStudyCount3;
        private int _allStudyCount4;
        private int _allStudyCount5;
        private int _orgTimeCount1;
        private int _orgTimeCount2;
        private int _orgTimeCount3;
        private int _orgTimeCount4;
        private int _orgTimeCount5;
        private int _orgStudyCount1;
        private int _orgStudyCount2;
        private int _orgStudyCount3;
        private int _orgStudyCount4;
        private int _orgStudyCount5;
        private int _orgDayTimeCount1;
        private int _orgDayTimeCount2;
        private int _orgDayTimeCount3;
        private int _orgDayTimeCount4;
        private int _orgDayTimeCount5;
        private int _orgDayStudyCount1;
        private int _orgDayStudyCount2;
        private int _orgDayStudyCount3;
        private int _orgDayStudyCount4;
        private int _orgDayStudyCount5;

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

        public DateTime ThisDay
        {
            get
            {
                return _thisDay;
            }

            set
            {
                _thisDay = value;
            }
        }

        public int AllTimeCount1
        {
            get
            {
                return _allTimeCount1;
            }

            set
            {
                _allTimeCount1 = value;
            }
        }

        public int AllTimeCount2
        {
            get
            {
                return _allTimeCount2;
            }

            set
            {
                _allTimeCount2 = value;
            }
        }

        public int AllTimeCount3
        {
            get
            {
                return _allTimeCount3;
            }

            set
            {
                _allTimeCount3 = value;
            }
        }

        public int AllTimeCount4
        {
            get
            {
                return _allTimeCount4;
            }

            set
            {
                _allTimeCount4 = value;
            }
        }

        public int AllTimeCount5
        {
            get
            {
                return _allTimeCount5;
            }

            set
            {
                _allTimeCount5 = value;
            }
        }

        public int AllStudyCount1
        {
            get
            {
                return _allStudyCount1;
            }

            set
            {
                _allStudyCount1 = value;
            }
        }

        public int AllStudyCount2
        {
            get
            {
                return _allStudyCount2;
            }

            set
            {
                _allStudyCount2 = value;
            }
        }

        public int AllStudyCount3
        {
            get
            {
                return _allStudyCount3;
            }

            set
            {
                _allStudyCount3 = value;
            }
        }

        public int AllStudyCount4
        {
            get
            {
                return _allStudyCount4;
            }

            set
            {
                _allStudyCount4 = value;
            }
        }

        public int AllStudyCount5
        {
            get
            {
                return _allStudyCount5;
            }

            set
            {
                _allStudyCount5 = value;
            }
        }

        public int OrgTimeCount1
        {
            get
            {
                return _orgTimeCount1;
            }

            set
            {
                _orgTimeCount1 = value;
            }
        }

        public int OrgTimeCount2
        {
            get
            {
                return _orgTimeCount2;
            }

            set
            {
                _orgTimeCount2 = value;
            }
        }

        public int OrgTimeCount3
        {
            get
            {
                return _orgTimeCount3;
            }

            set
            {
                _orgTimeCount3 = value;
            }
        }

        public int OrgTimeCount4
        {
            get
            {
                return _orgTimeCount4;
            }

            set
            {
                _orgTimeCount4 = value;
            }
        }

        public int OrgTimeCount5
        {
            get
            {
                return _orgTimeCount5;
            }

            set
            {
                _orgTimeCount5 = value;
            }
        }

        public int OrgStudyCount1
        {
            get
            {
                return _orgStudyCount1;
            }

            set
            {
                _orgStudyCount1 = value;
            }
        }

        public int OrgStudyCount2
        {
            get
            {
                return _orgStudyCount2;
            }

            set
            {
                _orgStudyCount2 = value;
            }
        }

        public int OrgStudyCount3
        {
            get
            {
                return _orgStudyCount3;
            }

            set
            {
                _orgStudyCount3 = value;
            }
        }

        public int OrgStudyCount4
        {
            get
            {
                return _orgStudyCount4;
            }

            set
            {
                _orgStudyCount4 = value;
            }
        }

        public int OrgStudyCount5
        {
            get
            {
                return _orgStudyCount5;
            }

            set
            {
                _orgStudyCount5 = value;
            }
        }

        public int OrgDayTimeCount1
        {
            get
            {
                return _orgDayTimeCount1;
            }

            set
            {
                _orgDayTimeCount1 = value;
            }
        }

        public int OrgDayTimeCount2
        {
            get
            {
                return _orgDayTimeCount2;
            }

            set
            {
                _orgDayTimeCount2 = value;
            }
        }

        public int OrgDayTimeCount3
        {
            get
            {
                return _orgDayTimeCount3;
            }

            set
            {
                _orgDayTimeCount3 = value;
            }
        }

        public int OrgDayTimeCount4
        {
            get
            {
                return _orgDayTimeCount4;
            }

            set
            {
                _orgDayTimeCount4 = value;
            }
        }

        public int OrgDayTimeCount5
        {
            get
            {
                return _orgDayTimeCount5;
            }

            set
            {
                _orgDayTimeCount5 = value;
            }
        }

        public int OrgDayStudyCount1
        {
            get
            {
                return _orgDayStudyCount1;
            }

            set
            {
                _orgDayStudyCount1 = value;
            }
        }

        public int OrgDayStudyCount2
        {
            get
            {
                return _orgDayStudyCount2;
            }

            set
            {
                _orgDayStudyCount2 = value;
            }
        }

        public int OrgDayStudyCount3
        {
            get
            {
                return _orgDayStudyCount3;
            }

            set
            {
                _orgDayStudyCount3 = value;
            }
        }

        public int OrgDayStudyCount4
        {
            get
            {
                return _orgDayStudyCount4;
            }

            set
            {
                _orgDayStudyCount4 = value;
            }
        }

        public int OrgDayStudyCount5
        {
            get
            {
                return _orgDayStudyCount5;
            }

            set
            {
                _orgDayStudyCount5 = value;
            }
        }

        public AnalyzeOfPie()
        {
            InitializeComponent();
            if (BLL == null)
                BLL = new OrgMessageBLL();
        }

        private void AnalyzeOfPie_Load(object sender, EventArgs e)
        {
            DataTable dtResult = BLL.AnalyzeSegmengSelect();
            if (dtResult.Rows.Count > 0)
            {
                _allTimeCount1 = int.Parse(dtResult.Rows[0]["AllTimeCount1"].ToString());
                _allTimeCount2 = int.Parse(dtResult.Rows[0]["AllTimeCount2"].ToString());
                _allTimeCount3 = int.Parse(dtResult.Rows[0]["AllTimeCount3"].ToString());
                _allTimeCount4 = int.Parse(dtResult.Rows[0]["AllTimeCount4"].ToString());
                _allTimeCount5 = int.Parse(dtResult.Rows[0]["AllTimeCount5"].ToString());

                _allStudyCount1 = int.Parse(dtResult.Rows[0]["AllStudyCount1"].ToString());
                _allStudyCount2 = int.Parse(dtResult.Rows[0]["AllStudyCount2"].ToString());
                _allStudyCount3 = int.Parse(dtResult.Rows[0]["AllStudyCount3"].ToString());
                _allStudyCount4 = int.Parse(dtResult.Rows[0]["AllStudyCount4"].ToString());
                _allStudyCount5 = int.Parse(dtResult.Rows[0]["AllStudyCount5"].ToString());

                _orgTimeCount1 = int.Parse(dtResult.Rows[0]["OrgTimeCount1"].ToString());
                _orgTimeCount2 = int.Parse(dtResult.Rows[0]["OrgTimeCount2"].ToString());
                _orgTimeCount3 = int.Parse(dtResult.Rows[0]["OrgTimeCount3"].ToString());
                _orgTimeCount4 = int.Parse(dtResult.Rows[0]["OrgTimeCount4"].ToString());
                _orgTimeCount5 = int.Parse(dtResult.Rows[0]["OrgTimeCount5"].ToString());

                _orgStudyCount1 = int.Parse(dtResult.Rows[0]["OrgStudyCount1"].ToString());
                _orgStudyCount2 = int.Parse(dtResult.Rows[0]["OrgStudyCount2"].ToString());
                _orgStudyCount3 = int.Parse(dtResult.Rows[0]["OrgStudyCount3"].ToString());
                _orgStudyCount4 = int.Parse(dtResult.Rows[0]["OrgStudyCount4"].ToString());
                _orgStudyCount5 = int.Parse(dtResult.Rows[0]["OrgStudyCount5"].ToString());

                _orgDayTimeCount1 = int.Parse(dtResult.Rows[0]["OrgDayTimeCount1"].ToString());
                _orgDayTimeCount2 = int.Parse(dtResult.Rows[0]["OrgDayTimeCount2"].ToString());
                _orgDayTimeCount3 = int.Parse(dtResult.Rows[0]["OrgDayTimeCount3"].ToString());
                _orgDayTimeCount4 = int.Parse(dtResult.Rows[0]["OrgDayTimeCount4"].ToString());
                _orgDayTimeCount5 = int.Parse(dtResult.Rows[0]["OrgDayTimeCount5"].ToString());

                _orgDayStudyCount1 = int.Parse(dtResult.Rows[0]["OrgDayStudyCount1"].ToString());
                _orgDayStudyCount2 = int.Parse(dtResult.Rows[0]["OrgDayStudyCount2"].ToString());
                _orgDayStudyCount3 = int.Parse(dtResult.Rows[0]["OrgDayStudyCount3"].ToString());
                _orgDayStudyCount4 = int.Parse(dtResult.Rows[0]["OrgDayStudyCount4"].ToString());
                _orgDayStudyCount5 = int.Parse(dtResult.Rows[0]["OrgDayStudyCount5"].ToString());
            }

            if (_thisDay != null)
            {
                this.lblThisDay.Text = "当前分析日期："+_thisDay.ToShortDateString();
            }

            this.chart1.MouseMove += Chart1_MouseMove;
            this.chart2.MouseMove += Chart2_MouseMove;
            this.chart3.MouseMove += Chart3_MouseMove;
            this.chart4.MouseMove += Chart4_MouseMove;
            this.chart5.MouseMove += Chart5_MouseMove;
            this.chart6.MouseMove += Chart6_MouseMove;

            this.chart1.MouseDown += Chart1_MouseDown;
            this.chart2.MouseDown += Chart2_MouseDown;
            this.chart3.MouseDown += Chart3_MouseDown;
            this.chart4.MouseDown += Chart4_MouseDown;
            this.chart5.MouseDown += Chart5_MouseDown;
            this.chart6.MouseDown += Chart6_MouseDown;

            chartLoad1();
            chartLoad2();
            chartLoad3();
            chartLoad4();
            chartLoad5();
            chartLoad6();
        }

        private void Chart6_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                HitTestResult result = this.chart6.HitTest(e.X, e.Y);
                if (result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.DataPointLabel)
                {
                    this.chart6.Series[0].Points[result.PointIndex].CustomProperties = "Exploded=true";
                    this.chart6.Series[0].Points[result.PointIndex].BorderColor = Color.Red;
                    this.chart6.Series[0].Points[result.PointIndex].BorderWidth = 3;
                }
                else
                {
                    foreach (var point in this.chart6.Series[0].Points)
                    {
                        point.CustomProperties = "Exploded=false";
                        point.BorderColor = point.Color;
                        point.BorderWidth = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Chart5_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                HitTestResult result = this.chart5.HitTest(e.X, e.Y);
                if (result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.DataPointLabel)
                {
                    this.chart5.Series[0].Points[result.PointIndex].CustomProperties = "Exploded=true";
                    this.chart5.Series[0].Points[result.PointIndex].BorderColor = Color.Red;
                    this.chart5.Series[0].Points[result.PointIndex].BorderWidth = 3;
                }
                else
                {
                    foreach (var point in this.chart5.Series[0].Points)
                    {
                        point.CustomProperties = "Exploded=false";
                        point.BorderColor = point.Color;
                        point.BorderWidth = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Chart4_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                HitTestResult result = this.chart4.HitTest(e.X, e.Y);
                if (result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.DataPointLabel)
                {
                    this.chart4.Series[0].Points[result.PointIndex].CustomProperties = "Exploded=true";
                    this.chart4.Series[0].Points[result.PointIndex].BorderColor = Color.Red;
                    this.chart4.Series[0].Points[result.PointIndex].BorderWidth = 3;
                }
                else
                {
                    foreach (var point in this.chart4.Series[0].Points)
                    {
                        point.CustomProperties = "Exploded=false";
                        point.BorderColor = point.Color;
                        point.BorderWidth = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Chart3_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                HitTestResult result = this.chart3.HitTest(e.X, e.Y);
                if (result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.DataPointLabel)
                {
                    this.chart3.Series[0].Points[result.PointIndex].CustomProperties = "Exploded=true";
                    this.chart3.Series[0].Points[result.PointIndex].BorderColor = Color.Red;
                    this.chart3.Series[0].Points[result.PointIndex].BorderWidth = 3;
                }
                else
                {
                    foreach (var point in this.chart3.Series[0].Points)
                    {
                        point.CustomProperties = "Exploded=false";
                        point.BorderColor = point.Color;
                        point.BorderWidth = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Chart2_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                HitTestResult result = this.chart2.HitTest(e.X, e.Y);
                if (result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.DataPointLabel)
                {
                    this.chart2.Series[0].Points[result.PointIndex].CustomProperties = "Exploded=true";
                    this.chart2.Series[0].Points[result.PointIndex].BorderColor = Color.Red;
                    this.chart2.Series[0].Points[result.PointIndex].BorderWidth = 3;
                }
                else
                {
                    foreach (var point in this.chart2.Series[0].Points)
                    {
                        point.CustomProperties = "Exploded=false";
                        point.BorderColor = point.Color;
                        point.BorderWidth = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Chart1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                HitTestResult result = this.chart1.HitTest(e.X, e.Y);
                if (result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.DataPointLabel)
                {
                    this.chart1.Series[0].Points[result.PointIndex].CustomProperties = "Exploded=true";
                    this.chart1.Series[0].Points[result.PointIndex].BorderColor = Color.Red;
                    this.chart1.Series[0].Points[result.PointIndex].BorderWidth = 3;
                }
                else
                {
                    foreach (var point in this.chart1.Series[0].Points)
                    {
                        point.CustomProperties = "Exploded=false";
                        point.BorderColor = point.Color;
                        point.BorderWidth = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Chart6_MouseDown(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Chart5_MouseDown(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Chart4_MouseDown(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Chart3_MouseDown(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Chart2_MouseDown(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Chart1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                HitTestResult result = this.chart1.HitTest(e.X, e.Y);
                if (result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.DataPointLabel)
                {
                    DataPoint dp = this.chart1.Series[0].Points[result.PointIndex];
                    string xLabel = dp.AxisLabel;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //听过本机构课的人数占总人数比例
        private void chartLoad1()
        {
            try
            {
                this.chart1.Series.Clear();
                this.chart1.Titles.Clear();

                Series series = new Series("Series1");
                series.ChartType = SeriesChartType.Pie;
                this.chart1.Series.Add(series);

                int allCount = BLL.AnalyzeAllStudentCount(_orgTypeID);
                int orgCount = BLL.AnalyzeOrgStudentCount(_orgTypeID,_orgID);
                double[] yValues = { orgCount, allCount - orgCount };
                string[] xValues = { "听过本机构课的人数", "其他人数" };
                

                this.chart1.Titles.Add("机构人数占总人数");
                this.chart1.Titles[0].ForeColor = Color.Green;
                this.chart1.Titles[0].Font = new Font("微软雅黑", 12f, FontStyle.Regular);
                this.chart1.Titles[0].Alignment = ContentAlignment.TopCenter;
                this.chart1.Titles.Add("总人数：" + allCount + " 人");
                this.chart1.Titles[1].ForeColor = Color.Green;
                this.chart1.Titles[1].Font = new Font("微软雅黑", 8f, FontStyle.Regular);
                this.chart1.Titles[1].Alignment = ContentAlignment.TopRight;

                
                this.chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);
                this.chart1.Series["Series1"].LegendText = "#VALX";
                this.chart1.Series["Series1"].Label = "#PERCENT{P2}" + "(#VALY人)";
                this.chart1.Series["Series1"].ToolTip = "#VALX";//鼠标移动到上面显示的文字  

                //this.chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
                //this.chart1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void chartLoad2()
        {
            try
            {
                this.chart2.Series.Clear();
                this.chart2.Titles.Clear();

                Series series = new Series("Series1");
                series.ChartType = SeriesChartType.Pie;
                this.chart2.Series.Add(series);

                DataTable dtResult = BLL.AnalyzeOrgStudentStudyAndTimeCount(_orgTypeID, _orgID);
                if (dtResult.Rows.Count > 0)
                {
                    string sqlFilter1 = string.Format("AllStudyCount <= {0}", _orgStudyCount1);
                    string sqlFilter2 = string.Format("AllStudyCount > {0} and AllStudyCount<= {1}", _orgStudyCount1, _orgStudyCount2);
                    string sqlFilter3 = string.Format("AllStudyCount > {0} and AllStudyCount<= {1}", _orgStudyCount2, _orgStudyCount3);
                    string sqlFilter4 = string.Format("AllStudyCount > {0} and AllStudyCount<= {1}", _orgStudyCount3, _orgStudyCount4);
                    string sqlFilter5 = string.Format("AllStudyCount > {0} and AllStudyCount<= {1}", _orgStudyCount4, _orgStudyCount5);
                    string sqlFilter6 = string.Format("AllStudyCount > {0}", _orgStudyCount5);

                    DataRow[] childRows1 = dtResult.Select(sqlFilter1);
                    DataRow[] childRows2 = dtResult.Select(sqlFilter2);
                    DataRow[] childRows3 = dtResult.Select(sqlFilter3);
                    DataRow[] childRows4 = dtResult.Select(sqlFilter4);
                    DataRow[] childRows5 = dtResult.Select(sqlFilter5);
                    DataRow[] childRows6 = dtResult.Select(sqlFilter6);

                    int allCount = BLL.AnalyzeAllStudentCount(_orgTypeID);
                    int orgCount = BLL.AnalyzeOrgStudentCount(_orgTypeID, _orgID);
                    double[] yValues = 
                        { childRows1.Length, childRows2.Length, childRows3.Length, childRows4.Length, childRows5.Length, childRows6.Length, };
                    string[] xValues = {
                        _orgStudyCount1 + " 次以下",
                        _orgStudyCount1 + " --- " +_orgStudyCount2+"  次",
                        _orgStudyCount2 + " --- " +_orgStudyCount3+"  次",
                        _orgStudyCount3 + " --- " +_orgStudyCount4+"  次",
                        _orgStudyCount4 + " --- " +_orgStudyCount5+"  次",
                        _orgStudyCount5 + " 次以上"
                    };
                    this.chart2.Series["Series1"].Points.DataBindXY(xValues, yValues);
                    this.chart2.Series["Series1"].LegendText = "#VALX";
                    this.chart2.Series["Series1"].Label = "#PERCENT{P2}" + "(#VALY人)";

                    this.chart2.Titles.Add("本机构听课次数分布");
                    this.chart2.Titles[0].ForeColor = Color.Green;
                    this.chart2.Titles[0].Font = new Font("微软雅黑", 12f, FontStyle.Regular);
                    this.chart2.Titles[0].Alignment = ContentAlignment.TopCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chartLoad3()
        {
            try
            {
                this.chart3.Series.Clear();
                this.chart3.Titles.Clear();

                Series series = new Series("Series1");
                series.ChartType = SeriesChartType.Pie;
                this.chart3.Series.Add(series);

                DataTable dtResult = BLL.AnalyzeOrgStudentStudyAndTimeCount(_orgTypeID, _orgID);
                if (dtResult.Rows.Count > 0)
                {
                    string sqlFilter1 = string.Format("AllStudyTime <= {0}", _orgTimeCount1);
                    string sqlFilter2 = string.Format("AllStudyTime > {0} and AllStudyTime<= {1}", _orgTimeCount1, _orgTimeCount2);
                    string sqlFilter3 = string.Format("AllStudyTime > {0} and AllStudyTime<= {1}", _orgTimeCount2, _orgTimeCount3);
                    string sqlFilter4 = string.Format("AllStudyTime > {0} and AllStudyTime<= {1}", _orgTimeCount3, _orgTimeCount4);
                    string sqlFilter5 = string.Format("AllStudyTime > {0} and AllStudyTime<= {1}", _orgTimeCount4, _orgTimeCount5);
                    string sqlFilter6 = string.Format("AllStudyTime > {0}", _orgTimeCount5);

                    DataRow[] childRows1 = dtResult.Select(sqlFilter1);
                    DataRow[] childRows2 = dtResult.Select(sqlFilter2);
                    DataRow[] childRows3 = dtResult.Select(sqlFilter3);
                    DataRow[] childRows4 = dtResult.Select(sqlFilter4);
                    DataRow[] childRows5 = dtResult.Select(sqlFilter5);
                    DataRow[] childRows6 = dtResult.Select(sqlFilter6);

                    int allCount = BLL.AnalyzeAllStudentCount(_orgTypeID);
                    int orgCount = BLL.AnalyzeOrgStudentCount(_orgTypeID, _orgID);
                    double[] yValues =
                        { childRows1.Length, childRows2.Length, childRows3.Length, childRows4.Length, childRows5.Length, childRows6.Length, };
                    string[] xValues = {
                        _orgTimeCount1 + " 分钟以下",
                        _orgTimeCount1 + " --- " +_orgTimeCount2+"  分钟",
                        _orgTimeCount2 + " --- " +_orgTimeCount3+"  分钟",
                        _orgTimeCount3 + " --- " +_orgTimeCount4+"  分钟",
                        _orgTimeCount4 + " --- " +_orgTimeCount5+"  分钟",
                        _orgTimeCount5 + " 分钟以上"
                    };
                    this.chart3.Series["Series1"].Points.DataBindXY(xValues, yValues);
                    this.chart3.Series["Series1"].LegendText = "#VALX";
                    this.chart3.Series["Series1"].Label = "#PERCENT{P2}" + "(#VALY人)";

                    this.chart3.Titles.Add("本机构听课时长分布");
                    this.chart3.Titles[0].ForeColor = Color.Green;
                    this.chart3.Titles[0].Font = new Font("微软雅黑", 12f, FontStyle.Regular);
                    this.chart3.Titles[0].Alignment = ContentAlignment.TopCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //听过本机构课的人数占本天总人数比例
        private void chartLoad4()
        {
            try
            {
                this.chart4.Series.Clear();
                this.chart4.Titles.Clear();

                Series series = new Series("Series1");
                series.ChartType = SeriesChartType.Pie;
                this.chart4.Series.Add(series);

                int orgCount = BLL.AnalyzeOrgStudentCount(_orgTypeID, _orgID);
                int orgThisDayCount = BLL.AnalyzeOrgStudentDayCount(_orgTypeID, _orgID, _thisDay);
                double[] yValues = { orgThisDayCount, orgCount - orgThisDayCount };
                string[] xValues = { "本机构本天听课人数", "本机构其他天听课人数" };

                this.chart4.Titles.Add("本天机构人数占机构总人数");
                this.chart4.Titles[0].ForeColor = Color.Green;
                this.chart4.Titles[0].Font = new Font("微软雅黑", 12f, FontStyle.Regular);
                this.chart4.Titles[0].Alignment = ContentAlignment.TopCenter;
                this.chart4.Titles.Add("机构总人数：" + orgCount + " 人");
                this.chart4.Titles[1].ForeColor = Color.Green;
                this.chart4.Titles[1].Font = new Font("微软雅黑", 8f, FontStyle.Regular);
                this.chart4.Titles[1].Alignment = ContentAlignment.TopRight;

                this.chart4.Series["Series1"].Points.DataBindXY(xValues, yValues);
                this.chart4.Series["Series1"].LegendText = "#VALX";
                this.chart4.Series["Series1"].Label = "#PERCENT{P2}" + "(#VALY人)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chartLoad5()
        {
            try
            {
                this.chart5.Series.Clear();
                this.chart5.Titles.Clear();

                Series series = new Series("Series1");
                series.ChartType = SeriesChartType.Pie;
                this.chart5.Series.Add(series);

                DataTable dtResult = BLL.AnalyzeOrgStudentDayStudyAndTimeCount(_orgTypeID, _orgID,_thisDay);
                if (dtResult.Rows.Count > 0)
                {
                    string sqlFilter1 = string.Format("AllStudyCount <= {0}", _orgDayStudyCount1);
                    string sqlFilter2 = string.Format("AllStudyCount > {0} and AllStudyCount<= {1}", _orgDayStudyCount1, _orgDayStudyCount2);
                    string sqlFilter3 = string.Format("AllStudyCount > {0} and AllStudyCount<= {1}", _orgDayStudyCount2, _orgDayStudyCount3);
                    string sqlFilter4 = string.Format("AllStudyCount > {0} and AllStudyCount<= {1}", _orgDayStudyCount3, _orgDayStudyCount4);
                    string sqlFilter5 = string.Format("AllStudyCount > {0} and AllStudyCount<= {1}", _orgDayStudyCount4, _orgDayStudyCount5);
                    string sqlFilter6 = string.Format("AllStudyCount > {0}", _orgDayStudyCount5);

                    DataRow[] childRows1 = dtResult.Select(sqlFilter1);
                    DataRow[] childRows2 = dtResult.Select(sqlFilter2);
                    DataRow[] childRows3 = dtResult.Select(sqlFilter3);
                    DataRow[] childRows4 = dtResult.Select(sqlFilter4);
                    DataRow[] childRows5 = dtResult.Select(sqlFilter5);
                    DataRow[] childRows6 = dtResult.Select(sqlFilter6);

                    int allCount = BLL.AnalyzeAllStudentCount(_orgTypeID);
                    int orgCount = BLL.AnalyzeOrgStudentCount(_orgTypeID, _orgID);
                    double[] yValues =
                        { childRows1.Length, childRows2.Length, childRows3.Length, childRows4.Length, childRows5.Length, childRows6.Length, };
                    string[] xValues = {
                        _orgDayStudyCount1 + " 次以下",
                        _orgDayStudyCount1 + " --- " +_orgDayStudyCount2+"  次",
                        _orgDayStudyCount2 + " --- " +_orgDayStudyCount3+"  次",
                        _orgDayStudyCount3 + " --- " +_orgDayStudyCount4+"  次",
                        _orgDayStudyCount4 + " --- " +_orgDayStudyCount5+"  次",
                        _orgDayStudyCount5 + " 次以上"
                    };
                    this.chart5.Series["Series1"].Points.DataBindXY(xValues, yValues);
                    this.chart5.Series["Series1"].LegendText = "#VALX";
                    this.chart5.Series["Series1"].Label = "#PERCENT{P2}" + "(#VALY人)";

                    this.chart5.Titles.Add("截止本天本机构听课次数分布");
                    this.chart5.Titles[0].ForeColor = Color.Green;
                    this.chart5.Titles[0].Font = new Font("微软雅黑", 12f, FontStyle.Regular);
                    this.chart5.Titles[0].Alignment = ContentAlignment.TopCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chartLoad6()
        {
            try
            {
                this.chart6.Series.Clear();
                this.chart6.Titles.Clear();

                Series series = new Series("Series1");
                series.ChartType = SeriesChartType.Pie;
                this.chart6.Series.Add(series);

                DataTable dtResult = BLL.AnalyzeOrgStudentStudyAndTimeCount(_orgTypeID, _orgID);
                if (dtResult.Rows.Count > 0)
                {
                    string sqlFilter1 = string.Format("AllStudyTime <= {0}", _orgDayTimeCount1);
                    string sqlFilter2 = string.Format("AllStudyTime > {0} and AllStudyTime<= {1}", _orgDayTimeCount1, _orgDayTimeCount2);
                    string sqlFilter3 = string.Format("AllStudyTime > {0} and AllStudyTime<= {1}", _orgDayTimeCount2, _orgDayTimeCount3);
                    string sqlFilter4 = string.Format("AllStudyTime > {0} and AllStudyTime<= {1}", _orgDayTimeCount3, _orgDayTimeCount4);
                    string sqlFilter5 = string.Format("AllStudyTime > {0} and AllStudyTime<= {1}", _orgDayTimeCount4, _orgDayTimeCount5);
                    string sqlFilter6 = string.Format("AllStudyTime > {0}", _orgDayTimeCount5);

                    DataRow[] childRows1 = dtResult.Select(sqlFilter1);
                    DataRow[] childRows2 = dtResult.Select(sqlFilter2);
                    DataRow[] childRows3 = dtResult.Select(sqlFilter3);
                    DataRow[] childRows4 = dtResult.Select(sqlFilter4);
                    DataRow[] childRows5 = dtResult.Select(sqlFilter5);
                    DataRow[] childRows6 = dtResult.Select(sqlFilter6);

                    int allCount = BLL.AnalyzeAllStudentCount(_orgTypeID);
                    int orgCount = BLL.AnalyzeOrgStudentCount(_orgTypeID, _orgID);
                    double[] yValues =
                        { childRows1.Length, childRows2.Length, childRows3.Length, childRows4.Length, childRows5.Length, childRows6.Length, };
                    string[] xValues = {
                        _orgDayTimeCount1 + " 分钟以下",
                        _orgDayTimeCount1 + " --- " +_orgDayTimeCount2+"  分钟",
                        _orgDayTimeCount2 + " --- " +_orgDayTimeCount3+"  分钟",
                        _orgDayTimeCount3 + " --- " +_orgDayTimeCount4+"  分钟",
                        _orgDayTimeCount4 + " --- " +_orgDayTimeCount5+"  分钟",
                        _orgDayTimeCount5 + " 分钟以上"
                    };
                    this.chart6.Series["Series1"].Points.DataBindXY(xValues, yValues);
                    this.chart6.Series["Series1"].LegendText = "#VALX";
                    this.chart6.Series["Series1"].Label = "#PERCENT{P2}" + "(#VALY人)";

                    this.chart6.Titles.Add("截止本天本机构听课时长分布");
                    this.chart6.Titles[0].ForeColor = Color.Green;
                    this.chart6.Titles[0].Font = new Font("微软雅黑", 12f, FontStyle.Regular);
                    this.chart6.Titles[0].Alignment = ContentAlignment.TopCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            //ViewState["no"] = e.PostBackValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AnalyzeSegment aSegment = new AnalyzeSegment();
                aSegment.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void loadSegmeng(int AllTimeCount1, int AllTimeCount2, int AllTimeCount3, int AllTimeCount4, int AllTimeCount5,
        int AllStudyCount1, int AllStudyCount2, int AllStudyCount3, int AllStudyCount4, int AllStudyCount5,
        int OrgTimeCount1, int OrgTimeCount2, int OrgTimeCount3, int OrgTimeCount4, int OrgTimeCount5,
        int OrgStudyCount1, int OrgStudyCount2, int OrgStudyCount3, int OrgStudyCount4, int OrgStudyCount5,
        int OrgDayTimeCount1, int OrgDayTimeCount2, int OrgDayTimeCount3, int OrgDayTimeCount4, int OrgDayTimeCount5,
        int OrgDayStudyCount1, int OrgDayStudyCount2, int OrgDayStudyCount3, int OrgDayStudyCount4, int OrgDayStudyCount5)
        {
            this._allTimeCount1 = AllTimeCount1;
            this._allTimeCount2 = AllTimeCount2;
            this._allTimeCount3 = AllTimeCount3;
            this._allTimeCount4 = AllTimeCount4;
            this._allTimeCount5 = AllTimeCount5;
            this._allStudyCount1 = AllStudyCount1;
            this._allStudyCount2 = AllStudyCount2;
            this._allStudyCount3 = AllStudyCount3;
            this._allStudyCount4 = AllStudyCount4;
            this._allStudyCount5 = AllStudyCount5;
            this._orgTimeCount1 = OrgTimeCount1;
            this._orgTimeCount2 = OrgTimeCount2;
            this._orgTimeCount3 = OrgTimeCount3;
            this._orgTimeCount4 = OrgTimeCount4;
            this._orgTimeCount5 = OrgTimeCount5;
            this._orgStudyCount1 = OrgStudyCount1;
            this._orgStudyCount2 = OrgStudyCount2;
            this._orgStudyCount3 = OrgStudyCount3;
            this._orgStudyCount4 = OrgStudyCount4;
            this._orgStudyCount5 = OrgStudyCount5;
            this._orgDayTimeCount1 = OrgDayTimeCount1;
            this._orgDayTimeCount2 = OrgDayTimeCount2;
            this._orgDayTimeCount3 = OrgDayTimeCount3;
            this._orgDayTimeCount4 = OrgDayTimeCount4;
            this._orgDayTimeCount5 = OrgDayTimeCount5;
            this._orgDayStudyCount1 = OrgDayStudyCount1;
            this._orgDayStudyCount2 = OrgDayStudyCount2;
            this._orgDayStudyCount3 = OrgDayStudyCount3;
            this._orgDayStudyCount4 = OrgDayStudyCount4;
            this._orgDayStudyCount5 = OrgDayStudyCount5;

            chartLoad1();
            chartLoad2();
            chartLoad3();
            chartLoad4();
            chartLoad5();
            chartLoad6();
        }

    }
}
