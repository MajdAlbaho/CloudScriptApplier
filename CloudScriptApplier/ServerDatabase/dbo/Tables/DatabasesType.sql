CREATE TABLE [dbo].[DatabasesType] (
    [Id]       INT            IDENTITY (0, 1) NOT NULL,
    [TypeName] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_DatabasesType_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

