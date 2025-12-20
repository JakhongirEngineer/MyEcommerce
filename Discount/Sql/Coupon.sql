CREATE TABLE Coupon
(
    Id          SERIAL PRIMARY KEY,
    ProductName VARCHAR(500) NOT NULL,
    Description TEXT,
    Amount      INT
)