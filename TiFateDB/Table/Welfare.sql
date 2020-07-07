CREATE TABLE [dbo].[Welfare]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NULL, 
    [Content] NVARCHAR(MAX) NULL, 
    [PublishTime] DATETIME NULL, 
    [StartTime] DATETIME NULL, 
    [EndTime] DATETIME NULL, 
    [IsDelete] BIT NULL
)
