using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class GroupInfo
    {
        public string Name { get; set; }//群名
        public string Number { get; set; }//群号
        public string Owner { get; set; }//群主号
        public string Manager { get; set; }//责任人
        public string Grade { get; set; }//群内客户等级
    }


    public class QQGroupMemberInfo
    {
        public string QQ { get; set; }//QQ号
        public string NickName { get; set; }//昵称
        public string GroupNumber { get; set; }//群号
        public string GroupCard { get; set; }//群昵称
        public string GroupGrade { get; set; }//群身份
        public string join_time { get; set; }//加入时间
        public string last_speak_time { get; set; }//最后发言时间
    }

    public class QQFriendInfo
    {
        public string NickName { get; set; }
        public string QQ { get; set; }
        public string SelfQQ { get; set; }
        public string OwnerNickName  { get; set; }//qq主人昵称
	    public string Manager  { get; set; }//责任人
    }

    public class KeQQStudyRecord//学员学习记录
    {
        public string QQ { get; set; }
        public DateTime ComeTime { get; set; }
        public DateTime LeavetTime { get; set; }
        public double StudyTime { get; set; }
        public string SubjectName { get; set; }
        public string TalkRecord { get; set; }//聊天记录
        public string Remark { get; set; }
    }

    public class KeQQPlan//qq课堂统计
    {
        public string SubjectName { get; set; }//课程名称
        public DateTime SubjectBeginTime { get; set; }//开始时间
        public DateTime SubjectEndTime { get; set; }//结束时间
        public string Teacher { get; set; }//教师
        public int MaxCnt { get; set; }//最大人数
        public int AVGCnt { get; set; }//平均人数
        public int BeginCnt { get; set; }//开始人数
        public int EndCnt { get; set; }//结束人数
    }

    public class userinfo //员工
    {
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string UserGrade { get; set; }
    }

    public class CustomerInfo//学员
    {
        public string QQ { get; set; }//QQ号
        public string NickName { get; set; }//昵称
        public string Grade { get; set; }//等级
        public string Manager { get; set; } //责任人
        public string TraceName { get; set; }//跟踪人
        public DateTime TraceTime { get; set; }//跟踪时间
        public string GroupNumber { get; set; }//群号
        public string GroupName { get; set; }//群名称
        public string GroupGrade { get; set; }//群身份
        public string Join_time { get; set; }//加入时间
        public string Last_speak_time { get; set; }//群最后发言时间
        public string FriendQQ { get; set; }//好友QQ号
        public string FriendNickName { get; set; }//好友昵称
        public double StudyTime { get; set; }//学习时长（分钟）
        public double StudyNumber { get; set; }//学习时长（分钟）
        public string StudyObject { get; set; }//学习科目
        public string TalkRecord { get; set; }//课堂聊天记录
        public string Remark { get; set; }//备注
    }

    public class KeQQChatRecord//学员聊天记录
    {
        public string NickName { get; set; }//昵称
        public DateTime TalkTime { get; set; }
        public string TalkRecord { get; set; }//聊天记录
    }
}
