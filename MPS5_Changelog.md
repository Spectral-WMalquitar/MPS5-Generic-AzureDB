# MPS5
Application: MPS5
Date Updated: 2018-10-16

**************************************************************************************
README
**************************************************************************************
			/* ALWAYS UPDATE THE VERION NO. EVERY TIME YOU PUSH AN UPDATE 									*/	
			/* UPDATE ACCORDINGLY. REVISION NO. FOR REVISIONS ONLY, MINOR FOR MINOR REVISIONS				*/

**************************************************************************************
CHANGELOG
**************************************************************************************
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.33
By: Tony
Date: 2019-08-12

	"Modified Planning: added validation if Travel (GTravel) is enabled and if user has permission; auto add to travel if user proceeds to create a travel booking"
	PLANNING
		-> Planning
	TRAVEL
		-> Travel_GTRS
		
	"Bug fix saving of Admin Report Logo"
	ADMIN
		-> Logo
		
	"Modified enabling of Security Filter Assignment form"
	SECURITY
		-> SecFilterAssignment
	
	"Modified enabling of Security Users form"
	SECURITY
		-> SecUser
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.32
By: Tony
Date: 2019-07-16

	"Bug fix on Admin Vessel Group List wherein selection does not refresh the main content"
	Admin
		-> VesselList
		
	"Bug fix on Delete Crew : Stored Procedure no longer have the LastUpdatedBy field"
	Crewing
		-> Crew.DeleteCrewAndRecords()
		
	"Added enabling/disabling of Delete Crew button if database has no record"
	Crewing
		-> frmCrewMain
		-> CrewList_ActivityList.MainView_FocusedRowChanged
		
	"Modified Crew forms to disable Add/Edit button if there is no crew record"
	Crewing
		-> Document, Training, Uniform, Appraisail, MedicalHis
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.31
By: Tony
Date: 2019-07-12

	"Modified Generate Feature form"
	Crewing
		-> frmFeatureID
		-> frmFeatureID_Objects
		
	"Removed Other Bonus Template form"
	Admin
		-> OtherBonusTemplate
		
	"Modified Admin Vessel form removing Other Bonus Template related controls"
	Admin
		-> Vessel
		
	"Bug fix selection of Admin Department and Admin Rank Type"
	Admin
		-> DepartmentList
		-> RankType

	"Modified AllowEdit if Biodata form has no data"
	"Set Name and Rank as default tab if has no record yet"
	Crewing
		-> Biodata
		
	"Fixed LoadSub in Admin Uniform Issue Type"
	Admin
		-> UniformIssueType
		
	"Modified Training and Documents form : adding must be disabled if blList (crew list) does not have any record"
	Crewing
		-> Documents
		-> Training
		
	"Fixed spelling on notification if account has no filter assignment"
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.30
By: Tony
Date: 2019-06-11

	"Changed default GTRS EndpointURL to https://gtrsapi.gtravel.no:8078/"
	MPS4
		-> modGTRS
		
	"Modified getting of EndpointURL for User Authentication"
	MPS4
		-> modGTRS
		
	"Updated app.config bindings for https"
	CREWING
		-> app.config
		
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.29
By: Tony
Date: 2019-06-04

	"Added toggle view password in GTRS Config form"
	TRAVEL
		-> GTRS_Config
		
	"Changed GTravel website label on Travel form"
	TRAVEL
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.28
By: Tony
Date: 2019-05-15

	"Modified behavior of Delete Crew button in Archive menu tab"
	CREWING
		-> CrewList
			DeleteArchivedCrew()
		-> RecordSum
			RefreshData()

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.27
By: Tony
Date: 2019-05-15

	"Added Payroll Government Reports (SSS, Philhealth & HDMF) taken from SCM"
	ReportObjectsGovernment
		-> Monthly SSS
		-> Monthly MCR
		-> Monthly HDMF
		-> Monthly RF1
		-> Philhealth ER2
		-> Monthly R-1A

------------------------------------------------------------------------------------------------------------------------------
Comment By: Tony
Date: 2019-02-11
	CREATED A SOURCE CODE BACKUP OF LATEST VERSION AND PLACED ON THE LINK BELOW BEFORE REVERT siemDevCheck commit applied on upstream/master		
		\\server2018\Server_Data\Progs\MPS\MPS5\Generic & Development\Source Code\1.10.24

		
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.26
By: Tony
Date: 2019-02-11

	"Bug fix on saving Comments in Biodata form"
	CREWING
		-> Biodata
			- saveComments

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.25
By: Tony
Date: 2018-12-27

	"Modified Mark as Completed button in Travel Module"
	TRAVEL
		-> Travel_GTRS
		
	"Bug fix on Travel Report"
	TRAVEL
		-> rptTravel_GTRSClass

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.24
By: Tony
Date: 2018-12-27
	"Change ETA (Earliest) and ETA (Latest) labels"
	TRAVEL
		-> Travel_GTRS
		
	"Change GTRS Control to fit on user control panel"
	TRAVEL
		-> Travel_GTRS
		
	"Added Please Wait form to GTravel Transactions (Send Request, Cancel Request)"
	TRAVEL
		-> Travel_GTRS
		
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.23
By: Tony
Date: 2018-12-17
	"Added Transaction Log in GTRS Config"
	"Modified Log Transaction (insert query)"
	TRAVEL
		-> Travel_GTRS
		-> GTRSControl
		
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.22
By: Tony
Date: 2018-12-10
	"Modified behavior of Send Updates to GTravel button in Travel"
	TRAVEL
		-> Travel_GTRS
		-> GTRSControl

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.21
By: Tony
Date: 2018-12-05

	"Modified Travel Module (Integrated with GTravel)"
	TRAVEL
		-> Travel_GTRS
		-> GTRSConfig
		-> GTRSControl
		-> GTRSControl_Invalid
		Added popup form for sub details: Travel Documents, Contact Info and flight details
			-> frmPopupDetails
			-> frmPopupTravelDetails
	MPS4
		-> ServiceReference > GTRSServiceReference
		-> modGTRS
			
	"Fixed BMI computation"
	CREWING
		-> Biodata
		
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.20
By: Tony
Date: 2018-11-21

	"Bug fixed on missing events of MainView in Admin > Fleet > Agent-Vessel Mapping"
	ADMIN
		-> AgentVslMapList
		
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.19
By: Tony
Date: 2018-11-13

	"Bug Fix on Saving New Travel Records"
	TRAVEL
		-> Travel_GTRS
			- Save Data on part of : If bAddMode Then
		
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.18

