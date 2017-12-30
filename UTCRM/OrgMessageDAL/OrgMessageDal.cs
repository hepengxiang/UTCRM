using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace UTCRM
{
    public class OrgMessageDal
    {
        public int InsertStudentDetailOne(string QQ, int OrgID, int StudyTime,
            string StudyRecord, string StartTime, string AwayTime,
            string DetailAttribute1, string DetailAttribute2, string DetailAttribute3, string Remark)
        {
            string SQLString =
"insert into Orginazation(EnterBatchID,QQ,OrgID,StudyTime,StudyRecord," +
"StartTime,AwayTime,DetailAttribute1,DetailAttribute2,DetailAttribute3,Remark) " +
"values((select max(EnterBatchID) from StudentDetail group by EnterBatchID)+1," +
"@QQ,@OrgID,@StudyTime,@StudyRecord,@StartTime,@AwayTime,@DetailAttribute1,@DetailAttribute2,@DetailAttribute3,@Remark)";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@QQ",QQ),
                new SqlParameter("@OrgID",OrgID),
                new SqlParameter("@StudyTime",StudyTime),
                new SqlParameter("@StudyRecord",StudyRecord),
                new SqlParameter("@StartTime",StartTime),
                new SqlParameter("@AwayTime",AwayTime),
                new SqlParameter("@DetailAttribute1",DetailAttribute1),
                new SqlParameter("@DetailAttribute2",DetailAttribute2),
                new SqlParameter("@DetailAttribute3",DetailAttribute3),
                new SqlParameter("@Remark",Remark)
            };
            int intResult = DbHelperSQL.ExecuteSql(SQLString, paras);
            return intResult;
        }

        #region -- 添加机构类别 --
        //插入机构类别信息,返回插入的ID
        public DataSet InsertOrgType(string OrgTypeName)
        {
            string SQLString = string.Format(
 " insert into OrgTypeTable (OrgTypeName) values (@OrgTypeName)" +
 " select @@identity ");
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@OrgTypeName",OrgTypeName)
           };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion

        #region -- 删除机构类别 --
        public bool DeleteOrgType(int OrgTypeID)
        {
            string SQLString = string.Format(
 " delete from OrgTypeTable where OrgTypeID = @OrgTypeID");
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@OrgTypeID",OrgTypeID)
           };
            int dtResult = DbHelperSQL.ExecuteSql(SQLString, paras);
            if (dtResult > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region -- 修改机构类别 --
        public bool UpdateOrgType(int OrgTypeID, string OrgTypeName)
        {
            string SQLString = string.Format(
"update OrgTypeTable set OrgTypeName = @OrgTypeName where OrgTypeID = @orgID");
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@OrgTypeID",OrgTypeID),
                new SqlParameter("@OrgTypeName",OrgTypeName)
            };
            int intResult = DbHelperSQL.ExecuteSql(SQLString, paras);
            if (intResult > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region -- 创建数据表 --
        public void CreateTable(int OrgTypeID)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" if exists(select * from sysobjects where name = '{0}') " +
" drop table {0} " +
" create table {0} " +
" ( " +
"     OrgID int identity(1, 1) primary key, " +
"     OrgTypeID int," +
"     OrgName varchar(100) Unique," +
"     Remark varchar(1000)" +
" ) " +
" if exists(select * from sysobjects where name = '{1}') " +
" drop table {1} " +
" create table {1}" +
" ( " +
"     StudentID int identity(1, 1) primary key," +
"     QQ varchar(40) Unique, " +
"     StudyCount  int, " +
"     StudyTime int, " +
"     FirstStudyTime datetime, " +
"     FirstStudyRecord varchar(200)," +
"     FirstStudyOrgID int, " +
"     LastStudyTime datetime, " +
"     LastStudyRecord varchar(200), " +
"     LastStudyOrgID int, " +
"     Remark varchar(1000) " +
" ) " +
" if exists(select * from sysobjects where name = '{2}') " +
" drop table {2} " +
" create table {2} " +
" ( " +
"     DetailID int identity(1, 1) primary key, " +
"     EnterBatchID int,  " +
"     OrgEnterBacthID int, " +
"     QQ varchar(40), " +
"     OrgID int, " +
"     EnterTime datetime,  " +
"     StudyTime int,  " +
"     StudyRecord varchar(200), " +
"     StartTime datetime, " +
"     AwayTime datetime,  " +
"     Remark varchar(1000) " +
" )", OrginazationTableName, StudentMessageTableName, StudentDetailTableName);

            DbHelperSQL.ExecuteQuery(SQLString);
        }
        #endregion

        #region -- 查询机构类型 --
        public DataSet SelectOrgTypeTable()
        {
            string SQLString = string.Format(
" select * from OrgTypeTable");
            DataSet dtResult = DbHelperSQL.Query(SQLString);
            return dtResult;
        }

        public DataSet SelectOrgTypeTable(string OrgTypeName)
        {
            string SQLString = string.Format(
" select * from OrgTypeTable where OrgTypeName = @OrgTypeName");
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@OrgTypeName",OrgTypeName)
            };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion


        #region -- 添加机构信息 --
        public DataSet InsertOrgMessage(int OrgTypeID, string OrgName, string Remark)
        {
            //Orginazation_1
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string SQLString = string.Format(
 " insert into {0} (OrgTypeID,OrgName,Remark) values (@OrgTypeID,@OrgName, @Remark) " +
 " select @@identity ", OrginazationTableName);
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@OrgTypeID",OrgTypeID),
                new SqlParameter("@OrgName",OrgName),
                new SqlParameter("@Remark",Remark)
           };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion

        #region -- 删除机构信息 --
        public bool DeleteOrgMessage(int OrgTypeID, int orgID)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string SQLString = string.Format(
"delete from {0} where OrgID = @orgID", OrginazationTableName);
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@orgID",orgID)
            };
            int intResult = DbHelperSQL.ExecuteSql(SQLString, paras);
            if (intResult > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region -- 修改机构信息 --
        public bool UpDateOrgMessage(int OrgTypeID, int OrgID, string OrgName, string Remark)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string SQLString = string.Format(
"update {0} set OrgName = @OrgName, Remark = @Remark where OrgID = @OrgID"
, OrginazationTableName);
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@OrgID",OrgID),
                new SqlParameter("@OrgName",OrgName),
                new SqlParameter("@Remark",Remark)
            };
            int intResult = DbHelperSQL.ExecuteSql(SQLString, paras);
            if (intResult > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region -- 查询机构信息 --
        public DataSet SelectOrgMessageByType(int OrgTypeID)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string SQLString = string.Format(
" select a.OrgTypeID,b.OrgTypeName,a.OrgID,a.OrgName,a.Remark from {0} a " +
" left join OrgTypeTable b on a.OrgTypeID = b.OrgTypeID ", OrginazationTableName);
            DataSet dtResult = DbHelperSQL.Query(SQLString);
            return dtResult;
        }
        #endregion


        #region -- 查询机构简短汇总数据 --
        public DataSet SelectOrgDataHeard(int OrgTypeID, int OrgID)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(@"
select EnterBatchID,OrgEnterBacthID,OrgName,OrgID,OrgTypeID,EnterTime,sum(StudentCount) as StudentCount from (
 select b.EnterBatchID,b.OrgEnterBacthID, a.OrgName,a.OrgID,a.OrgTypeID, b.EnterTime,count(1) as StudentCount from {0} a 
 left join {1} b on a.OrgID = b.OrgID 
 where b.OrgID = @OrgID
 group by b.EnterBatchID, b.OrgEnterBacthID, a.OrgName, a.OrgID, a.OrgTypeID, b.EnterTime 
 ) a
 group by EnterBatchID,OrgEnterBacthID,OrgName,OrgID,OrgTypeID,EnterTime
 order by OrgEnterBacthID desc  ",
OrginazationTableName, StudentDetailTableName);

            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@orgID",OrgID)
           };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }

        #endregion

        #region -- 查询机构批次详细数据 --
        public DataSet SelectOrgDataDetail(int OrgTypeID, int OrgID, int EnterBatchID)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" select a.QQ, b.OrgName, a.StudyTime, a.StudyRecord, a.StartTime, a.AwayTime, a.Remark  " +
