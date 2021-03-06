--/*------------------------------------------------------------
--*        Script SQLSERVER 
--------------------------------------------------------------*/

--/*------------------------------------------------------------
---- Table: subject
--------------------------------------------------------------*/
--CREATE TABLE subject(
--	id     INT IDENTITY (1,1) NOT NULL ,
--	name   VARCHAR (50) NOT NULL  ,
--	CONSTRAINT subject_PK PRIMARY KEY (id)
--);


--/*------------------------------------------------------------
---- Table: teacher
--------------------------------------------------------------*/
--CREATE TABLE teacher(
--	id          INT IDENTITY (1,1) NOT NULL ,
--	lastName    VARCHAR (50) NOT NULL ,
--	firstName   VARCHAR (50) NOT NULL ,
--	mail        VARCHAR (50) NOT NULL  ,
--	CONSTRAINT teacher_PK PRIMARY KEY (id)
--);


--/*------------------------------------------------------------
---- Table: class
--------------------------------------------------------------*/
--CREATE TABLE class(
--	id           INT IDENTITY (1,1) NOT NULL ,
--	name         VARCHAR (10) NOT NULL ,
--	id_teacher   INT  NOT NULL  ,
--	CONSTRAINT class_PK PRIMARY KEY (id)

--	,CONSTRAINT class_teacher_FK FOREIGN KEY (id_teacher) REFERENCES teacher(id)
--);


--/*------------------------------------------------------------
---- Table: student
--------------------------------------------------------------*/
--CREATE TABLE student(
--	id           INT IDENTITY (1,1) NOT NULL ,
--	lastName     VARCHAR (50) NOT NULL ,
--	firstName    VARCHAR (50) NOT NULL ,
--	id_class     INT  NOT NULL ,
--	id_teacher   INT  NOT NULL  ,
--	CONSTRAINT student_PK PRIMARY KEY (id)

--	,CONSTRAINT student_class_FK FOREIGN KEY (id_class) REFERENCES class(id)
--	,CONSTRAINT student_teacher0_FK FOREIGN KEY (id_teacher) REFERENCES teacher(id)
--);


--/*------------------------------------------------------------
---- Table: note
--------------------------------------------------------------*/
--CREATE TABLE note(
--	id           INT IDENTITY (1,1) NOT NULL ,
--	valueNote    FLOAT   ,
--	id_subject   INT  NOT NULL ,
--	id_student   INT  NOT NULL  ,
--	CONSTRAINT note_PK PRIMARY KEY (id)

--	,CONSTRAINT note_subject_FK FOREIGN KEY (id_subject) REFERENCES subject(id)
--	,CONSTRAINT note_student0_FK FOREIGN KEY (id_student) REFERENCES student(id)
--);

--INSERT INTO [dbo].[teacher] ([lastName], [firstName],[mail])
--VALUES
--	('Rubeus', 'Hagrid', 'rubeus.hagrid@gmail.com'),
--	('Gilderoy', 'Lockhart', 'gilderoy.lock@gmail.fr'),
--	('Albus', 'Dumbledore', 'albus.dumb@gmail.com'),
--	('Minerva', 'Mcgonagald', 'minervamacdo@gmail.fr'),
--	('Severus', 'Rogue', 'darkseverus@gmail.com')
--GO

--INSERT INTO [dbo].[class] ([name], [id_teacher]) 
--VALUES
--	('cp', 1),
--	('ce1', 2),
--	('ce2', 3),
--	('cm1', 4),
--	('cm2', 5)
--GO

--INSERT INTO [dbo].[subject] ([name])
--VALUES
--	('Math'),
--	('Fran�ais'),
--	('Sport'),
--	('Anglais'),
--	('Histoire'),
--	('Geographie')
--GO

--INSERT INTO [dbo].[student] ([lastName], [firstName], [id_class], [id_teacher])
--VALUES
--	('GARCIA', 'Babacar', '6', '1'),
--	('MARTY', 'Balthazar', '6', '1'),
--	('FAURE', 'Bazile', '6', '1'),
--	('MARTIN', 'Baudoin', '6', '1'),
--	('VIDAL', 'Bob', '6', '1'),
--	('PUJOL', 'Boubaker', '6', '1'),
--	('MARTINEZ', 'Brandon', '2', '2'),
--	('LOPEZ', 'Zahr-Eddine ', '2', '2'),
--	('PEREZ', 'Zaid', '2', '2'),
--	('PONS', 'Zakarya', '2', '2'),
--	('DURAND', 'Nabile', '2', '2'),
--	('ROQUES', 'Kassandra', '3', '3'),
--	('FABRE', 'Katharina', '3', '3'),
--	('SANCHEZ', 'Galeane', '3', '3'),
--	('BONNET', 'Cl�mentine', '3', '3'),
--	('DUPUY', 'Corentine', '3', '3'),
--	('RIVIERE', 'Cyrine', '4', '4'),
--	('FERNANDEZ', 'Colette', '4', '4'),
--	('BLANC', 'Quentin', '4', '4'),
--	('RODRIGUEZ', 'Quiesie-Vanessa ', '4', '4'),
--	('GONZALEZ', 'Quincy', '4', '4'),
--	('REY', 'Elif', '5', '5'),
--	('BOUSQUET', 'Eleana', '5', '5'),
--	('DEJEAN', 'Edouardine', '5', '5'),
--	('DELMAS', 'Leila', '5', '5'),
--	('BOYER', 'Ohiri', '5', '5'),
--	('RAYNAUD ', 'Orlan', '6', '1'),
--	('SOULA', 'Oscar', '2', '2'),
--	('DEDIEU', 'Baptiste', '3', '3'),
--	('ROBERT ', 'Birama', '4', '4'),
--	('LOPEZ', 'Jordan', '5', '5')
--GO

