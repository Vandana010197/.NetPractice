create database CategoryAdio
use CategoryAdio

create table Product(Id int primary key identity,
ProductName varchar(max))

Create Proc Products
@action varchar(max),
@Id int =0,
@ProductName varchar(max)=null
as
begin
if(@action='CREATE')
begin
insert into Product(ProductName)values
(@ProductName)
select 1 as result
end

else if(@action='Select')
begin
Select*from Product
end

else if(@action='DELETE')
BEGIN
delete  from product Where Id=@Id
select 1 as result
end

else if(@action='UPDATE')
BEGIN
update Product set ProductName=@ProductName Where Id=@Id
end
end

exec Products 'Select'
exec Products 'CREATE',0,'Cheese'
exec Products 'UPDATE',2,'Corn'


Create table Customer
(Id int primary key identity,
CustomerName varchar(max),
Email varchar(max),
Contact varchar(max),
ProductId int foreign key references Product(Id))

Alter PROC CUSTOMERS
@action varchar(30),
@Id int =0,
@CustomerName varchar(max)=null,
@Email varchar(max)=null,
@contact varchar(max)=null,
@ProductId int=0
as
begin
if(@action='CREATE')
begin
INSERT into Customer(CustomerName,Email,contact,ProductId)values
(@CustomerName,@Email,@contact,@ProductId)
select 1 as result
end
else if(@action='SELECT')
begin
select*from Customer
end
else if(@action='SELECT JOIN')
BEGIN
select c.Id,c.CustomerName,c.Email,c.contact,c.ProductId from Customer c
--full outer join
inner Join
Product P
on c.Id=P.Id
end

else if(@action='DELETE')
begin
delete from Customer Where Id=@id
select 1 as result
end
else if(@action='Update')
begin
update Customer set CustomerName=@CustomerName,
Email=@Email,
Contact=@contact,
ProductId=@ProductName Where Id=@id
select 1 as result
end
end

exec Customers 'Create',0,'Priya','priya@gmail.com','3455123456','2'
exec Customers 'Update',3,'Siya','siya@gmail.com','234567899','3'

EXEC Customers 'SELECT JOIN'

select*from Customer
select*from Product























