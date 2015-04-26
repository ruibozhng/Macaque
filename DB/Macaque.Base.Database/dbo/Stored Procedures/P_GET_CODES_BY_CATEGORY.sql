-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[P_GET_CODES_BY_CATEGORY]
	@CATEGORY VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [ID]
      ,[CATEGORY]
      ,[CODE]
	  ,[CODE_DESC]	  
	FROM [dbo].[T_CODE] WHERE [CATEGORY] = @CATEGORY
 
END