
CREATE OR ALTER PROCEDURE GetAuditRecords

AS

BEGIN
	SELECT table_name as TableName, modified_by_user as ModifiedBy, modified_by_last as ModifiedLast, modified_date as Modified, audit_action as Action
	FROM dbo.Audit a
END
