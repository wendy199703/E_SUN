CREATE TABLE [dbo].[LikeListDetail] (
    [SN]           INT NOT NULL,
    [SubNo]        INT NOT NULL,
    [ProductNo]    INT NULL,
    [Fee]          INT NULL,
    [ProductCount] INT NULL,
    PRIMARY KEY CLUSTERED ([SN], SUBNO)
);

