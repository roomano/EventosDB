CREATE DATABASE EventosVIVO
GO
USE EventosVIVO

CREATE TABLE Guests(
Id INT PRIMARY KEY IDENTITY(2024, 1),
GuestName NVARCHAR(150) NOT NULL,
Contact NVARCHAR(13) NOT NULL UNIQUE,
Created_at DATETIME DEFAULT GETDATE(),
Updated_at DATETIME DEFAULT NULL,
Deleted_at DATETIME DEFAULT NULL,
)

CREATE TABLE GuestType(
Id INT PRIMARY KEY IDENTITY(1,1),
Designation NVARCHAR(250) NOT NULL,
)

DROP TABLE Event
CREATE TABLE Events(
Id INT PRIMARY KEY IDENTITY(1,1),
EventHostId INT NOT NULL,
Dates NVARCHAR(300) NOT NULL
)

CREATE TABLE EventHost(
Id INT PRIMARY KEY IDENTITY(1,1),
Name NVARCHAR(250) NOT NULL UNIQUE,
Description VARCHAR(MAX) NOT NULL,
)

CREATE TABLE InvitationType(
Id INT PRIMARY KEY IDENTITY(1,1),
Designation NVARCHAR(100) NOT NULL UNIQUE,
Description VARCHAR(MAX) NOT NULL,
)

CREATE TABLE Invitation(
Id INT PRIMARY KEY IDENTITY(1,1),
EventId INT NOT NULL,
EventHostId INT NOT NULL,
InvitationTypeId INT NOT NULL,
Created_at DATETIME DEFAULT GETDATE(),

FOREIGN KEY (EventId) REFERENCES Events(Id),
FOREIGN KEY (EventHostId) REFERENCES EventHost(Id),
FOREIGN KEY (InvitationTypeId) REFERENCES InvitationType(Id)
)


ALTER TABLE Events
ADD 
 Created_at DATETIME NOT NULL DEFAULT GETDATE()
	FOREIGN KEY (EventHostId) REFERENCES EventHost(Id)


DROP TABLE Guests

USE EventosVIVO
INSERT INTO Guests(GuestName, Contact) values ('Romano Pedro', '847198930' )


USE EventosVIVO

UPDATE Guests
SET GuestName = 'Ivandro Cariot', Updated_at = GETDATE()
WHERE Id=2024

ALTER TABLE Guests
ADD 
    GuestTypeId INT NOT NULL DEFAULT 1 
	FOREIGN KEY (GuestTypeId) REFERENCES GuestType(Id)

ALTER TABLE Events
ADD 
    
	FOREIGN KEY (EventHostId) REFERENCES EventHost(Id)


SELECT * FROM GuestType
SELECT * FROM Guests
SELECT * FROM Events
SELECT * FROM InvitationType
SELECT Guests.GuestName as 'Nome do Convidado', GuestType.Designation as 'Tipo Convidado' FROM Guests

INNER JOIN GuestType ON Guests.GuestTypeId = GuestType.Id





-- dotnet tool install dotnet-ef --versin <VERSION_NUMBER> -g      -para instalar globalmente a ferramenta
-- dotnet ef dbcontext scaffold "Data Source=.\ITIS;Initial Catalog=EventosVIVO;Persist Security Info=True;User ID=sa;Password=Itis2022;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Data -f --no-onconfiguring
-- dotnet tool install dotnet-aspnet-codegenerator --version 7 -g
--  dotnet aspnet-codegenerator controller -name GuestsController -m Guest -dc EventosVivoContext --relativeFolderPath Controllers --useDefaultLayout
-- 