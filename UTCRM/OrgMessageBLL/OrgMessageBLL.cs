using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace UTCRM
{
    public class OrgMessageBLL
    {
        OrgMessageDal DAL;
        public OrgMessageBLL()
        {
            if (DAL == null)
            {
                DAL = new OrgMessageDal();
            }
        }
        
        public int InsertStudentDetailOne(string QQ, int OrgID, int StudyTime,
            string StudyRecord, string StartTime, string AwayTime,
            string DetailAttribute1, string DetailAttribute2, string DetailAttribute3, string Remark)
        {
            return DAL.InsertStudentDetailOne(QQ, OrgID, StudyTime,
                StudyRecord, StartTime, AwayTime, DetailAttribute1, DetailAttribute2, DetailAttribute3, Remark);
        }

        #region -- 添加机构类别 --
        public int InsertOrgType(string OrgTypeName)
        {
            try
            {
                if (OrgTypeName == "")
                    return 0;
                DataSet dsResult = DAL.InsertOrgType(OrgTypeName);
                DataTable dtResult = dsResult.Tables[0];
                int intResult = int.Parse(dtResult.Rows[0][0].ToString());
                if (intResult>0)
                {
                    CreateTable(intResult);//暂时注释建表语句
                }
                return intResult;
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region -- 删除机构类别 --
        public bool DeleteOrgType(int OrgTypeID)
        {
            try
            {
                if (OrgTypeID <= 0)
                    return false;
                bool boolResult = DAL.DeleteOrgType(OrgTypeID);
                return boolResult;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region -- 修改机构类别 --
        public bool UpdateOrgType(int OrgTypeID, string OrgTypeName)
        {
            try
            {
                if (OrgTypeID <= 0|| OrgTypeName == "" || OrgTypeName == null)
                    return false;
                bool boolResult = DAL.UpdateOrgType(OrgTypeID, OrgTypeName);
                return boolResult;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region -- 创建数据表 --
        public void CreateTable(int OrgTypeID)
        {
            try
            {
                DAL.CreateTable(OrgTypeID);
            }
            catch
            {

            }
        }
        #endregion

        #region -- 查询机构类型 --
        public DataTable SelectOrgTypeTable()
        {
            DataTable dtResult = new DataTable();
            try
            {
                DataSet ds = DAL.SelectOrgTypeTable();
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }

        public DataTable SelectOrgTypeTable(string OrgTypeName)
        {
            DataTable dtResult = new DataTable();
            try
            {
                DataSet ds = DAL.SelectOrgTypeTable( OrgTypeName);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion


        #region -- 添加机构信息 --
        public int InsertOrgMessage(int OrgTypeID, string OrgName, string Remark)
        {
            try
            {
                if (OrgTypeID == 0 || OrgName == "")
                    return 0;
                DataSet dsResult = DAL.InsertOrgMessage(OrgTypeID, OrgName, Remark);
                DataTable dtResult = dsResult.Tables[0];
                int intResult = int.Parse(dtResult.Rows[0][0].ToString());
                return intResult;
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region -- 删除机构信息 --
        public bool DeleteOrgMessage(int OrgTypeID, int OrgID)
        {
            try
            {
                if (OrgTypeID <= 0|| OrgID <= 0)
                    return false;
                bool boolResult = DAL.DeleteOrgMessage(OrgTypeID, OrgID);
                return boolResult;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region -- 修改机构信息 --
        public bool UpDateOrgMessage(int OrgTypeID, int OrgID, string OrgName, string Remark)
        {
            try
            {
                if (OrgTypeID <= 0 || OrgID <=0 || OrgName == "" || OrgName == null)
                    return false;
                bool boolResult = DAL.UpDateOrgMessage(OrgTypeID, OrgID, OrgName, Remark);
                return boolResult;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region -- 查询机构信息 --
        public DataTable SelectOrgMessage(int OrgTypeID)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0)
                    return null;
                DataSet ds = DAL.SelectOrgMessageByType(OrgTypeID);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion


        #region -- 查询机构简短汇总数据 --
        public DataTable SelectOrgDataHeard(int OrgTypeID, int OrgID)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0|| OrgID<=0)
                    return null;
                DataSet ds = DAL.SelectOrgDataHeard(OrgTypeID, OrgID);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion

        #region -- 查询机构批次详细数据 --
        public DataTable SelectOrgDataDetail(int OrgTypeID, int OrgID, int EnterBatchID)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0 || OrgID <= 0 || EnterBatchID <= 0)
                    return null;
                DataSet ds = DAL.SelectOrgDataDetail(OrgTypeID, OrgID, EnterBatchID);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion


        #region -- 获取总最大批次 --
        public int SelectMaxEnterBatchID(int OrgTypeID)
        {
            try
            {
                if (OrgTypeID <= 0)
                    return 0;
                int intResult = DAL.SelectMaxEnterBatchID(OrgTypeID);
                return intResult;
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region -- 获取机构最大批次 --
        public int SelectMaxEnterBatchID(int OrgTypeID, int OrgID)
        {
            try
            {
                if (OrgTypeID <= 0|| OrgID<=0)
                    return 0;
                int intResult = DAL.SelectMaxEnterBatchID(OrgTypeID, OrgID);
                return intResult;
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region -- 获取总最大批次向详情库中插入抓取到的学生信息,datatable中的表名应该为插入表名 --
        public void InsertStudentDetailMore(DataTable dataTable)
        {
            try
            {
                if (dataTable.Rows.Count == 0)
                    return;
                DAL.InsertStudentDetailMore(dataTable);
            }
            catch
            {

            }
        }
        #endregion

        #region -- 过滤出此批次在总表中不存在的数据 --
        public DataTable SelectStudentMessageNotExist(int OrgTypeID, int EnterBatchID)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0 || EnterBatchID <= 0)
                    return dtResult;
                DataSet dsResult = DAL.SelectStudentMessageNotExist(OrgTypeID, EnterBatchID);
                if (dsResult.Tables.Count == 0)
                    return dtResult;
                dtResult = dsResult.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion

        #region -- 向总表中插入不存在的数据 --
        public void InsertStudentMessageNotExist(DataTable dataTable)
        {
            try
            {
                if (dataTable.Rows.Count == 0)
                    return;
                DAL.InsertStudentMessageNotExist(dataTable);
            }
            catch
            {

            }
        }
        #endregion

        #region -- 通过批次更新总表中的数据 --
        public int UpdateStudentMessageExist(int OrgTypeID, int EnterBatchID)
        {
            try
            {
                if (OrgTypeID <= 0 || EnterBatchID <= 0)
                    return 0;
                int intResult = DAL.UpdateStudentMessageExist(OrgTypeID, EnterBatchID);
                return intResult;
            }
            catch
            {
                return 0;
            }
        }
        #endregion


        #region -- 监控数据插入 --
        public int InsertCRMStudengData(DataTable dataTable, int OrgTypeID, int orgID,string EnterTimeStr)
        {
            try
            {
                //参数校验
                if (dataTable.Rows.Count == 0 || OrgTypeID <= 0 || orgID <= 0)
                    return 0;

                //将机构时间整合进数据源
                dataTable.Columns.Add("EnterTime", typeof(DateTime));
                foreach (DataRow dr in dataTable.Rows)
                    dr["EnterTime"] = EnterTimeStr;
                 
                //将机构ID整合进数据源
                dataTable.Columns.Add("OrgID", typeof(int));
                foreach (DataRow dr in dataTable.Rows)
                    dr["OrgID"] = orgID;

                //获取前的总批次
                int enterBatchIDStart = DAL.SelectMaxEnterBatchID(OrgTypeID);

                dataTable.Columns.Add("EnterBatchID", typeof(int));
                foreach (DataRow dr in dataTable.Rows)
                    dr["EnterBatchID"] = enterBatchIDStart + 1;

                //获取此机构插入前的批次
                int enterOrgBatchIDMax = DAL.SelectMaxEnterBatchID(OrgTypeID, orgID);
                //将机构批次整合进数据源
                dataTable.Columns.Add("OrgEnterBacthID", typeof(int));
                foreach (DataRow dr in dataTable.Rows)
                    dr["OrgEnterBacthID"] = enterOrgBatchIDMax + 1;

                //插入详情表
                dataTable.TableName = "StudentDetail_" + OrgTypeID;
                DAL.InsertStudentDetailMore(dataTable);
                //获取插入后总批次
                int enterBatchIDEnd = DAL.SelectMaxEnterBatchID(OrgTypeID);
                //比较两次ID，看是否插入成功
                if (enterBatchIDStart == enterBatchIDEnd)
                    return 0;
                //过滤出此批次在总库中不存在的数据
                DataSet dsNotExist = DAL.SelectStudentMessageNotExist(OrgTypeID, enterBatchIDEnd);
                DataTable dtNotExist = dsNotExist.Tables[0];
                if (dtNotExist.Rows.Count != 0)
                {
                    dtNotExist.TableName = "StudentMessage_" + OrgTypeID;
                    DAL.InsertStudentMessageNotExist(dtNotExist);
                }
                //更新总表
                int intResult = DAL.UpdateStudentMessageExist(OrgTypeID, enterBatchIDEnd);
                return intResult;
            }
            catch
            {
                return 0;
            }
        }
        #endregion


        #region -- 数据分析划段查询 --
        public DataTable AnalyzeSegmengSelect()
        {
            DataTable dtResult = new DataTable();
            try
            {
                DataSet ds = DAL.AnalyzeSegmengSelect();
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion

        #region -- 数据分析划段删除新增 --
        public bool AnalyzeSegmeng(
             int AllTimeCount1, int AllTimeCount2, int AllTimeCount3, int AllTimeCount4, int AllTimeCount5,
             int AllStudyCount1, int AllStudyCount2, int AllStudyCount3, int AllStudyCount4, int AllStudyCount5,
             int OrgTimeCount1, int OrgTimeCount2, int OrgTimeCount3, int OrgTimeCount4, int OrgTimeCount5,
             int OrgStudyCount1, int OrgStudyCount2, int OrgStudyCount3, int OrgStudyCount4, int OrgStudyCount5,
             int OrgDayTimeCount1, int OrgDayTimeCount2, int OrgDayTimeCount3, int OrgDayTimeCount4, int OrgDayTimeCount5,
             int OrgDayStudyCount1, int OrgDayStudyCount2, int OrgDayStudyCount3, int OrgDayStudyCount4, int OrgDayStudyCount5)
        {
            try
            {
                if (AllTimeCount1 <= 0 || AllTimeCount2 <= 0 || AllTimeCount3 <=0 || AllTimeCount4 <= 0 || AllTimeCount5 <= 0
                    || AllStudyCount1 <= 0 || AllStudyCount2 <= 0 || AllStudyCount3 <= 0 || AllStudyCount4 <= 0 || AllStudyCount5 <= 0
                    || OrgTimeCount1 <= 0 || OrgTimeCount2 <= 0 || OrgTimeCount3 <= 0 || OrgTimeCount4 <= 0 || OrgTimeCount5 <= 0
                    || OrgStudyCount1 <= 0 || OrgStudyCount2 <= 0 || OrgStudyCount3 <= 0 || OrgStudyCount4 <= 0 || OrgStudyCount5 <= 0
                    || OrgDayTimeCount1 <= 0 || OrgDayTimeCount2 <= 0 || OrgDayTimeCount3 <= 0 || OrgDayTimeCount4 <= 0 || OrgDayTimeCount5 <= 0
                    || OrgDayStudyCount1 <= 0 || OrgDayStudyCount2 <= 0 || OrgDayStudyCount3 <= 0 || OrgDayStudyCount4 <= 0 || OrgDayStudyCount5 <= 0)
                {
                    return false;
                }
                bool boolResult = DAL.AnalyzeSegmengDeleteThenAdd(
                     AllTimeCount1, AllTimeCount2, AllTimeCount3, AllTimeCount4, AllTimeCount5,
                     AllStudyCount1, AllStudyCount2, AllStudyCount3, AllStudyCount4, AllStudyCount5,
                     OrgTimeCount1, OrgTimeCount2, OrgTimeCount3, OrgTimeCount4, OrgTimeCount5,
                     OrgStudyCount1, OrgStudyCount2, OrgStudyCount3, OrgStudyCount4, OrgStudyCount5,
                     OrgDayTimeCount1, OrgDayTimeCount2, OrgDayTimeCount3, OrgDayTimeCount4, OrgDayTimeCount5,
                     OrgDayStudyCount1, OrgDayStudyCount2, OrgDayStudyCount3, OrgDayStudyCount4, OrgDayStudyCount5);
                return boolResult;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region -- 机构数据分析-- 机构名-机构批次-总人数--
        public DataTable AnalyzeSelectOrgNameBatchCount(int OrgTypeID, int OrgID, DateTime StartTime, DateTime EndTime)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0 || OrgID <= 0 || StartTime == null || EndTime == null || (StartTime > EndTime))
                    return dtResult;
                string StartTimeEnter = StartTime.ToString();
                string EndTimeEnter = EndTime.ToString();
                DataSet ds = DAL.AnalyzeSelectOrgNameBatchCount(OrgTypeID, OrgID, StartTimeEnter, EndTimeEnter);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }

        public DataSet AnalyzeSelectOrgNameBatchCount(int OrgTypeID, DateTime StartTime, DateTime EndTime)
        {
            DataSet dsResult = new DataSet();
            try
            {
                if (OrgTypeID <= 0 || StartTime == null || EndTime == null || (StartTime > EndTime))
                    return dsResult;
                string StartTimeEnter = StartTime.ToString();
                string EndTimeEnter = EndTime.ToString();
                DataSet dsOrg = DAL.SelectOrgMessageByType(OrgTypeID);
                DataTable dtOrg = dsOrg.Tables[0];

                foreach (DataRow drOrg in dtOrg.Rows)
                {
                    DataSet ds = DAL.AnalyzeSelectOrgNameBatchCount(OrgTypeID, StartTimeEnter, EndTimeEnter);
                    DataTable dtTemp = ds.Tables[0];
                    dtTemp.TableName = drOrg["OrgName"].ToString();
                    dsResult.Tables.Add(dtTemp);
                }
                return dsResult;
            }
            catch
            {
                return dsResult;
            }
        }
        #endregion

        #region -- 机构数据分析-- 机构名-录入日期-总人数--
        public DataTable AnalyzeSelectOrgNameDateCount(int OrgTypeID, int OrgID, DateTime StartTime, DateTime EndTime)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0 || OrgID <= 0 || StartTime == null || EndTime == null || (StartTime > EndTime))
                    return dtResult;
                string StartTimeEnter = StartTime.ToString();
                string EndTimeEnter = EndTime.ToString();
                DataSet ds = DAL.AnalyzeSelectOrgNameDateCount(OrgTypeID, OrgID, StartTimeEnter, EndTimeEnter);
                dtResult = ds.Tables[0];
                if (dtResult.Rows.Count>0)
                {
                    dtResult.TableName = dtResult.Rows[0]["OrgName"].ToString();
                }
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }

        public DataSet AnalyzeSelectOrgNameDateCount(int OrgTypeID, DateTime StartTime, DateTime EndTime)
        {
            DataSet dsResult = new DataSet();
            try
            {
                if (OrgTypeID <= 0 || StartTime == null || EndTime == null || (StartTime > EndTime))
                    return dsResult;
                string StartTimeEnter = StartTime.ToString();
                string EndTimeEnter = EndTime.ToString();
                DataSet dsOrg = DAL.SelectOrgMessageByType(OrgTypeID);
                DataTable dtOrg = dsOrg.Tables[0];

                foreach (DataRow drOrg in dtOrg.Rows)
                {
                    int OrgTypeID_Temp = tools.ToInt(drOrg["OrgTypeID"].ToString());
                    int OrgID_Temp = tools.ToInt(drOrg["OrgID"].ToString());
                    DataSet ds = DAL.AnalyzeSelectOrgNameDateCount(OrgTypeID_Temp, OrgID_Temp, StartTimeEnter, EndTimeEnter);
                    DataTable dtTemp = new DataTable();
                    dtTemp = ds.Tables[0].Copy();
                    dtTemp.TableName = drOrg["OrgName"].ToString();

                    dsResult.Tables.Add(dtTemp);
                }
                return dsResult;
            }
            catch
            {
                return dsResult;
            }
        }
        #endregion

        #region -- 机构数据分析-- 监控库总人数 --
        public int AnalyzeAllStudentCount(int OrgTypeID)
        {
            int intResult = 0;
            try
            {
                if (OrgTypeID <= 0)
                    return 0;
                DataSet ds = DAL.AnalyzeAllStudentCount(OrgTypeID);
                intResult = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                return intResult;
            }
            catch
            {
                return intResult;
            }
        }
        #endregion

        #region -- 机构数据分析-- 机构总人数 --
        public int AnalyzeOrgStudentCount(int OrgTypeID, int OrgID)
        {
            int intResult = 0;
            try
            {
                if (OrgTypeID <= 0 || OrgID <= 0)
                    return 0;
                DataSet ds = DAL.AnalyzeOrgStudentCount(OrgTypeID, OrgID);
                intResult = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                return intResult;
            }
            catch
            {
                return intResult;
            }
        }
        #endregion

        #region-- 机构数据分析-- 机构学员听课次数和时间情况 --
        public DataTable AnalyzeOrgStudentStudyAndTimeCount(int OrgTypeID, int OrgID)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0 || OrgID <= 0)
                    return dtResult;
                DataSet ds = DAL.AnalyzeOrgStudentStudyAndTimeCount(OrgTypeID, OrgID);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion

        #region -- 机构数据分析-- 机构本天总人数 --
        public int AnalyzeOrgStudentDayCount(int OrgTypeID, int OrgID, DateTime ThisDay)
        {
            int intResult = 0;
            try
            {
                if (OrgTypeID <= 0 || OrgID <= 0 || ThisDay == null)
                    return 0;
                DataSet ds = DAL.AnalyzeOrgStudentDayCount(OrgTypeID, OrgID, ThisDay);
                intResult = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                return intResult;
            }
            catch
            {
                return intResult;
            }
        }
        #endregion

        #region -- 机构数据分析-- 机构学员截止本天听课次数和时长情况 --
        public DataTable AnalyzeOrgStudentDayStudyAndTimeCount(int OrgTypeID, int OrgID, DateTime ThisDay)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0 || OrgID <= 0 || ThisDay == null)
                    return dtResult;
                DataSet ds = DAL.AnalyzeOrgStudentDayStudyAndTimeCount(OrgTypeID, OrgID, ThisDay);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion


        #region -- 本类型总的学员信息 --
        public DataTable AnalyzeSelectOrgTypeData(int OrgTypeID)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0 )
                    return dtResult;
                DataSet ds = DAL.AnalyzeSelectOrgTypeData(OrgTypeID);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion

        #region -- 听过该机构课的学员信息 --
        public DataTable AnalyzeSelectOrgData(int OrgTypeID, int OrgID)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0 || OrgID <= 0)
                    return dtResult;
                DataSet ds = DAL.AnalyzeSelectOrgData(OrgTypeID, OrgID);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion

        #region -- 未听过该机构课的学员信息 --
        public DataTable AnalyzeSelectOrgDataNot(int OrgTypeID, int OrgID)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0 || OrgID <= 0)
                    return dtResult;
                DataSet ds = DAL.AnalyzeSelectOrgDataNot(OrgTypeID, OrgID);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion

        #region -- 听过该机构课的学员信息，根据在本机构的学习总时长划分 --
        public DataTable AnalyzeSelectOrgDataByTime(int OrgTypeID, int OrgID, int IntStartTime, int IntEndTime)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0 || OrgID <= 0 || (IntStartTime >= IntEndTime))
                    return dtResult;
                DataSet ds = DAL.AnalyzeSelectOrgDataByTime(OrgTypeID, OrgID, IntStartTime, IntEndTime);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion

        #region -- 听过该机构课的学员信息，根据在本机构的学习总次数划分 --
        public DataTable AnalyzeSelectOrgDataByCount(int OrgTypeID, int OrgID, int IntStartCount, int IntEndCount)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0 || OrgID <= 0 || (IntStartCount >= IntEndCount))
                    return dtResult;
                DataSet ds = DAL.AnalyzeSelectOrgDataByCount(OrgTypeID, OrgID, IntStartCount, IntEndCount);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion


        #region -- 本天该类型的所有学员信息 --
        public DataTable AnalyzeSelectOrgTypeDataByDay(int OrgTypeID, DateTime EnterTime)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0 || EnterTime == null)
                    return dtResult;
                string strEnterTime = EnterTime.ToShortDateString();
                DataSet ds = DAL.AnalyzeSelectOrgTypeDataByDay(OrgTypeID, strEnterTime);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion

        #region -- 本天听过该机构课的学员信息 --
        public DataTable AnalyzeSelectOrgDataByDay(int OrgTypeID, int OrgID, DateTime EnterTime)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0 || OrgID <= 0 || EnterTime == null)
                    return dtResult;
                string strEnterTime = EnterTime.ToShortDateString();
                DataSet ds = DAL.AnalyzeSelectOrgDataByDay(OrgTypeID, OrgID, strEnterTime);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion

        #region -- 本天未听过该机构课的学员信息 --
        public DataTable AnalyzeSelectOrgDataByDayNot(int OrgTypeID, int OrgID, DateTime EnterTime)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0 || OrgID <= 0 || EnterTime == null)
                    return dtResult;
                string strEnterTime = EnterTime.ToShortDateString();
                DataSet ds = DAL.AnalyzeSelectOrgDataByDayNot(OrgTypeID, OrgID, strEnterTime);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion

        #region -- 本天听过该机构课的学员信息，根据在本机构的学习总时长划分 --
        public DataTable AnalyzeSelectOrgDataByTime(int OrgTypeID, int OrgID, DateTime EnterTime, int IntStartTime, int IntEndTime)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0 || OrgID <= 0 || EnterTime == null || (IntStartTime >= IntEndTime))
                    return dtResult;
                string strEnterTime = EnterTime.ToShortDateString();
                DataSet ds = DAL.AnalyzeSelectOrgDataByTime(OrgTypeID, OrgID, strEnterTime, IntStartTime, IntEndTime);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion

        #region -- 本天听过该机构课的学员信息，根据在本机构的学习总次数划分 --
        public DataTable AnalyzeSelectOrgDataByCount(int OrgTypeID, int OrgID, DateTime EnterTime, int IntStartCount, int IntEndCount)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID <= 0 || OrgID <= 0 || EnterTime == null || (IntStartCount >= IntEndCount))
                    return dtResult;
                string strEnterTime = EnterTime.ToShortDateString();
                DataSet ds = DAL.AnalyzeSelectOrgDataByCount(OrgTypeID, OrgID, strEnterTime, IntStartCount, IntEndCount);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion


        #region -- 机构数据查询 -- 
        public DataTable SelectOutDataAll(string OrgTypeID, string MinStudyCount, string MaxStudyCount, string MinStudyTime, string MaxStudyTime, 
            string StartEnterTime, string EndEnterTime, string OrgID)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID == "" || OrgTypeID == null)
                    return dtResult;
                if (MinStudyCount != "" && MinStudyCount != null && MaxStudyCount != "" && MaxStudyCount != null)
                {
                    int intMinStudyCount = int.Parse(MinStudyCount);
                    int intMaxStudyCount = int.Parse(MaxStudyCount);
                    if (intMinStudyCount> intMaxStudyCount)
                        return dtResult;
                }
                if (MinStudyTime != "" && MinStudyTime != null && MaxStudyTime != "" && MaxStudyTime != null)
                {
                    int intMinStudyTime = int.Parse(MinStudyTime);
                    int intMaxStudyTime = int.Parse(MaxStudyTime);
                    if (intMinStudyTime > intMaxStudyTime)
                        return dtResult;
                }
                if (StartEnterTime != "" && StartEnterTime != null && EndEnterTime != "" && EndEnterTime != null)
                {
                    DateTime dtStartEnterTime = DateTime.Parse(StartEnterTime);
                    DateTime dtEndEnterTime = DateTime.Parse(EndEnterTime);
                    if (dtStartEnterTime > dtEndEnterTime)
                        return dtResult;
                }
                if (OrgID != "" && OrgID != null)
                {
                    int intOrgID = int.Parse(OrgID);
                    if (intOrgID<=0)
                        return dtResult;
                }

                DataSet ds = DAL.SelectOutDataAll(OrgTypeID, MinStudyCount, MaxStudyCount, MinStudyTime, MaxStudyTime,
                    StartEnterTime, EndEnterTime, OrgID);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch(Exception ex)
            {
                return dtResult;
            }
        }

        public int SelectOutDataAllCount(string OrgTypeID, string MinStudyCount, string MaxStudyCount, string MinStudyTime, string MaxStudyTime, 
            string StartEnterTime, string EndEnterTime, string OrgID)
        {
            int intResult = 0;
            try
            {
                if (OrgTypeID == "" || OrgTypeID == null)
                    return intResult;
                if (MinStudyCount != "" && MinStudyCount != null && MaxStudyCount != "" && MaxStudyCount != null)
                {
                    int intMinStudyCount = int.Parse(MinStudyCount);
                    int intMaxStudyCount = int.Parse(MaxStudyCount);
                    if (intMinStudyCount > intMaxStudyCount)
                        return intResult;
                }
                if (MinStudyTime != "" && MinStudyTime != null && MaxStudyTime != "" && MaxStudyTime != null)
                {
                    int intMinStudyTime = int.Parse(MinStudyTime);
                    int intMaxStudyTime = int.Parse(MaxStudyTime);
                    if (intMinStudyTime > intMaxStudyTime)
                        return intResult;
                }
                if (StartEnterTime != "" && StartEnterTime != null && EndEnterTime != "" && EndEnterTime != null)
                {
                    DateTime dtStartEnterTime = DateTime.Parse(StartEnterTime);
                    DateTime dtEndEnterTime = DateTime.Parse(EndEnterTime);
                    if (dtStartEnterTime > dtEndEnterTime)
                        return intResult;
                }
                if (OrgID != "" && OrgID != null)
                {
                    int intOrgID = int.Parse(OrgID);
                    if (intOrgID <= 0)
                        return intResult;
                }
                DataSet ds = DAL.SelectOutDataAllCount(OrgTypeID, MinStudyCount, MaxStudyCount, MinStudyTime, MaxStudyTime,
                    StartEnterTime, EndEnterTime, OrgID);
                DataTable dtResult = ds.Tables[0];
                intResult = int.Parse(dtResult.Rows[0][0].ToString());
                return intResult;
            }
            catch
            {
                return intResult;
            }
        }

        public DataTable SelectOutDataPage(int PageNum, string OrgTypeID, string MinStudyCount, string MaxStudyCount, string MinStudyTime, string MaxStudyTime,
            string StartEnterTime, string EndEnterTime, string OrgID)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (OrgTypeID == "" || OrgTypeID == null|| PageNum==0)
                    return dtResult;
                if (MinStudyCount != "" && MinStudyCount != null && MaxStudyCount != "" && MaxStudyCount != null)
                {
                    int intMinStudyCount = int.Parse(MinStudyCount);
                    int intMaxStudyCount = int.Parse(MaxStudyCount);
                    if (intMinStudyCount > intMaxStudyCount)
                        return dtResult;
                }
                if (MinStudyTime != "" && MinStudyTime != null && MaxStudyTime != "" && MaxStudyTime != null)
                {
                    int intMinStudyTime = int.Parse(MinStudyTime);
                    int intMaxStudyTime = int.Parse(MaxStudyTime);
                    if (intMinStudyTime > intMaxStudyTime)
                        return dtResult;
                }
                if (StartEnterTime != "" && StartEnterTime != null && EndEnterTime != "" && EndEnterTime != null)
                {
                    DateTime dtStartEnterTime = DateTime.Parse(StartEnterTime);
                    DateTime dtEndEnterTime = DateTime.Parse(EndEnterTime);
                    if (dtStartEnterTime > dtEndEnterTime)
                        return dtResult;
                }
                if (OrgID != "" && OrgID != null)
                {
                    int intOrgID = int.Parse(OrgID);
                    if (intOrgID <= 0)
                        return dtResult;
                }

                DataSet ds = DAL.SelectOutDataPage(PageNum, OrgTypeID, MinStudyCount, MaxStudyCount, MinStudyTime, MaxStudyTime, StartEnterTime, EndEnterTime, OrgID);
                dtResult = ds.Tables[0];
                return dtResult;
            }
            catch
            {
                return dtResult;
            }
        }
        #endregion
    }
}
