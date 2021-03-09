CREATE TABLE [dbo].[ParcelLockersContent]
(
	[ParcelLockerId] UNIQUEIDENTIFIER NOT NULL,
	[ParcelId] UNIQUEIDENTIFIER NOT NULL,

	CONSTRAINT [FK_ParcelLockersContent_ParcelLockers] 
		FOREIGN KEY ([ParcelLockerId]) REFERENCES [ParcelLockers]([Id])
)
