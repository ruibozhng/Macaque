

CREATE PROCEDURE [dbo].[P_DELETE_USER_BY_ID]
    @ID INT
AS 
    BEGIN
        SET NOCOUNT ON;
        UPDATE  T_USER
        SET     IS_DELETED = 1
        WHERE   ID = @ID
       
    END