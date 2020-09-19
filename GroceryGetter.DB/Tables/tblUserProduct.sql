﻿CREATE TABLE [dbo].[tblUserProduct]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [ProductId] UNIQUEIDENTIFIER NOT NULL, 
    [InCart] BIT NOT NULL, 
    [Amount] INT NOT NULL DEFAULT 1, 
    [Notes] VARCHAR(250) NULL
)
