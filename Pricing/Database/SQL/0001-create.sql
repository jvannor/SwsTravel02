CREATE TABLE GeographicBoundary(
    GeographicBoundaryID INT IDENTITY(1, 1) NOT NULL,
    GeographicCode NVARCHAR(32) NOT NULL,
    GeographicBoundaryName NVARCHAR(256) NOT NULL,
    Abbreviation NVARCHAR(16) NOT NULL,
    CONSTRAINT PK_GeographicBoundary PRIMARY KEY (GeographicBoundaryID),
    CONSTRAINT UC_GeographicCode UNIQUE (GeographicCode),
    CONSTRAINT UC_GeographicBoundaryName UNIQUE (GeographicBoundaryName),
    CONSTRAINT UC_GeographicAbbreviation UNIQUE (Abbreviation)
);
GO

CREATE TABLE PartyType(
    PartyTypeID INT IDENTITY(1, 1) NOT NULL,
    Description NVARCHAR(512) NOT NULL
    CONSTRAINT PK_PartyType PRIMARY KEY (PartyTypeID)
);
GO

CREATE TABLE ProductCategory(
    ProductCategoryID INT IDENTITY(1, 1) NOT NULL,
    Description NVARCHAR(512) NOT NULL,
    CONSTRAINT PK_ProductCategory PRIMARY KEY (ProductCategoryID)
);
GO

CREATE TABLE QuantityBreak(
    QuantityBreakID INT IDENTITY(1, 1) NOT NULL,
    FromQuantity INT NOT NULL,
    ThruQuantity INT NULL,
    CONSTRAINT PK_QuantityBreak PRIMARY KEY (QuantityBreakID)
);
GO

CREATE TABLE OrderValue(
    OrderValueID INT IDENTITY(1, 1) NOT NULL,
    FromAmount INT NOT NULL,
    ThruAmount INT NULL,
    CONSTRAINT PK_OrderValue PRIMARY KEY (OrderValueID)
);
GO

CREATE TABLE SaleType(
    SaleTypeID INT IDENTITY(1, 1) NOT NULL,
    Description NVARCHAR(512) NOT NULL,
    CONSTRAINT PK_SaleType PRIMARY KEY (SaleTypeID)
);
GO

CREATE TABLE UnitOfMeasureType(
    UnitOfMeasureTypeID INT IDENTITY(1, 1) NOT NULL,
    UnitOfMeasureTypeName NVARCHAR(256) NOT NULL,
    CONSTRAINT PK_UnitOfMeasureType PRIMARY KEY (UnitOfMeasureTypeID),
    CONSTRAINT UC_UnitOfMeasureTypeName UNIQUE (UnitOfMeasureTypeName)
);
GO

CREATE TABLE UnitOfMeasure(
    UnitOfMeasureID INT IDENTITY(1, 1) NOT NULL,
    UnitOfMeasureTypeID INT NOT NULL,
    Abbreviation NVARCHAR(16) NOT NULL,
    Description NVARCHAR(512) NOT NULL,
    CONSTRAINT PK_UnitOfMeasure PRIMARY KEY (
        UnitOfMeasureID, 
        UnitOfMeasureTypeID
    ), CONSTRAINT UC_UnitOfMeasureAbbreviation UNIQUE(
        Abbreviation
    ), CONSTRAINT FK_UnitOfMeaaureTypeUnitOfMeasure FOREIGN KEY (
        UnitOfMeasureTypeID
    ) REFERENCES UnitOfMeasureType (
        UnitOfMeasureTypeID
    )
);
GO

CREATE TABLE Product(
    ProductID INT NOT NULL,
    ProductName NVARCHAR(256) NOT NULL,
    CONSTRAINT PK_Product PRIMARY KEY (ProductID),
    CONSTRAINT UC_ProductProductName UNIQUE(ProductName)
);
GO

CREATE TABLE ProductFeature(
    ProductFeatureID INT NOT NULL,
    Description NVARCHAR(512) NOT NULL,
    CONSTRAINT PK_ProductFeature PRIMARY KEY (ProductFeatureID)
);
GO

CREATE TABLE Organization(
    OrganizationID INT IDENTITY(1, 1) NOT NULL,
    OrganizationName NVARCHAR(256) NOT NULL,
    CONSTRAINT PK_Organization PRIMARY KEY (OrganizationID),
    CONSTRAINT UC_OrganizationOrganizationName UNIQUE (OrganizationName)
);
GO

CREATE TABLE PriceComponentType(
    PriceComponentTypeID INT IDENTITY(1, 1) NOT NULL,
    PriceComponentTypeName NVARCHAR(256) NOT NULL,
    CONSTRAINT PK_PriceComponentType PRIMARY KEY (PriceComponentTypeID),
    CONSTRAINT UC_PriceComponentTypePriceComponentName UNIQUE (PriceComponentTypeName)
);
GO

CREATE TABLE PriceComponent(
    PriceComponentID INT IDENTITY(1, 1) NOT NULL,
    PriceComponentTypeID INT NOT NULL,
    FromDate DATE NOT NULL,
    ThruDate DATE NULL,
    Price MONEY NULL,
    Percentage DECIMAL NULL,
    Comment NVARCHAR(512) NULL,
    Quantity INT NULL,
    CONSTRAINT PK_PriceComponent PRIMARY KEY (
        PriceComponentID,
        PriceComponentTypeID
    ), CONSTRAINT FK_PriceComponentTypePriceComponent FOREIGN KEY (
        PriceComponentTypeID
    ) REFERENCES PriceComponentType (
        PriceComponentTypeID
    )
);
GO