By: Neil
Date: 2018-11-13

	Bugs MPS 1969 OCT 22 AWC
		MPS 1978 NOV 13 AWC
		MPS 1979 NOV 13 AWC
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.17
By: Tony
Date: 2018-11-13

	"Removed RepositorySearchItem ColumnEdit to Invoice No. field in Travel GTRS Cost"
	TRAVEL
		-> Travel_GTRS
		
	"Bug fix on GTRS Sub control when there is no account linked to the program"
	TRAVEL
		-> Travel_GTRS
		-> GTRSControl_Invalid

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.16
By: Tony
Date: 2018-11-9

	"Added ExportToExcel Class"
	UTILITIES
		-> modExcel
			- ExportToExcel Class
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.15
By: Neil
Date: 2018-11-6

	bugs -> MPS 1970 to 1979 except 1975
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.14
By: Tony
Date: 2018-10-26

	"Modified Delete (Archived) Crew function"
	MPS4
		-> CrewList
			- DeleteCrewsInArchive
			
	DATABASE
		- RunDeleteCrewInArchive
		
	"Added Log Deletion on Admin Data Tool"
	ADMIN
		-> DataUtility

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.13
By: Tony
Date: 2018-10-25

	"Added Log Deletion to All Forms in Crew and Admin"
	MPS4
		-> MPS4BasicFunctions
			- Public oLogDeletion As New LogDeletion
			
		NOTE: oLogDeletion.Init and oLogDeletion.AddLogEntryToDatabase functions has been added to most of the forms in the program
		
	ACTIVITY
	-> ContractExtension
	-> GoBack

	ADMIN
		-> AdmCashAdvance
		-> AdmDocument
		-> AdmGovtReceipt
		-> AdmKPI
		-> AdmTravelCostItem
		-> Agent
		-> Airline
		-> Airport
		-> Bank
		-> Bank
		-> CBAType
		-> Capacity
		-> CertFunc
		-> CertLimit
		-> CertType
		-> Company
		-> CompanyDefined
		-> CompetenceTemplate
		-> Country
		-> Course
		-> CourseCost
		-> CourseInst
		-> CrewCmpl
		-> Currency
		-> Department
		-> DocGroup
		-> Employer
		-> Fleet
		-> Garment
		-> GarmentType
		-> Language
		-> MedCert
		-> MgFleet
		-> MgrTech
		-> MinCrew
		-> NatInfo
		-> OtherBonusTemplate
		-> PICost
		-> PayScale
		-> PhilHealth
		-> Port
		-> PortAgent
		-> Rank
		-> RankGroup
		-> RankType
		-> Rate
		-> Relation
		-> RemitRcpt
		-> RequiredTraining
		-> SSS
		-> SSSList
		-> Signatories
		-> Status
		-> TravelDoc
		-> UniformIssueType
		-> UniformTemplate
		-> UniformTemplate
		-> Vessel
		-> VesselGroup
		-> VesselType
		-> WMBP
		-> WageASH
		-> WageAshEmp
		-> WageDen
		-> WageInfo
		-> WageONB
		-> WagePrd
		-> WageScaleCalendar
		
	CREWING
		-> Biodata
		-> Appraisal
		-> Document
		-> MedicalHis
		-> Relative
		-> Service
		-> Training
		-> Uniform
		-> UniformIssuance
		-> DocViewer
		
	KPI
		-> basKPITemplate

	MPS4
		-> MPS4BasicFunctions
			- LogDeletion Class

	PAYROLL
		-> CrewAmortization
		-> CrewWages
		-> GovtReceipts
		-> PayrollViewHA
		-> PayrollViewONB
		-> PayrollViewSA
		-> Remittances
		-> frmPayrollList
		
	PLANNING
		-> LTP
		-> Planning
		
	REPORTS
		-> basReportTemplate

	SECURITY	
		-> SecFilterAssignment
		-> SecGroup
		-> SecUser
		-> Security.vbproj
		-> basSecurity
		
	TRAVEL
		-> Travel_GTRS
		-> TravelEvent
		-> TravelEventV2
		
	DATABASE
		-> CREATE TABLE : tblLog_Deletion
		-> CREATE STORED PROCEDURE : AddDeletionLog
		-> ALTER STORED PROCEDURE : SP_SIGN_OFF
		-> ALTER STORED PROCEDURE : SP_SIGN_ON
		-> ALTER STORED PROCEDURE : SP_GOBACK
		-> ALTER STORED PROCEDURE : SP_LTP_INSERT_UPDATE
		-> ALTER STORED PROCEDURE : SP_LTP_INSERT_UPDATE_withExt
		-> ALTER STORED PROCEDURE : SP_LTP_UPDATE_PLAN
			
	
	"Fixed Behavior of sub table in Admin Uniform Template"
	ADMIN
		-> UniformTemplate
			- AddData
			
	"Modified Delete Seaman function, added LastUpdatedBy field/parameter"
	CREWING
		-> Crew
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.13
By: Neil
Date: 2018-10-24

	"Bug fix on AddData on Remittances form - clearing the Bank dropdown"
	PAYROLL
		-> Remittances
			- AddData
			
	"Modified 'Deduct Employee Contribution' checkbox and transferred to allottee details tab"
	PAYROLL
		-> Remittances
			- AddData
			
	"Bug Fix on the Process Payroll form wherein Vessel list does not clear out after changing the period and clearing the principal"
	PAYROLL
		-> PayrollProcessHA
			- cboPeriod_EditValueChanged
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.12
By: Neil
Date: 2018-10-16

	Bug	:  Activity->SignOff->After dragging crew from list to sign off list, list of crew show not in filter
			applies also to other activity forms
	modified:   Activity/GoBack.vb
	modified:   Activity/Promotion.vb
	modified:   Activity/SickOnboard.vb
	modified:   Activity/SignOff.vb
	modified:   Activity/SignOn.vb
	modified:   Activity/Transfer.vb
	modified:   Crewing/frmCrewMain.designer.vb
	modified:   Crewing/frmCrewMain.resx
	modified:   Crewing/frmCrewMain.vb
	modified:   MPS4/MPS4Functions.vb
	
	"Enabled resizing of vessel column in Process HA Payroll form"
	PAYROLL
		-> PayrollProcessHA
		
	"Bug Fix on Warnings produced on Build"
	PLANNING
		-> frmSelection
			- getCondition()
			- SelectItemsInGridSelectedByUser()
			
	ACTIVITY
		-> SignOn
			- CheckPlannedBeforeAfterSelectedDateSON()
			
		-> ContractExtension
			- gcCancel_DragDrop()
			
	TRAVEL
		-> Travel_GTRS
			- SetBookingStatusColorProperty
			- GetRemovePassengerValidationMessage()
	
		
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.11
By: Neil
Date: 2018-10-15

	Bug	:  Record count appearing in crew list is not the expected if data group by selected column	
	modified:   Crewing/CrewList_ActivityList.vb
	modified:   MPS4/MPS4BasicFunctions.vb : ShowRecordCountOnGridBand
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.10
By: Neil
Date: 2018-10-11

	Bug	: MPS does not restarting after theme has been saved
	
	modified:   BaseControl/BaseFunction.vb -> Public IS_RESTARTING As Boolean = False
    modified:   Crewing/frmCrewMain.vb -> If Not IS_RESTARTING Then...
    modified:   MPS4/ThemeControl.vb ->  IS_RESTARTING = True

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.09
By: Fords
Date: 2018-10-11

	Admin
		-> CompetenceTemplate
			- Restore course tab
			(update all related to Checklist())

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.08
By: Tony
Date: 2018-10-10

	"Bug fix on Mos Column in the Sea Service section of the Complete Biodata (Landscape) and Essential Biodata (Landscape) reports"
	ReportObjectsHistory
		-> BiodataEssential_L, BiodataComplete_L
			- changed referenced date fields to use DateStart and DateEnd instead of DateSOn and DateSOff respectively on below line of code:
				LoadDetailReport(MainReport.DetailReport_SeaServ.....
								 

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.07
By: Tony
Date: 2018-10-09

	"Bug fix on On and Off Dates in the Sea Service section of the Complete Biodata (Landscape) and Essential Biodata (Landscape) reports"
	ReportObjectsHistory
		-> BiodataEssential_L, BiodataComplete_L
			- changed binding of celSeaServOn to DateStart and
								 celSeaServOff to DateEnd

	"Bug Fix on Dragging Crews in the Crew List form when Signing On"
	ACTIVITY
		-> SignOn
			- MainGrid_DragDrop
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.06
By: Tony
Date: 2018-10-08

	"Bug fix on Add All Crew button in Onboard Wages > Add Advances form"
	PAYROLL
		-> PayAdvances

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.05
By: Tony
Date: 2018-10-08

	"Modified GTRS Config form. Added Sign Out and Change Login Buttons"
	TRAVEL
		-> GTRSConfig
		
	"Added logging functionality for every GTRS interaction"
	TRAVEL
		-> GTRSConfig, Travel_GTRS
	MPS4
		-> ModGTRS
		
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.04
By: Neil
Date: 2018-10-08

	Bug	"Date Sign On must not be Empty" prompt in adding plan event
		modified:   Planning/Planning.Designer.vb
	
	Add rank filter
		"Transfer List" report
		scripts 
			1. ALTER VIEW [dbo].[Rpt_CrewHis_Trans] 20181005.sql
			2. UPDATE_rptCrewHis_Trans 20181005.sql
			
By: Tony
Date: 2018-10-04

	"Fixed Sign On when a Planned Crew is dragged from Planned Crew list to the crew list grid"
	ACTIVITY
		-> SignOn
		
	"Fixed Crew List Grid when Crews on this grid are dragged to the same grid"
	ACTIVITY
		-> SignOn
		
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.03
By: Tony
Date: 2018-10-03

	"Modified Checking if GTRS Integration Feature is enabled"
	CREWING
		-> frmCrewMain
			- DoCheckForTravelRequestResponse()
	
	MPS4
		-> modGTRS
			- CheckForTravelRequestResponse()

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.02
By: Tony
Date: 2018-09-11

	"Bug fix on Contract Extension when month of extension is set to 0"
	ACTIVITY
		-> ContractExtension

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.10.01
By: Tony
Date: 2018-09-10

	"Modified Payroll Processing Approach for New Payroll and Add Crew to Payroll in Home Allotment Payroll and Onboard Payroll"
	PAYROLL
		-> PayrollProcessHA, PayrollProcessOnb
					
	"Changed default selected tab to Passengers tab in Travel form"
	TRAVEL
		-> Travel_GTRS
		
	"Modified Request For Amendment Parameter Caption from 'Name/Spelling' to 'Seafarer's Detail'"
	REPORTOBJECTSGOVERNMNET
		-> RAF.vb
		
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.45		
By: Fords
Date: 2018-09-06
	
	ADMIN
		- CompetenceTemplate - allow duplicate documents but with different country/capacity


------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.44
By: Tony
Date: 2018-09-05
	
	"Added Progress Bar Class"
	UTIL
		-> frmProgressBar, MPS5ProgressBarClass
		-> frmProgressBarTest (to be removed later)

	"Added Signatory to Certificate of Contribution reports (SSS, MCR, HDMF)"
	REPORTOBJECTSGOVERNMNET
		-> HDMFContriCert, MCRContriCert, SSSContriCert
		-> rptHDMFContriCert, rptMCRContriCert, rptSSSContriCert
		
	"Added selectable reason in Certificate of Contribution Reports (SSS, MCR, HDMF)"
	REPORTOBJECTSGOVERNMNET
		-> HDMFContriCert, MCRContriCert, SSSContriCert
		-> rptHDMFContriCert, rptMCRContriCert, rptSSSContriCert	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.43
By: Tony
Date: 2018-08-14

	"Renamed 'Date Expiry' Caption to 'Date Expiry / Date Ended' in Exp Docs Popup form"
	CREWING
		-> frmPopupExpDoc

	"Set Filter Option column width to Auto size - so to auto adjust based on screen size and resolution"
	Reports
		-> FilterControlDefault
			- set width of columns FCaption and FDisplayValue to 75
	
	"Fixed Sorting of Nationality and Vessel in Crew List Filter"
	MPS4
		-> CrewListFilter
			- Modified InitControls()
				If tmpdt.Rows.Count > 0 Then
					dttblAdmVsl = tmpdt.Select("VslStat<>2").CopyToDataTable
					Dim dv As DataView = New DataView(tmpdt)
					dv.Sort = "Name asc"
					dttblAdmVsl = dv.ToTable
				Else
					dttblAdmVsl = tmpdt
				End If
				
				.cboNat.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Nat FROM dbo.CntryList ORDER BY Nat ASC")   'fixed by tony20180815 - changed Name to Nat

	"Modified Resizing of Travel - GTravel form"
	Travel
		-> Travel_GTRS

	"Modified ReportConfig - added preview of filteroption or selectionsource data source"
	Reports
		-> ReportConfig
		- added forms:
			-> frmFilterOptionDataSample.vb
			-> frmSelectionSourceDataSample.vb
			
	"Set AllowCustomization of main LayoutControl to false"
		-> MPS4/frmConnect.vb
		-> MPS4/frmLogin.vb
		-> MPS4/frmChangePassword.vb
		-> MPS4/frmActivate.vb
		-> MPS4/ThemeControl.vb
		-> MPS4/UserPreference.vb
		
		-> Planning/frmCheckList.vb
		-> Planning/frmPopUpCrew.vb
		-> Planning/frmSelection.vb
		
		-> Payroll/PayrollFilter.vb
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.42
By: Tony
Date: 2018-08-04

	"Modified Individual Reports - Added collation if generated from archive to fix report has no data"
	ReportObjectsIndividual
		- modified report datasource construction of the following classes
			-> BiodataComplete
			-> BiodataComplete_L
			-> BiodataEssential
			-> BiodataEssential_L
			-> Medical
			-> SeaServ
			-> ServiceHistory
			-> SeaServCertification
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.41
By: Tony
Date: 2018-07-31

	"Modified Allotment Slip Report"
	ReportObjectsGovernment
		-> AllotSlip
			modified line of code 
			FROM:
				BindData(MainReport.celBankName, "Text", Nothing, "BankName")
			TO:
				BindData(MainReport.celBankName, "Text", Nothing, "BankBranchName")
				
	DATABASE
		- altered the following views:
			- Rpt_Remittance
			- Rpt_AllotSlip

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.40
By: Tony
Date: 2018-07-30

	"Fixed Behavior of Remittance form"
	PAYROLL
		-> Remittance
			- fixed error when adding new record with empty allottees
			- added new bank combo box with "Bank - Branch" list format
			- modified SaveData to used new bank combobox/dropdown

	ADMIN
		-> Bank
			- modified Branch list. Added Branch Name column

			
	DATABASE
		- (See scripts in 75 - 20180731 - Add BranchName field to Bank Branch Table)
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.39
By: Tony
Date: 2018-07-28

	"Added Templates Folder Browser"
	ADMIN
		-> added ProgramSettings_Templates
		-> ProgramSettings
			added button to txtTemplateFolder
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.38
By: Tony
Date: 2018-07-25

	ReportObjectsGovernment
		-> RAF
			- modified caption of those that gets if checked
			
			
	MPS4 
		-> frmLogin
			- removed selection of first entry in user list if first run
			
	PAYROLL
		-> frmPayrollList
		-> PayrollViewHA, PayrollViewONB, PayrollViewSA
			- modified calling of frmPayrollList which refreshes the payroll form if a payroll is deleted from frmPayrollList

	"Modified Print Biodata in Crew List form"
	CREWING 
		-> ReportSelectionInd
		
	"Modified GetCondition in Present Record Class to handles entries with Apostrophe"
	REPORTS
		-> basReports
		
		
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.37
By: Tony
Date: 2018-07-15

	"Added feature to print Custom POEA Contract"
		CREWING
			- added form frmPopupPrintPOEAContract
			-> CrewListActivityList, CrewList
				- added "Print POEA Contract" in right-click menu
				- modified rightClickMenu click event
			
		REPORTOBJECTSGOVERNMNET
			- modified POEACont
			
		REPORTS
			-> ReportDetail class
				- added sub class Parameters
				- added variable Params
				
		DATABASE
			- inserted "PrintCustomPOEAContract" in tblObjects
			
	
	"Modified Payroll Vessel List form"
		PAYROLL
			-> frmVslList
				- shown Delete button when listing vessels 
				  has checking if has permission to delete
				- added function for deleting payroll
				- added header to show text what type of payroll are listed
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.36
By: Tony
Date: 2018-07-09

	REPORTOBJECTSOTHER
		- added reports
			-> rptUniformIssuanceSummary
			-> rptOngoingMedicalStatus
		- added class
			-> UniformIssuanceSummary
			-> OngoingMedicalStatus		

	ReportObjectsIndividual
		-> BiodataPage1
			- Fixed building of datasource
			- added try catch in added beforeprint handlers on sub reports
			
		-> rptBiodataPage1
			- Modified beforeprint events for chkMale and chkFemale to properly handle the fields required.
			
		-> BiodataPage2
			- Modified datasource generating codes where "Replace(REPORT_DETAIL.GetMainReportFilter(GetUserFilterString()), "idnbr", "FKeyIDNbr")" is called
			- CHANGED 
					Replace(REPORT_DETAIL.GetMainReportFilter(GetUserFilterString()), "idnbr", "FKeyIDNbr")
			  TO
					Replace(REPORT_DETAIL.GetMainReportFilter(GetUserFilterString()), "IDNbr", "FKeyIDNbr")
					
	ADMIN
		-> CompetenceTemplate
			- edited parameters of sub PopulateRepository
				CHANGED:
					Public Sub PopulateRepository(tableName As String, criteria As String, repository As RepositoryItemLookUpEdit)
					
				TO:
					Public Sub PopulateRepository(tableName As String, criteria As String, repository As RepositoryItemLookUpEdit, Optional OrderByString As String = "")
					
			- edited InitControls()
				CHANGED:
					PopulateRepository("dbo.tblAdmRank", "", RepRank)
					PopulateRepository("dbo.tblAdmRank", "", RepSec)
					
				TO:
					PopulateRepository("dbo.tblAdmRank", "", RepRank, "Name Asc")
					PopulateRepository("dbo.tblAdmRank", "", RepSec, "Name Asc")

		-> Status
			- Shown editing if status is a Medical Status also for Ashore Activities
			
		-> VesselList
			- shown GroupPanel
	
	ACTIVITY
		-> SignOff
			- modified sign off check if the selected Next Activity is set as "Medical Status"
			  if yes, a popup form will appear where user can input the Medical (History) Status details
			  
		-> AshoreActivity
			- modified adding of Ashore Activity and check if the selected Next Activity is set as "Medical Status"
			  if yes, a popup form will appear where user can input the Medical (History) Status details
			  
	PAYROLL
		-> Remittance
			- modified form design
			- modified Amount columns columnedit property of gcOtherEarnings and gcOtherDeductions and gvAllotment to properly mask the amount "n2"
			- modified CheckRequiredFields function
			  
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.35
By: Tony
Date: 2018-06-27

	ADMIN
		-> Vessel.vb
			- modified loading of datasource of cboFKeyWScaleCode

	CREWING
		-> UniformIssuance
			- modified setting of Sea Service Selection Repository datasource in LoadSub
				CHANGED
					repSS.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.view_SeaServiceSelection WHERE FKeyIDNbr = " & ChangeToSQLString(strID) & " ORDER BY seq desc")
					
				TO
				
					repSS.DataSource = MPSDB.CreateTable("EXEC dbo.GenerateSeaServSelection " & ChangeToSQLString(strID))
				
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.34
By: Fords
Date: 2018-06-25

	CREWING
		-> frmCrewMain
			- added function DoCheckForTravelRequestResponse()
			- changed sub CheckForTravelRequestResponse to function DoCheckForTravelRequestResponse in LoadContent
	
	TRAVEL
		-> Travel_GTRS
			- removed isConfirmed and isTravelCompleted checkbox controls and associated procedures and functions
			- added btnCompleted button
			
		-> Travel_GTRS_List
			- added Show Completed List filter Option
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.33
By: Fords
Date: 2018-06-22

	CREWING
		-> SignOn
			- show ashore crew only in Planned Crews grid

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.32
By: Tony
Date: 2018-06-13

	REPORTOBJECTSPAYROLL
		- Added Home Allotment Payslip Per Vessel
		  added the ff. controls:
			-> rptPayHAReportCrewPerVsl
			-> PayHACrewPerVsl
			
	REPORTS
		-> FilterControlDefault
			- added DefaultValue column in GridFilterView
			- added sub LoadFilterOptionDefaultValues() which loads the default value as set for the report
			
	ADMIN
		-> CrewCmpl
			- Changed Sorting of Ranks from SortCode to Name
			
	CREWING
		-> frmCrewMain
			- added rpgTravelRefresh ribbonpagegroup on rpTravel ribbonpage
			

VERSION: 1.09.31
By: Fords
Date: 2018-06-13
	
	UTILITIES
		- Function: AssignCrewListPerm(DataTable)
			- applied to function get_permissions_all()

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.30
By: Tony
Date: 2018-06-05

	ADMIN
		- Renamed the following objects
			-> OtherBonus to OtherBonusTemplate
			-> OtherBonusList to OtherBonusTemplateList
			-> OtherBonus_copyRankAndDetails to OtherBonusTemplate_copyRankAndDetails
			
		-> OtherBonusTemplate, OtherBonusTemplateList
			- modify design to use template-based records instead of being assigned to principal
			
		-> OtherBonusTemplate
			- added error catch when calling LoadSub
			
		-> Vessel
			- added With66KVSwitchboard checkbox and OtherBonus Template selection
			- modified saving to save the above fields
			- set displayformat and editformat of the ff. controls:
				- Date Active
				- Date Inactive
				- Vessel History (Date Change)
				
		-> AdmTravelCostItemList
			- Added display for record count
			- Added menu button icon
			
	CREWING
		-> Travel_GTRS
			- removed "Imports MPS4.GTRSServiceReference"
			- individually called GTRSServiceReference controls directly from MPS4.GTRSServiceReference
			  instead of just "CancelPassenger", the object is declared/called as "MPS4.GTRSServiceReference.CancelPassenger"				
			
	UTILITIES
		-> Util
			- added sub AssembleUpdateSript (for LayoutControlGroup and LayoutControlItem parameters)
			- Added Function GenerateUpdateScript_Recursive with similar contents of GenerateUpdateScript but uses recursive approach with the help of the AssembleUpdateSript subs

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.29
By: Tony
Date: 2018-06-04

	TRAVEL
		-> Travel_GTRS_List
			- added highlight if received new reply from GTravel
			- modified Unread field source to "isUnread"
			
		-> modGTRS
			- added setting of Unread if newly had received response from GTravel
			- modified Unread field source to "isUnread"

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.28
By: Tony
Date: 2018-06-01
	
	ADDED TRAVEL INTEGRATION WITH GTRAVEL
	
	TRAVEL
		- Added forms
			-> Travel_GTRS
			-> Travel_GTRS_List
			-> GTRSConfig
			-> frmAddFromPlanningEvent
			-> frmCopyBookingDetails
			
		- Added Report
			-> rptTravel_GTRS

		- Added way to load Planning Event to GTravel
		- Modified GTRS Config 
		- Added Planning Event Label text in Travel Details
		
	MPS4
		- Added Service Reference
			-> GTRSServiceReference
			
		- Added form for notification when receiving response from GTravel
			-> frmGTravelNotif
			
		- Added module
			-> modGTRS
		
	ADMIN
		-> Added Admin Travel Cost Items form

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.28
By: Tony
Date: 2018-05-25

	ADMIN
		-> PhilHealth
			- Added Rate Field
			- Modified loading and saving of data
			
		-> PhilHealthList
			- Added Rate Field
			
	DATABASE
	
		- Added Rate field in MCR Table
		- Modified view frmPhilHealth
		- Modified functions GetMCREmployee and GetMCREmployer
		
	CREWING
		-> Biodata
			- Removed BandedGridColumn3, PKey and haExpiringDocs columns from customizationform
			
	REPORTS
		-> ReportConfig
			- Adjusted ColumnHeaderAutoHeight on FilterOptions grid

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.27
By: Tony
Date: 2018-05-22

	ADMIN
	
		-> OtherBonus
			- Modified loading of Sub Details when Edit button is clicked
			- Fixed updating of all views's datasource after deleting a record in it

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.27
By: Tony
Date: 2018-05-22

	CREWING
		-> Biodata
			- renamed the following controls:
				LayoutControlItem18 = lciBloodType
				LayoutControlItem29 = lciHairColor
				LayoutControlItem31 = lciEyeColor
				LayoutControlItem33 = lciBMI
				LayoutControlItem36 = lciNatInfoGrid
				TabPage1 = tabNameAndRank
				TabPage2 = tabAddr
				TabPage4 = tabNatInfo
				TabPage5 = tabComments
				TabPage6 = tabFormerCompany
				TabPage7 = tabConflictWithCrew
				LayoutControlItem19 = lcigridCrewConflict
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.26
By: Tony
Date: 2018-05-22

	ADMIN
		-> frmAdmMain
			- added Other Bonus menu item in WagesMenu menu control
			
		-> OtherBonus, OtherBonusList
			- added user controls for Admin Other Bonus
		
		-> OtherBonusCopyRankAndDetails
			- added form for Copy Rank+Details
			  
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.25
By: Tony
Date: 2018-05-011

	CREWING
		-> Biodata
			- modified size and text position of uniform size fields
		-> UniformIssuance
			- Changed grouping of Size Information in UniformIssuance form
			  Added LayoutControlGroup for the Size Information fields
			  

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.24
By: Tony
Date: 2018-05-09

	CREWING
		-> CrewListActivityList
			- Added code below on first line of RefreshData
				MainView.OptionsView.ColumnAutoWidth = True
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.23
By: Tony
Date: 2018-05-09

	CREWING
		-> CrewListActivityList
			- Added Tooltip display when mouse is hovered over the last name or due date saying that the crew's contract is overdue or crew's contract is about to due within x days
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.22
By: Tony
Date: 2018-05-05

	CREWING
		-> Biodata
			- Modified BMI Field to auto-compute based on the weight and height fields
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.21
By: Tony
Date: 2018-05-05

	CREWING
		-> Biodata
			- Added Blood Type, Hair Color, Eye Color and BMI fields
			
	UTILITIES
		-> CrewDetails
			- Added HairColor, EyeColor and BMI properties
			
	DATABASE
		-> tblcrewinfo
			- Added HairColor, EyeColor and BMI fields
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.20
By: Fords
Date: 2018-04-27

	CREWING
		-> CrewList
			- modified function GetDesc. changed output to crew name with format: <lname>, <fname> <m.i.> - <rank>
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.19
By: Fords
Date: 2018-04-24

	CREWING
		-> Service
			- modified saving of other seaservice wherein saved value of activity type is always NULL

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.18
By: Fords
Date: 2018-04-11

	CREWING
		-> Biodata
			- on Add New Crew, always starts in Name and Rank tab
	
	PLANNING
		-> Planning
			- Crew To Relieve column show same rank only (to reflect LTP)
	
	PAYROLL
		-> fixed behaviour of Delete button on empty views

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.17
By: Fords
Date: 2018-03-14

	CREWING
		-> Crew list
			- popup Contract Extension icon in Activity List

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.16
By: Fords
Date: 2018-03-13

	CREWING
		-> Crew list
			- show popup Contract Extension in Activity List

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.15
By: Fords
Date: 2018-03-01

	ACTIVITY
		-> Contract Extension
			- add details in tblContractExt instead of adding new service.
			- cancel of contract extension
	
	DATABASE
		-> Table
			- tblContractExt
			
		-> Stored Procedure
			- SP_CONTRACT_EXTENSION
			- SP_Crewlist_Activities
			- SP_Crewlist_Main
			- SP_Crewlist_Main_SpeedTest
		
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.14
By: Tony
Date: 2018-01-31

	CREWING
		-> frmPopUpDeleteCrew
			- Modified design. Added Form image and crew biodata photo
			
		-> Biodata
		
		-> Crew
			- modified Delete Seaman code and completion/validation messages
		
	MPS4
		-> MPS4Functions
			- added function GetCrewBiodataPhoto and GetCrewPhotoPath which returns the string file path of the crew biodata photo path
			
	UTILITIES
		-> Util		
		

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.13
By: Tony
Date: 2018-01-29

	ACTIVITY
		-> SignOn
			- Fixed GetSelectedPlanRows(), added Nat column
			
		-> Transfer
			- Added 'New Wage Scale Rank' in RequiredFields Check
			- Modified dragging of new crew wherein if there is no default wage scale for the vessel to transfer to, use the crew's current wage scale.
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.12
By: Tony
Date: 2018-01-29

	ReportObjectsIndividual
		-> BiodataComplete_L
			- modified data source to retrieve date first employed (date first signed on) information
			- fixed bind source of Nationality field
		
		-> BiodataEssential_L
			- modified data source to retrieve date first employed (date first signed on) information
			- fixed bind source of Nationality field			
			
	REPORTS
		-> ReportSelection
			- modified drag-and-drop data selection to retain toprowindex when a data is (are) selected
			- added labels 'Available Records' and 'Selected Records' in Record Selection grids
	
	DATABASE
		-> rpt_CrewActFirstVoyahge
			- modified sql source
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.11
By: Neil
Date: 2018-01-23

	Add default Wage Scale on Sign On, Promote, Transfer 
		Activity/Promotion.Designer.vb
		Activity/Promotion.vb
		Activity/Transfer.Designer.vb
		Activity/Transfer.vb
		MPS4/modCustom.vb
		Activity/SignOn.vb

	Added entry for Default Wage Scale per nationality 
		Admin/Vessel.Designer.vb
		Admin/Vessel.vb

		MPS4/MPS4.vbproj
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.10
By: Tony
Date: 2018-01-18

	CREWING
		-> CrewList
			- placed 'View Essential Info' on top of popup menu
			
		-> Biodata
			- modified the validation when switching the tab and adding a new crew wherein the Name and rank must be saved first.
			
	PLANNING
		-> frmLTPCrewList
			- modified Filter Panel so that the sub user control cannot be dragged
			
	ACTIVITY
		-> SignOn
			- Modified validation when a planned crew is dragged to the crew selection and if the planned date sign on is before or after the selected sign on date.
			
	REPORTS
		-> ReportSelection
			- modified RefreshData to clear the find panel when switching to from one report to another

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.09.09
By: Tony
Date: 2018-01-14

	ADMIN
		-> Course
			- added Repeat Course Training tab
			
	CREWING
		-> Training
			- added notification on course training data if need to be retaken
		-> CrewList
			- adding procedure AddToLogTransfer()
			
	DATABASE
		-> added tblAdmCourseRetake
		-> added function CheckCourseForRetake
		-> altered view frmCrew_Training
		-> added tblLog_Transfer
			
	UTILITIES
		-> Util
			- added enum TransferType
			- added structure TransferTypeTableValue

	MPS4
		-> UserPreference
			- added configuration for no. of days within a crew training course is to be checked if to be retaken.
			
	ReportObjectsHistory
		-> HistoricalCrewList, rptHistoricalCrewList
			- Added Date Of Birth field after Nationality

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.9.8
By: Tony
Date: 2018-01-09

	ADMIN
		-> Logo
			- modified saving of Logo
			
	UTILITIES
		-> Util
			- added GetLogoAndHeaderAdminDir function

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.9.7
By: Tony
Date: 2018-01-08

	BASECONTROl
		-> BaseControl
			- added event 'ProcessedPayrollListVisibility' and procedure 'SetProcessedPayrollListVisibility' to hide and show Processed Payroll Ribbon Page Group
			
	CREWING
		-> frmCrewMain
			- added procedure 'ProcessedPayrollListVisibility' to hide and show Processed Payroll Ribbon Page Group
			
		-> UniformIssuance
			- fixed Size Information label forecolor to FireBrick red
			
		-> CrewListActivityList
			- Modified Essential Info flyout form: added message after information is copied to clipboard; closes flyout form if visible and right-click menu is shown
			
	
	PAYROLL
		-> ProcessHA, PayrollProcessOnb, PayrollProcessSA, PayrollViewHA, PayrollViewONB, PayrollViewSA
			- modified initcontrol procedure in forms and controls under payroll tab so they show and hide the processed payroll ribbon page group accordingly 
	
	REPORTS
		-> ReportSelection
			- modified initcontrol procedure to hide the processed payroll ribbon page group 
			
		-> clsFilterOptionValues
			- Fixed Clear Filter button so that it does not remove custom Filter Option Control
			
	REPORTOBJECTSPAYROLL
		-> rptCrewWageAcct
			- corrected typo error on affirmation text below report
			
	ADMIN
		-> UniformTemplate
			- Fixed bug in saving Quantity in Uniform Template
			
		-> Added Record Count Header to the MainGrid of the following forms:
			- DepartmentList
			- VesselGroupList
			- AgentVslMapList
			- AgentList
			- WageDenList
			- WagePrdList
			- CompetenceTemplateList
			- RemitRcptList
			- WageScaleCalendarList
			 
			
	PLANNING
		-> LTP
			- Disabled timeline zoom in/out in LTP
			
	ACTIVITY
		-> SignOff, AshoreActivity
			- Resets the Next Activity and Ashore Wage Scale to default value after clicking Save button
			- Set clear button on Ashore Wage Scale dropdown to set value to default value instead of clearing it
			
	QUALIFICATIONMATRIXREPORTS
		-> rptQualificationExperienceMatrixReport, rptReportVersion1, rptReportVersion2, rptReportVersion3, rptReportVersion4, rptTCC1, rptVettingMatrixReportChevronTotal, rptVettingMatrixReportConocoPhilips, rptVettingMatrixReportKoch, rptVettingMatrixReportShell
			- add call to open wait form when loading data and closes wait form when showing the report
			
		-> WaitForm1
			- added new object
			
		-> modQualificationMatrixReports
			- added new module with subs OpenWaitForm and CloseWaitForm
			

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.9.6
By: Tony
Date: 2018-01-02

	CREWING
		-> frmCrewMain
			- added tooltip in rowindicator of crew list form which shows if document has expired or about to expire
			
	MPS4
		-> UserPreference
			- added icon indicator for expired and expiring documents in User Settings form
			
	ADMIN
		-> Status
			- fixed auto sizing of controls related to Medical Status

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.9.5
By: Tony
Date: 2017-12-29

	ADMIN
		-> Status
			- renamed checkbox and label description for Medical Status checkbox

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.9.4
By: Tony
Date: 2017-12-28
	
	PLANNING
		-> LTP
			- modified format of menu buttons in Right Click menu
			- removed mouse over event to display popup details. Placed in right click menu instead as a "View Information" button
			- modified behavior of Copy, Paste and Delete buttons in right click menu
			- modified POpup Information form to show in center instead of based on mouse locations
			- added validation message on Delete button if no data is selected
			- changed label in Lacking Document in popup crew detail form to "Qualification Check"
			- added tooltip on row indicator in popup crew detail form "Qualification Check"
			- added validation when dragging a planned crew to another row level while crew is currently set as a reliever of another crew
			
	CREWING
		-> frmCrewMain
			- removed "Quick Access Toolbar" popupmenu on RibbonControl
			
	ADMIN
		-> frmAdmMain
			- removed "Quick Access Toolbar" popupmenu on RibbonControl

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.9.4
By: Tony
Date: 2017-12-22

	ADMIN
		- added Record Count header in the ff Lists:
			CertTypeList
			TravelDocList
			LanguageList
			RateList
			PICostList
			RankList
			CapacityList
			CertFuncList
			CertLimitList
			CourseInstList
			CourseList
			MedCertList
			NatInfoList
			CompanyDefinedList
			PortList
			CompanyList
			CrewCmplList
			EmployerList
			FleetList
			MgFleetList
			MinCrewList
			MgrTechList
			VesselList
			VesselTypeList
			CBATypeList
			AirlineList
			AirportList
			BankList
			CurrencyList
			WageASHList
			WageAshEmpList
			WageInfoList
			WageOnbList
			AdmCashAdvancesList
			PayScaleList
			RelationList
			RankTypeList
			StatusList
			GarmentTypeList
			GarmentList
			UniformIssueTypeList
			UniformTemplateList
			CountryList
			PortAgentList
		

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.9.3
By: Tony
Date: 2017-12-21

	ADMIN
		-> Status
			- modified saving of Retention Rate Termination Type
			- added "Not Applicable" in the type of Retention Rate Terminations
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.9.2
By: Tony
Date: 2017-12-20

	CREWING
		-> UniformIssuance
			- set intial value of issue type to "Standard" when adding a new record
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.9.1
By: Tony
Date: 2017-12-18

	CREWING
		-> frmCrewMain
			- modified LTP saving last selected vessel/rank  
			
		-> UniformIssuance
			- added label "Note: These information are read only. Go to the Biodata form to edit any of these information."
			
	MPS4
		-> frmLogin
			- modified validation when logging in without username and/or password

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.9.0
By: Tony
Date: 2017-12-15
 
	PLANNING
		-> LTP
			- added filter vessel/rank functionality
			- modified LTPShowAllRecords procedure to capture vessel/rank filter
			
	CREWING
		-> frmCrewMain
			- added Filter Rank(s)/ Filter Vesseol(s) button to be used by LTPShowAllRecords
			- set Show All Ranks (Vessels) button used by LTP to hidden 
			
	UTILITIES
		-> Util

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.32
By: Neil
Date: 2017-12-14

	QUALIFICATION
		modified:   Qualification/QualificationMatrix.Designer.vb
					QualificationMatrixRepo rts/QualificationMatrixReports.vbproj
		
		add:	QualificationMatrixReports/Classes/rptTCC1.vb
				QualificationMatrixReports/Reports/TCC1.Designer.vb
				QualificationMatrixReports/Reports/TCC1.resx
				QualificationMatrixReports/Reports/TCC1.vb

			-> add TCC QUALIFICATION MATRIX REPORT
		
	Crew
		-> Document
			- Bug fix on date expiry checking
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.31
By: Fords
Date: 2017-12-15

	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.31
By: Tony
Date: 2017-12-12

	Admin
		-> AgentVslMap
			- Bug fix on double-clicking when not in Edit mode
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.30
By: Fords
Date: 2017-12-08

	MPS4
		-> MPS4Functions.vb (AttachDocument class)
			- modify saving file format
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.29
By: Tony
Date: 2017-12-07

	Reports
		-> rptHeader
			- set pbLogo anchor property from "right" to "left"
			
	ReportObjectsOther
		-> rptCrewListAll.vb
			- added PageHeader
			- moved contents of ReportHeader to PageHeader
			- added MPS5 default Header
			- set backcolor of column labels to gray
			- set GroupFooter to PageBreak AfterBandExceptLastEntry
			
		-> rptCrewListAll_Agent.vb
			- added PageHeader
			- moved contents of ReportHeader to PageHeader
			- added MPS5 default Header
			- set backcolor of column labels to gray
			- set GroupFooter to PageBreak AfterBandExceptLastEntry
			
		-> rptCrewListAll_Prin.vb
			- added PageHeader
			- moved contents of ReportHeader to PageHeader
			- added MPS5 default Header
			- set backcolor of column labels to gray
			- set GroupFooter to PageBreak AfterBandExceptLastEntry
			
	MPS4
		-> frmLogin
			- encrypted LastUser when saved in setting.ini

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.28
By: Tony
Date: 2017-12-05

	Crewing
		-> frmActivityList
			- set MainGrid ColumnHeaderAutoHeight property to true
			- modified DateDep, DateArr, DateSOn and DateSOff fields to ActDateDep, ActDateArr, ActDateSOn and ActDateSOff
			
		-> Service
			- set proper columnedit property of DateDep and DateArr columns in MainGrid
			- Bug fix on saving in Other Sea Service form.
			- modified DateDep, DateArr, DateSOn and DateSOff fields to ActDateDep, ActDateArr, ActDateSOn and ActDateSOff
			
		-> frmCrewMain
			- revised confirmation message when closing the program to "Are you sure you want to exit the MPS5 Crew?"
	MPS4
		-> frmLogin
			- modified reloading of last user when remmember password is not enabled
			
	Admin
		-> frmAdmMain
			- revised confirmation message when closing the program to "Are you sure you want to exit the MPS5 Admin?"
			

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.27
By: Neil
Date: 2017-12-05

	modified:   Admin/frmAdmMain.designer.vb
				Admin/frmAdmMain.resx
				Admin/frmAdmMain.vb
				Crewing/frmCrewMain.designer.vb
				Crewing/frmCrewMain.resx
				Crewing/frmCrewMain.vb
					-> add close button
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.26
By: Neil
Date: 2017-12-05


	modified:   ReportObjectsOther/ReportObjectsOther.vbproj
	added:
        ReportObjectsOther/Class/clsCrewListAll.vb
        ReportObjectsOther/Class/clsCrewListAll_Agent.vb
        ReportObjectsOther/Class/clsCrewListAll_Prin.vb
        ReportObjectsOther/Reports/rptCrewListAll.Designer.vb
        ReportObjectsOther/Reports/rptCrewListAll.resx
        ReportObjectsOther/Reports/rptCrewListAll.vb
        ReportObjectsOther/Reports/rptCrewListAll_Agent.Designer.vb
        ReportObjectsOther/Reports/rptCrewListAll_Agent.resx
        ReportObjectsOther/Reports/rptCrewListAll_Agent.vb
        ReportObjectsOther/Reports/rptCrewListAll_Prin.Designer.vb
        ReportObjectsOther/Reports/rptCrewListAll_Prin.resx
        ReportObjectsOther/Reports/rptCrewListAll_Prin.vb
			-> new reports Crewlist All (All/Agent/Principal)

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.25
By: Tony
Date: 2017-11-29
	Crewing

		-> frmActivityList
			- added DateDep, DateSOn, DateSoff and DateArr
			- removed unnecessary columns from customuzationlist
			
		-> Service
			- added DateDep and DateArr
			- removed unnecessary columns from customuzationlist
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.24
By: Neil
Date: 2017-11-28

	Security/SecGroup.vb
		-> bug fix 
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.23
By: Fords
Date: 2017-11-27

	Crewing
		--> Crewlist.vb and CrewList_ActivityList.vb
			- r-click popup crew Travel Info
		
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.22
By: Tony
Date: 2017-11-27

	ReportObjectsOther
		--> added report PlannedCourseCrewList on Crew Training Category
		
		
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.21
By: Fords
Date: 2017-11-27

	ReportObjectsIndividual
		--> added reports : BiodataComplete (Landscape) and BiodataEssential (Landscape)
		

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.20
By: Tony
Date: 2017-11-26

	ReportObjectsHistory
		--> rptHistoricalCrewList and HistoricalCrewList
			- added DateDep, DateSOn, DateSOff, DateArrival fields

By: Tony
Date: 2017-11-27

	Security/SecGroup.Designer.vb
	Security/SecGroup.vb
		-> amend assigning of objects permission. "view only" will be checked if any or all of the edit permissions(add,delete,update) are checked.
			and unchecked all if "view only" is unchecked
				
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.19
By: Tony
Date: 2017-11-25

	ReportObjectsIndividual
		--> rptCrewList.vb AND CrewList.vb
			- added DateSign On
			- fixed datedeparted column
			- replaced age with date of birth
			- added former vessel column
				
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.18
By: Tony
Date: 2017-11-25

	Crewing
		--> frmCrewMain.vb
			- added new report categories on Reports page tab
				Crew Training
				All Crew

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.17
By: Fords
Date: 2017-11-25
	
	Crewing
		--> CrewListFilter.vb
			- added ff. filters:
				Rank Type
				Rank Group
				Vessel Type
				Vessel Group
	
	Database
		--> SP_Archived_Crewlist_Activities, SP_Crewlist_Activities, SP_Crewlist_Main, SP_Crewlist_Main_SpeedTest
			- added columns
				FKeyRankTypeCode
				FKeyRankGrpCode
				FKeyVslGrpCode
				FKeyVslTypeCode

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.16
By: Tony
Date: 2017-11-25

	Crewing
		--> Biodata.vb
			- added the ff. fields in the display and in the loading and saving procedures:
				ShoeSize
				CoverallSize
				PoloSize
				PantsSize
				
		--> RecordSum.vb
			- added the ff. fields
				ShoeSize
				CoverallSize
				PoloSize
				PantsSize
			- added controls padding to 4,4,0,12 in the .root layoutcontrol group
			
		--> UniformIssuance.vb
			- added the ff. fields and grouped as Size Info
				ShoeSize
				CoverallSize
				PoloSize
				PantsSize
				
		--> Training.vb
			- added Clear button to lookupedits and dateedits
				
	ReportObjectsIndividual
		--> BiodataComplete
			- modified main datasource; added the ff. fields in the main datasource construction
				ShoeSize
				CoverallSize
				PoloSize
				PantsSize
				
		--> rptBiodataComplete
			- added the ff. in the report format/layout
				ShoeSize
				CoverallSize
				PoloSize
				PantsSize
				
	ReportObjectsHistory
		--> HistoricalCrewList.vb
			- Fixed datasource of SignOffList and SignOnList reports
		
		--> rptHistoricalSignOffList.vb
			- Removed Deck Column
			- Rearranged column
			- Change report title to "SIGN OFF LIST"
			- added row number
			
		--> rptHistoricalSignOnList.vb
			- Removed Deck Column
			- Rearranged column
			- Change report title to "SIGN ON LIST"
			- added row number
			
		--> rptHistoricalCrewList.vb
			- Removed Deck Column
			- Changed Rank displayed to abbreviation instead of name
			- Rearranged column
			- added row number
			
		--> rptSOffDueToMedReason.vb
			- Removed Deck Column
			- Changed Rank displayed to abbreviation instead of name
			- Rearranged column
			- added row number
			
		--> SOffDueToSpecificReason.vb
			- Removed Deck Column
			- Changed Rank displayed to abbreviation instead of name
			- Rearranged column
			- added row number
			
		--> CrewHis_SeaServ.vb
			- Modified text in Group Header: added underline
			
		--> CrewHis_Prom.vb
			- Removed Deck Column
			- Rearranged column
			- added row number
			
		--> CrewHis_Trans.vb
			- Removed Deck Column
			- Rearranged column
			- added row number
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.15
By: Tony
Date: 2017-11-24

	Security
		--> SecUser.vb
			- Added FullName, Description, EmployeeID and ContactInfo fields in form design, SaveData and RefreshData
			
		--> UserList.vb
			- Added FullName, Description, EmployeeID and ContactInfo when loading the data
			
	Utilities
		--> clsSecurity
			- Modified add_user: added FullName, Description, EmployeeID and ContactInfo
			- Modified update_user: added FullName, Description, EmployeeID and ContactInfo
		--> Util
			- Added GenerateFileTag function
			
	Database
		- modified Stored Procedures:
			sec_update_user
			sec_add_user
			
		- modified views:
			frm_Login
			
		- modified table
			MSysSec_Users: added FullName, Description, EmployeeID and ContactInfo
			
		- added stored procedures related to GenerateFileTag function created in Utilities.Util.vb
			GenerateAlphaNumericString
			GenerateID
			GenerateFileTag
			
	ReportObjectsIndividual
		--> BiodataComplete.vb AND BiodataEssential.vb
			- modified datasource construction of SubReport_SeaServ 
		
		- Change details font size to 9 on the following sub reports and added (bottom) border topmost rowcell:
			rptBiodataSub_Cert.vb
			rptBiodataSub_CourseCompl.vb
			rptBiodataSub_CourseReq.vb
			rptBiodataSub_Educ.vb
			rptBiodataSub_Sbk.vb
			rptBiodataSub_SeaServ.vb
			rptBiodataSub_TravelDoc.vb
			
		--> rptBiodataSub_SeaServ.vb
			- adjusted column sizes
			
			
			
	ReportObjectsAshore
		--> rptCrewWithSpecificCourse.vb
			- adjusted column widths
			
	Admin
		- added GenerateFileTag in AddData
			--> CertType.vb
			--> TravelDoc.vb
			--> Medcert	.vb
			--> NatInfo.vb
			--> CompanyDefined.vb

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.14
By: Tony
Date: 2017-11-24

	Admin 
		--> UniformTemplate
			- added Qty column in SubGrid and in SaveData function/procedure
			- added checking in SubGridView.ShownEditor to filter out items already selected in the grid.
			
	Crewing
		--> UniformIssuance
			- added Qty column in MainGrid and in SaveData function/procedure

------------------------------------------------------------------------------------------------------------------------------			
VERSION: 1.8.13
By: Neil
Date: 2017-11-23

	Security/GroupList.vb
	Security/SecGroup.vb
		--> enhancement security form
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.12
By: Neil
Date: 2017-11-23

	Admin/frmAdmMain.vb
	BaseControl/BaseControl.vb
	Utilities/clsSecurity.vb
		--> amend checking of button permission on basecontrol refresh data. if user is admin, still check the permissions A,E,D of a button.
			because some button only have certain permission. ex. edit only...
	script	
		--> Z:\Progs\MPS 5\DB Scripts\19- 20171121 - button permission checking
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.11
By: Tony
Date: 2017-11-17

	Crewing
		--> frmCrewMain 
			- renamed variable 'found' to 'foundContentToLoad'
			- modified sub RibbonControl_SelectedPageChanged for cases of ribbonpage with multiple ribbonpagegroup with groupindex of 1
				changed line of codes:
				FROM:
					If found Then
                        found = False
						Exit For
                    End If
					
				TO:
					If foundContentToLoad Then
                        foundContentToLoad = False
						Exit Sub
                    End If
	
	Admin
		--> frmAdmMain
			- renamed variable 'found' to 'foundContentToLoad'
			- modified sub RibbonControl_SelectedPageChanged for cases of ribbonpage with multiple ribbonpagegroup with groupindex of 1
				changed line of codes:
				FROM:
					If found Then
                        found = False
						Exit For
                    End If
					
				TO:
					If foundContentToLoad Then
                        foundContentToLoad = False
						Exit Sub
                    End If

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.10
By: Tony
Date: 2017-11-17

	Pulled changes from upstream master to local branch and fetched changes for the following objects:
		Admin/PayScale.vb
		Crewing/Document.Designer.vb
		MPS4/MPS4BasicFunctions.vb
		Payroll/Remittances.vb


------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.09
By: Neil
Date: 2017-11-17

	Admin/frmAdmMain.designer.vb
	Admin/frmAdmMain.resx
	Admin/frmAdmMain.vb
	Crewing/Biodata.Designer.vb
	Crewing/Document.Designer.vb
	Crewing/frmCrewMain.vb
		--> add issued date and issued place in document forms
	
	Admin/frmAdmMain.vb
	Crewing/frmCrewMain.vb
		--> modify RibbonControl_SelectedPageChanged
		--> add function loopchekdropdown
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.08
Date: 2017-11-15

	DocumentViewer
		--> DocViewer.Designer.vb
			- commented out the following codes which causes warnings:
				Friend WithEvents SplashScreenManager2 As DevExpress.XtraSplashScreen.SplashScreenManager
				Me.SplashScreenManager2 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.DocumentViewer.DMS_Waitform), True, True, DevExpress.XtraSplashScreen.ParentType.UserControl)
				
		--> DocViewer.vb
			- added LayoutControlGroup for Crew List and Document List

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.07
Date: 2017-11-12
By: Tony

	DocumentViewer
		--> DocViewer
			- added Class DocFilter
			- added new private variable oDocFilter As New DocFilter()
			- added button: Clear Filter
			- added Sub SetAllowAddition
			- Modified the following events:
				1. AddData
				2. gvCrewList_CellValueChanging
				3. luDocGrp_ButtonClick
				4. luDocGrp_CloseUp
				5. luDoc_ButtonClick
				6. luDoc_CloseUp
				7. UpdMainviewActiveFilter
				8. dtefrom_ButtonClick
				9. dtefrom_CloseUp
				10. dteTo_ButtonClick
				11. dteTo_CloseUp
				12. dteTo_DateTimeChanged
				13. dtefrom_DateTimeChanged
				14. dtefrom_KeyDown
				15. dteTo_KeyDown
				16. btnClearFilter_Click

			- Set placement of Document Group lookupedit before Document

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.06
Date: 2017-11-11
By: Tony

	MPS4
		--> frmLogin
			modified Remember Password function, disables auto load of last user if Remember Password is not enabled

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.05
Date: 2017-11-11
By: Tony

	MPS4
		--> frmLogin
			- modified appproach in disabling/enabling 'Remember Password' and 'Forgot Password' functions
			
	ReportObjectsIndividual
		--> BiodataEssential
			- modified sorting in detail bands for sub reports
			- modified sea service display to optionally be displayed continuously or grouped by sea service type
		--> BiodataComplete
			- modified sorting in detail bands for sub reports
			- modified sea service display to optionally be displayed continuously or grouped by sea service type
			
			
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.04
Date: 2017-11-09
By: Tony

	Reports
		--> ReportSelection
			- modifed gridselectionview and gridselectedview added TopRowIndex variable to track displayed top row index so it does not change when a selection is made

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.04
Date: 2017-11-09
By: Tony

	Reports
		--> basReports.vb
			- edited format from "Short Code" to "dd-MMM-yyyy" 
				rep.FindControl("lblDatePrinted", False).Text = "Date Printed: " & Format(Now(), "dd-MMM-yyyy")

	Crewing
		Added Date Printed
			--> rptExpDoc
			--> rptExpDoc_All
			
	ReportObjectsAdmin
		Added Page Number
			--> rptAdminCourse
			--> rptAdminPay_CashAdvanceType
			--> rptAdminPay_EmployersContri
			--> rptAdminPay_OtherWageItems
			--> rptAdminPay_RemitReceipts
			--> rptAdminPay_WagesAshore
			--> rptAdminPay_WagesOnboard
			--> rptAdminPay_WScale
			--> rptAdminStatus
			--> rptAdminVslCoSpec
			--> rptAdminVslSpec
			
		Added Date Printed
			--> rptAdminCrewCompliment
				Added Date Printed
				
	ReportObjectsAshore
		Added Date Printed
			--> rptCrewAsh_AllCrew_Rem
			--> rptCrewAsh_New
			--> rptCrewAsh_Sick
			--> rptCrewRequiredToTakeASpecificCourse
			--> rptCrewWithoutASpecificCertificate
			--> rptCrewWithoutASpecificCourse
			--> rptCrewWithoutASpecificMedical
			--> rptCrewWithoutASpecificTravel
			--> rptCrewWithoutSpecificCompanyDefinedDoc
			--> rptCrewWithSpecificCertificate
			--> rptCrewWithSpecificCompanyDefinedDoc
			--> rptCrewWithSpecificCourse
			--> rptCrewWithSpecificMedical
			--> rptCrewWithSpecificTravel
			
	ReportObjectsHistory
		Added Date Printed
			--> rptApplicantList
			--> rptCrewHis_Prom
			--> rptCrewHis_SeaServ
			--> rptCrewHis_Trans
			--> rptFirstVoyage
			--> rptHistoricalCrewList
			--> rptHistoricalSignOffList
			--> rptHistoricalSignOnList
			--> rptPromCadetToOff
			--> rptSickOnboardHistory
			--> rptSickOnboardList
			--> rptSOffDueToMedReason
			--> rptSOffDueToSpecificReason
			
	ReportObjectsIndividual
		Added Page Number
			--> rptBiodataComplete
			--> rptBiodataEssential
			--> rptCertificates
			--> rptCourse
			--> rptMedHis
			--> rptMedical
			--> rptSeaServ
			--> rptTrainingPlanned
			--> rptTrainingRequired
			--> rptTrainingStatus
			--> rptTravelDoc
			
		Added Page Number and Date Printed
			--> rptAppraisalReport_Indi
			--> rptAppraisalSummary
			--> rptCrewUniform
			--> rptSeaServCertification
			--> rptServiceHistory
			
	ReportObjectsOnboard
		Added Date Printed
			--> rptCrewList
			--> rptCrewList_wNotify
			--> rptCrewOnb_ReliefList
			--> rptCrewOnb_VacList_byRank
			--> rptCrewOnb_VacList_byVsl
			--> rptCrewOverdue
			
		Added Page Number
			--> rptCrewList_Wages
		
	ReportObjectsOnboard
		Added Date Printed and Page Number
			--> rptCrewSOnOff
			--> rptUniformIssuance
			--> rptUniformIssuance_PerMonth
			
	ReportObjectsPayroll
		Added Date Printed and Page Number
			--> rptBDORemittance
			--> rptBPIExport
			--> rptBankReport
			--> rptRetirementPlan
			--> rptCrewPay
			--> rptMonthlyHA
			--> rptPaySASummaryReport
			--> rptPaySASummaryReportCrew
			--> rptPaySASummaryReportVsl
			
	ReportObjectsPlanning
		Added Date Printed and Page Number
			--> rptCrewAsh_Plan
			--> rptCrewAsh_Plan_Vsl
			
	ReportObjectsStatistics
		Added Date Printed and Page Number
			--> rptCrewApplicants
			--> rptCrewAvgAge
			--> rptCrewCount
			--> rptCrewNatStat
			--> rptNatSOnSOffList
