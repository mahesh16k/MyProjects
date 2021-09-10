create proc DeleteStudent
@Id int
as
delete Students where @Id = id;
End