CREATE PROCEDURE [dbo].[UpdateLikeListDetail]
	@SN int,
	@SubNo int,
	@ProductNo int,
	@ProductCount int
AS 
DECLARE @UserID nvarchar(12)
DECLARE @Account_D nvarchar(50)
DECLARE @Fee int
Set @Fee=0
SELECT @Fee=@ProductCount*[FeeRate]*[Price]*0.01 FROM [dbo].[Product] WHERE No=@ProductNo
	UPDATE [dbo].[LikeListDetail] 
	SET ProductNo=@ProductNo,Fee=@Fee,ProductCount=@ProductCount
	WHERE SN=@SN AND SubNo=@SubNo


SELECT @UserID=[UserID],@Account_D=[Account] FROM [dbo].[LikeList] WHERE SN=@SN 
EXEC [UpdateLikeList] @SNPK=@SN,@UserID=@UserID,@Account=@Account_D
RETURN