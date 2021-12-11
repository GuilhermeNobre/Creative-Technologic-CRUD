create database registration -- Cria a database para registros 
use registration -- Usa a database para criação de tabelas e querrys

-- Caminho padrão da path no C#
-- path = "Data Source=DESKTOP-DTKBJB1;Initial Catalog=registration;Integrated Security=True";
-- Lembrando que Data Source muda de computador para computador, sendo necessário alterar no código todo
-- ou realizando a criação de uma váriavel pública que passe o valor, no caso não foi necessário utilizar. 


-- Tabela de Registros Funcionários
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
insert into Employee values('Guilherme','Dantas', 'Coder', 'Admin@gmail.com', '1231','Macho', 'Brasil');

-- Tabela de Faturamento
create table Fature
(
month_id int primary key identity (1,1),
name_month varchar(50),
value_number varchar(50)
);

select * from Fature;
insert into Fature values('January', 35670);
insert into Fature values('Febuary', 41411);

-- Tabela de produtos
create table products
(
product_Id int primary key identity (1,1),
name_product varchar(50),
type_product varchar(50)
);

select * from products;
insert into products values('Casa Smart', 'A');

-- Tabela de Reports e advertências 
create table reports
(
report_id int primary key identity (1,1),
name_report varchar(50),
obs_report varchar(50)
);

select * from reports;
insert into reports values('João Da Silva', 'Dormindo no expediente');

truncate table Employee
truncate table Fature
truncate table products
truncate table reports;

-- Cria a tabela de login de usuários 
create table LoginUsers
(
U_ID int primary key identity (1,1),
U_Name varchar(50),
U_Pass varchar(50)
);

select * from LoginUsers;

