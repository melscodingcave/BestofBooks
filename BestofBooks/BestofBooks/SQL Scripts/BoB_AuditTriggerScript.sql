/*Best of Books Audit Table Creation and Triggers Script*/

USE BestofBooks
GO

CREATE TABLE Audit (
	change_id            int	IDENTITY(1,1)		NOT NULL UNIQUE,
	table_name           varchar(30)      NOT NULL,
	modified_by_user     varchar(30)      NOT NULL,
	modified_by_last     varchar(30)      NOT NULL,
	modified_date        varchar(30)      NOT NULL,
	audit_action         varchar(30)	NOT NULL,
	CONSTRAINT pk_Audit	PRIMARY KEY  (change_id) 
);
GO

CREATE TRIGGER TR_Book_AfterInsert
ON Book
AFTER INSERT
AS

DECLARE @ModifiedBy varchar(30)
DECLARE @ModifiedByLast varchar(30)

SELECT @ModifiedBy = ins.ModifiedBy FROM INSERTED ins;
SELECT @ModifiedByLast = u.user_last FROM dbo.BoBUser u WHERE u.username = @ModifiedBy;

INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Book', @ModifiedBy, @ModifiedByLast, GETDATE(), 'Insert');

GO

CREATE TRIGGER TR_Book_AfterUpdate
ON Book
AFTER UPDATE
AS

DECLARE @ModifiedBy varchar(30)
DECLARE @ModifiedByLast varchar(30)

SELECT @ModifiedBy = ins.ModifiedBy FROM INSERTED ins;
SELECT @ModifiedByLast = u.user_last FROM dbo.BoBUser u WHERE u.username = @ModifiedBy;

INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Book', @ModifiedBy, @ModifiedByLast, GETDATE(), 'Update');

GO

CREATE TRIGGER TR_Book_AfterDelete
ON Book
AFTER DELETE
AS

DECLARE @ModifiedBy varchar(30)
DECLARE @ModifiedByLast varchar(30)

SELECT @ModifiedBy = ins.ModifiedBy FROM DELETED ins;
SELECT @ModifiedByLast = u.user_last FROM dbo.BoBUser u WHERE u.username = @ModifiedBy;

INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Book', @ModifiedBy, @ModifiedByLast, GETDATE(), 'Delete');
GO

CREATE TRIGGER TR_Author_AfterInsert
ON Author
AFTER INSERT
AS

DECLARE @ModifiedBy varchar(30)
DECLARE @ModifiedByLast varchar(30)

SELECT @ModifiedBy = ins.ModifiedBy FROM INSERTED ins;
SELECT @ModifiedByLast = u.user_last FROM dbo.BoBUser u WHERE u.username = @ModifiedBy;

INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Author', @ModifiedBy, @ModifiedByLast, GETDATE(), 'Insert');

GO

CREATE TRIGGER TR_Author_AfterUpdate
ON Author
AFTER UPDATE
AS

DECLARE @ModifiedBy varchar(30)
DECLARE @ModifiedByLast varchar(30)

SELECT @ModifiedBy = ins.ModifiedBy FROM INSERTED ins;
SELECT @ModifiedByLast = u.user_last FROM dbo.BoBUser u WHERE u.username = @ModifiedBy;

INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Author', @ModifiedBy, @ModifiedByLast, GETDATE(), 'Update');

GO

CREATE TRIGGER TR_Author_AfterDelete
ON Author
AFTER DELETE
AS

DECLARE @ModifiedBy varchar(30)
DECLARE @ModifiedByLast varchar(30)

SELECT @ModifiedBy = ins.ModifiedBy FROM DELETED ins;
SELECT @ModifiedByLast = u.user_last FROM dbo.BoBUser u WHERE u.username = @ModifiedBy;

INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Author', @ModifiedBy, @ModifiedByLast, GETDATE(), 'Delete');

GO

CREATE TRIGGER TR_BoBUser_AfterInsert
ON BoBUser
AFTER INSERT
AS

DECLARE @ModifiedBy varchar(30)
DECLARE @ModifiedByLast varchar(30)

SELECT @ModifiedBy = ins.ModifiedBy FROM INSERTED ins;
SELECT @ModifiedByLast = u.user_last FROM dbo.BoBUser u WHERE u.username = @ModifiedBy;

INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('BoBUser', @ModifiedBy, @ModifiedByLast, GETDATE(), 'Insert');

GO

CREATE TRIGGER TR_BoBUser_AfterUpdate
ON BoBUser
AFTER UPDATE
AS

DECLARE @ModifiedBy varchar(30)
DECLARE @ModifiedByLast varchar(30)

SELECT @ModifiedBy = ins.ModifiedBy FROM INSERTED ins;
SELECT @ModifiedByLast = u.user_last FROM dbo.BoBUser u WHERE u.username = @ModifiedBy;

INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('BoBUser', @ModifiedBy, @ModifiedByLast, GETDATE(), 'Update');

GO

CREATE TRIGGER TR_BoBUser_AfterDelete
ON BoBUser
AFTER DELETE
AS

DECLARE @ModifiedBy varchar(30)
DECLARE @ModifiedByLast varchar(30)

SELECT @ModifiedBy = ins.ModifiedBy FROM DELETED ins;
SELECT @ModifiedByLast = u.user_last FROM dbo.BoBUser u WHERE u.username = @ModifiedBy;

INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('BoBUser', @ModifiedBy, @ModifiedByLast, GETDATE(), 'Delete');

GO

CREATE TRIGGER TR_Genre_AfterInsert
ON Genre
AFTER INSERT
AS

DECLARE @ModifiedBy varchar(30)
DECLARE @ModifiedByLast varchar(30)

SELECT @ModifiedBy = ins.ModifiedBy FROM INSERTED ins;
SELECT @ModifiedByLast = u.user_last FROM dbo.BoBUser u WHERE u.username = @ModifiedBy;

INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Genre', @ModifiedBy, @ModifiedByLast, GETDATE(), 'Insert');

GO

CREATE TRIGGER TR_Genre_AfterUpdate
ON Genre
AFTER UPDATE
AS

DECLARE @ModifiedBy varchar(30)
DECLARE @ModifiedByLast varchar(30)

SELECT @ModifiedBy = ins.ModifiedBy FROM INSERTED ins;
SELECT @ModifiedByLast = u.user_last FROM dbo.BoBUser u WHERE u.username = @ModifiedBy;

INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Genre', @ModifiedBy, @ModifiedByLast, GETDATE(), 'Update');

GO

CREATE TRIGGER TR_Genre_AfterDelete
ON Genre
AFTER DELETE
AS

DECLARE @ModifiedBy varchar(30)
DECLARE @ModifiedByLast varchar(30)

SELECT @ModifiedBy = ins.ModifiedBy FROM DELETED ins;
SELECT @ModifiedByLast = u.user_last FROM dbo.BoBUser u WHERE u.username = @ModifiedBy;

INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Genre', @ModifiedBy, @ModifiedByLast, GETDATE(), 'Delete');

GO