------------------------------------------------------------------------------------------------------------------------------

VERSION: 1.8.03
Date: 2017-11-08
By: Tony

	MPS4
		--> frmConnect
			- Modified form design
			
	ReportObjectsIndividual
		--> rptBiodataComplete
			- Modified design
		--> rptBiodataEssential
			- Modified design
			
	Crewing
		--> frmCrewMain
			- fixed icons of cmdQuickFilter and cmdFilterAshore

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.03
Date: 2017-11-08
By: Tony


SetupCustomAction (NEW)
	--> CustomAction.vb	- added new class which contains events for uninstall actions
	
MPS Setup
	--> Added SetupCustomAction.dll in FileSystem and CustomActions
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.02
Date: 2017-11-08
By: Tony

Crewing
	--> frmCrewMain
			- Fixed designer.vb, removed duplicate declaration of 'Activity_Docs'
			- Added comments in cmdEdit.Click explaining that the codes are moved to cmdEdit_DownChanged

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.01
Date: 2017-11-07
By: Fords

FIXED 
	1. Sick Onboard
		- DragDrop event : FKeyStatCode to StatCode(based on CrewList datasource)

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.8.00
Date: 2017-10-30
By: Fords

CHANGED 
	1. LTP new design
		- added sorting
		- single row per onboard-plan record
		- different datasource and procedure

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.7.11
Date: 2017-10-27
By: Tony

