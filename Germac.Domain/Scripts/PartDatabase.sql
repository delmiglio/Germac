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