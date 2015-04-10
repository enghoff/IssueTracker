
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/09/2015 22:34:39
-- Generated from EDMX file: C:\Users\enghoff\Documents\Visual Studio 2013\Projects\IssueTracking\IssueTracking\IssueTracking.Common\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
--USE [Database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_IssueComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_IssueComment];
GO
IF OBJECT_ID(N'[dbo].[FK_IssueIssue_Issue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IssueIssue] DROP CONSTRAINT [FK_IssueIssue_Issue];
GO
IF OBJECT_ID(N'[dbo].[FK_IssueIssue_Issue1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IssueIssue] DROP CONSTRAINT [FK_IssueIssue_Issue1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Issues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Issues];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO
IF OBJECT_ID(N'[dbo].[IssueIssue]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IssueIssue];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Issues'
CREATE TABLE [dbo].[Issues] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [State] int  NOT NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Issue_Id] int  NOT NULL
);
GO

-- Creating table 'IssueIssue'
CREATE TABLE [dbo].[IssueIssue] (
    [IssueIssue_Issue1_Id] int  NOT NULL,
    [AssocIssues_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Issues'
ALTER TABLE [dbo].[Issues]
ADD CONSTRAINT [PK_Issues]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IssueIssue_Issue1_Id], [AssocIssues_Id] in table 'IssueIssue'
ALTER TABLE [dbo].[IssueIssue]
ADD CONSTRAINT [PK_IssueIssue]
    PRIMARY KEY CLUSTERED ([IssueIssue_Issue1_Id], [AssocIssues_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Issue_Id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_IssueComment]
    FOREIGN KEY ([Issue_Id])
    REFERENCES [dbo].[Issues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IssueComment'
CREATE INDEX [IX_FK_IssueComment]
ON [dbo].[Comments]
    ([Issue_Id]);
GO

-- Creating foreign key on [IssueIssue_Issue1_Id] in table 'IssueIssue'
ALTER TABLE [dbo].[IssueIssue]
ADD CONSTRAINT [FK_IssueIssue_Issue]
    FOREIGN KEY ([IssueIssue_Issue1_Id])
    REFERENCES [dbo].[Issues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AssocIssues_Id] in table 'IssueIssue'
ALTER TABLE [dbo].[IssueIssue]
ADD CONSTRAINT [FK_IssueIssue_Issue1]
    FOREIGN KEY ([AssocIssues_Id])
    REFERENCES [dbo].[Issues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IssueIssue_Issue1'
CREATE INDEX [IX_FK_IssueIssue_Issue1]
ON [dbo].[IssueIssue]
    ([AssocIssues_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------