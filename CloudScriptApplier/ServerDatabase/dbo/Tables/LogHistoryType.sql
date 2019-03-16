CREATE TABLE [dbo].[LogHistoryType] (
    [Id]     INT            IDENTITY (0, 1) NOT NULL,
    [EnName] NVARCHAR (100) NOT NULL,
    [ArName] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_LogHistoryType_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

