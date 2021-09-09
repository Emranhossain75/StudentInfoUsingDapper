create proc StudentAddEdit
@Id int,
@Name varchar(50),
@Gender varchar(50),
@Salary varchar(50),
@Age int
as
begin
	if @Id = 0
	insert into StudentInfo values 
	(@Name,@Gender,@Salary,@Age)

	else
	update StudentInfo set Name=@Name,
	Gender= @Gender,Salary=@Salary,Age=@Age 
	where Id=@Id
end