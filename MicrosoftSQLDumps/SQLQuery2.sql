CREATE PROC UserAddOrEdit
@CustomerID bigint,
@CustomerName varchar(50),
@PhoneNumber bigint,
@Address varchar(250),
@UserName varchar(50),
@Password varchar(50),
@Email varchar(200),
@CreditCardNumber bigint
AS
	IF @CustomerID = 0
	BEGIN
	INSERT INTO team_project475.customer(CustomerName,PhoneNumber,Address, Email, username, password, CreditCardNumber)
	VALUES (@CustomerName,@PhoneNumber,@Address, @Email, @UserName,@Password, @CreditCardNumber)
END
ELSE
BEGIN
	UPDATE team_project475.customer
	SET
	CustomerName = @CustomerName,
	PhoneNumber = @PhoneNumber,
	Email = @Email,
	CreditCardNumber = @CreditCardNumber,
	Address = @Address,
	username =@UserName,
	password =@Password
WHERE CustomerID = @CustomerID
	END