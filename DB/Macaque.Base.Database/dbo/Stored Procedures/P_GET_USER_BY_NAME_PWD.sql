-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[P_GET_USER_BY_NAME_PWD]
	@USER_NAME VARCHAR(500),
	@USER_PWD VARCHAR(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [ID]
      ,[USER_ID]
      ,[USER_NAME]
	  ,[USER_PWD]
      ,[MOBILE_NUMBER]
      ,[EMAIL_ADDRESS]
	FROM [dbo].[T_USER] WHERE @USER_NAME = @USER_NAME AND [USER_PWD] = @USER_PWD
 
END