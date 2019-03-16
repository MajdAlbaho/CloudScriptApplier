CREATE TABLE [dbo].[LogHistory] (
    [Id]               UNIQUEIDENTIFIER CONSTRAINT [Default_LogHistory_Id] DEFAULT (newsequentialid()) NOT NULL,
    [LogMessage]       NVARCHAR (MAX)   NOT NULL,
    [LogHistoryTypeId] INT              NOT NULL,
    [Script]           NVARCHAR (MAX)   NOT NULL,
    [ServerName]       NVARCHAR (200)   NOT NULL,
    [DbName]           NVARCHAR (200)   NOT NULL,
    CONSTRAINT [PK_LogHistory_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LogHistory_LogHistoryType_LogHistoryTypeId] FOREIGN KEY ([LogHistoryTypeId]) REFERENCES [dbo].[LogHistoryType] ([Id])
);

