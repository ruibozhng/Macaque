-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[P_GET_FUNCTION_BY_ROLE_CODE]
	@ROLE_CODE VARCHAR(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [ID]
      ,[ROLE_CODE]
      ,[FUNCTION_CODE]
	FROM [dbo].[T_ROLE_FUNCTION] WHERE [ROLE_CODE] = @ROLE_CODE 
 
END