" from {1} a left  join {0} b on a.OrgID = b.OrgID " +
" where a.orgID = @orgID and a.EnterBatchID = @EnterBatchID" +
" order by a.StartTime desc",
 OrginazationTableName, StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@orgID",OrgID),
                new SqlParameter("@EnterBatchID",EnterBatchID)
           };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion


        #region -- 监控数据插入相关 --

        #region -- 获取总最大批次 --
        public int SelectMaxEnterBatchID(int OrgTypeID)
        {
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
"select coalesce(max(EnterBatchID),0) from {0}", StudentDetailTableName);
            DataSet dsResult = DbHelperSQL.Query(SQLString);
            string count = dsResult.Tables[0].Rows[0][0].ToString();
            return int.Parse(count);
        }
        #endregion

        #region -- 获取机构最大批次 --
        public int SelectMaxEnterBatchID(int OrgTypeID, int OrgID)
        {
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
"select coalesce(max(OrgEnterBacthID),0) from {0} where OrgID = @OrgID", StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@orgID",OrgID)
            };
            DataSet dsResult = DbHelperSQL.Query(SQLString, paras);
            string count = dsResult.Tables[0].Rows[0][0].ToString();
            return int.Parse(count);
        }
        #endregion

        #region -- 获取总最大批次向详情库中插入抓取到的学生信息,datatable中的表名应该为插入表名 --
        public void InsertStudentDetailMore(DataTable dataTable)
        {
            DbHelperSQL.InsertMore(dataTable, 1000);
        }
        #endregion

        #region -- 过滤出此批次在总表中不存在的数据 --
        public DataSet SelectStudentMessageNotExist(int OrgTypeID, int EnterBatchID)
        {
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" select " +
" a.QQ, " +
" 1 as StudyCount, " +
" a.StudyTime," +
" a.StartTime as FirstStudyTime," +
" a.StudyRecord as FirstStudyRecord," +
" a.OrgID as FirstStudyOrgID," +
" a.Remark " +
" from {0} a left join {1} b on a.QQ = b.QQ where b.QQ is null and a.EnterBatchID = @EnterBatchID",
StudentDetailTableName, StudentMessageTableName);

            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@EnterBatchID",EnterBatchID)
            };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion

        #region -- 过滤出此批次在总表中已存在的数据 --
        public DataSet SelectStudentMessageExist(int OrgTypeID, int EnterBatchID)
        {
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" select a.QQ,a.OrgID,a.StudyTime,a.StudyRecord,a.StartTime,a.AwayTime, a.Remark " +
" from {0} a left join {1} b on a.QQ = b.QQ where b.QQ is not null and a.EnterBatchID = @EnterBatchID" +
" group by a.QQ,a.OrgID,a.StudyTime,a.StudyRecord,a.StartTime,a.AwayTime, a.Remark ", StudentDetailTableName, StudentMessageTableName);

            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@EnterBatchID",EnterBatchID)
            };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion

        #region -- 向总表中插入不存在的数据 --
        public void InsertStudentMessageNotExist(DataTable dataTable)
        {
            //向学生信息总库中插入dataTable中不存在的数据
            DbHelperSQL.InsertMore(dataTable, 1000);
        }
        #endregion

        #region -- 通过批次更新总表中的数据 --
        public int UpdateStudentMessageExist(int OrgTypeID, int EnterBatchID)
        {
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" update a set " +
" a.StudyCount = a.StudyCount + 1 ," +
" a.StudyTime = a.StudyTime + b.StudyTime," +
" a.LastStudyTime = b.StartTime," +
" a.LastStudyRecord = b.StudyRecord," +
" a.LastStudyOrgID = b.OrgID" +
" from {0} a," +
" (select QQ, OrgID, StudyTime, StudyRecord, StartTime from {1}" +
" where EnterBatchID = @EnterBatchID) b" +
" where a.QQ = b.QQ", StudentMessageTableName, StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@EnterBatchID",EnterBatchID)
            };
            int intResult = DbHelperSQL.ExecuteSql(SQLString, paras);
            return intResult;
        }

        public int UpdateStudentMessageExist(int OrgTypeID)//最大批次
        {
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string SQLString = string.Format(
" update a set " +
" a.StudyCount = a.StudyCount + 1 ," +
" a.StudyTime = a.StudyTime + b.StudyTime," +
" a.LastStudyTime = b.StartTime," +
" a.LastStudyRecord = b.StudyRecord," +
" a.LastStudyOrgID = b.OrgID" +
" from {0} a," +
" (select QQ, OrgID, StudyTime, StudyRecord, StartTime from {1}" +
" where EnterBatchID = (select max(EnterBatchID) from {1})) b" +
" where a.QQ = b.QQ",
StudentMessageTableName, StudentDetailTableName);
            int intResult = DbHelperSQL.ExecuteSql(SQLString);
            return intResult;
        }
        #endregion

        #endregion


        #region -- 数据分析划段查询 --
        public DataSet AnalyzeSegmengSelect()
        {
            string SQLString = string.Format(
" select top 1 * from AnalyzeSegment");
            DataSet dtResult = DbHelperSQL.Query(SQLString);
            return dtResult;
        }
        #endregion

        #region -- 数据分析划段删除新增 --
        public bool AnalyzeSegmengDeleteThenAdd(
             int AllTimeCount1, int AllTimeCount2, int AllTimeCount3, int AllTimeCount4, int AllTimeCount5,
             int AllStudyCount1, int AllStudyCount2, int AllStudyCount3, int AllStudyCount4, int AllStudyCount5,
             int OrgTimeCount1, int OrgTimeCount2, int OrgTimeCount3, int OrgTimeCount4, int OrgTimeCount5,
             int OrgStudyCount1, int OrgStudyCount2, int OrgStudyCount3, int OrgStudyCount4, int OrgStudyCount5,
             int OrgDayTimeCount1, int OrgDayTimeCount2, int OrgDayTimeCount3, int OrgDayTimeCount4, int OrgDayTimeCount5,
             int OrgDayStudyCount1, int OrgDayStudyCount2, int OrgDayStudyCount3, int OrgDayStudyCount4, int OrgDayStudyCount5)
        {
            string SQLString = string.Format(
 " delete from AnalyzeSegment " +
 " insert into AnalyzeSegment " +
 " (" +
 " AllTimeCount1, AllTimeCount2, AllTimeCount3, AllTimeCount4, AllTimeCount5," +
 " AllStudyCount1, AllStudyCount2, AllStudyCount3, AllStudyCount4, AllStudyCount5," +
 " OrgTimeCount1, OrgTimeCount2, OrgTimeCount3, OrgTimeCount4, OrgTimeCount5," +
 " OrgStudyCount1, OrgStudyCount2, OrgStudyCount3, OrgStudyCount4, OrgStudyCount5," +
 " OrgDayTimeCount1, OrgDayTimeCount2, OrgDayTimeCount3, OrgDayTimeCount4, OrgDayTimeCount5," +
 " OrgDayStudyCount1, OrgDayStudyCount2, OrgDayStudyCount3, OrgDayStudyCount4, OrgDayStudyCount5" +
 " )" +
 " values" +
 " (" +
 " @AllTimeCount1, @AllTimeCount2, @AllTimeCount3, @AllTimeCount4, @AllTimeCount5," +
 " @AllStudyCount1, @AllStudyCount2, @AllStudyCount3, @AllStudyCount4, @AllStudyCount5," +
 " @OrgTimeCount1, @OrgTimeCount2, @OrgTimeCount3, @OrgTimeCount4, @OrgTimeCount5," +
 " @OrgStudyCount1, @OrgStudyCount2, @OrgStudyCount3, @OrgStudyCount4, @OrgStudyCount5," +
 " @OrgDayTimeCount1, @OrgDayTimeCount2, @OrgDayTimeCount3, @OrgDayTimeCount4, @OrgDayTimeCount5," +
 " @OrgDayStudyCount1, @OrgDayStudyCount2, @OrgDayStudyCount3, @OrgDayStudyCount4, @OrgDayStudyCount5" +
 " )"
                );
            SqlParameter[] paras = new SqlParameter[]
          {
                new SqlParameter("@AllTimeCount1",AllTimeCount1),
                new SqlParameter("@AllTimeCount2",AllTimeCount2),
                new SqlParameter("@AllTimeCount3",AllTimeCount3),
                new SqlParameter("@AllTimeCount4",AllTimeCount4),
                new SqlParameter("@AllTimeCount5",AllTimeCount5),
                new SqlParameter("@AllStudyCount1",AllStudyCount1),
                new SqlParameter("@AllStudyCount2",AllStudyCount2),
                new SqlParameter("@AllStudyCount3",AllStudyCount3),
                new SqlParameter("@AllStudyCount4",AllStudyCount4),
                new SqlParameter("@AllStudyCount5",AllStudyCount5),
                new SqlParameter("@OrgTimeCount1",OrgTimeCount1),
                new SqlParameter("@OrgTimeCount2",OrgTimeCount2),
                new SqlParameter("@OrgTimeCount3",OrgTimeCount3),
                new SqlParameter("@OrgTimeCount4",OrgTimeCount4),
                new SqlParameter("@OrgTimeCount5",OrgTimeCount5),
                new SqlParameter("@OrgStudyCount1",OrgStudyCount1),
                new SqlParameter("@OrgStudyCount2",OrgStudyCount2),
                new SqlParameter("@OrgStudyCount3",OrgStudyCount3),
                new SqlParameter("@OrgStudyCount4",OrgStudyCount4),
                new SqlParameter("@OrgStudyCount5",OrgStudyCount5),
                new SqlParameter("@OrgDayTimeCount1",OrgDayTimeCount1),
                new SqlParameter("@OrgDayTimeCount2",OrgDayTimeCount2),
                new SqlParameter("@OrgDayTimeCount3",OrgDayTimeCount3),
                new SqlParameter("@OrgDayTimeCount4",OrgDayTimeCount4),
                new SqlParameter("@OrgDayTimeCount5",OrgDayTimeCount5),
                new SqlParameter("@OrgDayStudyCount1",OrgDayStudyCount1),
                new SqlParameter("@OrgDayStudyCount2",OrgDayStudyCount2),
                new SqlParameter("@OrgDayStudyCount3",OrgDayStudyCount3),
                new SqlParameter("@OrgDayStudyCount4",OrgDayStudyCount4),
                new SqlParameter("@OrgDayStudyCount5",OrgDayStudyCount5)
          };
            int dtResult = DbHelperSQL.ExecuteSql(SQLString, paras);
            if (dtResult > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region -- 机构数据分析-- 机构名-机构批次-总人数--
        public DataSet AnalyzeSelectOrgNameBatchCount(int OrgTypeID, string StartTime, string EndTime)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
 " select a.OrgID, b.OrgName, a.OrgEnterBacthID, a.EnterTime, count(1) as StudentCount" +
 " from {1} a left" +
 " join {0} b on a.OrgID = b.OrgID" +
 " where a.EnterTime between @StartTime and @EndTime" +
 " group by a.OrgID, b.OrgName, a.OrgEnterBacthID, a.EnterTime" +
 " order by a.OrgEnterBacthID asc  ",
 OrginazationTableName, StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@StartTime",StartTime),
                new SqlParameter("@EndTime",EndTime)
           };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }

        public DataSet AnalyzeSelectOrgNameBatchCount(int OrgTypeID, int OrgID, string StartTime, string EndTime)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
 " select a.OrgID, b.OrgName, a.OrgEnterBacthID, a.EnterTime, count(1) as StudentCount" +
 " from {1} a left" +
 " join {0} b on a.OrgID = b.OrgID" +
 " where a.EnterTime between @StartTime and @EndTime and a.OrgID = @OrgID" +
 " group by a.OrgID, b.OrgName, a.OrgEnterBacthID, a.EnterTime" +
 " order by a.OrgEnterBacthID asc  ",
 OrginazationTableName, StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@OrgID",OrgID),
                new SqlParameter("@StartTime",StartTime),
                new SqlParameter("@EndTime",EndTime)
           };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion

        #region -- 机构数据分析-- 机构名-录入日期-总人数--
        public DataSet AnalyzeSelectOrgNameDateCount(int OrgTypeID, string StartTime, string EndTime)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
 " select a.OrgID, b.OrgName, a.EnterTime, count(1) as StudentCount" +
 " from {1} a left" +
 " join {0} b on a.OrgID = b.OrgID" +
 " where a.EnterTime between @StartTime and @EndTime" +
 " group by a.OrgID, b.OrgName, a.EnterTime" +
 " order by a.EnterTime asc  ",
 OrginazationTableName, StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@StartTime",StartTime),
                new SqlParameter("@EndTime",EndTime)
           };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }

        public DataSet AnalyzeSelectOrgNameDateCount(int OrgTypeID, int OrgID, string StartTime, string EndTime)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
 " select a.OrgID, b.OrgName, a.EnterTime, count(1) as StudentCount" +
 " from {1} a left" +
 " join {0} b on a.OrgID = b.OrgID" +
 " where a.EnterTime between @StartTime and @EndTime and a.OrgID = @OrgID" +
 " group by a.OrgID, b.OrgName, a.EnterTime" +
 " order by a.EnterTime asc  ",
 OrginazationTableName, StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@OrgID",OrgID),
                new SqlParameter("@StartTime",StartTime),
                new SqlParameter("@EndTime",EndTime)
           };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion



        #region -- 机构数据分析-- 监控库总人数 --
        public DataSet AnalyzeAllStudentCount(int OrgTypeID)
        {
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string SQLString = string.Format(
 " select count(distinct(qq)) from {0}",StudentMessageTableName);
            DataSet dtResult = DbHelperSQL.Query(SQLString);
            return dtResult;
        }
        #endregion

        #region -- 机构数据分析-- 机构总人数 --
        public DataSet AnalyzeOrgStudentCount(int OrgTypeID, int OrgID)
        {
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
 " select count(distinct(qq)) from {0} where OrgID = @OrgID",StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@OrgID",OrgID)
           };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion

        #region -- 机构数据分析-- 机构学员听课次数和时长情况 --
        public DataSet AnalyzeOrgStudentStudyAndTimeCount(int OrgTypeID, int OrgID)
        {
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
 " select distinct(qq),  count(1) as AllStudyCount, sum(StudyTime) as AllStudyTime from {0} "+
 " where OrgID = @OrgID group by qq order by AllStudyCount desc", StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@OrgID",OrgID)
           };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion

        #region -- 机构数据分析-- 机构本天总人数 --
        public DataSet AnalyzeOrgStudentDayCount(int OrgTypeID, int OrgID, DateTime ThisDay)
        {
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
 " select count(distinct(qq)) from {0} where OrgID = @OrgID and EnterTime = @ThisDay", StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
           {
               new SqlParameter("@OrgID",OrgID),
                new SqlParameter("@ThisDay",ThisDay)
           };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion

        #region -- 机构数据分析-- 本天听过该机构课的学员听课次数和时长情况 --
        public DataSet AnalyzeOrgStudentDayStudyAndTimeCount(int OrgTypeID, int OrgID, DateTime ThisDay)
        {
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
 " select distinct(qq),  count(1) as AllStudyCount, sum(StudyTime) as AllStudyTime from {0} " +
 " where OrgID = @OrgID and EnterTime = @ThisDay group by qq order by AllStudyCount desc", StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@OrgID",OrgID),
                new SqlParameter("@ThisDay",ThisDay)
           };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion


        #region -- 本类型总的学员信息 --
        public DataSet AnalyzeSelectOrgTypeData(int OrgTypeID)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" select a.QQ, a.StudyCount, a.StudyTime, "+
" a.FirstStudyTime, b.OrgName as FirstStudyOrgName, a.FirstStudyRecord," +
" a.LastStudyTime, c.OrgName as LastStudyOrgName, a.LastStudyRecord," +
" a.Remark  from {1} a" +
" left  join {0} b on a.FirstStudyOrgID = b.OrgID " +
" left  join {0} c on a.LastStudyOrgID = c.OrgID " +
" where 1>0 " +
" order by a.LastStudyRecord desc",
 OrginazationTableName, StudentMessageTableName, StudentDetailTableName);

            DataSet dtResult = DbHelperSQL.Query(SQLString);
            return dtResult;
        }
        #endregion

        #region -- 听过该机构课的学员信息 --
        public DataSet AnalyzeSelectOrgData(int OrgTypeID, int OrgID)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" select a.QQ, a.StudyCount, a.StudyTime, " +
