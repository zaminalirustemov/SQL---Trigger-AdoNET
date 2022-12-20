CREATE DATABASE AcademiesDB_ZR
GO 
USE AcademiesDB_ZR
GO
CREATE TABLE Academies
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(75)
)

CREATE TABLE Groups
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(75),
	AcademyId INT FOREIGN KEY(AcademyId) REFERENCES Academies(Id)
)

CREATE TABLE Students
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(75),
	Surname NVARCHAR(75),
	Age TINYINT,
	Adulthood NVARCHAR(5),
	GroupID INT FOREIGN KEY(GroupID) REFERENCES Groups(Id)
)



CREATE TABLE DeletedStudents
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(75),
	Surname NVARCHAR(75),
	GroupID INT 
)

CREATE TABLE DeletedGroups
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(75),
	AcademyId INT 
)
GO

CREATE VIEW VW_Academies
AS
SELECT *FROM Academies

GO

CREATE VIEW VW_Groups
AS
SELECT *FROM Groups

GO

CREATE VIEW VW_Students
AS
SELECT *FROM Students

GO

CREATE PROCEDURE GroupWithThisName @value NVARCHAR(75)
AS
SELECT *FROM Groups
WHERE Name=@value

EXEC GroupWithThisName @value='BB-201'
GO

CREATE PROCEDURE OlderThanThisAge @value TINYINT
AS
SELECT *FROM Students
WHERE Age>@value
Go

EXEC OlderThanThisAge @value=17
GO

CREATE PROCEDURE YoungerThanThisAge @value TINYINT
AS
SELECT *FROM Students
WHERE Age<@value
Go

EXEC YoungerThanThisAge @value=17
Go

CREATE TRIGGER TRGR_SaveDeletedStudentDatas
ON Students
AFTER DELETE   
AS
INSERT INTO DeletedStudents (Name,Surname,GroupID)
SELECT Name,Surname,GroupID FROM deleted

DELETE FROM Students WHERE Id=4
GO

CREATE TRIGGER TRGR_SaveDeletedGroupDatas
ON Groups
AFTER DELETE   
AS
INSERT INTO DeletedGroups (Name,AcademyId)
SELECT Name,AcademyId FROM deleted

DELETE FROM Groups WHERE Id=2
GO
