CREATE DATABASE testDB
use testDB
CREATE TABLE Role
(
	[id] [int] IDENTITY(1,1) PRIMARY KEY,
	[roleName] [nvarchar](200) NOT NULL
	UNIQUE(roleName)
)


CREATE TABLE Staff
(
	ID [int] IDENTITY(1,1) PRIMARY KEY,
	Name nVarChar(30) not null,
	[RoleId] [int] REFERENCES [Role](id)
	UNIQUE(Name)
)

INSERT INTO [Role](RoleName)
VALUES('Admin')

INSERT INTO [Role](RoleName)
VALUES('User')

INSERT INTO [Staff]([Name], RoleId)
VALUES('Ivan', 3)


--use testDB
--DROP DATABASE testDB



select * from [Role]
select * from [Staff]