" a.FirstStudyTime, b.OrgName as FirstStudyOrgName, a.FirstStudyRecord," +
" a.LastStudyTime, c.OrgName as LastStudyOrgName, a.LastStudyRecord," +
" a.Remark  from {1} a" +
" left  join {0} b on a.FirstStudyOrgID = b.OrgID " +
" left  join {0} c on a.LastStudyOrgID = c.OrgID " +
" where a.QQ in " +
" (select distinct(QQ) from {2} where OrgID = @OrgID)" +
" order by a.LastStudyRecord desc",
 OrginazationTableName, StudentMessageTableName, StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@OrgID",OrgID)
           };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion

        #region -- 未听过该机构课的学员信息 --
        public DataSet AnalyzeSelectOrgDataNot(int OrgTypeID, int OrgID)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" select a.QQ, a.StudyCount, a.StudyTime, " +
" a.FirstStudyTime, b.OrgName as FirstStudyOrgName, a.FirstStudyRecord," +
" a.LastStudyTime, c.OrgName as LastStudyOrgName, a.LastStudyRecord," +
" a.Remark  from {1} a" +
" left  join {0} b on a.FirstStudyOrgID = b.OrgID " +
" left  join {0} c on a.LastStudyOrgID = c.OrgID " +
" where a.QQ in " +
" (select distinct(QQ) from {2} where OrgID != @OrgID)" +
" order by a.LastStudyRecord desc",
 OrginazationTableName, StudentMessageTableName, StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@OrgID",OrgID)
           };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion

        #region -- 听过该机构课的学员信息，根据在本机构的学习总时长划分 --
        public DataSet AnalyzeSelectOrgDataByTime(int OrgTypeID, int OrgID, int IntStartTime, int IntEndTime)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" select a.QQ, a.StudyCount, a.StudyTime, " +
