CREATE PROCEDURE [dbo].[InsertLikeList]
	@SNPK int,
	@OrderName int,
	@Account int,
	@TotalFee int,
	@TotalAmount int,
	@UserID nvarchar(12)	
AS 
INSERT INTO [dbo].[LikeList] 
([SN],[OrderName],[Account],[TotalFee],[TotalAmount],[UserID],[CreateDate],[UpdaeDate])
VALUES(@SNPK,@OrderName,@Account,@TotalFee,@TotalAmount,@UserID,GETDATE(),GETDATE() )

RETURN