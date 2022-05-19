CREATE TABLE ContactMechanism(
    ContactMechanismID INT IDENTITY(1, 1) NOT NULL,
    ContactMechanismName NVARCHAR(256) NOT NULL,
    Description NVARCHAR(512) NULL,
    CONSTRAINT PK_ContactMechanism PRIMARY KEY (ContactMechanismID),
	CONSTRAINT UC_ContactMechanismName UNIQUE (ContactMechanismName)
);
GO

CREATE TABLE FacilityType(
    FacilityTypeID INT IDENTITY(1, 1) NOT NULL,
    FacilityTypeName NVARCHAR(256) NOT NULL,
    CONSTRAINT PK_FacilityType PRIMARY KEY (FacilityTypeID),
	CONSTRAINT UC_FacilityTypeName UNIQUE (FacilityTypeName)
);
GO

CREATE TABLE Facility(
    FacilityID INT IDENTITY(1, 1) NOT NULL,
    FacilityTypeID INT NOT NULL,
    FacilityName NVARCHAR(256),    
    Description NVARCHAR(512) NULL,
    SquareFootage INT,
    PartOfFacilityID INT NULL,
    PartOfFacilityTypeID INT NULL
    CONSTRAINT PK_Facility PRIMARY KEY (
        FacilityID 
    ), CONSTRAINT FK_FacilityTypeFacility FOREIGN KEY (
        FacilityTypeID
    ) REFERENCES FacilityType (
        FacilityTypeID
    ), CONSTRAINT FK_FacilityFacility FOREIGN KEY (
        PartOfFacilityID
    ) REFERENCES Facility (
        FacilityID
    ), CONSTRAINT UC_FAcilityName UNIQUE (FacilityName)
);
GO

CREATE TABLE FacilityContactMechanism(
    ContactMechanismID INT NOT NULL,
    FacilityID INT NOT NULL,
    CONSTRAINT PK_FacilityContactMechanism PRIMARY KEY (
        ContactMechanismID, 
        FacilityID
    )
);
GO

CREATE TABLE TravelProductType(
    TravelProductTypeID INT IDENTITY(1, 1) NOT NULL,
    TravelProductTypeName NVARCHAR(256) NOT NULL,
    Description NVARCHAR(512) NULL,
    CONSTRAINT PK_TravelProductTypeID PRIMARY KEY (TravelProductTypeID),
	CONSTRAINT UC_TravelProductTypeName UNIQUE (TravelProductTypeName)
);
GO

CREATE TABLE TravelProduct(
    TravelProductID INT IDENTITY(1, 1) NOT NULL,
    TravelProductTypeID INT NOT NULL,
    TravelProductName NVARCHAR(256) NOT NULL,
    Description NVARCHAR(512) NULL,
    FacilityID_GoingTo INT NULL,
    FacilityID_OriginatingFrom INT NULL,
    CONSTRAINT PK_TravelProduct PRIMARY KEY (
        TravelProductID
    ), CONSTRAINT FK_TravelProductTypeTravelProduct FOREIGN KEY (
        TravelProductTypeID
    ) REFERENCES TravelProductType(
        TravelProductTypeID
    ), CONSTRAINT FK_FacilityGoingToTravelProduct FOREIGN KEY (
        FacilityID_GoingTo
    ) REFERENCES Facility (
        FacilityID
    ), CONSTRAINT FK_FacilityOriginatingFromTravelProduct FOREIGN KEY (
        FacilityID_OriginatingFrom
    ) REFERENCES Facility (
        FacilityID
    ), CONSTRAINT UC_TravelProductName UNIQUE (TravelProductName),
);
GO

CREATE TABLE TravelProductReferenceNumber(
    TravelProductReferenceNumberID NVARCHAR(32) NOT NULL,
    TravelProductID INT NOT NULL,
    FromDate DATE NOT NULL,
    ThruDate DATE NOT NULL
    CONSTRAINT PK_TravelProductReferenceNumber PRIMARY KEY (
        TravelProductReferenceNumberID, 
        TravelProductID,
        FromDate
	), CONSTRAINT FK_TravelProductTravelProductReferenceNumber FOREIGN KEY (
        TravelProductID
    ) REFERENCES TravelProduct (
        TravelProductID
    )
);
GO

CREATE TABLE TravelProductComplement(
    TravelProductID_Of INT NOT NULL,
    TravelProductID_For INT NOT NULL
    CONSTRAINT PK_TravelProductComplement PRIMARY KEY (
        TravelProductID_Of, 
        TravelProductID_For
    ), CONSTRAINT FK_TravelProductTravelProductComplementOf FOREIGN KEY (
        TravelProductID_Of
    ) REFERENCES TravelProduct(
        TravelProductID
    ), CONSTRAINT FK_TravelProductTravelProductComplementFor FOREIGN KEY (
        TravelProductID_For
    ) REFERENCES TravelProduct(
        TravelProductID
    )
);
GO

