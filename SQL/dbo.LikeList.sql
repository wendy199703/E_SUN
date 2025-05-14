CREATE TABLE [dbo].[LikeList] (
    [SN]          INT           NOT NULL,
    [OrderName]   INT           NULL,
    [Account]     NVARCHAR (50) NULL,
    [TotalFee]    INT           DEFAULT ((0)) NULL,
    [TotalAmount] INT           DEFAULT ((0)) NULL,
    [UserID]      NVARCHAR (12) NULL,
    [CreateDate]  DATETIME      NULL,
    [UpdaeDate]   DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([SN] ASC)
);

