
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/04/2021 16:00:03
-- Generated from EDMX file: D:\Arul\Projects\LandRegistration\LandRegistrationUI\Models\LandDataEntity.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LandRecord];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BlockMaster_RevenueVillageMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BlockMaster] DROP CONSTRAINT [FK_BlockMaster_RevenueVillageMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_RevenueVillageMaster_TalukMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RevenueVillageMaster] DROP CONSTRAINT [FK_RevenueVillageMaster_TalukMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_TalukMaster_RegionMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TalukMaster] DROP CONSTRAINT [FK_TalukMaster_RegionMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_UserImages_UsersData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserImages] DROP CONSTRAINT [FK_UserImages_UsersData];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersData_BlockMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersData] DROP CONSTRAINT [FK_UsersData_BlockMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersData_RevenueVillageMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersData] DROP CONSTRAINT [FK_UsersData_RevenueVillageMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersData_TalukMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersData] DROP CONSTRAINT [FK_UsersData_TalukMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersData_UsersData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersData] DROP CONSTRAINT [FK_UsersData_UsersData];
GO
IF OBJECT_ID(N'[dbo].[FK_WardMaster_RevenueVillageMaster1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WardMaster] DROP CONSTRAINT [FK_WardMaster_RevenueVillageMaster1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[BlockMaster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BlockMaster];
GO
IF OBJECT_ID(N'[dbo].[RegionMaster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegionMaster];
GO
IF OBJECT_ID(N'[dbo].[RevenueVillageMaster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RevenueVillageMaster];
GO
IF OBJECT_ID(N'[dbo].[TalukMaster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TalukMaster];
GO
IF OBJECT_ID(N'[dbo].[UserImages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserImages];
GO
IF OBJECT_ID(N'[dbo].[UsersData]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersData];
GO
IF OBJECT_ID(N'[dbo].[WardMaster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WardMaster];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'BlockMasters'
CREATE TABLE [dbo].[BlockMasters] (
    [BlockID] int IDENTITY(1,1) NOT NULL,
    [BlockName] nvarchar(50)  NOT NULL,
    [RevenueVillageId] int  NOT NULL
);
GO

-- Creating table 'RegionMasters'
CREATE TABLE [dbo].[RegionMasters] (
    [Id] tinyint IDENTITY(1,1) NOT NULL,
    [Region] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'RevenueVillageMasters'
CREATE TABLE [dbo].[RevenueVillageMasters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RevenueVillageName] nvarchar(50)  NOT NULL,
    [TalukID] int  NOT NULL,
    [IsWard] bit  NOT NULL
);
GO

-- Creating table 'TalukMasters'
CREATE TABLE [dbo].[TalukMasters] (
    [TalukID] int IDENTITY(1,1) NOT NULL,
    [TalukName] nvarchar(50)  NOT NULL,
    [RegionID] tinyint  NOT NULL
);
GO

-- Creating table 'UserImages'
CREATE TABLE [dbo].[UserImages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ImagePath] nvarchar(max)  NULL,
    [UserDataID] int  NOT NULL
);
GO

-- Creating table 'WardMasters'
CREATE TABLE [dbo].[WardMasters] (
    [WardID] int IDENTITY(1,1) NOT NULL,
    [WardName] nvarchar(50)  NOT NULL,
    [RevenueVillageID] int  NOT NULL
);
GO

-- Creating table 'UsersDatas'
CREATE TABLE [dbo].[UsersDatas] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RegionID] tinyint  NOT NULL,
    [TalukID] int  NOT NULL,
    [WardID] int  NULL,
    [BlockID] int  NULL,
    [RevenueVillageID] int  NOT NULL,
    [TSNo] nvarchar(50)  NULL,
    [SubDivisionNo] nvarchar(20)  NULL,
    [RSNo] nvarchar(50)  NULL,
    [PattaNo] nvarchar(50)  NULL,
    [OwnerName] nvarchar(50)  NULL,
    [TenantName] nvarchar(50)  NULL,
    [AddressLine1] nvarchar(100)  NULL,
    [AddressLine2] nvarchar(100)  NULL,
    [AddressLine3] nvarchar(100)  NULL,
    [PreviousOwnerAddLine1] nvarchar(100)  NULL,
    [PreviousOwnerAddLine2] nvarchar(100)  NULL,
    [PreviousOwnerAddLine3] nvarchar(100)  NULL,
    [Remarks] nvarchar(500)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [BlockID] in table 'BlockMasters'
ALTER TABLE [dbo].[BlockMasters]
ADD CONSTRAINT [PK_BlockMasters]
    PRIMARY KEY CLUSTERED ([BlockID] ASC);
GO

-- Creating primary key on [Id] in table 'RegionMasters'
ALTER TABLE [dbo].[RegionMasters]
ADD CONSTRAINT [PK_RegionMasters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RevenueVillageMasters'
ALTER TABLE [dbo].[RevenueVillageMasters]
ADD CONSTRAINT [PK_RevenueVillageMasters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [TalukID] in table 'TalukMasters'
ALTER TABLE [dbo].[TalukMasters]
ADD CONSTRAINT [PK_TalukMasters]
    PRIMARY KEY CLUSTERED ([TalukID] ASC);
GO

-- Creating primary key on [Id] in table 'UserImages'
ALTER TABLE [dbo].[UserImages]
ADD CONSTRAINT [PK_UserImages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [WardID] in table 'WardMasters'
ALTER TABLE [dbo].[WardMasters]
ADD CONSTRAINT [PK_WardMasters]
    PRIMARY KEY CLUSTERED ([WardID] ASC);
GO

-- Creating primary key on [ID] in table 'UsersDatas'
ALTER TABLE [dbo].[UsersDatas]
ADD CONSTRAINT [PK_UsersDatas]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RevenueVillageId] in table 'BlockMasters'
ALTER TABLE [dbo].[BlockMasters]
ADD CONSTRAINT [FK_BlockMaster_RevenueVillageMaster]
    FOREIGN KEY ([RevenueVillageId])
    REFERENCES [dbo].[RevenueVillageMasters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BlockMaster_RevenueVillageMaster'
CREATE INDEX [IX_FK_BlockMaster_RevenueVillageMaster]
ON [dbo].[BlockMasters]
    ([RevenueVillageId]);
GO

-- Creating foreign key on [RegionID] in table 'TalukMasters'
ALTER TABLE [dbo].[TalukMasters]
ADD CONSTRAINT [FK_TalukMaster_RegionMaster]
    FOREIGN KEY ([RegionID])
    REFERENCES [dbo].[RegionMasters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TalukMaster_RegionMaster'
CREATE INDEX [IX_FK_TalukMaster_RegionMaster]
ON [dbo].[TalukMasters]
    ([RegionID]);
GO

-- Creating foreign key on [TalukID] in table 'RevenueVillageMasters'
ALTER TABLE [dbo].[RevenueVillageMasters]
ADD CONSTRAINT [FK_RevenueVillageMaster_TalukMaster]
    FOREIGN KEY ([TalukID])
    REFERENCES [dbo].[TalukMasters]
        ([TalukID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RevenueVillageMaster_TalukMaster'
CREATE INDEX [IX_FK_RevenueVillageMaster_TalukMaster]
ON [dbo].[RevenueVillageMasters]
    ([TalukID]);
GO

-- Creating foreign key on [RevenueVillageID] in table 'WardMasters'
ALTER TABLE [dbo].[WardMasters]
ADD CONSTRAINT [FK_WardMaster_RevenueVillageMaster1]
    FOREIGN KEY ([RevenueVillageID])
    REFERENCES [dbo].[RevenueVillageMasters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WardMaster_RevenueVillageMaster1'
CREATE INDEX [IX_FK_WardMaster_RevenueVillageMaster1]
ON [dbo].[WardMasters]
    ([RevenueVillageID]);
GO

-- Creating foreign key on [BlockID] in table 'UsersDatas'
ALTER TABLE [dbo].[UsersDatas]
ADD CONSTRAINT [FK_UsersData_BlockMaster]
    FOREIGN KEY ([BlockID])
    REFERENCES [dbo].[BlockMasters]
        ([BlockID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersData_BlockMaster'
CREATE INDEX [IX_FK_UsersData_BlockMaster]
ON [dbo].[UsersDatas]
    ([BlockID]);
GO

-- Creating foreign key on [RegionID] in table 'UsersDatas'
ALTER TABLE [dbo].[UsersDatas]
ADD CONSTRAINT [FK_UsersData_UsersData]
    FOREIGN KEY ([RegionID])
    REFERENCES [dbo].[RegionMasters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersData_UsersData'
CREATE INDEX [IX_FK_UsersData_UsersData]
ON [dbo].[UsersDatas]
    ([RegionID]);
GO

-- Creating foreign key on [RevenueVillageID] in table 'UsersDatas'
ALTER TABLE [dbo].[UsersDatas]
ADD CONSTRAINT [FK_UsersData_RevenueVillageMaster]
    FOREIGN KEY ([RevenueVillageID])
    REFERENCES [dbo].[RevenueVillageMasters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersData_RevenueVillageMaster'
CREATE INDEX [IX_FK_UsersData_RevenueVillageMaster]
ON [dbo].[UsersDatas]
    ([RevenueVillageID]);
GO

-- Creating foreign key on [TalukID] in table 'UsersDatas'
ALTER TABLE [dbo].[UsersDatas]
ADD CONSTRAINT [FK_UsersData_TalukMaster]
    FOREIGN KEY ([TalukID])
    REFERENCES [dbo].[TalukMasters]
        ([TalukID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersData_TalukMaster'
CREATE INDEX [IX_FK_UsersData_TalukMaster]
ON [dbo].[UsersDatas]
    ([TalukID]);
GO

-- Creating foreign key on [UserDataID] in table 'UserImages'
ALTER TABLE [dbo].[UserImages]
ADD CONSTRAINT [FK_UserImages_UsersData]
    FOREIGN KEY ([UserDataID])
    REFERENCES [dbo].[UsersDatas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserImages_UsersData'
CREATE INDEX [IX_FK_UserImages_UsersData]
ON [dbo].[UserImages]
    ([UserDataID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------