--INSERT INTO [dbo].[note] ([valueNote], [id_subject], [id_student])
--VALUES
--	(20, 1, 2),
--	(15, 1, 3),
--	(14, 1, 4),
--	(16, 1, 5),
--	(13, 6, 6),
--	(17, 1, 7),
--	(12, 1, 8),
--	(10, 1, 9),
--	(10, 1, 9),
--	(10, 2, 10),
--	(8, 6, 11),
--	(9, 2, 12),
--	(4, 2, 13),
--	(13, 2, 14),
--	(1, 2, 15),
--	(10.5, 2, 16),
--	(11.5, 6, 16),
--	(11, 2, 17),
--	(15, 2, 18),
--	(7, 2, 19),
--	(6.5, 2, 20),
--	(3.5, 3, 21),
--	(19, 6, 22),
--	(20, 3, 22),
--	(18, 3, 22),
--	(19.5, 3, 21),
--	(16, 3, 23),
--	(6, 3, 24),
--	(3, 6, 25),
--	(2, 3, 26),
--	(1, 3, 27),
--	(15.5, 3, 28),
--	(14.5, 4, 29),
--	(10, 4, 30),
--	(0, 4, 31),
--	(9, 6, 29),
--	(7, 6, 32),
--	(8, 4, 25),
--	(9, 4, 14),
--	(10, 4, 3),
--	(10, 4, 24),
--	(10, 4, 15),
--	(3, 4, 4),
--	(7.5, 4, 7),
--	(8, 6, 6),
--	(10.5, 5, 20),
--	(16, 5, 11),
--	(18, 5, 32),
--	(14, 5, 9),
--	(4, 5, 20)
--GO

--Exo 1:
--SELECT
--	[dbo].[note].[valueNote] AS [Note],
--	[dbo].[subject].[name] AS [Mati�re],
--	[dbo].[student].[firstName] AS [Pr�nom],
--	[dbo].[student].[lastName] AS [Nom]
--FROM
--	[dbo].[note]
--INNER JOIN
--	[dbo].[student]
--	ON [dbo].[note].[id_student] = [dbo].[student].[id]
--INNER JOIN
--	[dbo].[subject]
--	ON [dbo].[note].[id_subject] = [dbo].[subject].[id]
--GO

--Exo 2:
--SELECT
--	[dbo].[student].[firstName] AS [Pr�nom],
--	[dbo].[student].[lastName] AS [Nom],
--	AVG([valueNote]) AS [Moyenne],
--	[dbo].[class].[name] AS [Classe],
--	[dbo].[teacher].[LastName] AS [Professeur Principal]
--FROM
--	[dbo].[student]
--INNER JOIN
--	[dbo].[note]
--	ON [dbo].[student].[id] = [dbo].[note].[id_student]
--INNER JOIN
--	[dbo].[class]
--	ON [dbo].[student].[id_class] = [dbo].[class].[id]
--INNER JOIN
--	[dbo].[teacher]
--	ON [dbo].[student].[id_teacher] = [dbo].[teacher].[id]
--GROUP BY 
--	[dbo].[student].[firstName],
--	[dbo].[student].[lastName],
--	[dbo].[class].[name],
--	[dbo].[teacher].[LastName]
--ORDER BY
--	[Moyenne] DESC
--GO

--Exo 3:
--SELECT
--	[dbo].[teacher].[firstName] AS [Pr�nom du prof],
--	[dbo].[teacher].[lastName] AS [Nom du prof],
--	[dbo].[class].[name] AS [Classe],
--	[dbo].[student].[firstName] AS [Pr�nom de l'�l�ve],
--	[dbo].[student].[lastName] AS [Nom de l'�l�ve]
--FROM
--	[dbo].[teacher]
--INNER JOIN
--	[dbo].[class]
--	ON [dbo].[teacher].[id] = [dbo].[class].[id_teacher]
--INNER JOIN
--	[dbo].[student]
--	ON [dbo].[teacher].[id] = [dbo].[student].[id_teacher]
--WHERE 
--	[dbo].[teacher].[lastName] ='Rubeus'
--ORDER BY
--	[Nom du prof] ASC
--GO