" a.FirstStudyTime, b.OrgName as FirstStudyOrgName, a.FirstStudyRecord," +
" a.LastStudyTime, c.OrgName as LastStudyOrgName, a.LastStudyRecord," +
" a.Remark  from {1} a" +
" left  join {0} b on a.FirstStudyOrgID = b.OrgID " +
" left  join {0} c on a.LastStudyOrgID = c.OrgID " +
" where a.QQ in " +
" ("+
    " select distinct(QQ) from "+
    " (select distinct(QQ), coalesce(sum(StudyTime),0) as StudyTime from {2} where OrgID = @OrgID group by qq)" +
    " where StudyTime >@IntStartTime and StudyTime <= @IntEndTime" +
" )" +
" order by a.LastStudyRecord desc",
 OrginazationTableName, StudentMessageTableName, StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@OrgID",OrgID),
                new SqlParameter("@IntStartTime",IntStartTime),
                new SqlParameter("@IntEndTime",IntEndTime)
           };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion

        #region -- 听过该机构课的学员信息，根据在本机构的学习总次数划分 --
        public DataSet AnalyzeSelectOrgDataByCount(int OrgTypeID, int OrgID, int IntStartCount, int IntEndCount)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" select a.QQ, a.StudyCount, a.StudyTime, " +
