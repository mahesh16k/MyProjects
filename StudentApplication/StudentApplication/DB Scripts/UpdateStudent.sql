
create proc UpdateStudent
(
@A_Id int,
@A_Name varchar(50),
@A_RollNumber varchar(25),
@A_Age int,
@A_Email varchar(30),
@A_Mobile bigint,
@A_City varchar(20)
)
as
Update Students set Name = @A_Name,RollNumber=@A_RollNumber,Age=@A_Age,Email = @A_Email,Mobile = @A_Mobile,City= @A_City where @A_Id = id;
End