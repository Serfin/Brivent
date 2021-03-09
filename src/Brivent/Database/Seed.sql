INSERT INTO [Parcels].[dbo].[Parcels]
	VALUES (NEWID(), 1.0, 1, 'TEST_1', GETDATE()),
		   (NEWID(), 3.8, 2, 'TEST_2', GETDATE()),
		   (NEWID(), 2.6, 0, 'TEST_3', GETDATE()),
		   (NEWID(), 10,  1, 'TEST_4', GETDATE()),
		   (NEWID(), 1.3, 2, 'TEST_5', GETDATE()),
		   (NEWID(), 1.7, 3, 'TEST_6', GETDATE())