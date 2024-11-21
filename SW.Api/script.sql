IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241119010925_InitialCreate')
BEGIN
    CREATE TABLE [UserAccount] (
        [Id] int NOT NULL IDENTITY,
        [UserName] nvarchar(150) NOT NULL,
        [Password] nvarchar(100) NOT NULL,
        [Email] varchar(150) NOT NULL,
        [IsActive] bit NOT NULL,
        [IsAuthorized] bit NOT NULL,
        [UserAccountType] smallint NOT NULL,
        [CreatedDate] datetime NOT NULL DEFAULT ((getdate())),
        [IsDeleted] bit NULL,
        CONSTRAINT [PK_UserAccount] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241119010925_InitialCreate')
BEGIN
    CREATE TABLE [UserCommend] (
        [Id] int NOT NULL IDENTITY,
        [Code] uniqueidentifier NOT NULL,
        [SleepQualityStatus] smallint NOT NULL,
        [Name] nvarchar(150) NOT NULL,
        [Description] nvarchar(max) NULL,
        [IsDeleted] bit NULL,
        [CreatedDate] datetime NOT NULL DEFAULT ((getdate())),
        [CreatedBy] nvarchar(20) NULL DEFAULT ((N'Admin')),
        [LastModifiedDate] datetime NULL,
        [LastModifiedBy] nvarchar(20) NULL,
        CONSTRAINT [PK_UserCommend] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241119010925_InitialCreate')
BEGIN
    CREATE TABLE [UserData] (
        [Id] int NOT NULL IDENTITY,
        [Code] uniqueidentifier NOT NULL,
        [FirstName] varchar(200) NOT NULL,
        [MiddleName] varchar(150) NULL,
        [LastName] varchar(200) NOT NULL,
        [CellPhone] varchar(50) NOT NULL,
        [Phone] varchar(50) NULL,
        [Gender] smallint NULL,
        [BirthDate] datetime2 NULL,
        [CreatedDate] datetime NOT NULL DEFAULT ((getdate())),
        [CreatedBy] nvarchar(50) NULL DEFAULT ((N'User')),
        [LastModifiedDate] datetime NULL,
        [LastModifiedBy] nvarchar(50) NULL,
        [IsDeleted] bit NULL,
        CONSTRAINT [PK_UserData_3214EC076D7D9088] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241119010925_InitialCreate')
BEGIN
    CREATE TABLE [DataDream] (
        [Id] int NOT NULL IDENTITY,
        [Code] uniqueidentifier NOT NULL,
        [UserDataId] int NOT NULL,
        [StartTime] datetime NOT NULL DEFAULT ((getdate())),
        [EndTime] datetime NOT NULL DEFAULT ((getdate())),
        [SleepQualityStatus] smallint NOT NULL,
        [AverageHearthRate] int NULL,
        [AverageOxygenLevel] float NULL,
        [DeepSleepHours] float NULL,
        [Interruptions] int NULL,
        [CreatedDate] datetime NOT NULL DEFAULT ((getdate())),
        [CreatedBy] nvarchar(50) NULL DEFAULT ((N'Admin')),
        [LastModifiedDate] datetime2 NULL,
        [LastModifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_DataDream] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_DataDream_UserData] FOREIGN KEY ([UserDataId]) REFERENCES [UserData] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241119010925_InitialCreate')
BEGIN
    CREATE TABLE [UserAccountUserData] (
        [UserAccountId] int NOT NULL,
        [UserDataId] int NOT NULL,
        CONSTRAINT [PK_UserAccountUserData] PRIMARY KEY ([UserAccountId], [UserDataId]),
        CONSTRAINT [FK_UserAccountUserData_UserAccount] FOREIGN KEY ([UserAccountId]) REFERENCES [UserAccount] ([Id]),
        CONSTRAINT [FK_UserAccountUserData_UserData] FOREIGN KEY ([UserDataId]) REFERENCES [UserData] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241119010925_InitialCreate')
BEGIN
    CREATE TABLE [UserDataCommend] (
        [Id] int NOT NULL IDENTITY,
        [UserDataId] int NOT NULL,
        [UserCommendId] int NOT NULL,
        CONSTRAINT [PK__UserDataCommend__3214EC07A20A3AD6] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserDataCommend_UserComment] FOREIGN KEY ([UserCommendId]) REFERENCES [UserCommend] ([Id]),
        CONSTRAINT [FK_UserDataCommend_UserData] FOREIGN KEY ([UserDataId]) REFERENCES [UserData] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241119010925_InitialCreate')
BEGIN
    CREATE INDEX [IX_DataDream_UserDataId] ON [DataDream] ([UserDataId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241119010925_InitialCreate')
BEGIN
    CREATE INDEX [IX_UserAccountUserData_UserDataId] ON [UserAccountUserData] ([UserDataId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241119010925_InitialCreate')
BEGIN
    CREATE INDEX [IX_UserDataCommend_UserCommendId] ON [UserDataCommend] ([UserCommendId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241119010925_InitialCreate')
BEGIN
    CREATE INDEX [IX_UserDataCommend_UserDataId] ON [UserDataCommend] ([UserDataId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241119010925_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241119010925_InitialCreate', N'7.0.12');
END;
GO

COMMIT;
GO

