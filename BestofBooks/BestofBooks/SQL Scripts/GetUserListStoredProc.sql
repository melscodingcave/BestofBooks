USE BestofBooks
GO

CREATE OR ALTER PROCEDURE GetUserList

AS

BEGIN
	BEGIN
	SELECT u.BoBuser_id,u.user_first,u.user_last,u.user_type,u.username,u.password,u.is_ViewOnly,u.adds_enabled,u.edits_enabled,u.deletes_enabled,u.is_Admin
	FROM dbo.BoBUser u
	END
END