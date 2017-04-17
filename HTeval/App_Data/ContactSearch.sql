CREATE PROCEDURE dbo.ContactSearch
	@FirstNameParameter varchar(50),
	@LastNameParameter varchar(50)
AS

SELECT 
	ID,
	FirstName,
	LastName,
	EmailAddress,
	BirthDate,
	NumberOfComputers
FROM ContactModels
WHERE FirstName like isnull(@FirstNameParameter,'') + '%'
	and LastName like isnull(@LastNameParameter,'') + '%'
ORDER BY 
	FirstName,
	LastName

RETURN 0