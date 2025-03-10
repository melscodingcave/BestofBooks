CREATE OR ALTER PROCEDURE CreateNewBook

@title varchar(100),
@isbn varchar(13),
@authorFirst varchar(100),
@authorLast varchar(100),
@genre varchar(50),
@location varchar(3),
@price money,
@quantity int,
@modifiedBy varchar(30)

AS

BEGIN

	DECLARE @AuthorID INT
	IF EXISTS (SELECT author_id FROM dbo.Author WHERE author_firstname = @authorFirst AND author_lastname = @authorLast)
	BEGIN
		SELECT @AuthorID = MAX(author_id) FROM dbo.Author WHERE author_firstname = @authorFirst AND author_lastname = @authorLast
	END
	ELSE
	BEGIN
		INSERT INTO dbo.Author (author_firstname, author_lastname, modifiedby) VALUES (@authorFirst, @authorLast, @modifiedBy)
		SET @AuthorID = SCOPE_IDENTITY()
	END

	DECLARE @GenreID INT
	IF EXISTS (SELECT genre_id FROM dbo.Genre WHERE genre_type = @genre)
	BEGIN
		SELECT @GenreID = MAX(genre_id) FROM dbo.Genre WHERE genre_type = @genre
	END
	ELSE
	BEGIN
		INSERT INTO dbo.Genre (genre_type, modifiedby) VALUES (@genre, @modifiedBy)
		SET @GenreID = SCOPE_IDENTITY()
	END

	INSERT INTO Book (isbn, title, author_id, genre_id, in_stock, quantity, location, price, modifiedby)
	VALUES
	(
		@isbn,
		@title,
		@AuthorID,
		@GenreID,
		CASE WHEN @quantity > 0 THEN 1 ELSE 0 END,
        @quantity,
		@location,
		@price,
		@modifiedBy
	)

END
