create database  Sales_db;
go
use Sales_db; 
go
CREATE TABLE Users(
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (100) NULL,
    [LastName]   VARCHAR (100) NULL,
    [UserName]  VARCHAR (100) NULL,
    [Password]  VARCHAR (MAX) NULL,
    PRIMARY KEY (Id)
); 
go
CREATE TABLE Products  (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (100) NULL,
    [Price]       MONEY  NULL,
    [Description]  VARCHAR (MAX) NULL,
    PRIMARY KEY (Id)
);
go
CREATE TABLE BuyProducts  (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [DateCreated]     DATETIME  NOT NULL,
    [UserId]  INT NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY ([UserId]) REFERENCES Users(Id),
);
go
CREATE TABLE BuyProductDetails  (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Quantity]  INT  NOT NULL,
    [BuyProductId] int not NULL,
    [ProductId] int not NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY ([BuyProductId]) REFERENCES BuyProducts(Id),
    FOREIGN KEY ([ProductId]) REFERENCES Products(Id),
);
go

CREATE PROCEDURE SP_LISTAR  (@UsuarioId int)
AS    
-- ===================================================================
-- Author: Dixroby Arone 
-- Create date: 17/11/21
-- Description: Consultar por usuario la lista de compras mediante un procedimiento
-- almacenado
-- =================================================================== 
   SELECT * FROM 
        Products a
        INNER JOIN 
        BuyProductDetails b  on a.Id = b.ProductId
        INNER JOIN 
        BuyProducts c on b.BuyProductId = c.id
        INNER JOIN 
        Users d on c.UserId = d.id

        where d.id = @UsuarioId
go