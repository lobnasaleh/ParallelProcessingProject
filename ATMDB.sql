create database ATM

CREATE TABLE Roles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50)
);
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50),
    [Password] NVARCHAR(255),
    Balance DECIMAL(18, 2) DEFAULT 0.00,
    RoleId INT FOREIGN KEY REFERENCES Roles(Id)
);
CREATE TABLE Transactions (
    Id INT PRIMARY KEY,
    TransactionType NVARCHAR(50),
    Amount DECIMAL(18, 2),
    TransactionDate DATETIME2,
    UserId INT FOREIGN KEY REFERENCES Users(Id)
);

create or alter procedure checkUser 
@id int
as
begin
select * from Users where Id=@id 
end

use ATM

CREATE OR ALTER PROCEDURE getAllTransactions
@id int
as
begin 
select * from Transactions where UserId=@id
end

EXEC getAllTransactions @id = 10005


CREATE OR ALTER PROCEDURE getAllUsers

as
begin 
select * from [Users] 
end

EXEC getAllUsers







create or alter procedure adduser @username nvarchar(50),@password nvarchar(255),@balance decimal (18,2),@role int
as
begin
insert into Users (Username,[Password],Balance,RoleId)
values (@username,@password,@balance,@role)
end
EXEC adduser @username='salma22',@password='1234',@balance=17888,@role=2


create or alter procedure checkDuplicateUsername @username nvarchar(50)
as
begin
select count(*) from [Users] where Username=@username and isDeleted =0
end

EXEC checkDuplicateUsername @username='ahmed21'


create or alter procedure checkDuplicateRoleName
@rolename NVARCHAR(50)
as
begin
select count(*) from [Roles] where [Name]=@rolename 
end


EXEC checkDuplicateRoleName @rolename='xYz'



create or alter procedure addrole @rolename NVARCHAR(50)
as
begin
insert into [Roles] ([Name])
values (@rolename)
end

EXEC addrole @rolename ='XYZ'


create or alter procedure updatePIN @id int, @pin NVARCHAR(255)
as
begin
update [Users] set [Password] =@pin where Id=@id
end


EXEC updatePIN @id=10010, @pin='1478'
USE ATM

Create or alter procedure getBalanceById @id int
as
begin
select [balance] from [Users] where Id=@id
end

exec getBalanceById 10095

Create or alter procedure DeleteUserByUsername @username nvarchar(50)
as
begin
UPDATE Users SET IsDeleted = 1 WHERE Username=@username
end

exec DeleteUserByUsername 'sally23'

ALTER TABLE Users
ADD IsDeleted BIT DEFAULT 0;

create or alter procedure checkUser 
@id int
as
begin
select * from Users where Id=@id and IsDeleted=0
end

exec checkUser 10115


CREATE OR ALTER PROCEDURE getAllUsers

as
begin 
select * from [Users] where isDeleted =0
end

EXEC getAllUsers

SELECT * FROM Transactions T inner join Users U on U.Id=T.UserId  where U.IsDeleted=0

create or alter procedure checkDuplicateUsername @username nvarchar(50)
as
begin
select count(*) from [Users] where Username=@username and isDeleted =0
end
