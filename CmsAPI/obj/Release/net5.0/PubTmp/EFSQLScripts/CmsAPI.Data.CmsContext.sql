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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211004031156_first')
BEGIN
    CREATE TABLE [Doctor] (
        [DoctorId] int NOT NULL IDENTITY,
        [Firstname] nvarchar(max) NOT NULL,
        [Lastname] nvarchar(max) NOT NULL,
        [Sex] nvarchar(max) NOT NULL,
        [Specialization] nvarchar(max) NOT NULL,
        [StartTime] nvarchar(max) NOT NULL,
        [EndTime] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Doctor] PRIMARY KEY ([DoctorId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211004031156_first')
BEGIN
    CREATE TABLE [Patient] (
        [PatientId] int NOT NULL IDENTITY,
        [Firstname] nvarchar(max) NOT NULL,
        [Lastname] nvarchar(max) NOT NULL,
        [Sex] nvarchar(max) NOT NULL,
        [age] int NOT NULL,
        [DOB] datetime2 NOT NULL,
        CONSTRAINT [PK_Patient] PRIMARY KEY ([PatientId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211004031156_first')
BEGIN
    CREATE TABLE [UserSetup] (
        [Username] nvarchar(450) NOT NULL,
        [Firstname] nvarchar(max) NOT NULL,
        [Lastname] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_UserSetup] PRIMARY KEY ([Username])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211004031156_first')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211004031156_first', N'5.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211004031855_second')
BEGIN
    EXEC sp_rename N'[Patient].[age]', N'Age', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211004031855_second')
BEGIN
    EXEC sp_rename N'[Doctor].[StartTime]', N'ToTime', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211004031855_second')
BEGIN
    EXEC sp_rename N'[Doctor].[EndTime]', N'FromTime', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211004031855_second')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211004031855_second', N'5.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211017061348_third')
BEGIN
    CREATE TABLE [Schedule] (
        [AppointmentId] int NOT NULL IDENTITY,
        [PatientId] int NOT NULL,
        [Specialization] nvarchar(max) NOT NULL,
        [DoctorName] nvarchar(max) NOT NULL,
        [VisitDate] datetime2 NOT NULL,
        [AppointmentTime] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Schedule] PRIMARY KEY ([AppointmentId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211017061348_third')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211017061348_third', N'5.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211018043851_last')
BEGIN
    EXEC sp_rename N'[Doctor].[ToTime]', N'StartTime', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211018043851_last')
BEGIN
    EXEC sp_rename N'[Doctor].[FromTime]', N'EndTime', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211018043851_last')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211018043851_last', N'5.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220214082941_forth')
BEGIN
    ALTER TABLE [UserSetup] ADD [Answer] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220214082941_forth')
BEGIN
    ALTER TABLE [UserSetup] ADD [CreationDate] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220214082941_forth')
BEGIN
    ALTER TABLE [UserSetup] ADD [EmailId] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220214082941_forth')
BEGIN
    ALTER TABLE [UserSetup] ADD [SecurityCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220214082941_forth')
BEGIN
    ALTER TABLE [UserSetup] ADD [SecurityQuestion] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220214082941_forth')
BEGIN
    ALTER TABLE [UserSetup] ADD [Status] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220214082941_forth')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220214082941_forth', N'5.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220214155556_fifth')
BEGIN
    ALTER TABLE [UserSetup] ADD [ConfirmPassword] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220214155556_fifth')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220214155556_fifth', N'5.0.10');
END;
GO

COMMIT;
GO

