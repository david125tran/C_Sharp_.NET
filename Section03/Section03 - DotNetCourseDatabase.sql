    USE master
    DROP DATABASE DotNetCourseDatabase
    CREATE DATABASE DotNetCourseDatabase
    GO
     
    USE DotNetCourseDatabase
    GO
     
    CREATE SCHEMA TutorialAppSchema
    GO
     
    CREATE TABLE TutorialAppSchema.Computer(
        ComputerId INT IDENTITY(1,1) PRIMARY KEY,
        Motherboard NVARCHAR(50),
        CPUCores INT,
        HasWifi BIT,
        HasLTE BIT,
        ReleaseDate DATE,
        Price DECIMAL(18,4),
        VideoCard NVARCHAR(50)
    );

    INSERT INTO TutorialAppSchema.Computer (
                    Motherboard,
                    HasWifi,
                    HasLTE,
                    ReleaseDate,
                    Price,
                    VideoCard
                ) VALUES ('Z690','True','False','7/15/2023 10:51:45 AM','943.87','RTX 260');

    SELECT * FROM TutorialAppSchema.Computer