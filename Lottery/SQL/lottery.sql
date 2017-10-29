-- User
CREATE TABLE [dbo].[User] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(255),
    [Password] nvarchar(255)
);
GO

ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Lottery
CREATE TABLE [dbo].[Lottery] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [LotteryName] nvarchar(255),
    [Prize] nvarchar(255),
	[DrowTime] datetime  NOT NULL
);
GO

ALTER TABLE [dbo].[Lottery]
ADD CONSTRAINT [PK_Lottery]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Lottery User
CREATE TABLE [dbo].[LotteryUser] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [UserId] bigint,
    [LotteryId] bigint,
    [IsWinner] bit NOT NULL,
    [Prize] nvarchar(255)
);
GO

ALTER TABLE [dbo].[LotteryUser]
ADD CONSTRAINT [PK_LotteryUser]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

ALTER TABLE [dbo].[LotteryUser]
ADD CONSTRAINT [FK_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

ALTER TABLE [dbo].[LotteryUser]
ADD CONSTRAINT [FK_LotteryUser]
    FOREIGN KEY ([LotteryId])
    REFERENCES [dbo].[Lottery]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO