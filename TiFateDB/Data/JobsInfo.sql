USE [TiFate]
GO

DELETE FROM [JobsInfo]
GO

INSERT INTO [JobsInfo] ([JobName], [CronTrigger])
VALUES 
('RandomFater', '0 59 23 * * ?'),
('CallForRequest', '0 0/10 * * * ?')
Go