-- Create the database if it does not exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'NestQuest_db')
    CREATE DATABASE NestQuest_db;
GO

USE NestQuest_db;
GO

-- Create the Users table if it does not exist
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users')
BEGIN
    CREATE TABLE Users (
        UserId INT PRIMARY KEY IDENTITY(1,1),
        Username VARCHAR(50) NOT NULL,
        Email VARCHAR(100) NOT NULL,
        Password VARCHAR(100) NOT NULL,
        UserType VARCHAR(10) NOT NULL,
        FullName VARCHAR(100),
        PhoneNumber VARCHAR(20),
        Address VARCHAR(255),
        City VARCHAR(100),
        State VARCHAR(100),
        Country VARCHAR(100),
        ZipCode VARCHAR(20),
        ProfileImageUrl VARCHAR(255)
    );
END
GO

-- Create the ShiftingRequests table if it does not exist
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ShiftingRequests')
BEGIN
    CREATE TABLE ShiftingRequests (
        RequestId INT PRIMARY KEY IDENTITY(1,1),
        UserId INT NOT NULL,
        CurrentLocation VARCHAR(255) NOT NULL,
        Destination VARCHAR(255) NOT NULL,
        RequiredServices TEXT,
        PreferredDate DATE,
        FOREIGN KEY (UserId) REFERENCES Users(UserId)
    );
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Properties')
BEGIN
    CREATE TABLE Properties (
        PropertyId INT PRIMARY KEY IDENTITY(1,1),
        OwnerId INT NOT NULL,
        Title VARCHAR(100) NOT NULL,
        Description TEXT,
        Price DECIMAL(10, 2) NOT NULL,
        Bedrooms INT NOT NULL,
        Bathrooms INT NOT NULL,
        Amenities VARCHAR(255),
        City VARCHAR(255),
        Location VARCHAR(255) NOT NULL,
        Zipcode VARCHAR(10),
        Latitude DECIMAL(10, 6),
        Longitude DECIMAL(10, 6),
        ImageUrl VARCHAR(255),
        ContactEmail VARCHAR(100),
        ContactPhone VARCHAR(20),
        Verified BIT DEFAULT 0,
        FOREIGN KEY (OwnerId) REFERENCES Users(UserId)
    );
END
ELSE
BEGIN
    -- If the table already exists, add the new columns if they don't exist
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Properties' AND COLUMN_NAME = 'City')
    BEGIN
        ALTER TABLE Properties
        ADD City VARCHAR(255);
    END;

    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Properties' AND COLUMN_NAME = 'Zipcode')
    BEGIN
        ALTER TABLE Properties
        ADD Zipcode VARCHAR(10);
    END;
END;


-- Create the User_Favorites table if it does not exist
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'User_Favorites')
BEGIN
    CREATE TABLE User_Favorites (
        UserId INT NOT NULL,
        PropertyId INT NOT NULL,
        FOREIGN KEY (UserId) REFERENCES Users(UserId),
        FOREIGN KEY (PropertyId) REFERENCES Properties(PropertyId),
        PRIMARY KEY (UserId, PropertyId)
    );
END
GO

-- Insert sample data into the Users table
INSERT INTO Users (Username, Email, Password, UserType, FullName, PhoneNumber, Address, City, State, Country, ZipCode, ProfileImageUrl)
VALUES 
    ('john_doe', 'john@example.com', 'password123', 'client', 'John Doe', '+1234567890', '123 Main St', 'AnyTown', 'CA', 'USA', '12345', 'https://images.unsplash.com/photo-1633332755192-727a05c4013d?q=80&w=1000&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8dXNlcnxlbnwwfHwwfHx8MA%3D%3D'),
    ('jane_smith', 'jane@example.com', 'password456', 'owner', 'Jane Smith', '+1987654321', '456 Elm St', 'Otherville', 'NY', 'USA', '54321', 'https://images.unsplash.com/photo-1508214751196-bcfd4ca60f91?q=80&w=1000&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fHVzZXJ8ZW58MHx8MHx8fDA%3D');

-- Insert sample data into the ShiftingRequests table
INSERT INTO ShiftingRequests (UserId, CurrentLocation, Destination, RequiredServices, PreferredDate)
VALUES 
    (1, 'Current Location 1', 'Destination 1', 'Packing, Transportation', '2024-05-01'),
    (1, 'Current Location 2', 'Destination 2', 'Packing', '2024-06-15');

-- Insert additional sample data into the Users table
INSERT INTO Users (Username, Email, Password, UserType, FullName, PhoneNumber, Address, City, State, Country, ZipCode, ProfileImageUrl)
VALUES 
    ('alice_wonder', 'alice@example.com', 'password789', 'client', 'Alice Wonder', '+1122334455', '789 Oak St', 'Anycity', 'TX', 'USA', '67890', 'https://example.com/profile_images/alice_wonder.jpg'),
    ('bob_dylan', 'bob@example.com', 'passwordabc', 'owner', 'Bob Dylan', '+9988776655', '101 Pine St', 'Somewhere', 'AZ', 'USA', '54321', 'https://example.com/profile_images/bob_dylan.jpg');

-- Insert additional sample data into the ShiftingRequests table
INSERT INTO ShiftingRequests (UserId, CurrentLocation, Destination, RequiredServices, PreferredDate)
VALUES 
    (2, 'Current Location 3', 'Destination 3', 'Packing, Loading, Unloading', '2024-07-10'),
    (2, 'Current Location 4', 'Destination 4', 'Packing, Transportation', '2024-08-20');


INSERT INTO Properties (OwnerId, Title, Description, Price, Bedrooms, Bathrooms, Amenities, City, Location, Zipcode, Latitude, Longitude, ImageUrl, ContactEmail, ContactPhone, Verified, Country)
VALUES
(1, 'Luxury Beachfront Villa', 'Elegant villa with panoramic ocean views and private beach access.', 1500000.00, 5, 5, 'Private Beach, Pool, Spa', 'Malibu', '123 Ocean Dr', '90265', 34.0259, -118.7798, 'https://example.com/image6.jpg', 'owner1@example.com', '123-456-7890', 1, 'USA'),
(2, 'Downtown Loft Apartment', 'Spacious loft apartment with modern design and city skyline views.', 2500.00, 1, 1, 'Fitness Center, Rooftop Deck', 'New York', '789 Broadway', '10003', 40.7306, -73.9352, 'https://example.com/image7.jpg', 'owner2@example.com', '987-654-3210', 1, 'USA'),
(3, 'Riverside Cottage Retreat', 'Cozy cottage nestled along the riverbank, surrounded by nature.', 300000.00, 3, 2, 'Riverside Deck, Fireplace', 'Aspen', '456 River Rd', '81611', 39.1911, -106.8175, 'https://example.com/image8.jpg', 'owner3@example.com', '555-123-4567', 0, 'USA'),
(4, 'Mountain View Chalet', 'Charming chalet with stunning mountain views, perfect for skiing enthusiasts.', 500000.00, 4, 3, 'Ski-in/Ski-out, Hot Tub', 'Whistler', '789 Mountain Ln', 'V0N 1B4', 50.1163, -122.9574, 'https://example.com/image9.jpg', 'owner4@example.com', '444-222-3333', 1, 'Canada'),
(5, 'Seaside Retreat Bungalow', 'Relaxing bungalow steps away from the beach, ideal for a coastal getaway.', 350000.00, 2, 1, 'Beach Access, Outdoor Dining', 'Sydney', '101 Beachfront Ave', '2000', -33.8651, 151.2099, 'https://example.com/image10.jpg', 'owner5@example.com', '999-888-7777', 1, 'Australia');
