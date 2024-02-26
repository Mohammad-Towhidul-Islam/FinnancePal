CREATE TABLE LiabilityList
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    AssetName VARCHAR(100) NOT NULL,
    Category VARCHAR(50),
    Amount DECIMAL(18, 2) NOT NULL,
    Description VARCHAR(255)
);