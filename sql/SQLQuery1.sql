select *
from Account A join Person P on A.AccountId = P.AccountId

select * from Person 
select *from GiaoVu
select *from Teacher
select *from TruongBoMon
select *from TruongPhoKhoa
select *from Student
select * 
from Person 

select * from Account

select * from RoleAccount

select * from Role

select * From Classroom

select * from TeacherSubject

select R.RoleName,P.FullName,S.SubjectName
From Teacher T join Person P on T.PersonId = P.PersonId
			   join Account A on A.AccountId = P.AccountId
			   join Role R on R.RoleId = A.RoleId
			   join TeacherSubject TS on TS.TeacherId = T.TeacherId
			   join Subject S on S.SubjectId = TS.SubjectId

select *
from Account A join Role R on A.RoleId = R.RoleId

select * from RoleAccount

select * from Subject

select * from Time

select * from Faculty

select * from ClassTime

select * from SubjectClass

--các khoảng giời gian học của 1 lớp
select C.ClassroomName,T.StartTime,T.EndTime
from Classroom C join ClassTime CT on C.ClassRoomId = CT.ClassroomId
				 join Time T on T.TimeId = CT.TimeId

select S.SubjectName,C.ClassroomName,T.StartTime,T.EndTime
from Subject S join SubjectClass SC on S.SubjectId = SC.SubjectId
			   join Classroom C on C.ClassRoomId = SC.ClassroomId
			   join Time T on T.TimeId = SC.TimeId


-- Tạo người dùng
CREATE LOGIN Admin WITH PASSWORD = 'Admin@123', check_expiration = off, check_policy = off;
CREATE LOGIN truongphokhoa WITH PASSWORD = 'Admin@123', check_expiration = off, check_policy = off;

DROP LOGIN Admin;

SELECT * FROM sys.server_principals


--Tạo người dùng cho db
CREATE USER Admin FOR LOGIN Admin
CREATE USER truongphokhoa FOR LOGIN truongphokhoa

DROP USER Admin


-- Tạo các vai trò
CREATE ROLE Admin
CREATE ROLE truongphokhoa
CREATE ROLE truongbomon
CREATE ROLE giaovu

DROP ROLE truongphokhoa;
DROP ROLE truongbomon;
DROP ROLE giaovu

-- Gán quyền truy cập cho các vai trò
GRANT SELECT,INSERT,DELETE,UPDATE ON SUBJECT TO truongphokhoa
GRANT 


select A.AccountId,A.UserName,R.RoleId,R.RoleName
from Account A join RoleAccount RA on A.AccountId = RA.AccountId
               join Role R on R.RoleId = RA.RoleId

select * from RoleAccount

select * From Subject

select S.SubjectId,S.SubjectName,S.credits
From Subject S join TeacherSubject TS on S.SubjectId = TS.SubjectId
			   join Teacher T on T.TeacherId = TS.TeacherId
			   join Person P on P.PersonId = T.TeacherId


select *
from SubjectClass

select *
from Person
where PersonId = 'f94bbf0f-51ee-486f-96d4-dcc196d9246e'

select ClassroomId,SubjectId,TeacherId,TimeId
from SubjectClass


select *
from teacher T JOIN SubjectClass SC on T.teacherId = SC.teacherid

select *
from Teacher T join Person P on T.PersonId = P.PersonId