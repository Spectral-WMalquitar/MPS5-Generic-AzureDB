DECLARE @Period AS VARCHAR(15)
SET @Period  = FORMAT(GETDATE(),'yyyMM','en-US')
--SELECT @Period
SELECT * FROM dbo.Crew_ActivityList_Complete aca
WHERE format(aca.DateSOn,'yyyyMM','en-US') = @Period