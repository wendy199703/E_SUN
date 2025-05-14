CREATE PROCEDURE [dbo].[InsertLikeListDetail]
	@SN int,
	@SubNo int,
	@ProductNo int,
	@ProductCount int,
	@User_ID nvarchar(12)
AS 
DECLARE @UserID nvarchar(12)
DECLARE @Account_D nvarchar(50)
DECLARE @Fee int
Set @Fee=0
BEGIN TRAN
SELECT @Fee=@ProductCount*[FeeRate]*[Price]*0.01 FROM [dbo].[Product] WHERE No=@ProductNo
	INSERT INTO [dbo].[LikeListDetail] 
	([SN],[SubNo],[ProductNo],[Fee],[ProductCount])
	VALUES(@SN,@SubNo,@ProductNo,@Fee,@ProductCount )

	IF @@ERROR =0
	BEGIN
		SELECT @UserID=[UserID],@Account_D=[Account] FROM [dbo].[LikeList] WHERE SN=@SN 
		IF @UserID IS NULL AND @Account_D IS NULL
			BEGIN
			DECLARE　@OrderCount_D int,@TotalFee_D int,@TotalAmount_D int
			SELECT @Account_D =Account FROM [dbo].[User] WHERE UserID=@User_ID
			SELECT @OrderCount_D=SUM([ProductCount]),@TotalFee_D=SUM([Fee]),@TotalAmount_D=SUM(B.Price*A.ProductCount) FROM [dbo].[LikeListDetail] A
			LEFT JOIN [dbo].[Product] B ON A.ProductNo=B.No WHERE SN=@SN 
			EXEC [InsertLikeList] @SNPK=@SN,@UserID=@User_ID,@Account=@Account_D,@OrderName=@OrderCount_D,@TotalFee=@TotalFee_D,@TotalAmount=@TotalAmount_D
			END
		ELSE
		EXEC [UpdateLikeList] @SNPK=@SN,@UserID=@User_ID,@Account=@Account_D

		IF @@ERROR =0
			COMMIT TRAN
		ELSE
			ROLLBACK TRAN	
	END
	ELSE
		ROLLBACK TRAN

RETURN