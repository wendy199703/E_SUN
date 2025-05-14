CREATE PROCEDURE [dbo].[UpdateLikeList]
	@SNPK int,
	@UserID nvarchar(12),
	@OrderCount int=-1,
	@Account nvarchar(50),
	@TotalFee int=-1,
	@TotalAmount int=-1
AS 
BEGIN TRAN
IF @Account IS NULL 
SELECT @Account=[Account] FROM [dbo].[LikeList] WHERE SN=@SNPK AND UserID=@UserID

IF @OrderCount<0 
SELECT @OrderCount = SUM(ProductCount) FROM [LikeListDetail] WHERE SN=@SNPK

IF @TotalFee<0 OR @TotalAmount<0
	SELECT @TotalFee=SUM(B.FeeRate*B.Price*A.ProductCount*0.01),@TotalAmount=SUM(B.Price*A.ProductCount) 
	FROM [LikeListDetail] A
	LEFT JOIN [dbo].[Product] B ON A.ProductNo=B.No
	WHERE A.SN=@SNPK


	UPDATE [dbo].[LikeList] 
	SET [TotalFee]=@TotalFee,
	[OrderName]=@OrderCount,
	[Account]=@Account,
	[TotalAmount]=@TotalAmount,
	[UpdaeDate]=GETDATE()
	WHERE SN=@SNPK AND UserID=@UserID

	IF @@ERROR =0		
		COMMIT TRAN		
	ELSE
		ROLLBACK TRAN
RETURN