CREATE TABLE ProductCategory(
    ProductCategoryID INT IDENTITY(1, 1) NOT NULL,
    ProductCategoryName NVARCHAR(256) NOT NULL,
    Description NVARCHAR(512) NULL,
    CONSTRAINT PK_ProductCategory PRIMARY KEY (ProductCategoryID),
	CONSTRAINT UC_ProductCategoryName UNIQUE (ProductCategoryName)
);
GO

CREATE TABLE ProductCategoryClassification(
    ProductCategoryID INT NOT NULL,
    TravelProductID INT NOT NULL,
    FromDate DATE NOT NULL,
    ThruDate DATE NOT NULL,
    Comments NVARCHAR(512) NULL,
    PrimaryFlag BIT NOT NULL
    CONSTRAINT PK_ProductCategoryClassification PRIMARY KEY (
        ProductCategoryID, 
        TravelProductID, 
        FromDate
    )
);
GO

CREATE TABLE DayOfTheWeek(
    DayOfTheWeekID INT IDENTITY(1, 1) NOT NULL,
    DayName NVARCHAR(32) NOT NULL,
    CONSTRAINT PK_DayOfTheWeek PRIMARY KEY (DayOfTheWeekID),
	CONSTRAINT UC_DayName UNIQUE (DayName)
);
GO

CREATE TABLE RegularlyScheduledTime(
    FromDate DATE NOT NULL,
    TravelProductID INT NOT NULL,
    DayID_OfferedArriving INT NOT NULL,
    DayID_OfferedDeparting INT NOT NULL,
    ArrivalTime TIME NOT NULL,
    DepartureTime TIME NOT NULL,
    ThruDate DATE NOT NULL,
    CONSTRAINT PK_RegularlyScheduledTime PRIMARY KEY (FromDate),
    CONSTRAINT FK_DayOfTheWeekRegularlyScheduledTime_OfferedArriving FOREIGN KEY (
        DayID_OfferedArriving
    ) REFERENCES DayOfTheWeek(
        DayOfTheWeekID
    ), CONSTRAINT FK_DayOfTheWeekRegularlyScheduledTime_OdderedDeparting FOREIGN KEY (
        DayID_OfferedDeparting
    ) REFERENCES DayOfTheWeek(
        DayOfTheWeekID
    ), CONSTRAINT FK_TravelProductRegularlyScheduledTime FOREIGN KEY (
        TravelProductID
    ) REFERENCES TravelProduct(
        TravelProductID
    )
);
GO

CREATE TABLE OrganizationRoleType(
    OrganizationRoleTypeID INT IDENTITY(1, 1) NOT NULL,
    OrganizationRoleName NVARCHAR(256),
    CONSTRAINT PK_OrganizationRoleType PRIMARY KEY (OrganizationRoleTypeID),
	CONSTRAINT UC_OrganizationRoleName UNIQUE (OrganizationRoleName)
);
GO

CREATE TABLE OrganizationRole(
    PartyID INT NOT NULL,
    OrganizationRoleTypeID INT NOT NULL,
    CONSTRAINT PK_OrganizationRole PRIMARY KEY (
        PartyID,
        OrganizationRoleTypeID
    ), CONSTRAINT FK_OrganizationRoleTypeOrganizationRole FOREIGN KEY (
        OrganizationRoleTypeID
    ) REFERENCES OrganizationRoleType(
        OrganizationRoleTypeID
    )
);
GO

CREATE TABLE FixedAssetType(
    FixedAssetTypeID INT IDENTITY(1, 1) NOT NULL,
    FixedAssetTypeName NVARCHAR(256) NOT NULL,
    Description NVARCHAR(512),
    CONSTRAINT PK_FixedAssetType PRIMARY KEY (FixedAssetTypeID),
	CONSTRAINT UC_FixedAssetTypeName UNIQUE (FixedAssetTypeName)
);
GO

