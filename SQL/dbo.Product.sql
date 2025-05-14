CREATE TABLE [dbo].[Product]
(
	[No] INT NOT NULL PRIMARY KEY, 
    [ProductName] NVARCHAR(200) NULL, 
    [Price] INT NULL, 
    [FeeRate] DECIMAL(18, 2) NULL
)
