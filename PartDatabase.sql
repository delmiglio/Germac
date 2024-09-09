CREATE SCHEMA germac;
USE germac;

CREATE TABLE Part (
    Id BIGINT NOT NULL AUTO_INCREMENT,
    PartId BIGINT NOT NULL,
    PartNumber TEXT NOT NULL,
    Name TEXT NOT NULL,
    Quantity BIGINT NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    CreateDate DATETIME NOT NULL,
    UpdateDate DATETIME NULL,
    PRIMARY KEY (Id),
    UNIQUE (PartId)
);

CREATE TABLE StockOrder (
    Id BIGINT NOT NULL,        
    OrderId BIGINT NOT NULL,               
    TotalPrice DECIMAL(18, 2) NOT NULL,    
    CreateDate DATETIME NOT NULL,
    UpdateDate DATETIME NULL,
    PRIMARY KEY (Id),
    UNIQUE (OrderId)
);


CREATE TABLE PartStockOrder (
    Id BIGINT NOT NULL AUTO_INCREMENT,
    PartId BIGINT NOT NULL,
    OrderId BIGINT NOT NULL,
    Quantity BIGINT NOT NULL,
    OrderDate DATETIME NOT NULL,
    CreateDate DATETIME NOT NULL,
    UpdateDate DATETIME NULL,
    PRIMARY KEY (Id)
);


ALTER TABLE PartStockOrder
ADD CONSTRAINT FK_PartStockOrder_Part FOREIGN KEY (PartId)
        REFERENCES Part(PartId)
        ON DELETE CASCADE
        ON UPDATE CASCADE;

ALTER TABLE PartStockOrder
ADD CONSTRAINT FK_PartStockOrder_StockOrder FOREIGN KEY (OrderId)
        REFERENCES PartStockOrder(OrderId)
        ON DELETE CASCADE
        ON UPDATE CASCADE;

USE germac;

-- Inserting sample data into the Part table
INSERT INTO Part (PartId, PartNumber, Name, Quantity, Price, CreateDate, UpdateDate)
VALUES
(1, 'PN001', 'Widget A', 100, 29.99, NOW(), NULL),
(2, 'PN002', 'Widget B', 150, 49.99, NOW(), NULL),
(3, 'PN003', 'Widget C', 200, 19.99, NOW(), NULL),
(4, 'PN004', 'Widget D', 300, 99.99, NOW(), NULL),
(5, 'PN005', 'Widget E', 50, 9.99, NOW(), NULL);

