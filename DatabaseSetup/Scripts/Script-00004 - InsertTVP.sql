CREATE PROCEDURE sp_InsertTVP
	@tvp LightTestTVP READONLY,
	@lookup LightLookup READONLY,
	@date DateTime
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[TestTable](ColumnA, ColumnB, ColumnC, ColumnD, ColumnE, ColumnF, ColumnG, ColumnH, ColumnI)
		SELECT t.ColumnA, l.RepeatableB, l.RepeatableC, l.RepeatableD, t.ColumnE, l.RepeatableF, l.RepeatableG, @date, @date
		FROM @tvp AS t
		INNER JOIN @lookup l ON t.RepeatableId = l.ID
END