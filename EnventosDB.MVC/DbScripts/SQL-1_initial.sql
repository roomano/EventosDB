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

DROP TABLE Guests

USE EventosVIVO
INSERT INTO Guests(GuestName, Contact) values ('Romano Pedro', '847198930' )


USE EventosVIVO

UPDATE Guests
SET GuestName = 'Ivandro Cariot', Updated_at = GETDATE()
WHERE Id=2024


SELECT * FROM Guests




-- dotnet tool install dotnet-ef --versin <VERSION_NUMBER> -g      -para instalar globalmente a ferramenta
-- dotnet ef dbcontext scaffold "Data Source=.\ITIS;Initial Catalog=EventosVIVO;Persist Security Info=True;User ID=sa;Password=Itis2022;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Data -f --no-onconfiguring