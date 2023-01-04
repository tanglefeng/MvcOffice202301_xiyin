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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130034909_InitialCreate')
BEGIN
    CREATE TABLE [Uniquedoor] (
        [ID] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [description] nvarchar(max) NULL,
        [detail] nvarchar(max) NULL,
        CONSTRAINT [PK_Uniquedoor] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130034909_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221130034909_InitialCreate', N'6.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130051627_20221130034909_InitialCreateTwo')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Uniquedoor]') AND [c].[name] = N'detail');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Uniquedoor] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Uniquedoor] ALTER COLUMN [detail] nvarchar(max) NOT NULL;
    ALTER TABLE [Uniquedoor] ADD DEFAULT N'' FOR [detail];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130051627_20221130034909_InitialCreateTwo')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Uniquedoor]') AND [c].[name] = N'description');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Uniquedoor] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Uniquedoor] ALTER COLUMN [description] nvarchar(max) NOT NULL;
    ALTER TABLE [Uniquedoor] ADD DEFAULT N'' FOR [description];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130051627_20221130034909_InitialCreateTwo')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Uniquedoor]') AND [c].[name] = N'Name');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Uniquedoor] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Uniquedoor] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
    ALTER TABLE [Uniquedoor] ADD DEFAULT N'' FOR [Name];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130051627_20221130034909_InitialCreateTwo')
BEGIN
    CREATE TABLE [PictureSum] (
        [PictureSumId] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [srcaddress] nvarchar(max) NOT NULL,
        [description] nvarchar(max) NOT NULL,
        [detail] nvarchar(max) NOT NULL,
        [detail2] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_PictureSum] PRIMARY KEY ([PictureSumId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130051627_20221130034909_InitialCreateTwo')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221130051627_20221130034909_InitialCreateTwo', N'6.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221201012809_RowVersion')
BEGIN
    ALTER TABLE [Uniquedoor] ADD [RowVersion] rowversion NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221201012809_RowVersion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221201012809_RowVersion', N'6.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221202014701_InitialThree')
BEGIN
    CREATE TABLE [KengicAspNetCore] (
        [ID] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [description] nvarchar(max) NOT NULL,
        [detail] nvarchar(max) NOT NULL,
        [RowVersion] rowversion NOT NULL,
        CONSTRAINT [PK_KengicAspNetCore] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221202014701_InitialThree')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221202014701_InitialThree', N'6.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221202022700_InitialFour')
BEGIN
    CREATE TABLE [KengicAspnetcorePictureSum] (
        [KengicAspnetcorePictureSumId] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [srcaddress] nvarchar(max) NOT NULL,
        [description] nvarchar(max) NOT NULL,
        [detail] nvarchar(max) NOT NULL,
        [detail2] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_KengicAspnetcorePictureSum] PRIMARY KEY ([KengicAspnetcorePictureSumId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221202022700_InitialFour')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221202022700_InitialFour', N'6.0.11');
END;
GO

COMMIT;
GO

