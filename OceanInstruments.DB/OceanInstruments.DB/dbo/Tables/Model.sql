CREATE TABLE [dbo].[Model] (
    [ModelId]  INT           IDENTITY (1, 1) NOT NULL,
    [Code]     NVARCHAR (10)  NOT NULL,
    [FullDesc] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_model] PRIMARY KEY CLUSTERED ([ModelId] ASC)
);

