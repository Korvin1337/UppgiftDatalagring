DROP TABLE IF EXISTS Projects;
DROP TABLE IF EXISTS Customers;
DROP TABLE IF EXISTS StatusEntity;


CREATE Table Customers
(
	CustomerId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Email NVARCHAR(200) NOT NULL
)

CREATE TABLE StatusEntity
(
	StatusId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	StatusName NVARCHAR(50) NOT NULL
)

/* Chatgpt4o generate syntax for creating the projects table */
CREATE TABLE Projects
(
    ProjectId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ProjectName NVARCHAR(50) NOT NULL,
    StartDate DATETIME2 NOT NULL,
    EndDate DATETIME2 NOT NULL,
    ProjectManager NVARCHAR(50) NOT NULL,
    CustomerId INT NOT NULL,
    TotalCost DECIMAL(18,2) NOT NULL,
    StatusId INT NOT NULL,

    -- Foreign Keys
    CONSTRAINT FK_Projects_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId) ON DELETE CASCADE,
    CONSTRAINT FK_Projects_Status FOREIGN KEY (StatusId) REFERENCES StatusEntity(StatusId) ON DELETE CASCADE
)


/* Insert snytax updated with chatgpt4o, multiple values, foreign keys, chage Table Status to StatusEntity */
INSERT INTO Customers(Name, Email)
VALUES('First Last', 'First.Last@domain.com');

INSERT INTO StatusEntity(StatusName)
VALUES('Not Started'), ('In Progress'), ('Completed');

INSERT INTO Projects(ProjectName, StartDate, EndDate, ProjectManager, CustomerId, TotalCost, StatusId)
VALUES('Project Name', '2025-01-20', '2025-02-26', 'Project Manager', 1, 1234567.89, 2);

SELECT * FROM Projects;