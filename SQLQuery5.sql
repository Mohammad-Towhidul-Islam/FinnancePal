CREATE TABLE Expenselist
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    ExpenseName VARCHAR(100) NOT NULL,
    Category VARCHAR(50),
    Value DECIMAL(18, 2) NOT NULL,
    Description VARCHAR(255),
	Date Varchar(200)
);