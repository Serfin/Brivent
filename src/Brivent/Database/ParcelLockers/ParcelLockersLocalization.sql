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
