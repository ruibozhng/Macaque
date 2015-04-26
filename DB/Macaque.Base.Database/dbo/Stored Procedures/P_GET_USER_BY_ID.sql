-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[P_GET_USER_BY_ID]
	@USER_ID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [ID]
      ,[USER_ID]
      ,[USER_NAME]
      ,[USER_PWD]
      ,[GENDER]
      ,[MOBILE_NUMBER]
      ,[EMAIL_ADDRESS]
      ,[GRADE]
      ,[IS_DELETED]
      ,[CREATED_BY]
      ,[CREATED_DATE]
      ,[UPDATED_BY]
      ,[UPDATED_DATE]
      ,[TIME_STAMP]
      ,[VERSION_NO]
	FROM [dbo].[T_USER] WHERE ID = @USER_ID AND IS_DELETED = 0
 
END