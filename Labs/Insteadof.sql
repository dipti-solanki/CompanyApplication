Use StudentDb
Go

Create Trigger tr_Student  
on vStudents  
instead of update  
as  
Begin   
declare @StudentId int=(select StudentId from inserted)
Update vStudents set StudentName=(select StudentName from inserted) where StudentId=@StudentId
Update vStudents set Address=(select Address from inserted) where StudentId=@StudentId
Update vStudents set MobileNumber=(select MobileNumber from inserted) where StudentId=@StudentId

 End  


 Update vStudents set 
 StudentName='Dipti',Address='Vadodara',MobileNumber=9662445484 where @StudentId=3

 select * from vStudents
 select * from Students
 select * from StudnetDetails