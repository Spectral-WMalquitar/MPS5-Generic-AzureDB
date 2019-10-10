ALTER TRIGGER TG_Pay_UpdateExRate
ON dbo.tblPayExRate
	AFTER UPDATE
AS
BEGIN

	DECLARE @LastUpdatedBy VARCHAR(200)
	SELECT @LastUpdatedBy = LastUpdatedBy FROM inserted -- Get LastUpdatedBy Description

	DECLARE @PayType VARCHAR(15)
	DECLARE @tblExRate Type_tblPayExRates
	DECLARE @FKeyPayID VARCHAR(15)
	DECLARE @MCode INT
	
	/* Get Pay Type */
	SELECT 
		@PayType = PayType , --get Pay Type
		@FKeyPayID = FKeyPay, -- Get Pay ID
		@MCode = Pay.MCode -- Get MCode
	FROM dbo.tblPay pay
		INNER JOIN deleted d  ON pay.PKey = d.FKeyPay

	/* Populate Data */
	SELECT 
		@FKeyPayID = FKeyPay,
		@MCode = Pay.MCode
	FROM deleted d
		INNER JOIN dbo.tblPay pay ON d.FKeyPay = pay.PKey
	WHERE pay.Paytype = @PayType
	/* Populate Data */

	INSERT INTO @tblExRate
	SELECT DISTINCT
		ex.FKeyCurr,
		CASE WHEN FKeyPay = @FKeyPayID
			THEN (SELECT ex.ExRate FROM inserted) 
			ELSE ex.ExRate END
	FROM dbo.tblPayExRate ex
		WHERE ex.FKeyPay = @FKeyPayID

/* Create ExRate Table */
	IF UPDATE(ExRate)
	BEGIN
		IF @PayType = 'HA'
		BEGIN
			/* UPDATE tblPay_Ash*/
				UPDATE
				pAsh
			SET
				DateUpdated = getDate(),
				LastUpdatedBy = @LastUpdatedBy,
				pash.ExRate = (SELECT ExRate FROM @tblExRate WHERE FKeyCurr = pallot.FKeyCurr),
				pash.CAmt = dbo.FN_RefAmount(@tblExRate,pAsh.Amt,pash.FKeyCurr,pallot.FKeyCurr) * (SELECT ExRate FROM @tblExRate WHERE FKeyCurr = pallot.FKeyCurr)
			FROM dbo.tblPay pay
				INNER JOIN inserted i ON pay.PKey = i.FKeyPay
				INNER JOIN dbo.tblPayCrew_HA pcha ON pay.PKey = pcha.FKeyPayID
				INNER JOIN dbo.tblPay_Allot pAllot ON pcha.PKey = pAllot.FKeyPayCrewHA
				INNER JOIN dbo.tblPay_Ash pAsh ON pAllot.PKey = pash.FKeyPayAllotID
			WHERE pay.Paytype = @PayType
				AND pay.PKey = @FKeyPayID
				AND MCode = @MCode
			/* UPDATE tblPay_Ash*/

			/* Update tblPayAshEmp*/
				--DECLARE @AllotCurr = (SELECT FKeyCurr FROM dbo.tblPay_Allot WHERE FKeyPayCrewHA)
			UPDATE
				pAshEmp
			SET
				DateUpdated = GetDate(),
				LastUpdatedBy = @LastUpdatedBy,
				pAshEmp.ExRate = (SELECT ExRate FROM @tblExRate WHERE FKeyCurr =pAshEmp.FKeyCurr),
				pAshEmp.CAmt = dbo.FN_RefAmount(@tblExRate,pAshEmp.Amt,pAshEmp.FKeyCurr,pay.RefCurr)/* (SELECT ExRate FROM @tblExRate WHERE FKeyCurr =pAshEmp.FKeyCurr) */
			FROM dbo.tblPay pay
				INNER JOIN inserted i ON pay.PKey = i.FKeyPay
				INNER JOIN dbo.tblPayCrew_HA pcha ON pay.PKey = pcha.FKeyPayID
				INNER JOIN dbo.tblPay_AshEmp pAshEmp ON pcha.PKey = pAshEmp.FKeyPayCrewHA
			WHERE pay.Paytype = @PayType
				AND pay.PKey = @FKeyPayID
				AND Pay.MCode = @MCode
			/* Update tblPayAshEmp*/
		END
		ELSE IF @PayType = 'ONB'
		BEGIN
			/* tblPay PayONB */
			UPDATE
				pONB
			SET
				DateUpdated = Getdate(),
				LastUpdatedBy = @LastUpdatedBy,
				ExRate =(SELECT ExRate FROM @tblExRate WHERE FKeyCurr =pONB.FKeyCurr),
				CAmt = dbo.FN_RefAmount(@tblExRate,pONB.Amt,pONB.FKeyCurr,pay.RefCurr)
			FROM dbo.tblPay pay
				INNER JOIN inserted i ON pay.PKey = i.FKeyPay
				INNER JOIN dbo.tblPayCrew_ONB pcONB ON i.FKeyPay = pcONB.FKeyPayID
				INNER JOIN dbo.tblPay_ONB pONB ON pcONB.PKey = pONB.FKeyPayCrewONB
			WHERE pay.Paytype = @PayType
				AND pay.PKey = @FKeyPayID
				AND MCode =@MCode
			/* tblPay PayONB */
		END
	END

END