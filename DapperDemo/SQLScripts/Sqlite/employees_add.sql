INSERT INTO Employees (Name, Title, Email, Phone, CompanyId) 
VALUES(@Name, @Title, @Email, @Phone, @CompanyId);
SELECT last_insert_rowid();