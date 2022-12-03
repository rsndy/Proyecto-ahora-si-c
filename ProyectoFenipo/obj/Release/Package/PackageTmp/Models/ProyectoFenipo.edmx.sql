
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/29/2022 19:10:33
-- Generated from EDMX file: C:\Users\Uriel Sandi G\Desktop\ProyectoFenipo\ProyectoFenipo\Models\ProyectoFenipo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProyectoFenipoDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AtletaInscripcionAtletas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InscripcionAtletasSet] DROP CONSTRAINT [FK_AtletaInscripcionAtletas];
GO
IF OBJECT_ID(N'[dbo].[FK_InscripcionAtletasIntento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Intentos] DROP CONSTRAINT [FK_InscripcionAtletasIntento];
GO
IF OBJECT_ID(N'[dbo].[FK_EquipoInscripcionEquipo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InscripcionEquipos] DROP CONSTRAINT [FK_EquipoInscripcionEquipo];
GO
IF OBJECT_ID(N'[dbo].[FK_InscripcionAtletasInscripcionEquipo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InscripcionAtletasSet] DROP CONSTRAINT [FK_InscripcionAtletasInscripcionEquipo];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetenciaInscripcionEquipo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InscripcionEquipos] DROP CONSTRAINT [FK_CompetenciaInscripcionEquipo];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetenciaInscripcionAtletas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InscripcionAtletasSet] DROP CONSTRAINT [FK_CompetenciaInscripcionAtletas];
GO
IF OBJECT_ID(N'[dbo].[FK_InscripcionAtletasCategoriaEdad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InscripcionAtletasSet] DROP CONSTRAINT [FK_InscripcionAtletasCategoriaEdad];
GO
IF OBJECT_ID(N'[dbo].[FK_InscripcionAtletasCategoriaPeso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InscripcionAtletasSet] DROP CONSTRAINT [FK_InscripcionAtletasCategoriaPeso];
GO
IF OBJECT_ID(N'[dbo].[FK_IntentoMovimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Intentos] DROP CONSTRAINT [FK_IntentoMovimiento];
GO
IF OBJECT_ID(N'[dbo].[FK_NumeroIntentoIntento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Intentos] DROP CONSTRAINT [FK_NumeroIntentoIntento];
GO
IF OBJECT_ID(N'[dbo].[FK_IntentoStatusMovimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Intentos] DROP CONSTRAINT [FK_IntentoStatusMovimiento];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Atletas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Atletas];
GO
IF OBJECT_ID(N'[dbo].[Equipos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipos];
GO
IF OBJECT_ID(N'[dbo].[Competencias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Competencias];
GO
IF OBJECT_ID(N'[dbo].[InscripcionEquipos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InscripcionEquipos];
GO
IF OBJECT_ID(N'[dbo].[InscripcionAtletasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InscripcionAtletasSet];
GO
IF OBJECT_ID(N'[dbo].[CategoriaPesos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoriaPesos];
GO
IF OBJECT_ID(N'[dbo].[CategoriaEdades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoriaEdades];
GO
IF OBJECT_ID(N'[dbo].[Intentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Intentos];
GO
IF OBJECT_ID(N'[dbo].[NumeroIntentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NumeroIntentos];
GO
IF OBJECT_ID(N'[dbo].[Movimientos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movimientos];
GO
IF OBJECT_ID(N'[dbo].[StatusMovimientoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StatusMovimientoSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Atletas'
CREATE TABLE [dbo].[Atletas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreAtleta] nvarchar(max)  NOT NULL,
    [FechaNacimiento] datetime  NOT NULL,
    [Sexo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Equipos'
CREATE TABLE [dbo].[Equipos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreEquipo] nvarchar(max)  NOT NULL,
    [NacionalidadEquipo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Competencias'
CREATE TABLE [dbo].[Competencias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Lugar] nvarchar(max)  NOT NULL,
    [Fecha] datetime  NOT NULL
);
GO

-- Creating table 'InscripcionEquipos'
CREATE TABLE [dbo].[InscripcionEquipos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EquipoId] int  NOT NULL,
    [DelegadoEquipo] nvarchar(max)  NOT NULL,
    [CompetenciaId] int  NOT NULL
);
GO

-- Creating table 'InscripcionAtletasSet'
CREATE TABLE [dbo].[InscripcionAtletasSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AtletaId] int  NOT NULL,
    [InscripcionEquipoId] int  NOT NULL,
    [CompetenciaId] int  NOT NULL,
    [CategoriaEdadId] int  NOT NULL,
    [CategoriaPesoId] int  NOT NULL,
    [PesoCorporal] float  NOT NULL,
    [Total] float  NOT NULL,
    [GLPoint] float  NOT NULL
);
GO

-- Creating table 'CategoriaPesos'
CREATE TABLE [dbo].[CategoriaPesos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreCategoriaPeso] int  NOT NULL,
    [Genero] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CategoriaEdades'
CREATE TABLE [dbo].[CategoriaEdades] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreCategoriaEdad] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Intentos'
CREATE TABLE [dbo].[Intentos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [InscripcionAtletasId] int  NOT NULL,
    [KilosMovimiento] decimal(18,0)  NOT NULL,
    [MovimientoId] int  NOT NULL,
    [NumeroIntentoId] int  NOT NULL,
    [StatusMovimientoId] int  NOT NULL
);
GO

-- Creating table 'NumeroIntentos'
CREATE TABLE [dbo].[NumeroIntentos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Numero] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Movimientos'
CREATE TABLE [dbo].[Movimientos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StatusMovimientoSet'
CREATE TABLE [dbo].[StatusMovimientoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Status] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Atletas'
ALTER TABLE [dbo].[Atletas]
ADD CONSTRAINT [PK_Atletas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Equipos'
ALTER TABLE [dbo].[Equipos]
ADD CONSTRAINT [PK_Equipos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Competencias'
ALTER TABLE [dbo].[Competencias]
ADD CONSTRAINT [PK_Competencias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InscripcionEquipos'
ALTER TABLE [dbo].[InscripcionEquipos]
ADD CONSTRAINT [PK_InscripcionEquipos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InscripcionAtletasSet'
ALTER TABLE [dbo].[InscripcionAtletasSet]
ADD CONSTRAINT [PK_InscripcionAtletasSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoriaPesos'
ALTER TABLE [dbo].[CategoriaPesos]
ADD CONSTRAINT [PK_CategoriaPesos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoriaEdades'
ALTER TABLE [dbo].[CategoriaEdades]
ADD CONSTRAINT [PK_CategoriaEdades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Intentos'
ALTER TABLE [dbo].[Intentos]
ADD CONSTRAINT [PK_Intentos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NumeroIntentos'
ALTER TABLE [dbo].[NumeroIntentos]
ADD CONSTRAINT [PK_NumeroIntentos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Movimientos'
ALTER TABLE [dbo].[Movimientos]
ADD CONSTRAINT [PK_Movimientos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StatusMovimientoSet'
ALTER TABLE [dbo].[StatusMovimientoSet]
ADD CONSTRAINT [PK_StatusMovimientoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AtletaId] in table 'InscripcionAtletasSet'
ALTER TABLE [dbo].[InscripcionAtletasSet]
ADD CONSTRAINT [FK_AtletaInscripcionAtletas]
    FOREIGN KEY ([AtletaId])
    REFERENCES [dbo].[Atletas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AtletaInscripcionAtletas'
CREATE INDEX [IX_FK_AtletaInscripcionAtletas]
ON [dbo].[InscripcionAtletasSet]
    ([AtletaId]);
GO

-- Creating foreign key on [InscripcionAtletasId] in table 'Intentos'
ALTER TABLE [dbo].[Intentos]
ADD CONSTRAINT [FK_InscripcionAtletasIntento]
    FOREIGN KEY ([InscripcionAtletasId])
    REFERENCES [dbo].[InscripcionAtletasSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InscripcionAtletasIntento'
CREATE INDEX [IX_FK_InscripcionAtletasIntento]
ON [dbo].[Intentos]
    ([InscripcionAtletasId]);
GO

-- Creating foreign key on [EquipoId] in table 'InscripcionEquipos'
ALTER TABLE [dbo].[InscripcionEquipos]
ADD CONSTRAINT [FK_EquipoInscripcionEquipo]
    FOREIGN KEY ([EquipoId])
    REFERENCES [dbo].[Equipos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipoInscripcionEquipo'
CREATE INDEX [IX_FK_EquipoInscripcionEquipo]
ON [dbo].[InscripcionEquipos]
    ([EquipoId]);
GO

-- Creating foreign key on [InscripcionEquipoId] in table 'InscripcionAtletasSet'
ALTER TABLE [dbo].[InscripcionAtletasSet]
ADD CONSTRAINT [FK_InscripcionAtletasInscripcionEquipo]
    FOREIGN KEY ([InscripcionEquipoId])
    REFERENCES [dbo].[InscripcionEquipos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InscripcionAtletasInscripcionEquipo'
CREATE INDEX [IX_FK_InscripcionAtletasInscripcionEquipo]
ON [dbo].[InscripcionAtletasSet]
    ([InscripcionEquipoId]);
GO

-- Creating foreign key on [CompetenciaId] in table 'InscripcionEquipos'
ALTER TABLE [dbo].[InscripcionEquipos]
ADD CONSTRAINT [FK_CompetenciaInscripcionEquipo]
    FOREIGN KEY ([CompetenciaId])
    REFERENCES [dbo].[Competencias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetenciaInscripcionEquipo'
CREATE INDEX [IX_FK_CompetenciaInscripcionEquipo]
ON [dbo].[InscripcionEquipos]
    ([CompetenciaId]);
GO

-- Creating foreign key on [CompetenciaId] in table 'InscripcionAtletasSet'
ALTER TABLE [dbo].[InscripcionAtletasSet]
ADD CONSTRAINT [FK_CompetenciaInscripcionAtletas]
    FOREIGN KEY ([CompetenciaId])
    REFERENCES [dbo].[Competencias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetenciaInscripcionAtletas'
CREATE INDEX [IX_FK_CompetenciaInscripcionAtletas]
ON [dbo].[InscripcionAtletasSet]
    ([CompetenciaId]);
GO

-- Creating foreign key on [CategoriaEdadId] in table 'InscripcionAtletasSet'
ALTER TABLE [dbo].[InscripcionAtletasSet]
ADD CONSTRAINT [FK_InscripcionAtletasCategoriaEdad]
    FOREIGN KEY ([CategoriaEdadId])
    REFERENCES [dbo].[CategoriaEdades]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InscripcionAtletasCategoriaEdad'
CREATE INDEX [IX_FK_InscripcionAtletasCategoriaEdad]
ON [dbo].[InscripcionAtletasSet]
    ([CategoriaEdadId]);
GO

-- Creating foreign key on [CategoriaPesoId] in table 'InscripcionAtletasSet'
ALTER TABLE [dbo].[InscripcionAtletasSet]
ADD CONSTRAINT [FK_InscripcionAtletasCategoriaPeso]
    FOREIGN KEY ([CategoriaPesoId])
    REFERENCES [dbo].[CategoriaPesos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InscripcionAtletasCategoriaPeso'
CREATE INDEX [IX_FK_InscripcionAtletasCategoriaPeso]
ON [dbo].[InscripcionAtletasSet]
    ([CategoriaPesoId]);
GO

-- Creating foreign key on [MovimientoId] in table 'Intentos'
ALTER TABLE [dbo].[Intentos]
ADD CONSTRAINT [FK_IntentoMovimiento]
    FOREIGN KEY ([MovimientoId])
    REFERENCES [dbo].[Movimientos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IntentoMovimiento'
CREATE INDEX [IX_FK_IntentoMovimiento]
ON [dbo].[Intentos]
    ([MovimientoId]);
GO

-- Creating foreign key on [NumeroIntentoId] in table 'Intentos'
ALTER TABLE [dbo].[Intentos]
ADD CONSTRAINT [FK_NumeroIntentoIntento]
    FOREIGN KEY ([NumeroIntentoId])
    REFERENCES [dbo].[NumeroIntentos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NumeroIntentoIntento'
CREATE INDEX [IX_FK_NumeroIntentoIntento]
ON [dbo].[Intentos]
    ([NumeroIntentoId]);
GO

-- Creating foreign key on [StatusMovimientoId] in table 'Intentos'
ALTER TABLE [dbo].[Intentos]
ADD CONSTRAINT [FK_IntentoStatusMovimiento]
    FOREIGN KEY ([StatusMovimientoId])
    REFERENCES [dbo].[StatusMovimientoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IntentoStatusMovimiento'
CREATE INDEX [IX_FK_IntentoStatusMovimiento]
ON [dbo].[Intentos]
    ([StatusMovimientoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------