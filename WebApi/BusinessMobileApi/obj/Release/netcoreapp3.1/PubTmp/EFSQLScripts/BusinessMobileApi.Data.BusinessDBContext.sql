IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117121905_InitialMigration')
BEGIN
    CREATE TABLE [Stores] (
        [id] int NOT NULL IDENTITY,
        [number] int NOT NULL,
        [name] nvarchar(max) NOT NULL,
        [ip] nvarchar(max) NOT NULL,
        [connected] int NOT NULL,
        [seller] int NOT NULL,
        [paidAmount] decimal(18,2) NOT NULL,
        [unpaidAmount] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Stores] PRIMARY KEY ([id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117121905_InitialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230117121905_InitialMigration', N'3.1.3');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230118115237_StoreIncomeByMonths')
BEGIN
    CREATE TABLE [StoreIncomePerMonths] (
        [Id] int NOT NULL IDENTITY,
        [number] int NOT NULL,
        [name] nvarchar(max) NOT NULL,
        [date] nvarchar(max) NOT NULL,
        [sdate] nvarchar(max) NOT NULL,
        [gdate] nvarchar(max) NOT NULL,
        [dname] nvarchar(max) NOT NULL,
        [amount] decimal(18,2) NOT NULL,
        [idc] int NOT NULL,
        CONSTRAINT [PK_StoreIncomePerMonths] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230118115237_StoreIncomeByMonths')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230118115237_StoreIncomeByMonths', N'3.1.3');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230119081727_StoreIncomeByYears')
BEGIN
    CREATE TABLE [StoreIncomePerYears] (
        [id] int NOT NULL IDENTITY,
        [number] int NOT NULL,
        [name] nvarchar(max) NOT NULL,
        [smonth] nvarchar(max) NOT NULL,
        [mname] nvarchar(max) NOT NULL,
        [amount] decimal(18,2) NOT NULL,
        [idc] int NOT NULL,
        CONSTRAINT [PK_StoreIncomePerYears] PRIMARY KEY ([id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230119081727_StoreIncomeByYears')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230119081727_StoreIncomeByYears', N'3.1.3');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230119094256_UserCredentials')
BEGIN
    CREATE TABLE [Users] (
        [id] uniqueidentifier NOT NULL,
        [number] int NOT NULL,
        [name] nvarchar(max) NOT NULL,
        [username] nvarchar(max) NOT NULL,
        [password] nvarchar(max) NOT NULL,
        [hasMonthStores] int NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230119094256_UserCredentials')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230119094256_UserCredentials', N'3.1.3');
END;

GO

