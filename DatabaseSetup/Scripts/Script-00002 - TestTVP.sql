IF NOT EXISTS (SELECT * FROM sys.types WHERE is_table_type = 1 AND name = 'TestTVP')
BEGIN
	CREATE TYPE dbo.TestTVP AS TABLE(
		
	)
END