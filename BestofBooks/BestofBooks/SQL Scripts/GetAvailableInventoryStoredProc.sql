USE BestofBooks
GO

CREATE OR ALTER PROCEDURE GetAvailableInventory
@InStock BIT = NULL,
@AuthorName VARCHAR(255) = NULL,
@Genre VARCHAR(255) = NULL
AS

BEGIN
	SET NOCOUNT ON;
	
	-- Base stored proc without any parameters. Will show all inventory information
	IF @InStock is null AND @AuthorName is null AND @Genre is null
		BEGIN
		SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname + ', ' + a.author_firstname AS AuthorName,g.genre_type AS Genre,CASE WHEN b.quantity > 0 THEN 1 ELSE 0 END AS InStock, b.quantity AS Quantity,b.location AS Location,b.price AS Price
		FROM dbo.Book b
		INNER JOIN dbo.Author a ON b.author_id = a.author_id
		INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
		END
	-- Stored proc if Genre Type is selected. Will display all Inventory, regardless of In Stock or not that is associated with that genre
	ELSE IF @InStock is null AND @AuthorName is null
		BEGIN
		SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname + ', ' + a.author_firstname AS AuthorName,g.genre_type AS Genre,CASE WHEN b.quantity > 0 THEN 1 ELSE 0 END AS InStock, b.quantity AS Quantity,b.location AS Location,b.price AS Price
		FROM dbo.Book b
		INNER JOIN dbo.Author a ON b.author_id = a.author_id
		INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
		WHERE
		g.genre_type = @Genre
		END
	-- Stored proc if Author name is selected. Will display all Inventory, regardless of In Stock or not that is associated with that author
	ELSE IF @InStock is null AND @Genre is null
		BEGIN
		SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname + ', ' + a.author_firstname AS AuthorName,g.genre_type AS Genre,CASE WHEN b.quantity > 0 THEN 1 ELSE 0 END AS InStock, b.quantity AS Quantity,b.location AS Location,b.price AS Price
		FROM dbo.Book b
		INNER JOIN dbo.Author a ON b.author_id = a.author_id
		INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
		WHERE
		a.author_lastname + ', ' + a.author_firstname = @AuthorName
		END
	-- Stored proc if In Stock is selected. Will display all Inventory that matches whether the user choise to display In Stock or Not
	ELSE IF @Genre is null AND @AuthorName is null
		BEGIN
		SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname + ', ' + a.author_firstname AS AuthorName,g.genre_type AS Genre,CASE WHEN b.quantity > 0 THEN 1 ELSE 0 END AS InStock, b.quantity AS Quantity,b.location AS Location,b.price AS Price
		FROM dbo.Book b
		INNER JOIN dbo.Author a ON b.author_id = a.author_id
		INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
		WHERE
		b.in_stock = @InStock
		END
	-- Stored proc if Author Name and Genre is selected. Will display all Inventory, regardless of In Stock or not that is associated with that author and genre
		ELSE IF @InStock is null
		BEGIN
		SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname + ', ' + a.author_firstname AS AuthorName,g.genre_type AS Genre,CASE WHEN b.quantity > 0 THEN 1 ELSE 0 END AS InStock, b.quantity AS Quantity,b.location AS Location,b.price AS Price
		FROM dbo.Book b
		INNER JOIN dbo.Author a ON b.author_id = a.author_id
		INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
		WHERE
		a.author_lastname + ', ' + a.author_firstname = @AuthorName
		AND g.genre_type = @Genre
		END
	-- Stored proc if Author Name and In Stock is selected. Will display all Inventory, that is associated with that author and is either in or out of stock depending on selection chosen
		ELSE IF @Genre is null
		BEGIN
		SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname + ', ' + a.author_firstname AS AuthorName,g.genre_type AS Genre,CASE WHEN b.quantity > 0 THEN 1 ELSE 0 END AS InStock, b.quantity AS Quantity,b.location AS Location,b.price AS Price
		FROM dbo.Book b
		INNER JOIN dbo.Author a ON b.author_id = a.author_id
		INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
		WHERE
		a.author_lastname + ', ' + a.author_firstname = @AuthorName
		AND b.in_stock = @InStock
		END
	-- Stored proc if Genre and In Stock is selected. Will display all Inventory, that is associated with that genre and is either in or out of stock depending on selection chosen
	ELSE IF @AuthorName is null
		BEGIN
		SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname + ', ' + a.author_firstname AS AuthorName,g.genre_type AS Genre,CASE WHEN b.quantity > 0 THEN 1 ELSE 0 END AS InStock, b.quantity AS Quantity,b.location AS Location,b.price AS Price
		FROM dbo.Book b
		INNER JOIN dbo.Author a ON b.author_id = a.author_id
		INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
		WHERE
		g.genre_type = @Genre
		AND b.in_stock = @InStock
		END
	-- Stored proc where all parameters are selected. Will display all inventory associated with the genre, author and whether the user chose in stock or out of stock
	ELSE
		BEGIN
		SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname + ', ' + a.author_firstname AS AuthorName,g.genre_type AS Genre,CASE WHEN b.quantity > 0 THEN 1 ELSE 0 END AS InStock, b.quantity AS Quantity,b.location AS Location,b.price AS Price
		FROM dbo.Book b
		INNER JOIN dbo.Author a ON b.author_id = a.author_id
		INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
		WHERE 
		a.author_lastname + ', ' + a.author_firstname = @AuthorName
		AND b.in_stock = @InStock
		AND g.genre_type = @Genre
		END
	END