-- Создание таблицы Cars
CREATE TABLE Cars (
    CarId SERIAL PRIMARY KEY,
    Model VARCHAR(100) NOT NULL,
    Manufacturer VARCHAR(100) NOT NULL,
    Year INT NOT NULL CHECK (Year > 1900 AND Year <= EXTRACT(YEAR FROM CURRENT_DATE)),
    PricePerDay DECIMAL(10, 2) NOT NULL CHECK (PricePerDay >= 0)
);

-- Создание таблицы Customers
CREATE TABLE Customers (
    CustomerId SERIAL PRIMARY KEY,
    FullName VARCHAR(150) NOT NULL,
    Phone VARCHAR(20) NOT NULL UNIQUE,
    Email VARCHAR(150) UNIQUE
);

-- Создание таблицы Rentals
CREATE TABLE Rentals (
	    RentalId SERIAL PRIMARY KEY,
    CarId INT NOT NULL REFERENCES Cars(CarId) ON DELETE CASCADE,
    CustomerId INT NOT NULL REFERENCES Customers(CustomerId) ON DELETE CASCADE,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalCost DECIMAL(10, 2) NOT NULL CHECK (TotalCost >= 0),
    CHECK (EndDate >= StartDate)
);

-- Создание таблицы Locations
CREATE TABLE Locations (
    LocationId SERIAL PRIMARY KEY,
    City VARCHAR(100) NOT NULL,
    Address VARCHAR(200) NOT NULL
);

-- Создание таблицы CarLocations
CREATE TABLE CarLocations (
    CarId INT NOT NULL REFERENCES Cars(CarId) ON DELETE CASCADE,
    LocationId INT NOT NULL REFERENCES Locations(LocationId) ON DELETE CASCADE,
    PRIMARY KEY (CarId, LocationId)
);


INSERT INTO Cars (Model, Manufacturer, Year, PricePerDay) VALUES
('Model S', 'Tesla', 2022, 120.50),
('Civic', 'Honda', 2020, 45.00),
('Corolla', 'Toyota', 2021, 50.00),
('Mustang', 'Ford', 2019, 75.00);

INSERT INTO Customers (FullName, Phone, Email) VALUES
('John Doe', '+1234567890', 'john.doe@example.com'),
('Jane Smith', '+9876543210', 'jane.smith@example.com'),
('Michael Brown', '+1029384756', 'michael.brown@example.com'),
('Emily Davis', '+5647382910', NULL);


INSERT INTO Locations (City, Address) VALUES
('New York', '123 Broadway St'),
('San Francisco', '456 Market St'),
('Chicago', '789 Lakeshore Dr'),
('Miami', '321 Ocean Ave');


INSERT INTO CarLocations (CarId, LocationId) VALUES
(1, 1), -- Tesla Model S в Нью-Йорке
(2, 2), -- Honda Civic в Сан-Франциско
(3, 3), -- Toyota Corolla в Чикаго
(1, 4), -- Tesla Model S также доступна в Майами
(4, 2); -- Ford Mustang в Сан-Франциско


INSERT INTO Rentals (CarId, CustomerId, StartDate, EndDate, TotalCost) VALUES
(1, 1, '2024-01-01', '2024-01-05', 482.00), -- John Doe арендует Tesla Model S
(2, 2, '2024-01-03', '2024-01-10', 315.00), -- Jane Smith арендует Honda Civic
(3, 3, '2024-02-01', '2024-02-05', 200.00), -- Michael Brown арендует Toyota Corolla
(4, 4, '2024-03-10', '2024-03-15', 375.00); -- Emily Davis арендует Ford Mustang


select * from Customers;

update Customers
set phone = 'sd5de'
where CustomerId=1
returning FullName;



