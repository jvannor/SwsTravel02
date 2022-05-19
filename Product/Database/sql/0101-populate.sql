INSERT INTO AccomodationMapType (
	AccomodationMapTypeName,
	Description
) VALUES (
	'Seat Map',
	NULL
), (
	'Room Map',
	NULL
);
GO

INSERT INTO DayOfTheWeek (
	DayName
) VALUES (
	'Sunday'
), (
	'Monday'
), (
	'Tuesday'
), (
	'Wednesday'
), (
	'Thursday'
), (
	'Friday'
), (
	'Saturday'
);
GO

INSERT INTO FacilityType (
	FacilityTypeName
) VALUES (
	'Train Station'
), (
	'Airport'
), (
	'Ship Port'
), (
	'Bus Depot'
), (
	'Other Port'
);
GO

INSERT INTO FixedAssetType (
	FixedAssetTypeName,
	Description
) VALUES (
	'Transportation Vehicle',
	NULL
), (
	'Rental Vehicle',
	NULL
), (
	'Hotel',
	NULL
);
GO

INSERT INTO OrganizationRoleType (
	OrganizationRoleName
) VALUES (
	'Travel Provider'
), (
	'Other'
);
GO

INSERT INTO TravelProductType (
	TravelProductTypeName,
	Description
) VALUES (
	'Flight Offering',
	NULL
), (
	'Bus Offering',
	NULL
), (
	'Train Offering',
	NULL
), (
	'Ship Offering',
	NULL
), (
	'Other Passenger Transportation Offering',
	NULL
), (
	'Hotel Offering',
	NULL
), (
	'Rental Car Offering',
	NULL
), (
	'Amenities Offering',
	NULL
), (
	'Item Offering',
	NULL
), (
	'Other Travel Offering',
	NULL
);
GO

DECLARE @FacilityTypeID INT;

SELECT @FacilityTypeID = FacilityTypeID
FROM FacilityType
WHERE FacilityTypeName LIKE 'Ship Port';

INSERT INTO Facility (
	FacilityTypeID,
	FacilityName
) VALUES (
	@FacilityTypeID,
	'Fort Lauderdale'
), (
	@FacilityTypeID,
	'Jacksonville'
), (
	@FacilityTypeID,
	'Miami'
), (
	@FacilityTypeID,
	'Palm Beach'
), (
	@FacilityTypeID,
	'Port Canaveral'
), (
	@FacilityTypeID,
	'Tampa'
), (
	@FacilityTypeID,
	'Roatan'
), (
	@FacilityTypeID,
	'Ochos Rios'
), (
	@FacilityTypeID,
	'Oranjestad'
), (
	@FacilityTypeID,
	'St. Kitts'
), (
	@FacilityTypeID,
	'San Juan'
), (
	@FacilityTypeID,
	'Grand Turk'
), (
	@FacilityTypeID,
	'Grand Cayman'
), (
	@FacilityTypeID,
	'Cozumel'
), (
	@FacilityTypeID,
	'St. Thomas'
), (
	@FacilityTypeID,
	'St. Maarten'
);
GO

DECLARE @TravelProductTypeID INT;

SELECT @TravelProductTypeID = TravelProductTypeID
FROM TravelProductType
WHERE TravelProductTypeName LIKE 'Ship Offering';

DECLARE @FacilityID_GoingTo INT;

SELECT @FacilityID_GoingTo = FacilityID 
FROM Facility
WHERE FacilityName LIKE 'St. Maarten';

DECLARE @FacilityID_OriginatingFrom INT;

SELECT @FacilityID_OriginatingFrom = FacilityID
FROM Facility
WHERE FacilityName LIKE 'Miami';

INSERT INTO TravelProduct (
	TravelProductTypeID,
	TravelProductName,
	FacilityID_GoingTo,
	FacilityID_OriginatingFrom
) VALUES (
	@TravelProductTypeID,
	'Seven Day Cruise',
	@FacilityID_GoingTo,
	@FacilityID_OriginatingFrom
), (
	@TravelProductTypeID,
	'Ten Day Cruise',
	@FacilityID_GoingTo,
	@FacilityID_OriginatingFrom
);
GO