CREATE TABLE FixedAsset(
    FixedAssetID INT IDENTITY(1, 1) NOT NULL,
    FixedAssetTypeID INT NOT NULL,
    FixedAssetName NVARCHAR(256),
    PartyID INT NOT NULL,
    OrganizationRoleTypeID INT NOT NULL,
    DateAcquired DATE NULL,
    DateLastServiced DATE NULL,
    DateNextService DATE NULL,
    Capacity DECIMAL NULL,
    TravelProductID INT NULL
    CONSTRAINT PK_FixedAsset PRIMARY KEY (
        FixedAssetID
    ), CONSTRAINT FK_FixedAssetTypeFixedAsset FOREIGN KEY (
        FixedAssetTypeID
    ) REFERENCES FixedAssetType(
        FixedAssetTypeID
    ), CONSTRAINT FK_OrgniazationRoleFixedAsset FOREIGN KEY (
        PartyID, 
        OrganizationRoleTypeID
    ) REFERENCES OrganizationRole(
        PartyID, 
        OrganizationRoleTypeID
    ),
    CONSTRAINT FK_TravelProductFixedAsset FOREIGN KEY (
        TravelProductID
    ) REFERENCES TravelProduct(
        TravelProductID
    ), CONSTRAINT UC_FixedAssetName UNIQUE (FixedAssetName),
);
GO

CREATE TABLE AccomodationClass(
    AccomodationClassID INT IDENTITY(1, 1) NOT NULL,
    Description NVARCHAR(512) NUll,
    CONSTRAINT PK_AccomodationClass PRIMARY KEY (AccomodationClassID)
);
GO

CREATE TABLE AccomodationMapType(
    AccomodationMapTypeID INT IDENTITY(1, 1) NOT NULL,
    AccomodationMapTypeName NVARCHAR(256) NOT NULL,
    Description NVARCHAR(512) NULL,
    CONSTRAINT PK_AccomodationMapType PRIMARY KEY (AccomodationMapTypeID),
	CONSTRAINT UC_AccomodationMapTypeName UNIQUE (AccomodationMapTypeName)
);
GO

CREATE TABLE AccomodationMap(
    AccomodationMapTypeID INT NOT NULL,
    AccomodationClassID INT NOT NULL,
    FixedAssetID INT NOT NULL,
    NumberOfSpaces INT NOT NULL,
    CONSTRAINT PK_AccomondationMap PRIMARY KEY (
        AccomodationMapTypeID, 
        AccomodationClassID, 
        FixedAssetID, 
        NumberOfSpaces
    ), CONSTRAINT FK_AccomodationMapTypeAccomodationMap FOREIGN KEY (
        AccomodationMapTypeID
    ) REFERENCES AccomodationMapType (
        AccomodationMapTypeID
    ), CONSTRAINT FK_AccomodationClassAccomodationMap FOREIGN KEY (
        AccomodationClassID
    ) REFERENCES AccomodationClass (
        AccomodationClassID
    ), CONSTRAINT FK_FixedAssetAccomodationMap FOREIGN KEY (
        FixedAssetID
    ) REFERENCES FixedAsset (
        FixedAssetID
    )
);
GO

CREATE TABLE ScheduledTransportation(
    FixedAssetID INT NOT NULL,
    TravelProductID INT NOT NULL,
    ScheduledTransportationID INT IDENTITY(1, 1) NOT NULL,
    PartyID INT NOT NULL,
    OrganizationRoleTypeID INT NOT NULL,
    ArrivalDate DATE NULL,
    ArrivalTime TIME NULL,
    DepartureDate DATE NULL,
    DepartureTime TIME NULL
    CONSTRAINT PK_ScheduledTransportation PRIMARY KEY (
        FixedAssetID, 
        TravelProductID, 
        ScheduledTransportationID
    ), CONSTRAINT FK_FixedAssetScheduledTransportation FOREIGN KEY (
        FixedAssetID
    ) REFERENCES FixedAsset (
        FixedAssetID
    ),CONSTRAINT FK_TravelProductScheduledTransportation FOREIGN KEY (
        TravelProductID
    ) REFERENCES TravelProduct (
        TravelProductID
    ), CONSTRAINT FK_OrgniazationRoleScheduledTransportation FOREIGN KEY (
        PartyID,
        OrganizationRoleTypeID
    ) REFERENCES OrganizationRole(
        PartyID, 
        OrganizationRoleTypeID
    )
);
GO

CREATE TABLE ScheduledTransportationOffering(
    FixedAssetID INT NOT NULL,
    TravelProductID INT NOT NULL,
    ScheduledTransportationID INT NOT NULL,
    ScheduledTransportationOfferingID INT IDENTITY(1, 1) NOT NULL,
    FromDate DATE NOT NULL,
    Quantity INT NOT NULL,
    ThruDate DATE NOT NULL,
    CONSTRAINT PK_ScheduledTransportationOffering PRIMARY KEY (
        FixedAssetID,
        TravelProductID,
        ScheduledTransportationID,
        ScheduledTransportationOfferingID
    ), CONSTRAINT FK_ScheduledTransportationScheduledTransportationOffering FOREIGN KEY (
        FixedAssetID,
        TravelProductID,
        ScheduledTransportationID
    ) REFERENCES ScheduledTransportation (
        FixedAssetID,
        TravelProductID,
        ScheduledTransportationID
    )
);
GO
