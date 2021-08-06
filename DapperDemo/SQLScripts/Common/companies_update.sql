UPDATE Companies 
SET Name = @Name, 
Address = @Address, 
City = @City, 
State = @State, 
PostalCode = @PostalCode 
WHERE CompanyId = @CompanyId