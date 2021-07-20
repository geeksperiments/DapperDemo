INSERT INTO Companies (Name, Address, City, State, PostalCode) 
VALUES(@Name, @Address, @City, @State, @PostalCode);
SELECT last_insert_rowid();