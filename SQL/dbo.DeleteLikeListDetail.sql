CREATE PROCEDURE [dbo].[DeleteLikeListDetail]
	@SN int,
	@SubNo int	
AS 
DECLARE @User_ID nvarchar(12)
DECLARE @Account_D nvarchar(50)
BEGIN TRAN
	DELETE [dbo].[LikeListDetail] 
	WHERE SN=@SN AND SubNo=@SubNo

	IF @@ERROR =0
	BEGIN
		SELECT @User_ID=[UserID],@Account_D=[Account] FROM [dbo].[LikeList] WHERE SN=@SN 

		
		EXEC [UpdateLikeList] @SNPK=@SN,@UserID=@User_ID,@Account=@Account_D

		IF @@ERROR =0
			COMMIT TRAN
		ELSE
			ROLLBACK TRAN	
	END
	ELSE
		ROLLBACK TRAN
RETURN