USE [LogoDb]
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 3/27/2022 10:44:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Salih Karakaya
-- Create date: 
-- Description:	
-- =============================================
CREATE OR ALTER   PROCEDURE [dbo].[InsertCompany] 
	@Id int = 1, 
	@Name nvarchar(50),
	@Sector nvarchar(50)
AS
BEGIN
	INSERT INTO [dbo].[Company]
           ([Id]
           ,[Name]
           ,[Sector])
	VALUES (
			@Id,
			@Name,
			@Sector
	)
END