CHANGED
	1. Removed ReportObjectsCompanySpecific project and re-added using the first added same object from Senator's branch to avoid future merge conflict
	2. Modified Login form. Added setting from tblconfig to enable/disable the Remember Password and Forgot Password functions

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.7.10
Date: 2017-10-25
By: Tony

FIXED

	1. Fixed entry in Admin Garment form
	
ADDED
	
	1. Added the following items in MPS4DataSource.getCourseType and Course.getCourseType
			4 - Safety
			5 - Technical
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.7.9
Date: 2017-10-23
By: Tony

CHANGED

	1. Change current Sick Onboard List report into Medical History, since the report produces such kind of data instead of sick onboard records from the activity
	
ADDED
	
	1. Added new version for Sick Onboard List Historical Report

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.7.9
Date: 2017-10-23
By: Tony

CHANGED
	1. Fixed PayrollViewHA form, adding necessary events in PayAshEmpView such as:
		- CellValueChanged
		- GotFocus
		- InitNewRow
		- LostFocus
		- RowCellStyle
		- ShownEditor
		- ValidateRow
		- ValidatingEditor
		
	2. Modified InitNewRow of EarnView and DedView in PayrollViewHA form
	   Modified DeleteData procedure in PayrollViewHA in which totals does not get recalculated after deletion
	
	3. Modified data entry validation in PayrollViewSA
	
	4. Modified InitNewRow of EarnView and DedView in PayrollViewONB form	
	   Modified DeleteData procedure in PayrollViewONB in which totals does not get recalculated after deletion

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.7.8
Date: 2017-10-19
By: Tony