" a.FirstStudyTime, b.OrgName as FirstStudyOrgName, a.FirstStudyRecord," +
" a.LastStudyTime, c.OrgName as LastStudyOrgName, a.LastStudyRecord," +
" a.Remark  from {1} a" +
" left  join {0} b on a.FirstStudyOrgID = b.OrgID " +
" left  join {0} c on a.LastStudyOrgID = c.OrgID " +
" where a.QQ in " +
" (" +
    " select distinct(QQ) from " +
    " (select distinct(QQ), coalesce(count(1),0) as StudyCount from {2} where OrgID = @OrgID group by qq)" +
    " where StudyCount >@IntStartCount and StudyCount <= @IntEndCount" +
" )" +
" order by a.LastStudyRecord desc",
 OrginazationTableName, StudentMessageTableName, StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@OrgID",OrgID),
                new SqlParameter("@IntStartCount",IntStartCount),
                new SqlParameter("@IntEndCount",IntEndCount)
           };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion


        #region -- 本天该类型的所有学员信息 --
        public DataSet AnalyzeSelectOrgTypeDataByDay(int OrgTypeID, string EnterTime)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" select a.QQ, a.StudyCount, a.StudyTime, " +
" a.FirstStudyTime, b.OrgName as FirstStudyOrgName, a.FirstStudyRecord," +
" a.LastStudyTime, c.OrgName as LastStudyOrgName, a.LastStudyRecord," +
" a.Remark  from {1} a" +
" left  join {0} b on a.FirstStudyOrgID = b.OrgID " +
" left  join {0} c on a.LastStudyOrgID = c.OrgID " +
" where a.QQ in " +
" (" +
    " select distinct(QQ) from {2} where EnterTime = @EnterTime" +
