CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Email NVARCHAR(50) NOT NULL UNIQUE,
    UserName NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME2 DEFAULT SYSDATETIME(),
    UpdatedAt DATETIME2 NULL,
    DeletedAt DATETIME2 NULL, --Bruger vi til soft-delete (Så brugeren findes i databasen, men bare ikke findes i programmet fx er planen) 
    IsActive BIT NOT NULL DEFAULT 1
);

CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL UNIQUE,
    OrganizationNumber NVARCHAR(50) NOT NULL,
    CompanyName NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME2 DEFAULT SYSDATETIME(),
    UpdatedAt DATETIME2 NULL,
    DeletedAt DATETIME2 NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
        ON DELETE CASCADE
);

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL UNIQUE,
    EmployeeNumber NVARCHAR(50) NOT NULL UNIQUE,
    [Role] NVARCHAR(50),
    HireDate DATE,
    CreatedAt DATETIME2 DEFAULT SYSDATETIME(),
    UpdatedAt DATETIME2 NULL,
    DeletedAt DATETIME2 NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
        ON DELETE CASCADE
);
