-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[P_GET_ROLE_BY_USER_ID]
	@USER_ID INT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [ID]
      ,[USER_ID]
      ,[ROLE_CODE]
	  ,[IS_DELETED]
      ,[CREATED_BY]
      ,[CREATED_DATE]
      ,[UPDATED_BY]
      ,[UPDATED_DATE]
      ,[TIME_STAMP]
      ,[VERSION_NO]
	FROM [dbo].[T_USER_ROLE] WHERE [USER_ID] = @USER_ID 
 
END