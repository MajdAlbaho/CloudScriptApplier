CREATE TABLE [dbo].[Scripts] (
    [Id]          UNIQUEIDENTIFIER CONSTRAINT [DEFAULT_Scripts_Id] DEFAULT (newsequentialid()) NOT NULL,
    [ScriptText]  NVARCHAR (MAX)   NOT NULL,
    [DatabaseId]  INT              NOT NULL,
    [CreatedDate] DATETIME         CONSTRAINT [Default_Scripts_CreatedDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Scripts_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Scripts_Databases_DatabaseId] FOREIGN KEY ([DatabaseId]) REFERENCES [dbo].[Databases] ([Id])
);

