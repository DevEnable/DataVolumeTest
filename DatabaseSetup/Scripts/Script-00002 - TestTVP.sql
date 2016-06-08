IF NOT EXISTS (SELECT * FROM sys.types WHERE is_table_type = 1 AND name = 'TestTVP')
BEGIN
	CREATE TYPE dbo.TestTVP AS TABLE(
		ColumnA varchar(255) NOT NULL,
		ColumnB varchar(255) NOT NULL,
		ColumnC varchar(50) NOT NULL,
		ColumnD varchar(128) NOT NULL,
		ColumnE varchar(2000) NULL,
		ColumnF decimal(18, 0) NULL,
		ColumnG decimal(18, 0) NULL,
		ColumnH datetime NULL,
		ColumnI datetime NOT NULL
	)
END