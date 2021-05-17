DROP TABLE Actors
DROP TABLE Producers
DROP TABLE Genres
DROP TABLE Movies
DROP TABLE MovieActorMapping
DROP TABLE MovieGenreMapping


CREATE TABLE Actors(Id int primary key Identity(1,1), Name NVARCHAR(100),Bio NVARCHAR(100),Dob DATE,Gender NVARCHAR(20))
CREATE TABLE Producers(Id int primary key Identity(1,1), Name NVARCHAR(100),Bio NVARCHAR(100),Dob DATE,Gender NVARCHAR(20))
CREATE TABLE Genres(Id int primary key Identity(1,1), Name NVARCHAR(100))
CREATE TABLE Movies(Id int primary key Identity(1,1),Name NVARCHAR(100),Year int, Plot NVARCHAR(100), ProducerId int,CoverImage NVARCHAR(100),FOREIGN KEY (ProducerId) REFERENCES Producers(Id))
CREATE TABLE MovieActorMapping(MovieId int, ActorId int,FOREIGN KEY (ActorId) REFERENCES Actors(Id),FOREIGN KEY (MovieId) REFERENCES Movies(Id))
CREATE TABLE MovieGenreMapping(MovieId int, GenreId int,FOREIGN KEY (GenreID) REFERENCES Genres(Id),FOREIGN KEY (MovieId) REFERENCES Movies(Id))



Drop Procedure IF EXISTS dbo.Insert_Actor
GO
CREATE PROCEDURE Insert_Actor @Id int, @Name NVARCHAR(100), @Bio NVARCHAR(100), @Dob DATE, @Gender NVARCHAR(50) 
AS
    INSERT INTO Actors VALUES(@Name,@Bio,@Dob,@Gender) 

GO




Drop Procedure IF EXISTS dbo.Update_Actor
GO
CREATE PROCEDURE Update_Actor @Id int, @Name NVARCHAR(100), @Bio NVARCHAR(100), @Dob DATE, @Gender NVARCHAR(50) 
AS
    UPDATE Actors SET Actors.Name = @Name, Actors.Gender = @Gender, Actors.Dob = @Dob, Actors.Bio = @Bio WHERE Actors.Id = @Id
GO



Drop Procedure IF EXISTS dbo.Insert_Producer
GO
CREATE PROCEDURE Insert_Producer @Id int, @Name NVARCHAR(100), @Bio NVARCHAR(100), @Dob DATE, @Gender NVARCHAR(50) 
AS
    INSERT INTO Producers VALUES(@Name,@Bio,@Dob,@Gender)    
GO

Drop Procedure IF EXISTS dbo.Update_Producer
GO
CREATE PROCEDURE Update_Producer @Id int, @Name NVARCHAR(100), @Bio NVARCHAR(100), @Dob DATE, @Gender NVARCHAR(50) 
AS
    UPDATE Producers SET Producers.Name = @Name, Producers.Gender = @Gender, Producers.Dob = @Dob, Producers.Bio = @Bio WHERE Producers.Id = @Id
GO



Drop Procedure IF EXISTS dbo.Insert_Genre
GO
CREATE PROCEDURE Insert_Genre @Id int,@Name NVARCHAR(100)
AS
    INSERT INTO Genres VALUES(@Name)    
GO

Drop Procedure IF EXISTS dbo.Update_Genre
GO
CREATE PROCEDURE Update_Genre @Id int, @Name NVARCHAR(100)
AS
    UPDATE Genres SET Genres.Name = @Name WHERE Genres.Id = @Id
GO


Drop Procedure IF EXISTS dbo.Insert_Movie
GO
CREATE PROCEDURE Insert_Movie @Id int, @Name NVARCHAR(100),@Year int, @Plot NVARCHAR(100), @ProducerId int, @ActorIds NVARCHAR(100), @GenreIds NVARCHAR(100),@CoverImage NVARCHAR(100)
AS
    INSERT INTO Movies VALUES(@Name,@Year,@Plot,@ProducerId,@CoverImage)

    DECLARE @Max_ID AS INT;
    SET @Max_ID =(
    SELECT max(Id) as id
    FROM Movies)
    

    INSERT INTO MovieActorMapping
    SELECT @Max_ID [MovieId], [value] [ActorId]
    FROM string_split(@ActorIds, ',')

    INSERT INTO MovieGenreMapping
    SELECT @Max_ID [MovieId], [value] [GenreId]
    FROM string_split(@GenreIds, ',')
GO

Drop Procedure IF EXISTS dbo.Update_Movie
GO
CREATE PROCEDURE Update_Movie @Id int, @Name NVARCHAR(100),@Year int, @Plot NVARCHAR(100), @ProducerId int, @ActorIds NVARCHAR(100), @GenreIds NVARCHAR(100),@CoverImage NVARCHAR(100)
AS

    UPDATE Movies SET Movies.Name = @Name,Year = @Year, Plot = @Plot,ProducerId = @ProducerId, CoverImage = @CoverImage WHERE Movies.Id = @Id

    DELETE FROM MovieActorMapping WHERE MovieActorMapping.MovieId = @Id
    DELETE FROM MovieGenreMapping WHERE MovieGenreMapping.MovieId = @Id


    INSERT INTO MovieActorMapping
    SELECT @Id [MovieId], [value] [ActorId]
    FROM string_split(@ActorIds, ',')

    INSERT INTO MovieGenreMapping
    SELECT @Id [MovieId], [value] [GenreId]
    FROM string_split(@GenreIds, ',')
GO

