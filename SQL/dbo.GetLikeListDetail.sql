CREATE PROCEDURE [dbo].[GetLikeListDetail]
	@UsrId nvarchar(12)
AS
SELECT C.SN,C.SubNo,C.Fee,C.ProductCount,D.ProductName,D.Price,D.FeeRate
FROM [dbo].[User] A
LEFT JOIN [dbo].[LikeList] B ON A.[UserID]=B.[UserID]
LEFT JOIN [dbo].[LikeListDetail] C ON B.SN=C.SN
LEFT JOIN [dbo].[Product] D ON C.[ProductNo] =D.[No]
WHERE A.[UserID]=@UsrId
RETURN