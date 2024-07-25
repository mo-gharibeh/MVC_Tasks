CREATE DATABASE TASKDATA
GO
USE TASKDATA
GO
CREATE TABLE Product (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    Category VARCHAR(50),
    Price DECIMAL(10, 2),
    StockQuantity INT,
    DateAdded DATE
);

SELECT * FROM Product
