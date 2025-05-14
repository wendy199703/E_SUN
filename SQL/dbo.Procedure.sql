CREATE PROCEDURE [dbo].[ProductSearch]
	@Usr nvarchar,
	@errorMsg nvarchar OUTPUT
AS
BEGIN
SELECT @Usr, @errorMsg
RETURN 0
END
	
