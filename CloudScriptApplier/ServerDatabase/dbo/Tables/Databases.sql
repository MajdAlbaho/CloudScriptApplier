CREATE TABLE [dbo].[Databases] (
    [Id]             INT            IDENTITY (0, 1) NOT NULL,
    [DatabaseName]   NVARCHAR (200) NOT NULL,
    [DatabaseTypeId] INT            NOT NULL,
    [DatabaseCode]   NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_Databases_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Databases_DatabasesType_DatabasesTypeId] FOREIGN KEY ([DatabaseTypeId]) REFERENCES [dbo].[DatabasesType] ([Id]) ON DELETE CASCADE
);

