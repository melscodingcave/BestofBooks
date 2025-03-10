
ALTER TABLE dbo.Book
ADD ModifiedBy varchar(50);

ALTER TABLE dbo.Author
ADD ModifiedBy varchar(50);

ALTER TABLE dbo.BobUser
ADD ModifiedBy varchar(50);

ALTER TABLE dbo.Genre
ADD ModifiedBy varchar(50);
