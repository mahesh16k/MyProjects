Create procedure Insert_Students
(
@A_Name varchar(50),
@A_RollNumber varchar(25),
@A_Age int,
@A_Email varchar(30),
@A_Mobile bigint,
@A_City varchar(20)
)
AS
BEGIN
INSERT INTO Students (
Name,RollNumber,Age,Email,Mobile,City
)

VALUES
(
@A_Name,@A_RollNumber,@A_Age,@A_Email,@A_Mobile,@A_City
)
END

