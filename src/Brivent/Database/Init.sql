CREATE DATABASE ParcelLockers

GO

USE [ParcelLockers]

GO

CREATE TABLE [dbo].[ParcelLockers]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[CreateDate] DATETIME2 NOT NULL,
	[UpdateDate] DATETIME2
)

GO

CREATE TABLE [dbo].[ParcelLockersContent]
(
	[ParcelLockerId] UNIQUEIDENTIFIER NOT NULL,
	[ParcelId] UNIQUEIDENTIFIER NOT NULL,

	CONSTRAINT [FK_ParcelLockersContent_ParcelLockers] 
		FOREIGN KEY ([ParcelLockerId]) REFERENCES [ParcelLockers]([Id])
)

GO

CREATE TABLE [dbo].[ParcelLockersLocalization]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Longtitude] REAL NOT NULL,
	[Latitude] REAL NOT NULL,
	[City] NVARCHAR(100) NOT NULL,
	[PostalCode] NVARCHAR(6) NOT NULL,
	[Street] NVARCHAR(100) NOT NULL,
	[AdditionalInfo] NVARCHAR(500),

    CONSTRAINT [FK_ParcelLockersLocalization_ParcelLockers] 
		FOREIGN KEY ([Id]) REFERENCES [ParcelLockers]([Id])
)

GO

CREATE DATABASE Parcels

GO

USE [Parcels]

GO

CREATE TABLE [dbo].[Parcels]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Weight] REAL NOT NULL,
	[Size] INT NOT NULL,
	[Status] INT NOT NULL,
	[Description] NVARCHAR(500),
	[CreateDate] DATETIME2 NOT NULL,
	[UpdateDate] DATETIME2
)

GO