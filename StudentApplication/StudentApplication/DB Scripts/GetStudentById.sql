create proc GetStudentById
@Id int
as
select * from Students where @Id = id;
End