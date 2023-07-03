USE [BioDataBase]
GO

/****** Объект: Table [dbo].[class_mkb] Дата скрипта: 12.05.2022 20:54:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[class_mkb] (
    [id]              INT  NOT NULL,
    [name]            TEXT NOT NULL,
    [code]            TEXT NOT NULL,
    [parentId]       INT  ,
	[parentCode]     TEXT ,
    [nodeCount]      INT NOT NULL,
    [additionalInfo] TEXT 
);


