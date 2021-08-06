INSERT INTO Employees (Name, Title, Email, Phone, CompanyId) 
VALUES(@Name, @Title, @Email, @Phone, @CompanyId);
SELECT CAST(SCOPE_IDENTITY() as int);