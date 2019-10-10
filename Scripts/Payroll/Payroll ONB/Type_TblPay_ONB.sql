-- ================================
-- Create User-defined Table Type
-- ================================
USE MPS
GO

-- Create the data type
CREATE TYPE TYPE_tblPay_ONB AS TABLE 
(
	FKeyIDNbr VARCHAR(15) NOT NULL,
	FKeyPayID VARCHAR(15) NOT NULL,
	ActID VARCHAR(15) NOT NULL,
	FKeyPayONB VARCHAR(15),
	FKeyWages VARCHAR(15) NOT NULL,
	WageType SMALLINT NOT NULL,
	FullAmt FLOAT  NOT NULL,
	FKeyCurr VARCHAR(15) NOT NULL,
	ExRate FLOAT DEFAULT(0) NOT NULL,
	Amt FLOAT DEFAULT(0) NOT NULL,
	CAmt FLOAT DEFAULT(0) NOT NULL,
	Prorata BIT DEFAULT(0),
	DateStart DATE NOT NULL, 
	DateEnd DATE NOT NULL
)
GO
