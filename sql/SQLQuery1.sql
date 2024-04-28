select *
from Account A join Person P on A.AccountId = P.AccountId

select *from GiaoVu
select *from Teacher
select *from TruongBoMon
select *from TruongPhoKhoa
select *from Student
select * 
from Person 

select * from Account

select * from Role

select * From Classroom

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
