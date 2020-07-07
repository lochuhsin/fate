CREATE TABLE [dbo].[Permission]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Position] VARCHAR(20) NULL, 
    [ModifyWelfare] BIT NULL, 
    [ModifyMeetUp] BIT NULL, 
    [ModifyImportant] BIT NULL, 
    [ModifyClubs] BIT NULL, 
    [ModifyExternal] BIT NULL
)
