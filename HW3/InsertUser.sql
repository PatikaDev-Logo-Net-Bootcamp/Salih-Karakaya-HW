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
ALTER   PROCEDURE [dbo].[InsertUser] 
	-- Add the parameters for the stored procedure here
	@Id int = 1, 
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@CompanyId int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[User]
           ([Id]
           ,[FirstName]
           ,[LastName]
           ,[CompanyId])
	VALUES (
			@Id,
			@FirstName,
			@LastName,
			@CompanyId
	)
END
