Create DATABASE Sqlsession
use [Sqlsession]

-- Create TABLE classes(ID int primary key Identity(1,1), Name NVARCHAR(100))
-- INSERT INTO classes VALUES ('ClassA'),('ClassB')

-- CREATE TABLE students(ID int primary key Identity(1,1), FirstName NVARCHAR(100), LastName NVARCHAR(100), Age DECIMAL(3),classID int , FOREIGN KEY (classID) REFERENCES classes(ID))
-- INSERT INTO students VALUES ('Ashish','Telu',21,1),('Akshay','Kumar',22,1),('Bharath','Kumar',23,2),('Ajit','Reddy',23,1),('Rajesh','Kumar',23,2)



-- select * from classes
-- select * from students

-- Select C.Name as ClassName ,count(S.ID) as studentCount
-- FROM classes as C
-- INNER JOIN students S on S.classID = C.ID
-- GROUP BY C.Name

<<<<<<< HEAD
-- SQL Assignment 1
=======
-- SQL Assignment1
>>>>>>> daf21c2f025c9b9cf5b95da22a35a4f0b92a03c0

CREATE TABLE Classess (ID int primary key IDENTITY(1,1),Name NVARCHAR(100),Section VARCHAR, NUMBER DECIMAL)
CREATE TABLE Teacherss (ID int primary key IDENTITY(1,1),Name NVARCHAR(100),DOB DATE,Gender NVARCHAR(50))
CREATE TABLE Studentss (ID int primary key IDENTITY(1,1),Name NVARCHAR(100),DOB DATE,Gender NVARCHAR(50),ClassId DECIMAL)

-- DROP TABLE Classess
-- DROP TABLE Teacherss
-- DROP TABLE Studentss
-- DROP TABLE TeacherClassMapping


CREATE TABLE TeacherClassMapping(TeacherID int, ClassID int)

INSERT INTO Classess values ('IX','A',201)
INSERT INTO Classess values ('IX','B',202)
INSERT INTO Classess values ('X','A',203)

INSERT INTO Teacherss values ('Lisa Kudrow','1985/06/08','Female')
INSERT INTO Teacherss values ('Monica Bing','1982/03/06','Female')
INSERT INTO Teacherss values ('Chandler Bing','1978/12/17','Male')
INSERT INTO Teacherss values ('Ross Geller','1993/01/26','Male')

INSERT INTO Studentss values ('Scotty Loman','2006/01/31','Male',1)
INSERT INTO Studentss values ('Adam Scott','2005/06/01','Male',1)
INSERT INTO Studentss values ('Natosha Beckles','2005/01/23','Female',2)
INSERT INTO Studentss values ('Lilly Page','2006/11/26','Female',2)
INSERT INTO Studentss values ('John Freeman','2006/06/14','Male',2)
INSERT INTO Studentss values ('Morgan Scott','2005/05/18','Male',3)
INSERT INTO Studentss values ('Codi Gass','2005/12/24','Female',3)
INSERT INTO Studentss values ('Nick Roll','2005/12/24','Male',3)
INSERT INTO Studentss values ('Dave Grohl','2005/02/12','Male',3)

INSERT INTO TeacherClassMapping values (1,1)
INSERT INTO TeacherClassMapping values (1,2)
INSERT INTO TeacherClassMapping values (2,2)
INSERT INTO TeacherClassMapping values (2,3)
INSERT INTO TeacherClassMapping values (3,3)
INSERT INTO TeacherClassMapping values (3,1)

SELECT Name FROM Studentss Where Gender = 'Male'
SELECT Name FROM Studentss Where DOB < '2005-01-01'
SELECT Name FROM Studentss Where DOB = (SELECT MAX(DOB) FROM Studentss)
SELECT DISTINCT DOB FROM Studentss 
SELECT ClassId, COUNT(*) as StudentCount FROM Studentss GROUP BY ClassId
SELECT C.Section, COUNT(*) as StudentCount FROM Classess C INNER JOIN Studentss S ON C.ID = S.ClassId GROUP BY C.Section
SELECT T.ID,T.Name,COUNT(*) as ClassesCount FROM Teacherss T INNER JOIN TeacherClassMapping TC ON T.ID = TC.TeacherID GROUP BY T.ID,T.Name

SELECT T.Name 
FROM Teacherss T
INNER JOIN TeacherClassMapping TC ON T.ID = TC.TeacherID
INNER JOIN Classess C on TC.ClassID = C.ID
WHERE C.Name = 'X'

