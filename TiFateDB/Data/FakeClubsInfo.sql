USE [TiFate]
GO

DELETE FROM [ClubsInfo]
GO

INSERT INTO [dbo].[ClubsInfo]
           ([ClubId]
           ,[Title]
           ,[Content]   
           ,[PublishTime]
           ,[StartTime]
           ,[EndTime]
           ,[IsDelete]
           )
     VALUES
           (1
           ,N'玩遊戲囉'
           ,N'嗨嗨嗨'
           ,'2020-06-04 09:30'
           ,'2020-06-08 0:00'
           ,'2020-06-15 0:00'
		   ,0
           )
GO