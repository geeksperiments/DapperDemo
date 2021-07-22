INSERT INTO Companies (Name, Address, City, State, PostalCode) 
VALUES(@Name, @Address, @City, @State, @PostalCode);
SELECT CAST(SCOPE_IDENTITY() as int);