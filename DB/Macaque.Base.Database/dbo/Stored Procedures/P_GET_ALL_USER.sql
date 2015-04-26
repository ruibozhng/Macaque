-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[P_GET_ALL_USER]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [ID]
      ,[USER_ID]
      ,[USER_NAME]
	  ,[GENDER]
	  ,[USER_PWD]
      ,[MOBILE_NUMBER]
      ,[EMAIL_ADDRESS]
	  ,[GRADE]
	FROM [dbo].[T_USER] WHERE IS_DELETED = 0
 
END