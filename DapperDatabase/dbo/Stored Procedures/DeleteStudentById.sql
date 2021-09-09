create proc DeleteStudentById
@Id int
as
begin
	delete from StudentInfo
	where Id=@Id
end