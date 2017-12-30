insert into KeQQForeignRecord select '2172484081','2017/6/15 21:43:45','2017/6/15 21:44:01',datediff(minute,cometime,leavetime),
'2017直通车爆款实操天猫淘宝运营直播课程-7天蜕变-30天盈利-驿路- 第2节','',''
select top 1 * from KeQQForeignRecord
insert into ForeignCustomerInfo 
select  qq,'','','','','','','','','','','','',sum(studytime),count(qq),'','',''  from keqqforeignrecord  
where qq not in (select qq from ForeignCustomerInfo) group by qq 

update a set a.StudyNumber=b.StudyNumber,a.studytime=b.studytime, a.join_time=b.lastcometime from ForeignCustomerInfo a inner join   
(select qq,count(qq) as StudyNumber,sum(studytime) as studytime, max(cometime) as lastcometime from KeQQForeignRecord  where cometime>='2017-06-15' group by qq )  b 
on a.qq=b.qq

update a set  a.join_time=b.cometime,a.StudyObject=b.subjectname,a.TalkRecord=b.TalkRecord from ForeignCustomerInfo a,KeQQForeignRecord b  
where a.qq=b.qq and b.cometime>='2017-06-15' order by  b.cometime asc

select * from ForeignCustomerInfo where join_time>='2017-06-15'

select count(1) from KeQQForeignRecord where cometime>='2017-06-15' group by qq 

update a set a.StudyObject=b.subjectname from ForeignCustomerInfo a,
(select qq, ) b  
where a.qq=b.qq and b.cometime>'2017-06-15' order by  b.cometime asc

select qq,count(qq) as StudyNumber,sum(studytime) as studytime, max(cometime) as lastcometime from KeQQForeignRecord group by qq




select qq,subjectname from KeQQForeignRecord where cometime is max





