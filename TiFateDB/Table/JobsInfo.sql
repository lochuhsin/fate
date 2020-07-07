CREATE TABLE [dbo].[JobsInfo]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [JobName] NVARCHAR(100) NULL, 
    [CronTrigger] NVARCHAR(20) NULL, 
    [LastExecute] DATETIME NULL
)
