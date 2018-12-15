CREATE TABLE [dbo].[Product] (    
    Id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(255),
	Quantity int,
    Price float,
	Photo VARCHAR(255),
);

CREATE TABLE [dbo].[Account] (    
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(255),
	Password VARCHAR(255),
);

CREATE TABLE [dbo].[Review] (    
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Content VARCHAR(255),
	Rating float,
    DatePost datetime,
	ProductId INT,
	AccountId INT,
	FOREIGN KEY(ProductId) REFERENCES Product(id),
	FOREIGN KEY(AccountId) REFERENCES Account(iD),
);

SET IDENTITY_INSERT Product ON

INSERT INTO Product (Id, Name, Price, Quantity, Photo)
    VALUES
	(1, 'audi', 1200, 5, 'audi.jpg'),
    (2, 'mercedes', 2000, 12, 'mercedes.jpg'),
    (3, 'ferrari', 3200, 2, 'ferrari.jpg');

SET IDENTITY_INSERT Product OFF 

SET IDENTITY_INSERT Account ON

INSERT INTO Account (Id, Username, Password)
    VALUES
	(1, 'zuber', 'password');

	SET IDENTITY_INSERT Account OFF 

