CREATE TABLE [dbo].[Passwords] (
    [UserName]  NVARCHAR (450) NOT NULL,
    [Hash]      VARBINARY(MAX) NULL,
    [Salt]      VARBINARY(MAX) NULL,
    [UserName1] NVARCHAR (450) NULL,
    CONSTRAINT [PK_Passwords] PRIMARY KEY CLUSTERED ([UserName] ASC),
    CONSTRAINT [FK_Passwords_Users_UserName1] FOREIGN KEY ([UserName1]) REFERENCES [dbo].[Users] ([Name])
);


GO
CREATE NONCLUSTERED INDEX [IX_Passwords_UserName1]
    ON [dbo].[Passwords]([UserName1] ASC);