CHANGED
	1. Modified Form_closing events in frmAdmMain and frmCrewMain forms, added try...catch so that it captures properly the error when a program is closed and at the same time loses connection to the database server.
	2. Changed Admin > Security > Users > Force Logout button icon.

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.7.7
Date: 2017-10-10
By: Tony

CHANGED
	1. Removed COLLATE DATABASE_DEFAULT in the following report object classes:
		BiodataComplete
		BiodataEssential
		Medical
		SeaServ
		SeaServCertification
		ServiceHistory
		TrainingStatus
		

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.7.7
Date: 2017-10-10
By: Tony

ADDED
	1. Added generate script function in Report Config (for developers)
	2. Added Company Specific Report button group in frmCrewMain
	3. Added Company Specific Reports Project
	
FIXED
	1. Fixed error when generating KPI
	2. Fixed error when entering new document data and auto-updating expiry date when the date issue and country is not yet defined
	3. Fixed behavior of Menu Button of dropdown type.(Reports > Government)

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.7.5
Date: 2017-10-06
By: Tony

CHANGED
	1. Modified size of Exchange Rate grids in View Home Allotment and View Onboard Pay forms so that it auto adjusts its default size when first opened
	2. Changed version number variable
	3. Commented out message that tells program is running in Debug Mode therefore licence check is skipped.
	4. Changed Setup program installation destination to C-Spectral
	5. Removed codes in MPS4/MPS4BasicFunctions.vb and in ReportAutoEmail/basReportAutoEmail.vb that forces administrator access right to corresponding folder used by Images and Report Auto Email.
	
