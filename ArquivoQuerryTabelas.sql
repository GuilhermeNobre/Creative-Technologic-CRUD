create database registration
use registration


create table Employee
(
Employee_Id int primary key identity (1,1),
Employee_Name varchar(50),
Employee_FName varchar(50),
Employee_Designation varchar(50),
Employee_Email varchar(50),
Emp_ID varchar(50),
Gender varchar(50),
Addrss varchar(50)
)
select * from Employee;
insert into Employee values('Asif','Karen Bux', 'Coder', 'Admin@gmail.com', '1231','Male', 'Brasil');


create table Fature
(
month_id int primary key identity (1,1),
name_month varchar(50),
value_number varchar(50)
);

select * from Fature;
insert into Fature values('January', 35670);
insert into Fature values('Febuary', 41411);





truncate table Employee