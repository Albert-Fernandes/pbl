
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/29/2019 14:26:09
-- Generated from EDMX file: C:\Users\albert.fonseca\Documents\Albert-pessoal\pbl\TomaRemedio\TomaRemedio\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dbTomaRemedio];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ReceitaSet'
CREATE TABLE [dbo].[ReceitaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Data] nvarchar(max)  NOT NULL,
    [Clinica] nvarchar(max)  NOT NULL,
    [Medico] nvarchar(max)  NOT NULL,
    [Especialidade] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RemedioSet'
CREATE TABLE [dbo].[RemedioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [IsReceita] bit  NOT NULL,
    [Intervalo] nvarchar(max)  NOT NULL,
    [Dosagem] nvarchar(max)  NOT NULL,
    [ReceitaId] int  NOT NULL,
    [Tipo] int  NOT NULL
);
GO

-- Creating table 'DoencaSet'
CREATE TABLE [dbo].[DoencaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Causas] nvarchar(max)  NOT NULL,
    [Sintomas] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RemedioDoencaSet'
CREATE TABLE [dbo].[RemedioDoencaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RemediosId] int  NOT NULL,
    [DoencaId] int  NOT NULL,
    [RemedioId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ReceitaSet'
ALTER TABLE [dbo].[ReceitaSet]
ADD CONSTRAINT [PK_ReceitaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RemedioSet'
ALTER TABLE [dbo].[RemedioSet]
ADD CONSTRAINT [PK_RemedioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DoencaSet'
ALTER TABLE [dbo].[DoencaSet]
ADD CONSTRAINT [PK_DoencaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RemedioDoencaSet'
ALTER TABLE [dbo].[RemedioDoencaSet]
ADD CONSTRAINT [PK_RemedioDoencaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ReceitaId] in table 'RemedioSet'
ALTER TABLE [dbo].[RemedioSet]
ADD CONSTRAINT [FK_ReceitaRemedios]
    FOREIGN KEY ([ReceitaId])
    REFERENCES [dbo].[ReceitaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReceitaRemedios'
CREATE INDEX [IX_FK_ReceitaRemedios]
ON [dbo].[RemedioSet]
    ([ReceitaId]);
GO

-- Creating foreign key on [DoencaId] in table 'RemedioDoencaSet'
ALTER TABLE [dbo].[RemedioDoencaSet]
ADD CONSTRAINT [FK_DoencaRemedioDoenca]
    FOREIGN KEY ([DoencaId])
    REFERENCES [dbo].[DoencaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoencaRemedioDoenca'
CREATE INDEX [IX_FK_DoencaRemedioDoenca]
ON [dbo].[RemedioDoencaSet]
    ([DoencaId]);
GO

-- Creating foreign key on [RemedioId] in table 'RemedioDoencaSet'
ALTER TABLE [dbo].[RemedioDoencaSet]
ADD CONSTRAINT [FK_RemedioRemedioDoenca]
    FOREIGN KEY ([RemedioId])
    REFERENCES [dbo].[RemedioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RemedioRemedioDoenca'
CREATE INDEX [IX_FK_RemedioRemedioDoenca]
ON [dbo].[RemedioDoencaSet]
    ([RemedioId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------