UPDATE Employees 
SET Name = @Name, 
Title = @Title, 
Email = @Email, 
Phone = @Phone, 
CompanyId = @CompanyId 
WHERE EmployeeId = @EmployeeId