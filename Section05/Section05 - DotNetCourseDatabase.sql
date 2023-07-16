USE master
GO
-- Go is a batch separator used by client tools (like SSMS) to break the entire script up into batches
DROP DATABASE IF EXISTS DotNetCourseDatabase
GO

CREATE DATABASE DotNetCourseDatabase
GO 

USE DotNetCourseDatabase
GO

DROP TABLE IF EXISTS TutorialAppSchema.Computer
GO

DROP SCHEMA IF EXISTS TutorialAppSchema
GO

CREATE SCHEMA TutorialAppSchema
GO

CREATE TABLE TutorialAppSchema.Computer
(
    -- TableId INT IDENTITY(Start/Seed, Increment/Step)
    ComputerId INT IDENTITY(1, 1) PRIMARY KEY,
    -- Motherboard CHAR(10),
    -- Motherboard VARCHAR(10),
    Motherboard NVARCHAR(255),
    CPUCores INT,
    HasWifi BIT,
    HasLTE DECIMAL(18, 4),
    ReleaseDate DATETIME, 
    Price DECIMAL(18, 4),
    VideoCard NVARCHAR(50)
)
GO
-- Use NVARCHAR() instead of CHAR() or VARCHAR() unless you know what characters you're working with.
-- NVARCHAR() takes up more space than CHAR() & VARCHAR().  
-- It is best practice to make NVARCHAR() length 255. 
-- BIT is either 1 or 0.  1 = true, 0 = false.  Conceptually, it is like our boolean.
-- DATE data type doesn't work the best.  So best practice is to use DATETIME data type. 
-- DATETIME2 is more accurate to the millisecond than DATETIME.

SELECT * FROM TutorialAppSchema.Computer
-- A shortcut to get all the field names is put your cursor right after the "*" from the select statement.  
-- Hold down "ctrl" and space.

-- You can manually enter in a protected field by unprotecting it.
-- After manually entering it, you want to reprotect the field:
-- SET IDENTITY_INSERT TutorialAppSchema.Computer ON 
-- SET IDENTITY_INSERT TutorialAppSchema.Computer OFF 

INSERT INTO TutorialAppSchema.Computer (
-- [ComputerId]   <-- This field is protected
[Motherboard],
[CPUCores],
[HasWifi],
[HasLTE],
[ReleaseDate],
[Price],
[VideoCard]
) VALUES (
    'Sample-Motherboard',
    4,
    1,
    0,
    '2022-01-01',
    1000,
    'Sample-Videocard'
)


SELECT * FROM TutorialAppSchema.Computer
GO

-- Delete a row
DELETE FROM TutorialAppSchema.Computer WHERE ComputerId = 1
GO

-- Update a column in a specific row
UPDATE TutorialAppSchema.Computer SET CPUCores = 4 WHERE ComputerId = 2
GO

-- Update a column in all rows
UPDATE TutorialAppSchema.Computer SET CPUCores = NULL 
GO

-- Replace NULL values with 0 (This doesn't permanently change it)
SELECT
[ComputerId],
[Motherboard],
ISNULL([CPUCores], 0) AS CPUCores,
[HasWifi],
[HasLTE],
[ReleaseDate],
[Price],
[VideoCard]
FROM TutorialAppSchema.Computer
ORDER BY HasWifi DESC, ReleaseDate DESC -- Sort by multiple fields

DROP TABLE IF EXISTS TutorialAppSchema.Users;

-- IF OBJECT_ID('TutorialAppSchema.Users') IS NOT NULL
--     DROP TABLE TutorialAppSchema.Users;

CREATE TABLE TutorialAppSchema.Users
(
    UserId INT IDENTITY(1, 1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(50),
    Gender NVARCHAR(50),
    Active BIT
);

INSERT INTO TutorialAppSchema.Users (
    FirstName, 
    LastName, 
    Email, 
    Gender, 
    Active)
VALUES 
    ('Albert', 'Smith', 'aofinan1red@gmail.com', 'Male', 'TRUE'),
    ('Franky', 'Brown', 'flailing12@yahoo.com', 'Male', 'TRUE'),
    ('Lexy', 'Johnson', 'lexyjohnson212@gmail.com', 'Female', 'FALSE'),
    ('Allie', 'Gregory', 'allieg1234@hotmail.com', 'Female', 'FALSE')
        
DROP TABLE IF EXISTS TutorialAppSchema.UserSalary;

-- IF OBJECT_ID('TutorialAppSchema.UserSalary') IS NOT NULL
--     DROP TABLE TutorialAppSchema.UserSalary;

CREATE TABLE TutorialAppSchema.UserSalary
(
    UserId INT,
    Salary DECIMAL(18, 4)
);

INSERT INTO TutorialAppSchema.UserSalary (
    UserId,
    Salary
)
VALUES 
    (1, 80000.50),
    (2, 66100.22),
    (3, 99252.10),
    (4, 16996.20)


DROP TABLE IF EXISTS TutorialAppSchema.UserJobInfo;

-- IF OBJECT_ID('TutorialAppSchema.UserJobInfo') IS NOT NULL
--     DROP TABLE TutorialAppSchema.UserJobInfo;

CREATE TABLE TutorialAppSchema.UserJobInfo
(
    UserId INT,
    JobTitle NVARCHAR(50),
    Department NVARCHAR(50)
);

INSERT INTO TutorialAppSchema.UserJobInfo (
    UserId,
    JobTitle,
    Department
)
VALUES
    (1, 'Chemist', 'Laboratory'),
    (2, 'Marketing', 'Support'),
    (3, 'Analyst', 'IT'),
    (4, 'Engineer', 'Manufacturing')

SELECT 
    [Users].[UserId],
    [Users].[FirstName] + ' ' + [Users].[LastName] AS FullName,
    [Users].[Email],
    [Users].[Gender],
    [Users].[Active],
    [UserJobInfo].[Department] 
FROM TutorialAppSchema.Users AS Users
JOIN TutorialAppSchema.UserJobInfo
ON Users.UserId = UserJobInfo.UserId
WHERE Active = 1                                                    -- The WHERE clause must come before the ORDER BY clause
ORDER BY Users.UserId DESC

DELETE FROM TutorialAppSchema.UserSalary WHERE UserId BETWEEN 250 and 750
-- When we use BETWEEN we also include the lower and upper bound of the value we're checking

SELECT 
[UserId],
[Salary] 
FROM TutorialAppSchema.UserSalary
WHERE EXISTS (
    SELECT * FROM TutorialAppSchema.UserJobInfo AS UserJobInfo
    WHERE UserJobInfo.UserId = UserSalary.UserId
    )
AND UserId <> 7

SELECT [UserId],
[Salary] FROM TutorialAppSchema.UserSalary
UNION ALL        
SELECT [UserId],
[Salary] FROM TutorialAppSchema.UserSalary

-- UNION only returns unique values
-- UNION ALL returns all records, including duplicates 