" )" +
" order by a.LastStudyRecord desc",
 OrginazationTableName, StudentMessageTableName, StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
          {
                new SqlParameter("@EnterTime",EnterTime)
          };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion

        #region -- 本天听过该机构课的学员信息 --
        public DataSet AnalyzeSelectOrgDataByDay(int OrgTypeID, int OrgID, string EnterTime)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" select a.QQ, a.StudyCount, a.StudyTime, " +
" a.FirstStudyTime, b.OrgName as FirstStudyOrgName, a.FirstStudyRecord," +
" a.LastStudyTime, c.OrgName as LastStudyOrgName, a.LastStudyRecord," +
" a.Remark  from {1} a" +
" left  join {0} b on a.FirstStudyOrgID = b.OrgID " +
" left  join {0} c on a.LastStudyOrgID = c.OrgID " +
" where a.QQ in " +
" (" +
    " select distinct(QQ) from {2} where EnterTime = @EnterTime and OrgID = @OrgID" +
" )" +
" order by a.LastStudyRecord desc",
 OrginazationTableName, StudentMessageTableName, StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
          {
              new SqlParameter("@OrgID",OrgID),
              new SqlParameter("@EnterTime",EnterTime)
          };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion

        #region -- 本天未听过该机构课的学员信息 --
        public DataSet AnalyzeSelectOrgDataByDayNot(int OrgTypeID, int OrgID, string EnterTime)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" select a.QQ, a.StudyCount, a.StudyTime, " +
" a.FirstStudyTime, b.OrgName as FirstStudyOrgName, a.FirstStudyRecord," +
" a.LastStudyTime, c.OrgName as LastStudyOrgName, a.LastStudyRecord," +
" a.Remark  from {1} a" +
" left  join {0} b on a.FirstStudyOrgID = b.OrgID " +
" left  join {0} c on a.LastStudyOrgID = c.OrgID " +
" where a.QQ in " +
" (" +
    " select distinct(QQ) from {2} where EnterTime = @EnterTime and OrgID != @OrgID" +
