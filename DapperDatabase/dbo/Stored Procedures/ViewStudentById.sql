create proc ViewStudentById
@Id int
as
begin
	select * from StudentInfo
	where Id=@Id
end