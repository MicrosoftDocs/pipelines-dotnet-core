CREATE TABLE [dbo].[superhero]
(
	heroID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	name VARCHAR(50),
	superPowerID INT, 
)
