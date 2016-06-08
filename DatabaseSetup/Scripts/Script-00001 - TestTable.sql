CREATE TABLE dbo.TestTable
	(
	Id bigint NOT NULL IDENTITY (1, 1),
	ColumnA varchar(255) NOT NULL,
	ColumnB varchar(255) NOT NULL,
	ColumnC varchar(50) NOT NULL,
	ColumnD varchar(128) NOT NULL,
	ColumnE varchar(2000) NULL,
	ColumnF decimal(18, 0) NULL,
	ColumnG decimal(18, 0) NULL,
	ColumnH datetime NULL,
	ColumnI datetime NOT NULL,
	)  ON [PRIMARY]

ALTER TABLE dbo.TestTable ADD CONSTRAINT
	PK_TestTable PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