FIXED
	1. Fixed Total Deduction and Total Amount values in View Home Allotment 
	2. Fixed computation/conversion procedure of amount and converted amount in Process Special Allotment form
	3. Fixed loading of crew detail pop up form in LTP for those with null StatusLevel values

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.7.4
Date: 2017-10-04
By: Fords

CHANGED
	1. SIGN ON - on vessel selected changed, validate to remove planned crew(s) dragged from previous vessel
	2. Changed Activity History label to Previous Status in Go Back To Previous Status form.
	3. Modified AddUserSession function MPSSession class when logging in as Administrator

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.7.3
Date: 2017-10-03
By: Fords

CHANGED
	1. SIGN ON - use PlanningEventCrewID to update specific planning
	
ADDED
	1. Added icon to Reset Connection button in settings
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.7.2
Date: 2017-09-30
By: Tony

CHANGED
	1. Changed Agent-Vessel Mapping form list, changed column to 'Agent' instead of 'Name'; Set Sort Code column visible property to false

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.7.1
Date: 2017-09-30
By: Tony

FIXED
	1. Fixed pop up details form wherein, for example the form is already shown, and then the bar is clicked, the form should not showup again. 
	
ADDED
	1. Added check if MPS5 is running in debug mode so to skip license checking.
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.7.00
Date: 2017-09-29
By: Tony

	1. Integrated with Licensing App

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.6.12
Date: 2017-09-27
By: Tony

ADDED
	1. Added wait form when testing connection or initiating connection in frmConnect form.
	2. Added Refresh List button on Activity Menu
	3. Added Icon for Activity Documents button
	
CHANGED
	1. Edited generating of setting.ini if does not exist yet
	2. Changed default value of Commented By column in Biodata > Comments
	3. Set column Comment Date properties: AllowEdit and AllowFocus to true in Biodata > Comments
	4. Commented out line of code that changes the caption of Print Biodata button when opening the Appraisal form.
	5. Edited Transfer form in Activity wherein Date Sign Off from previous vessel and Date Sign On to the new vessel updates each other when dates overlaps
	6. Set Work Related and P&I Case default value to unchecked in adding of medical history form when a crew is set as sick onboard.
	7. Edited Arrival Place and Next Place of Activity values when crew is dragged from the crew list to the list of crews to sign off
	8. Added function that clears the form after saving in Activity > Ashore Activity
	9. Added Activity Date Start Column in Go Back To Previous form
	10. Modified handling of parameter with single quote when generating KPI result
	11. Redesigned grid display of Sick Onboard
	12. Modify message when a new user is added/saved in Security users.
	13. Changed display format of date filter fields in DMS
	14. Added validation in DMS when selecting a crew document and the system cannot find the images folder
	15. Added validation in DMS that checks if the image folder exists when Attach Image is clicked
	16. Modified validation in Travel Event when clicking View Report even if there is no report to view.
	17. Re-added Clear button in Quick Filter function
	
FIXED
	1. Fixed Quick Filter button
	2. Fixed refreshing of data in crew list List object (the one loaded on the left side panel of Biodata forms, activity, etc.)
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.6.11
Date: 2017-09-26
By: Tony

FIXED
	1. Fixed bug when clicking Add button in Admin Country
	2. Fixed permission check for Delete Crew button in Main Crew List and in Archive forms
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.6.10
Date: 2017-09-25
By: Tony

ADDED
	1. Added icon to Security Force Logout button.
	
CHANGED
	1. Modified FolderPath form into Program Settings 
	
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.6.9
Date: 2017-09-18
By: Tony

FIXED
	1. Fixed bugged when saving address
	2. Fixed updating of dateissue when entering updating records in Documents form
	3. Fixed Activity List popup form wherein changing of text and bg color does not apply to the main view at some time
	
ADDED
	1. Added flag check in LTP that checks if an appointment is clicked/right-clicked before showing the crew popup details
	
CHANGED
	1. Modified setting of DateExpiry value in documents form (for Travel Document and Medical Document)
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.6.8
Date: 2017-09-14
By: Tony

FIXED
	1. Fixed filtering for Crew Overdue and Crew with Expiring/Expired Docs
	
ADDED
	1. Added Quick Filter function feature
	
CHANGED
	1. Modified Filtering for Crew Overdue
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.6.7
Date: 2017-09-12
By: Tony

FIXED
	1. 
	
ADDED
	1. 
	
CHANGED
	1. Edited Sign On form grid, date dep or date son column automatically updates the other when one of the column is edited.
	2. Edited Transfer form grid, date sign off or new date sign on column automatically updates the other when one of the column is edited.
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.6.6
Date: 2017-09-12
By: Fords

FIXED
	1. Fixed issue in LTP where checking of overlapping activity does not initiate when a reliever is assigned to an onboard/planned crew
	2. Fixed issue in LTP wherein when a crew has been removed as a reliever, the corresponding id's does not get removed from the dtNewDepencies table, which is used to created the links between reliever and relievee when saving the data
	3. Fixed Copy-Paste Issue in LTP wherein there are cases where the copied appointment (crew bar) does not get pasted in a selected rank/vessel row
	
ADDED
	1. Added line of code in RemoveReliever in LTP form to remove the dependency removed from the dtNewDepencies datatable.
	
CHANGED
	1.	
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.6.6
Date: 2017-09-11
By: Tony

