USE BestofBooks
GO

CREATE OR ALTER PROCEDURE GetChangeReport
@Username VARCHAR(255) = NULL,
@UserLast VARCHAR(255) = NULL,
@BeginDate DATE = REQUIRED,
@EndDate DATE = REQUIRED
AS

BEGIN
	SET NOCOUNT ON;
	
	-- Base stored proc without any parameters. A default Date of current is set. Will show all changes from current day only as default
		IF @Username is null AND @UserLast is null AND @BeginDate is null AND @EndDate is null
			BEGIN
			SET @BeginDate = GETDATE(); 
			SET @EndDate = GETDATE();
			SELECT a.table_name AS 'Table Name',a.audit_action AS 'Change Action',a.modified_by_user AS Username,a.modified_date AS Date
			FROM dbo.Audit a
			WHERE a.modified_date BETWEEN @BeginDate AND @EndDate
			END
	-- Stored proc with only Begin Date set. A default End Date of current is set. Will show all changes from selected Start Date to Current day
		ELSE IF @Username is null AND @UserLast is null AND @EndDate is null
			BEGIN 
			SET @EndDate = GETDATE();
			SELECT a.table_name AS 'Table Name',a.audit_action AS 'Change Action',a.modified_by_user AS Username,a.modified_date AS Date
			FROM dbo.Audit a
			WHERE a.modified_date BETWEEN @BeginDate AND @EndDate
			END
	-- Stored proc with only End Date set. A default Begin Date equal to End Date is set. Will show all changes from selected End Date only
		ELSE IF @Username is null AND @UserLast is null AND @BeginDate is null
			BEGIN
			SET @BeginDate = @EndDate; 
			SELECT a.table_name AS 'Table Name',a.audit_action AS 'Change Action',a.modified_by_user AS Username,a.modified_date AS Date
			FROM dbo.Audit a
			WHERE a.modified_date BETWEEN @BeginDate AND @EndDate
			END
	-- Stored proc if only Username is selected. Will display all changes made by that username for default Date Range of Current Day only
		ELSE IF @UserLast is null AND @BeginDate is null AND @EndDate is null
			BEGIN
			SET @BeginDate = GETDATE(); 
			SET @EndDate = GETDATE();
			SELECT a.table_name AS 'Table Name',a.audit_action AS 'Change Action',a.modified_by_user AS Username,a.modified_date AS Date
			FROM dbo.Audit a
			WHERE (a.modified_date BETWEEN @BeginDate AND @EndDate) AND
				a.modified_by_user = @Username
			END
	-- Stored proc if only Last Name is selected. Will display all changes made by that username for default Date Range of Current Day only
		ELSE IF @Username is null AND @BeginDate is null AND @EndDate is null
			BEGIN
			SET @BeginDate = GETDATE(); 
			SET @EndDate = GETDATE();
			SELECT a.table_name AS 'Table Name',a.audit_action AS 'Change Action',a.modified_by_user AS Username,a.modified_date AS Date
			FROM dbo.Audit a
			WHERE (a.modified_date BETWEEN @BeginDate AND @EndDate) AND
				a.modified_by_last = @UserLast
			END
	-- Stored proc with only Username and User Last set. Will show specific Username and User Last selection for Default current day only
		ELSE IF @BeginDate is null AND @EndDate is null
			BEGIN
			SET @BeginDate = GETDATE(); 
			SET @EndDate = GETDATE();
			SELECT a.table_name AS 'Table Name',a.audit_action AS 'Change Action',a.modified_by_user AS Username,a.modified_date AS Date
			FROM dbo.Audit a
			WHERE (a.modified_date BETWEEN @BeginDate AND @EndDate) AND
			a.modified_by_user = @Username AND
			a.modified_by_last = @UserLast
			END

	-- Stored proc with only Date Range set. Will show all changes for date range
		ELSE IF @Username is null AND @UserLast is null
			BEGIN
			SELECT a.table_name AS 'Table Name',a.audit_action AS 'Change Action',a.modified_by_user AS Username,a.modified_date AS Date
			FROM dbo.Audit a
			WHERE a.modified_date BETWEEN @BeginDate AND @EndDate
			END
	-- Stored proc if Username and Begin Date is selected. Will display all changes made by that username for specified Begin Date to Current Date
		ELSE IF @UserLast is null AND @EndDate is null
			BEGIN
			SET @EndDate = GETDATE();
			SELECT a.table_name AS 'Table Name',a.audit_action AS 'Change Action',a.modified_by_user AS Username,a.modified_date AS Date
			FROM dbo.Audit a
			WHERE (a.modified_date BETWEEN @BeginDate AND @EndDate) AND
				a.modified_by_user = @Username
			END
	-- Stored proc if Username and End Date is selected. Will display all changes made by that username for Begin Date euql to specified End Date
		ELSE IF @UserLast is null AND @BeginDate is null
			BEGIN
			SET @BeginDate = @EndDate;
			SELECT a.table_name AS 'Table Name',a.audit_action AS 'Change Action',a.modified_by_user AS Username,a.modified_date AS Date
			FROM dbo.Audit a
			WHERE (a.modified_date BETWEEN @BeginDate AND @EndDate) AND
				a.modified_by_user = @Username
			END
	-- Stored proc if Last Name and Begin Date is selected. Will display all changes made by any user with selected last name for specified Begin Date to Default Current Date
		ELSE IF @Username is null AND @EndDate is null
			BEGIN
			SET @EndDate = GETDATE();
			SELECT a.table_name AS 'Table Name',a.audit_action AS 'Change Action',a.modified_by_user AS Username,a.modified_date AS Date
			FROM dbo.Audit a
			WHERE (a.modified_date BETWEEN @BeginDate AND @EndDate) AND
				a.modified_by_last = @UserLast
			END
	-- Stored proc if Last Name and End Date is selected. Will display all changes made by any user with selected last name for Begin Date equal to specified End Date
		ELSE IF @Username is null AND @BeginDate is null
			BEGIN
			SET @BeginDate = @EndDate;
			SELECT a.table_name AS 'Table Name',a.audit_action AS 'Change Action',a.modified_by_user AS Username,a.modified_date AS Date
			FROM dbo.Audit a
			WHERE (a.modified_date BETWEEN @BeginDate AND @EndDate) AND
				a.modified_by_last = @UserLast
			END
	-- Stored proc if Last Name and Date Range is selected. Will display all changes made by any user with selected last name for specified date range
		ELSE IF @Username is null
			BEGIN
			SELECT a.table_name AS 'Table Name',a.audit_action AS 'Change Action',a.modified_by_user AS Username,a.modified_date AS Date
			FROM dbo.Audit a
			WHERE (a.modified_date BETWEEN @BeginDate AND @EndDate) AND
				a.modified_by_last = @UserLast
			END
	-- Stored proc if Username and Date Range is selected. Will display all changes made by that username for specified date range
		ELSE IF @UserLast is null
			BEGIN
			SELECT a.table_name AS 'Table Name',a.audit_action AS 'Change Action',a.modified_by_user AS Username,a.modified_date AS Date
			FROM dbo.Audit a
			WHERE (a.modified_date BETWEEN @BeginDate AND @EndDate) AND
				a.modified_by_user = @Username
			END
	-- Stored proc with only Username, User Last, and Begin Date set. Will show specific Username and User Last selection for Selected Begin to Current Day only
		ELSE IF @EndDate is null
			BEGIN
			SET @EndDate = GETDATE();
			SELECT a.table_name AS 'Table Name',a.audit_action AS 'Change Action',a.modified_by_user AS Username,a.modified_date AS Date
			FROM dbo.Audit a
			WHERE (a.modified_date BETWEEN @BeginDate AND @EndDate) AND
			a.modified_by_user = @Username AND
			a.modified_by_last = @UserLast
			END
	-- Stored proc with only Username, User Last, and End Date set. Will show specific Username and User Last selection for Begin Date equal to End Date
		ELSE IF @BeginDate is null
			BEGIN
			SET @BeginDate = @EndDate;
			SELECT a.table_name AS 'Table Name',a.audit_action AS 'Change Action',a.modified_by_user AS Username,a.modified_date AS Date
			FROM dbo.Audit a
			WHERE (a.modified_date BETWEEN @BeginDate AND @EndDate) AND
			a.modified_by_user = @Username AND
			a.modified_by_last = @UserLast
			END
	-- Stored proc if all params selected. Will display all changes made by specific user with specific last name for specified date range
		ELSE
			BEGIN
			SELECT a.table_name AS 'Table Name',a.audit_action AS 'Change Action',a.modified_by_user AS Username,a.modified_date AS Date
			FROM dbo.Audit a
			WHERE (a.modified_date BETWEEN @BeginDate AND @EndDate) AND
				a.modified_by_last = @UserLast AND
				a.modified_by_user = @Username
			END
	END