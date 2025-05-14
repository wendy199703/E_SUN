CREATE PROCEDURE [dbo].[GetLikeList]
	@UsrId nvarchar(12)
AS
SELECT A.UserID AS UserId ,A.UserName AS UserName,A.Account AS　UserAccount,
A.Email AS UserEmail,ISNULL(B.TotalAmount,0) AS OrderPrice,ISNULL(B.TotalFee,0) AS OrderFee,
B.Account AS OrderAccount,ISNULL(B.OrderName,0) AS OrderCount,
B.CreateDate AS OrderCreateDate,B.UpdaeDate AS OrderUpdateDate,B.SN
FROM [dbo].[User] A
LEFT JOIN [dbo].[LikeList] B ON A.[UserID]=B.[UserID]
WHERE A.[UserID]=@UsrId
RETURN