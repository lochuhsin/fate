CREATE TABLE [dbo].[MeetUp]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NULL, 
    [Content] NVARCHAR(MAX) NULL, 
    [PublishTime] DATETIME NULL, 
    [StartTime] DATETIME NULL, 
    [IsDelete] BIT NULL, 
    [EndTime] DATETIME NULL
)