FIXED
	1. Fixed saving of data on Admin > Garment
	2. Fixed deletion of state in Admin Country form 
	3. Fixed error when deleting vessel.
			commented out 
				IO.Directory.Delete("ADMIN\VESSEL\" & strID, True)
			on Admin > DeleteData > Vessel.vb 
	4. Fixed error when deleting email account used for Scheduled Emailing
	5. LTP - cancel editing of onboard crew
	6. LTP - msg for deleting crew onboard
	7. Fixed Duplicate Rank function in Admin Qualification Template wherein "Include In..." columns does not get duplicated properly.
	8. Fixed adding/editing in Relatives form when entering in a blank field.
	
ADDED
	1. Added Please Wait form when saving in Security > Filter Assignment
	2. Modified hasNoDeletePermission function to give permission if user is an AdminUSer
	3. Added Crew With Specific Company Defined Document and Crew Without Specific Company Defined Document reports
	4. Added a check when Connection is Reset and in Debug mode.
	5. Added icon to program setup.
	
CHANGED
	1. Changed layout of Crew Amortization; Added Loan Total column in Crew Amortization List
	2. Changed header of the following report to use uniform header in which company name and address is in the middle and the logo is on the right side.
		- Complete Biodata
		- Essential Biodata
		- Certificates
		- Course
		- Medical
		- Sea Service
		- Sea Service Certification
		- Sea Service History
		- Planned Training
		- Required Training
		- Training Status
		- Travel Doc
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.6.5
Date: 2017-09-05

FIXED
	1. Fixed duplicate rank function in Admin Qualification Template
	2. Fixed size of legend in Plan Checklist form
	3. Fixed setting of Arrival Place and Date on Activity > Sign Off
	4. Fixed clearing of Arrival Place and Date on Activity > Sign Off
	
CHANGED
	1. Changed position of Group form and placed it before User form in Admin Security
	2. Modified Admin Logo and Header form so changes will be saved in the database
	3. Modified prompt messages when saving activities (e.g. sign on, sign off, transfer, etc.)
	4. Updated Admin Company Defined
	5. Updated Admin Competence Template, Company Defined module.
	6. Updated Crewing Documents, Added Company Defined Tab.
	7. Updated Crewing and Planning Checklist
	8. Updated Graphical Planning with Company Defined on popup forms.
	9. Modified displaying of Filter Info in frmCrewMain when no filter is applied when loaded
	
ADDED
	1. Added checking after login wherein a notification message will appear if the images directory is not set.
	2. Added Country Code and Call (Calling) Code fields in Admin Country
	3. Added CrewCompanyDefined View on Database to be used on Crewing Document module.
	4. Modified Crew List Filter form: Added checkbox if to filter by age.

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.6.4
Date: 2017-08-25

FIXED
	1. Fixed force logout when logging out same user used to create such procedure.
	2. Bug Fix on GetConfig function wherein error occurs when config textvalue is NULL.
	3. LTP  - fix crew complement data source
			- fix pop up form behaviour
			- expand/collapse crew competence, load only when expanded
	
CHANGED
	1. Modified Reset Connection function to avoid single-instance application related error.
	2. Modified Uniform Issuance
		- Added Validity on Admin Garment Form
		- Modified Crew Uniform Issuance Form
		
ADDED
	1. Added Crew Uniform Issuance Report
	2. Added function that will generate Company ID when new crew is added thru the Biodata form

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.6.3
Date: 2017-08-14

FIXED
	1. Fixed handling when program could not connect to database at startup or loses connection in between program activities.

CHANGED
	1. Modified checking if a user's account has been logout from MPS
	2. Reports.DLL - removed DAO reference

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.6.2
Date: 2017-08-07

FIXED
	1. Fixed plotting of bars in Export to Excel function of Graphical Planning.
	2. Fixed saving/loading of selected color scheme in Graphical Planning.
	
CHANGED
	1. Set Crewing and Admin Projects/Exe to open as single instance.
	2. Renamed source table for report filter options to "msystblreportfilteroptions"
	3. Changed default focus of forms frmLoadTempalte and frmSaveTemplate; set Cancel button as default button
	4. Modified Click and DoubleClick event in the Report List grid in the ReportSelection form when focus is on an open space area
	5. Moved codes in LoadContent procedure in frmCrewMain that checks if a user has been logged out by the admin to a new separate procedure
	6. Modified Report: Birth Details 
	7. Modified Crew List Historical, Sign On List & Sign Off List Reports: Added Rank Type field in data source
	8. Changed images of Legends (Crew List) in User Settings form
	9. Modified message when logging in a user that is logged in from another computer
	
ADDED
	1. Added "Do Not Include Onboard Service" filter on Sea Service Certification Report	
	2. Added Report:
		- (History) Crew Sign Off Due to Medical Reason
		- (History) Applicant List
		- (History) Crew First Voyage
		- (History) Crew Cadets Promoted to Officer
		- (History) Crew Sign Off Due To Specific Reasons
	3. Added Date Arrived Home and Arrival Place fields in Sign Off Form
		
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.6.1
Date: 2017-08-01

FIXED
	1. Fixed Export to Excel in Graphical Planning wherein if a crew has more than one planned/onboard service in the Graphical Planning, only the earliest service will appear in the export.
	2. Fixed Type column in Travel Document tab in Documents form. Apparently the columns of the repository has disappeared, therefore, all columns have shown up.
	3. Fixed Graphical Planning to properly capture the right-click > copy on an empty space.
	4. Commented out/removed variable declaration of "isFormInitialized" in CrewList.vb and CrewList_ActivityList.vb. 
	5. Modified Graphical Planning form. Changes applied in the ff. below can be saved in per-user settings so they can be used later when the form is loaded/initialized:
		- Show Empty Vessels/Rank
		- Color Scheme
		- Scale
	6. Renamed "Color Schemes" to "Color Scheme" in Graphical Planning form.
	
CHANGED
	1. Modified end range of month calendar header in the excel exported by the Export to Excel form in Graphical Planning. Should now cover until 3 months after the most farthest ending date (farthest end date + LOC)
	2. Changed Crew Checklist and Planning Checklist legend image.
	3. Changed source table of Report Filter Options to "MSystblReportFilterOptions"
	4. Modified default control focus when forms frmSaveTemplate or frmLoadTempalte is shown
	
ADDED
	1. Added Duplicate Rank functionality in Admin Qualification template
	2. Added legend for competence check in Graphical Planning

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.6.1
Date: 2017-07-21

FIXED
	1. Fixed issue in Popup Crew Info in Graphical Planning wherein if you try to show the popup form for two different services of the same crew, the form does not refresh. 
		The details for the first shown service will always remain
	2. Fixed issue with icon indicator in Graphical Planning wherein if you copy a crew to a different rank/vessel, the icon remains the same when it should not (due to competence check)
	3. Fixed showing of popup details in Graphical Planning when mouse right-click is pressed.
	4. Fixed excel export feature in Graphical Planning in which a crew does not get included in the export if a planned crew has no crew to relieve
	5. Fixed question message box on the following locations. Used question icon instead of the icon each currently use (either information or exclamation)
			-- ADMIN --
			5.1. Airline > Delete
			5.2. Bank > Delete Bank
					> Delete Branch
					> Add City
					> Add Province
			5.3. Certificate Capacity > Delete
			5.4. Certificate Limit > Delete
			5.5. Certificate Type > Delete
			5.6. CBA Type > Delete
			5.7. Course 	> Certificate > Delete
						> Course Institution > Delete
			5.8. Employer > Delete
			5.9. Fleet > Delete
			5.10. Language > Delete
			5.11. Rank > Delete
			5.12. Rank Type > Delete
			5.13. Relation > Delete
			5.14. Remittance Receipt > Delete
			5.15. SSS Table > Delete
			5.16. Ashore Wages > Delete
			5.17. Employer's Contribution > Delete
			5.18. Other Wages > Delete
			5.19. Onboard Wages > Delete
			5.20. Wage Period > Delete
			5.21. User Group
			5.22. Users > Delete
			5.33. Change User
			
			-- CREWING --
			5.34. Change User
			5.35. View Onboard Payroll > Delete
			5.36. Biodata 	> Add Province
							> Add City
			5.37. Export Crew List
			5.38. Relatives > Delete Sub Table
			
	
CHANGED
	1. Modified Competence details grid in Graphical Planning popup form to display as multi-line and with column widths auto sized
	2. Set visible property of severity column to true in Admin Competence form > National Information tab
	
ADDED
	1. Added new reports:
		- Uniform Issuance Per Garment
		- Uniform Issuance Per Month
	2. Added icon indicator to crew detail pop up form in Graphical Planning (High, Medium, Low Severity/Priority)
	
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.6.0
Date: 2017-07-17

FIXED
	1. Fixed bug wherein Export button does not show up when opening the Graphical Planning form right after opening the Payroll form/s
	2. Fixed bug when opening the Graphical Planning form, the focus moves out of MPS5.
	3. Fixed bug in Biodata form wherein if you are in a different tab (within the biodata form), then you select another crew (with a crew photo), when you move back to the Name and Rank tab, the crew photo does not update.
	4. Fixed showing of Add, Edit, Delete, Save and Data Tool buttons in Admin DB Connection File form in Admin Other Settings
	5. Fixed showing of Add, Edit, Delete, Save and Data Tool buttons in Admin Payroll > Payroll Security
	
CHANGED
	1. Modified when adding handler to grids which opens up and removes flyout control
	2. Modified saving of Pagibig Contribution, SSS Contribution and Philhealth Contribution exports. The program now asks the user where the exported file will be saved.
	3. Modified behavior of Uniform Grid in Uniform (Issuance) form.
	4. Modified part in saving new crew wherein if a crew is edited the wage scale is also updated
	5. Modified behavior of sub Grid in Travel Event
	6. Removed Reports menu in Admin and replaced with a new Report menu with sub menus for Admin Crew and Admin Payroll
	7. Changed menus in Admin form, grouped those with similar types
	8. Modified Process Home Allotment Payroll, other than drag-and-drop, user can now select/deselect crews by double-clicking on them
	9. Modified frmPayCrewError form, view is set to expand by default
	10. Modified Process Onboard Payroll, other than drag-and-drop, user can now select/deselect crews by double-clicking on them
	11. Modified Process Special Allotment Payroll, added drag-and-drop on selected crews grid to remove crew-allottees.
	12. Modified Joining Checklist, a message now shows that there are no document/vessel experience setup for the competence, therefore is considered lacking.
	
ADDED
	1. Added view (locked, unlocked or all) filter in Processed Payroll List
	2. Added RemoveFlyOut Event and Procedure
	3. Added check if template file exists for Pagibig Contribution and Philhealth Contribution reports
	4. Added validation in Promotion wherein a crew selected is checked first if he has a planned reliever before he can be promoted.
	5. Added validation in Transfer wherein a crew selected is checked first if he has a planned reliever before he can be transferred.
	6. Added Admin Payroll Reports:
		a. List of Wages Ashore
		b. List of Wages Onboard
		c. List of Employer's Contribution
		d. List of Other Wages
		e. List of Cash Advance Types
		f. List of Wage Scales
		g. List of Remittance Receipt
	7. Added sequence no./numbering to Process Home Allotment form
	8. Added sequence no./numbering to Process Onboard Payroll form
	9. Added sequence no./numbering to Process Special Allotment form

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.5.4
Date: 2017-06-30

FIXED
	1. Fixed application of criteria in Crew List Filter for Document Expiry Condition
	2. Fixed Delete button caption in View/Edit Home Allotment
	3. Fixed showing of Export button when opening the View/Edit Home Allotment, View/Edit Special Allotment and View/Edit Onboard Payroll forms.
	4. Fixed Crew List in DMS form.
	5. Fixed focusing of row in Crew List grid when opening the View Exp Docs form
	6. Fixed focusing of row in Crew List grid in Planning Event form when a crew is dragged to the list of crews to be planned
	7. Fixed Planning in which validation message "Would you like to save the changes you've made?" appears twice.
	8. Fixed behavior of Edit button in Biodata form when pressed and moves in and out of the different tabs inside.
	9. Fixed error message after transferring a crew to archive/active wherein splashscreenmanager.closeform call returns an error
	10. Fixed refreshing of crew grid/view in Archived Crews in which maincontent details does not refresh if the crew being updated is the only record in the list
	11. Renamed button "Start Archiving Crews" to "Start Transfer to Archive"
	12. Fixed generating of Travel Report (Flight Request)
	
CHANGED
	1. Modified design of Uniform Issuance form
	2. Modified GetUserSettings function/procedure; Added a structure type parameter for better calling
	3. Modified Crew List Filter form; changed design and approach for Due date days and document expiry conditions
	4. Modified validation in Uniform Issuance form.
	5. Changed labels in Qualification > Document Mapping
	6. Changed labels with Earnings in View/Edit Home Allotment and View/Edit Onboard Payroll forms to "Payment"
	7. Resized labels in first column items of crew details popup form in Graphical Planning form
	8. Modified Add New Crew in Biodata wherein the Crew List (found on the left panel) focuses on the newly added crew after adding a new crew
	9. Modified display message when saving while a sub grid has column errors
	10. Changed design of frmConnect form
	11. Renamed tabs in Documents form. (from "Certificates" to "Licenses/Certificates"; and from "Medicals" to "Medical Documents")
	12. Modified Vessel column in Medical History form: added inactive column to be used by inactive vessels
	13. Modified Status Monitoring and Cost Monitoring grids in Medical History form to have initial values for Date Entry and User when adding a new record
	
ADDED
	1. 

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.5.3
Date: 2017-06-20

FIXED
	1. Fixed bug/error when printing crew list historical report with date parameters
	2. Fixed bug in Sign On wherein sign on does not proceed if a crew has no issue with his competence.
	3. Fixed refreshing of Uniform details when moving in and out of activity entry.
	4. Fixed validation in adding Uniform details (when blank)
	
CHANGED
	1. Changed default height of Planned Crews sub form in Sign On form.
	2. Modified SignOn form to allow drop on Planned Crews grid when removing a planned crew from the Crew List grid
	3. Modified Crew Reassignment Notification and Request forms
	4. Modified Crew Reassignment forms
	5. Modified Education grid in Training form to have a fixed width.

ADDED
	1. Added Vessel Column in Activity > Go Back to Previous status form
	2. Added Rank column in Crew Reassignment Notification form.

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.5.2
Date: 2017-06-06

FIXED
	1. Fixed error when opening the Sign On/Off form when there is no created crew data table
	2. Fixed size for buttons: clear, select all and deselect all in KPI form.
	3. RefreshData focus when Crew List is updated.
	
CHANGED
	1. Set KeepTogether property of complete/essential biodata sub reports to true
	2. Changed message in payroll process when you select a vessel that another user has already selected.
	3. Changed message in admin vessel when you set a vessel to inactive which has onboard and/or planned crew/s to it.
	4. Modified checking of onboard/planned crews when setting a vessel to inactive in the MPS5 Admin > Vessel Form
	5. Removed clearing of Sort Options when Clear Filter is clicked in Report Selection
	6. Modified displaying of Grouped By and Period columns
	
ADDED
	1. Clear button in Garment Dropdown in Uniform Issuance form in Crew menu
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.5.1
Date: 2017-05-29

FIXED
	1. Column Header Borders in AMOSUP Crew List Report
	2. Fixed EditFormatString of Date Fields in Audit form to 'dd-MMM-yyyy'
	3. Fixed Filter panel height in Payroll List in Payroll
	4. Fixed typo error with competence check in sign on form.
	5. Fixed calling of Crew Comments form, added crew name in new sub parameter 
	6. Fixed Scheduling Email error
	7. Fixed error in Graphical Planning export to Excel; Crew on board and reliever not properly aligned. 
	
CHANGED
	1. Modified Borders and AutoRowHeight Settings in Report Selection
	2. Modified required field validation in Activity forms
	3. Modified checking of FeatureID in ReportConfig.vb
	4. Modified Generate Feature ID form - added Feature Name in object list
	5. Modified Adjust Demo Dates form, added selection for data to be adjusted
	6. Changed MininumSize property of frmCrewMain and frmAdmMain to "800, 400"
	7. Modified setting of default values (Wage Scale Rank and DateArrival) in Sign Off form
	8. Modified ComBy column in Comments popup form: changed caption to 'Commented By'; Changed column value to use USER_NAME value
	9. Changed Caption of 'Add Comment' to 'View/Add Comment' in Crew List Right-Click Menu
	10. Displayed 'Commented By' column in Biodata > Comments form
	11. Modified Qualification Matrix module by adding a Severity selection for each document.
	12. Update Crew and Planning Checklist forms and reports.
	13. Updated query for validating the Documents against the Qualification matrix by adding the severity criteria.
	14. Updated Crew Filtering based on the Qualification Checklist.
	15. Updated tables that are related on Qualification Matrix module.
	16. LTP crew data change to popup
	17. apply contract due filter in crew list
	18. Modified KPI, wherein selection of listing and period can be dynamically changed for each kpi item.
	19. Change loading of Checklist data.

ADDED
	1. Added Admin forms:
		- Garment Type
		- Garment
		- Uniform Issue Type
		- Uniform Template
	2. Added Crew Uniform form
	3. Added AssembleName Function.
	4. Added a Pre-Joining Checklist feature on Sign On module. Report will be shown if a crew to be signed-on has lacking documents.
	5. Added buffer editing on Admin Documents module.
	6. Added a Checklist grid on popup form when hovered on crew in Graphical Planning.
	7. Added icons on each crew based on the result of Checklist in Graphical Planning.
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.5.0
Date: 2017-04-24

FIXED
	1. Payroll Locking Bugs Found Fixed.
	2. Initialziation of Planning form wherein All Crews Ashore listing is enabled at first open of the form wherein it should be disabled until Edit button is clicked.
	3. Fixed enabling/disabling of Sex Code dropdown list in Remittances form
	4. Fixed showing/hiding of KPI Config form if not Administrator or Spectral user
	5. Fixed initialziation of sorting in Print Biodata pop up form in the Crew List form.
	6. Fixed EditData in Remittances form
	7. Saving of newly inserted and/or updated record Admin Status
	8. Fixed border malfunction when viewing the Appraisal report.
	9. Fixed the error encountered while right-clicking on the Crew List to access the Appraisal through shortcut.
	10. Fixed new splashscreen logo so it does not get dragged/clicked, etc.
	11. Fixed Edit button and EditData behavior in Crew Amortization form.
	12. Currency selection error in Process Special Allotment form
	13. Fixed Checklist process when saving comments
	14. Corrected Appraisal process for editing by following the permission process
	15. Fixed permission settings on Archiving process.
	16. Fixed Save and Report button in Qualification module. 
	17. Fixed the Delete Appraisal process in Appraisal module.
	18. Fixed sorting of Currency to show referential currency on top on the following forms:
			- Remittances
			- Onboard Crew Wages > Variable Wages
			- Onboard Crew Wages > Add Advances

ADDED
	1. Admin Status List Add new Column for System Records; Disabled Delete on System Records
	2. Cash Advances: Import/Export and Generate Template.
	3. Added instruction "Select vessel first..." to Sign Off and Transfer forms
	4. Added Agent column in Sign On
	5. Added Crewlist Filter Information
	6. Added Validation in Sign On and Transfer. Vessel should be assigned to a principal before it can be selected
	7. Added Admin Report:
		- Status Listing
		- Travel Document Listing
		- Medical Document Listing
		- National Document Listing
		- Port Listing
		- Agent Listing
		- Owner Listing
		- Crew Employer List
		- Fleet List
		- Travel Agent List
		- Bank Listing Report
	8. Added BPI Export and Report
	9. Added File Attachment on Appraisal module.
	10.Added tblCrewAppraisalAttachment to store File Attachment in Appraisal module.
	11. Added Form to create MPS Database Connection File
	12. Added button Connect Using MPS Database Connection File option in Database Connect form
	13. Revision on Graphical Planning Export to Excel
		- Added checking if the computer does have a Microsoft Excel installed.
		- Added color on headers (Years and Months)
		- Added saving of excel template after generating/exporting the Graphical planning.
		- Added borders and merging of headers with Years and Months.
		- Added date generated at the end of ranks/vessel rows.
		- Added name of Rank/Vessel inside the worksheet.
	14. Added Payroll Log logging in BDO Export and BPI Export features
	15. Added separate splash screen for MPS Admin and MPS Crew applications
	16. Added a Delete Archived Crew button on Archive module.
	

CHANGED
	1. Modified automatic setting of default values of date fields in Sign On, Sign Off and Transfer forms.
	2. Rearranged Document Type and Document Group dropdown list in the DMS, placing the Document Type in the first order.
	3. Changed datasource of Document Type in DMS so it can be independently used without filtering first a Document Group.
	4. Modified Sign On form so that the wage scale column's default value should always be the crew's latest wage scale assigned (or the planned crew's planned wage scale)
	5. Modified Planning form so that the new crew dragged's wage scale shall be set to his latest wage scale.	
	6. Renamed 'Email Automation Profile' to 'Scheduled Emailing'
	7. Automatically expanded the groups in 'Scheduled Emailing' form
	8. Renamed 'System Record' column in Admin Status form to 'System Status'
	9. Incorporated generating of Featured ID for reports in Report Configuration form
	10. Rearranged SortCode in Admin Reports
	11. Modified Double-Clicking and Grid Background Color in Print Biodata popup form in Crew List form.
	12. Modified DeleteSubTable Procedure in Biodata form, removed RefreshData at the end of the procedure so that the user will no longer need to click the Edit button again to delete multiple records
	13. Updated icons of the following buttons:
			- Reports > Government > Individual
			- Reports > Government > Monthly
			- Crew List > View Activities > Leave Day History
			- Onboard Wages > Generate Cash Advance Template
			- Onboard Wages > Import From Template
			- Admin > Payroll > Password Settings
	14. Added Icons to Exp Docs and View Activities in Right-Click menu of Crew List left panel.
	15. Changed the sorting of grades in Appraisal module. 
	16. Changed Splashscreen image to MPS5 Crew logo
	17. Modified save validation in activity, added indicator to a cell that says "Required field must not be blank"
	18. Changed labeling on User Preference of Graphical Planning.
	19. Updated Graphical Planning excel template.
	20. Modified saving of Report and KPI template wherein an existing template can be selected if needed to overwrite an existing
	21. Modified Graphical Planning Export to Excel, hides the excelapp during export, added status bar
	22. Changed Icon of Refresh button in Audit
	23. Renamed 'Read Only' column in Admin Group Permissions to 'Open/Read Only'
	24. Modified Grid Controls in Admin Group Permission to use LayoutControl for its layout
	
------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.4.3
Date: 2017-04-06

FIXED

	*	SEC Group Form Bug when no group is listed (Neil)

	1.	Bugs Fixing In Payroll (Earlsan)
	2.	Bug fix in SaveReports procedure in EmailProfile.vb

ADDED

	1.	Admin Vessel Union Agreements - attach documents
	2.	Class AttachDoc in MPS4Functions module
	3.	Table tblAttachDoc
	4. * Appraisal Summary Report (Reports -> Individual)
	5.	Added KPI Configuration form (visible only in Debug mode when logged in as Adminstrator or Spectra)
	6.	BDO Remittance Report/Export feature with Admin form
	7.	Export to Excel of Graphical Planning module result.
	8. 	Appraisal module and report generator.

CHANGED

	1.	Modified Filter Options, Sort Options and SavedFilterOptionValues into separate classes
	2.	Modified loading of Filter Options in KPI to use the new method
	3.	Modified History Reports: Crew Overdue and Embarkation and Disembarkation reports, so that error 
		messages won't show up when sent from the Auto Email feature
	4.	* Appraisal Report
	5. 	Modified Appraisal module : Include Master, Chief Officer and Chief Engineer that has served within the lenght of 			contract of the service selected for each crew.
	6. 	Modified Appraisal module : Changed the grading process for appraisal factor, by using a decimal value and rounding 			up/down for overall grade and remaks.

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.4.2
Date: 2017-03-22

FIXED
	1.	Generating of reports in Crew List > Print Biodata


ADDED
	1.	Refresh Button on Admin -> Audit Page
	2.	Function that saves filter option values into global repo and reloads it when moving to another report selection
	3. Appraisal Report on Reports > Individual

CHANGED

	1.	Changed Report Group Source for Government reports in Crew List > Print Biodata
	2.  Comment out ShowCustomLoadScreen and CloseCustomLoadScreen in cmdSave event of frmCrewMain (Note: must add manually)
	3.	Changed placement of "Loading... Please Wait" form when loggin in, especially for new users who are setting up password.
	4.	Modified generating of result in KPI
	5.	Modified loading of filter option datasource
	6.	Allowed resizing of filter option combobox/dropdown controls so users can resize it if the text is too long


------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.4.1
Date: 2017-03-08

FIXED
	1.	Show proper msg in email profile when sending
	2.	comment out a line ine SetAppPath()

ADDED
	1.	Report Config Interface (Debug Mode Only) to allow easy creation of report object/s
	2.  Appraisal report template 
CHANGED
	1.	Revised Process Special Allotment Form (Earlsan 20170306)
	2.	Fixed Update Wage Scale Bug (Earlsan 20170306)
	3.	Set all DLL to x86
	4.	Email Profile
		- Collapsable Group in Settings
		- Email Profile - Add loading screen
		- Validate sending email


------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.4.0
Date: 2017-03-03

FIXED

	1.	Fixed Drag Drop of Update PayScale
	2.	Fix Sea Service Summary column in Group Type grid
	3.	Corrected Crew List loading of data when changing from Biodata to Transfer to Archive and vice versa

ADDED
	
	1.	Update: the Program will create INI file with default Format (Earlsan)
	2.	Generic Appraisal module

CHANGED
	
	1.	Modified event of Cancel button in frmConnect form when initialized in startup.
	2.	Add interop.msdasc.dll in Report Project Resources (Earlsan)
	3.	Add Initializations for setting.ini (Earlsan)
	4.	Modified event of Cancel button in frmConnect form when initialized in startup
	5.	Modified frmUpdatePayScale.vb : New Column Selection of Wage Scale Rank - Seniority (Earlsan)
	6.	Modified Process Home Allotment and Onboard Payroll : Add New Agent and Nationality Filter (Earlsan)
	7.	Modified PayAdvances: Add New Column [Items] for 'Bond A/C' and 'Slopchest' (Earlsan 20170302)
	8.	Modified Crew Advances: Add Filters and Running Sum (Earlsan 20160302)
	9.	Modified Lock/Unlock Payroll function in Processed Payroll List form so that it 

	10.	Modified event of Cancel button in frmConnect form when initialized in startup
	11.	Modified frmUpdatePayScale.vb : New Column Selection of Wage Scale Rank - Seniority (Earlsan)
	12.	Modified Process Home Allotment and Onboard Payroll : Add New Agent and Nationality Filter (Earlsan)
	13.	Modified PayAdvances: Add New Column [Items] for 'Bond A/C' and 'Slopchest' (Earlsan 20170302)
	14.	Modified Crew Advances: Add Filters and Running Sum (Earlsan 20160302)
	15.	Modified Lock/Unlock Payroll function in Processed Payroll List form so that it 
		refocuses to the last selected payroll after the locking/unlocking a payroll.
	16.	Modified Govt. Receipts button in Processed Payroll List form, making it only
		visible for HA payrolls only.
	17.	Modify Email Automation Profile 
		- modify design on Settings group
		- adjust design on Reports group
	18.	Modify Email Config
		- grouped the controls
		- adjust contents of test email

------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.3.3
Date: 2017-02-22

FIXED

	1.	Signed On List Report
	2.	Report/KPI Template List Content Display
	3.	Bug fix on loading of Report/KPI from Template
	4.	Crew and Rank labels on List of Courses report
	5.	Modify Sea Service Summary Group Type
	
ADDED
	
	1.	Option to View Report/Generate KPI after a template is loaded
	2.  	Added loading of auto report email date condition for reports: Promotion List and Transfer List"
	3.	Added Crew Count By Agent and By Principal reports
	4.	Added StoredProcedureCommand class
	5.	Validation in Update Wage Scale wherein selected former and new wage scales should not be the same.
	6.	Enabling of Copy Wage Scale Rank and Update Wage Scale buttons in Admin > Pay Scale


CHANGED

	1.  Changed message when setting a wage scale to inactive"
	2. 	Grid labels in Update Wage Scale Form
	3.	Design of Admin Crew Status form
	4.	Added backcolor to editable columns in Admin KPI Mapping form
	5.	Modified layout of Biodata form to reduce height size and remove scroll bars when viewed on smaller monitors
	6.	Expired/Expiring Document Warning icon in the Crew List form.



------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.3.2
Date: 2017-02-17

CHANGED
	
	1. Modified Function that creates the report/kpi object/s used by the auto email report feature
	2. Changed labels of Grid Options Text Color and Background Color dropdown list labels in Activity List form.
	3. Added computation of leave days/pay in activities.
	4. Added Leave Form in Service and View Activity Pop-up form.
	5. Added Leave Type radio group(Earn, consume, none) in admin status.
	6. Added View Activity and View Exp Docs in right click options for Crewlist(Baselist).
		-Need to add icons, i can't find icons in server.
	7. Changes made based on the ff images.
		-02-03-2017 (1534) Sign on_Calvz
		-02-08-2017 (1544) Graphical Planning_Calvz
		-02-08-2017 (1546) Crew Amortization_Calvz
		-02-13-2017 (1559) Sign Out_Calvz
		-02-14-2017 (1564) Sign Off_Calvz
		-02-14-2017 (1565) Sign Off_Calvz
		-02-14-2017 (1569) Sign On - Planned Crews_Calvz
		-02-14-2017 (1570) Sign on
	8. Vessel Qualification in LTP to better identify crews that do not comply to vessel's requirements


------------------------------------------------------------------------------------------------------------------------------
VERSION: 1.3.1
Date: 2017-02-13

FIXED
	
	1. Fixed loading of report selection form if a report button has already been selected as a shortcut button.
	2. Added Validation in KPI when there is no selected data 

------------------------------------------------------------------------------------------------------------------------------

VERSION: 1.3.0
Date: 2017-02-09

ADDED
	
	1. Added Admin for SMTP Email Config. -Fords
	2. Added feature to manage email accounts of a user. -Fords
	3. Added feature to manage email profiles of a user to be send automatically as configured. -Fords
	4. Added input for wage scale in sign-off and ashore activity. - Calvhin
	5. Added Home Allotment Bank Report
	6. Added progress bar when selecting all/deselecting all in Report Selection form.
	7. Added validations in promotion, transfer, contract extension and change payscale. Validate if crew's current status is "Sick Onboard". -Calvhin
	8. Added LogError in Activity, Planning, TravelEvent. - Calvhin
	9. Added validation in change password, validate if answer for security question is empty. -Calvhin
	
CHANGED
	
	1. Modified Report Selection to allow multi-selection and drag-drop of records in the selection list.
	2. Modified "Loading Please Wait" form on reports
	3. Modified the loading of shortcut buttons to handle drop-down menu style buttons in the main Ribbon. 
		(Check Z:\Progs\MPS 4\Docs\Documentation per Module\QuickAccessButtons_Tutorial.docx for additional instructions.) 
	
BUG FIXED
	
	1. Fixed View/Hide Quick button function in Payroll > View Special Allotment.	
	2. Fixed error in activity when saving without losing focus on grid. -Calvhin
	3. Fixed error in travel event when clicking on empty travel event grid. -Calvhin
	4. Fixed Forms behaviour when changing a view triggered via Shortcut buttons. - Welly 
	
------------------------------------------------------------------------------------------------------------------------------

VERSION: 1.2.1
Date: 2017-01-25

	1.	Modified Reports and KPI templates to be saved and loaded per user.
	
------------------------------------------------------------------------------------------------------------------------------

VERSION: 1.2.0
Date: 2017-01-20

	1.	Added Auto generating of report from a selected template.