SELECT C.Name
FROM Classess C
INNER JOIN TeacherClassMapping TC ON C.ID = TC.ClassID
GROUP BY C.Name
HAVING COUNT(*)>2



SELECT S.Name
FROM Studentss S
INNER JOIN TeacherClassMapping TC ON S.ClassId = TC.ClassID
INNER JOIN Teacherss T ON TC.TeacherID = T.ID
WHERE T.Name LIKE '%Lisa%'



-- SQL Assignment2



CREATE TABLE Actors(ID int primary key Identity(1,1), Name NVARCHAR(100),Gender NVARCHAR(20) ,DOB DATE)
CREATE TABLE Producers(ID int primary key Identity(1,1),ProducerName NVARCHAR(100),Company NVARCHAR(100) ,CompanyEstDate Date)
CREATE TABLE Movies(ID int primary key Identity(1,1), Name NVARCHAR(100),Language NVARCHAR(50) ,ProducerName NVARCHAR(100),Profit DECIMAL)

CREATE TABLE MovieActorMapping(MovieID int,ActorID int)

INSERT INTO Actors VALUES ('Mila Kunis','Female','1986-11-14'),('Robert DeNiro','Male','1957-07-10'),('George Michael','Male','1978-11-23'),('Mike Scott','Male','1969-08-06'),('Pam Halpert','Female','1996-09-26'),('Dame Judi Dench','Female','1947-04-05')
INSERT INTO Producers VALUES ('Arjun','Fox','1998-05-14'),('Arun','Bull','2004-09-11'),('Tom','Hanks','1987-11-03'),('Zeshan','Male','1996-11-14'),('Nicole','Team Coco','1992-09-26')
INSERT INTO Movies VALUES ('Rocky','English','Arjun',10000),('Rocky','Hindi','Tom',3000),('Terminal','English','Zeshan',300000),('Rambo','Hindi','Arun',93000),('Rudy','English','Nicole',9600)

INSERT INTO MovieActorMapping VALUES (1,1),(1,3),(1,5),(2,2),(2,4),(2,5),(2,6),(3,2),(3,3),(4,1),(4,3),(4,6),(5,2),(5,3),(5,5)



UPDATE Movies SET Movies.Profit = Movies.Profit + 1000 Where Movies.ProducerName LIKE '%run%'
SELECT COUNT(Movies.ID) as MovieCount,Movies.Name FROM Movies GROUP BY Movies.Name


SELECT A.Name,A.DOB,movieId
FROM Actors A
INNER JOIN (SELECT MA.MovieID as movieId,MIN(A.DOB) as Oldest
FROM MovieActorMapping MA
INNER JOIN Actors A ON A.ID = MA.ActorID 
INNER JOIN Movies M ON M.ID = MA.MovieID
GROUP BY MA.MovieID) ea ON A.DOB = ea.Oldest
ORDER BY(movieId) ASC


SELECT P.ProducerName
FROM Producers P
WHERE P.ProducerName NOT IN (
SELECT M.ProducerName
FROM Movies M
INNER JOIN MovieActorMapping MA ON MA.MovieID = M.ID
INNER JOIN Actors A on MA.ActorID = A.ID
WHERE A.Name = 'Mila Kunis')



SELECT A1.Name as FirstActor, A2.Name as SecondActor
FROM MovieActorMapping M1
INNER JOIN MovieActorMapping M2 on M1.MovieID = M2.MovieID
INNER JOIN Actors A1 on M1.ActorID = A1.ID
INNER JOIN Actors A2 on M2.ActorID = A2.ID
WHERE M1.ActorID<M2.ActorID 
GROUP BY M1.ActorID, M2.ActorID,A1.Name,A2.Name
HAVING COUNT(*)>2


CREATE NONCLUSTERED INDEX profitIdx ON Movies(Profit)




GO
CREATE PROCEDURE GetAllActors @MovieID int
AS
    SELECT A.Name
    FROM Actors A
    INNER JOIN MovieActorMapping M ON M.ActorID = A.ID
    WHERE M.MovieID = @MovieID
    
GO

EXECUTE GetAllActors 1


GO
create function age (@dob date)
returns int  
as  
begin 
    return (YEAR(GETDATE()) - YEAR(@dob))
end  
GO

SELECT dbo.age('1985/06/08')





GO
CREATE PROCEDURE IncreaseProfitBy100 @MovieID NVARCHAR(100)
AS
    UPDATE Movies SET Movies.Profit = Movies.Profit + 100 WHERE Movies.ID IN (SELECT * from  STRING_SPLIT(@MovieID,','))   
GO

EXECUTE IncreaseProfitBy100 '1,2'








