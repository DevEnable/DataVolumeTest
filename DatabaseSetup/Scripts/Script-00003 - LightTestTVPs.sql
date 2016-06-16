IF NOT EXISTS (SELECT * FROM sys.types WHERE is_table_type = 1 AND name = 'LightTestTVP')
BEGIN
	CREATE TYPE dbo.LightTestTVP AS TABLE(
		ColumnA varchar(255) NOT NULL,
		RepeatableId INT NOT NULL,
		ColumnE varchar(2000) NULL
	)

	CREATE TYPE dbo.LightLookup AS TABLE(
		ID INT NOT NULL PRIMARY KEY,
		RepeatableB varchar(255) NOT NULL,
		RepeatableC varchar(50) NOT NULL,
		RepeatableD varchar(128) NOT NULL,
		RepeatableF decimal(18, 0) NOT NULL,
		RepeatableG decimal(18, 0) NOT NULL
	)
END