" )" +
" order by a.LastStudyRecord desc",
 OrginazationTableName, StudentMessageTableName, StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
          {
              new SqlParameter("@OrgID",OrgID),
              new SqlParameter("@EnterTime",EnterTime)
          };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion

        #region -- 本天听过该机构课的学员信息，根据在本机构的学习总时长划分 --
        public DataSet AnalyzeSelectOrgDataByTime(int OrgTypeID, int OrgID, string EnterTime, int IntStartTime, int IntEndTime)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" select a.QQ, a.StudyCount, a.StudyTime, " +
" a.FirstStudyTime, b.OrgName as FirstStudyOrgName, a.FirstStudyRecord," +
" a.LastStudyTime, c.OrgName as LastStudyOrgName, a.LastStudyRecord," +
" a.Remark  from {1} a" +
" left  join {0} b on a.FirstStudyOrgID = b.OrgID " +
" left  join {0} c on a.LastStudyOrgID = c.OrgID " +
" where a.QQ in " +
" (" +
    " select distinct(QQ) from " +
    " (select distinct(QQ), coalesce(sum(StudyTime),0) as StudyTime from {2} where EnterTime = @EnterTime and OrgID = @OrgID and group by qq)" +
    " where StudyTime >@IntStartTime and StudyTime <= @IntEndTime" +
" )" +
" order by a.LastStudyRecord desc",
 OrginazationTableName, StudentMessageTableName, StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
          {
              new SqlParameter("@OrgID",OrgID),
              new SqlParameter("@EnterTime",EnterTime),
              new SqlParameter("@IntStartTime",IntStartTime),
              new SqlParameter("@IntEndTime",IntEndTime)
          };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion

        #region -- 本天听过该机构课的学员信息，根据在本机构的学习总次数划分 --
        public DataSet AnalyzeSelectOrgDataByCount(int OrgTypeID, int OrgID, string EnterTime, int IntStartCount, int IntEndCount)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" select a.QQ, a.StudyCount, a.StudyTime, " +
" a.FirstStudyTime, b.OrgName as FirstStudyOrgName, a.FirstStudyRecord," +
" a.LastStudyTime, c.OrgName as LastStudyOrgName, a.LastStudyRecord," +
" a.Remark  from {1} a" +
" left  join {0} b on a.FirstStudyOrgID = b.OrgID " +
" left  join {0} c on a.LastStudyOrgID = c.OrgID " +
" where a.QQ in " +
" (" +
    " select distinct(QQ) from " +
    " (select distinct(QQ), coalesce(count(1),0) as StudyCount from {2} where EnterTime = @EnterTime and OrgID = @OrgID and group by qq)" +
    " where StudyCount >@IntStartCount and StudyCount <= @IntEndCount" +
" )" +
" order by a.LastStudyRecord desc",
 OrginazationTableName, StudentMessageTableName, StudentDetailTableName);
            SqlParameter[] paras = new SqlParameter[]
          {
              new SqlParameter("@OrgID",OrgID),
              new SqlParameter("@EnterTime",EnterTime),
              new SqlParameter("@IntStartCount",IntStartCount),
              new SqlParameter("@IntEndCount",IntEndCount)
          };
            DataSet dtResult = DbHelperSQL.Query(SQLString, paras);
            return dtResult;
        }
        #endregion



        #region -- 机构数据查询 -- 
        public DataSet SelectOutDataAll(string OrgTypeID, string MinStudyCount, string MaxStudyCount, string MinStudyTime, string MaxStudyTime, 
            string StartEnterTime, string EndEnterTime, string OrgID)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" select a.QQ, a.StudyCount, a.StudyTime, " +
" a.FirstStudyTime, b.OrgName as FirstStudyOrgName, a.FirstStudyRecord," +
" a.LastStudyTime, c.OrgName as LastStudyOrgName, a.LastStudyRecord," +
" a.Remark  from {1} a" +
" left  join {0} b on a.FirstStudyOrgID = b.OrgID " +
" left  join {0} c on a.LastStudyOrgID = c.OrgID " +
" left  join {2} d on a.QQ = d.QQ  where 1>0",
 OrginazationTableName, StudentMessageTableName, StudentDetailTableName);

            #region -- 过滤条件 --
            if (MinStudyCount != "" && MinStudyCount != null && MaxStudyCount != "" && MaxStudyCount != null)
                SQLString += string.Format(
" and a.StudyCount >{0} and a.StudyCount<= {1}", 
MinStudyCount, MaxStudyCount);
            if (MinStudyTime != "" && MinStudyTime != null && MaxStudyTime != "" && MaxStudyTime != null)
                SQLString += string.Format(
" and a.StudyTime >{0} and a.StudyTime<= {1}",
MinStudyTime, MaxStudyTime);
            if (StartEnterTime != "" && StartEnterTime != null && EndEnterTime != "" && EndEnterTime != null)
                SQLString += string.Format(
" and d.EnterTime >='{0}' and d.EnterTime< '{1}'",
StartEnterTime, EndEnterTime);
            if (OrgID != "" && OrgID != null)
                SQLString += string.Format(
" and d.OrgID ={0}",OrgID);
            #endregion

            SQLString += string.Format(
" group by a.QQ, a.StudyCount, a.StudyTime, " +
" a.FirstStudyTime, b.OrgName, a.FirstStudyRecord," +
" a.LastStudyTime, c.OrgName, a.LastStudyRecord, a.Remark" +
" order by a.LastStudyRecord desc");

            DataSet dtResult = DbHelperSQL.Query(SQLString);
            return dtResult;
        }

        public DataSet SelectOutDataAllCount(string OrgTypeID, string MinStudyCount, string MaxStudyCount, string MinStudyTime, string MaxStudyTime, 
            string StartEnterTime, string EndEnterTime, string OrgID)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" select sum(qqs) from(" +
