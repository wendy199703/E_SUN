﻿CREATE PROCEDURE [dbo].[DeleteLikeList]
	@SN int
AS 
BEGIN TRAN
	DELETE [dbo].[LikeList] 
	WHERE SN=@SN
	IF @@ERROR =0
		BEGIN
		DELETE [dbo].[LikeListDetail] WHERE SN=@SN

		IF @@ERROR =0
			COMMIT TRAN
		ELSE
			ROLLBACK TRAN
		END
	ELSE
		ROLLBACK TRAN
RETURN