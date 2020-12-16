CREATE DATABASE CompanyDb;
use CompanyDb;
CREATE TABLE Positions(
Id int Primary Key identity,
Title varchar(50)
);

CREATE TABLE Companies(
Id int Primary Key identity,
Title varchar(50) NOT NULL,
OrganisationalForm varchar(50) NOT NULL
);

CREATE TABLE Employees(
Id int Primary Key identity,
FirstName varchar(50) NOT NULL,
LastName varchar(50) NOT NULL,
Patronymic varchar(50) DEFAULT '',
EmploymentDate DateTime,
PositionId INT NOT NULL REFERENCES Positions(Id),
CompanyId INT NOT NULL REFERENCES Companies(Id)
);
Insert into Positions(Title)
Values ('Developer'),('QA'),('BA'),('Manager');
 