" select count(distinct(a.QQ)) as qqs from {1} a" +
" left  join {0} b on a.FirstStudyOrgID = b.OrgID " +
" left  join {0} c on a.LastStudyOrgID = c.OrgID " +
" left  join {2} d on a.QQ = d.QQ  where 1>0",
 OrginazationTableName, StudentMessageTableName, StudentDetailTableName);

            #region -- 过滤条件 --
            if (MinStudyCount != "" && MinStudyCount != null && MaxStudyCount != "" && MaxStudyCount != null)
                SQLString += string.Format(
" and a.StudyCount >{0} and StudyCount<= {1}",
MinStudyCount, MaxStudyCount);
            if (MinStudyTime != "" && MinStudyTime != null && MaxStudyTime != "" && MaxStudyTime != null)
                SQLString += string.Format(
" and a.StudyTime >{0} and StudyTime<= {1}",
MinStudyTime, MaxStudyTime);
            if (StartEnterTime != "" && StartEnterTime != null && EndEnterTime != "" && EndEnterTime != null)
                SQLString += string.Format(
" and d.EnterTime >='{0}' and d.EnterTime< '{1}'",
StartEnterTime, EndEnterTime);
            if (OrgID != "" && OrgID != null)
                SQLString += string.Format(
" and d.OrgID ={0}", OrgID);
            #endregion

            SQLString += string.Format(
" group by a.QQ) a");

            DataSet dtResult = DbHelperSQL.Query(SQLString);
            return dtResult;
        }
        #endregion

        #region -- 机构数据查询,分页 -- 
        public DataSet SelectOutDataPage(int pageNum, string OrgTypeID, string MinStudyCount, string MaxStudyCount, string MinStudyTime, string MaxStudyTime, 
            string StartEnterTime, string EndEnterTime, string OrgID)
        {
            string OrginazationTableName = "Orginazation_" + OrgTypeID;
            string StudentMessageTableName = "StudentMessage_" + OrgTypeID;
            string StudentDetailTableName = "StudentDetail_" + OrgTypeID;
            string SQLString = string.Format(
" select a.StudentID , a.QQ, a.StudyCount, a.StudyTime, " +
" a.FirstStudyTime, b.OrgName as FirstStudyOrgName, a.FirstStudyRecord," +
" a.LastStudyTime, c.OrgName as LastStudyOrgName, a.LastStudyRecord," +
" a.Remark  from {1} a" +
" left  join {0} b on a.FirstStudyOrgID = b.OrgID " +
" left  join {0} c on a.LastStudyOrgID = c.OrgID " +
" left  join {2} d on a.QQ = d.QQ  where 1>0" ,
 OrginazationTableName, StudentMessageTableName, StudentDetailTableName);

            #region -- 过滤条件 --
            if (MinStudyCount != "" && MinStudyCount != null && MaxStudyCount != "" && MaxStudyCount != null)
                SQLString += string.Format(
" and a.StudyCount >{0} and a.StudyCount<= {1}",
MinStudyCount, MaxStudyCount);
            if (MinStudyTime != "" && MinStudyTime != null && MaxStudyTime != "" && MaxStudyTime != null)
                SQLString += string.Format(
" and a.StudyTime >{0} and a.StudyTime<= {1}",
MinStudyTime, MaxStudyTime);
            if (StartEnterTime != "" && StartEnterTime != null && EndEnterTime != "" && EndEnterTime != null)
                SQLString += string.Format(
" and d.EnterTime >='{0}' and d.EnterTime< '{1}'",
StartEnterTime, EndEnterTime);
            if (OrgID != "" && OrgID != null)
                SQLString += string.Format(
" and d.OrgID ={0}", OrgID);
            #endregion

            SQLString += string.Format(
" group by a.StudentID, a.QQ, a.StudyCount, a.StudyTime, " +
" a.FirstStudyTime, b.OrgName, a.FirstStudyRecord," +
" a.LastStudyTime, c.OrgName, a.LastStudyRecord, a.Remark" );

            string SQLStringPage = string.Format(
" select * from "+
"  (" +
"   select top 1000 * from" +
"   (" +
"   select top({1}) * from" +
"   (" +
"{0}" +
" )" +
  " a order by StudentID asc) x" +
  " order by StudentID desc" +
  " ) a order by LastStudyTime desc", SQLString, (1000 * pageNum) - 1);

            DataSet dtResult = DbHelperSQL.Query(SQLStringPage);
            return dtResult;
        }
        #endregion
    }
}
