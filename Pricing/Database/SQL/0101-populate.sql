INSERT INTO PriceComponentType(
    PriceComponentTypeName
) VALUES (
    'Base Price'
), (
    'Discount Price'
), (
    'Surcharge Component'
), (
    'Manufacturer Suggested Price'
), (
    'One Time Charge'
), (
    'Recurring Charge'
), (
    'Utilization Charge'
);
GO

INSERT INTO UnitOfMeasureType (
    UnitOfMeasureTypeName
) VALUES (
    'Time Frequency Measure'
), (
    'Currency Measure'
);
GO