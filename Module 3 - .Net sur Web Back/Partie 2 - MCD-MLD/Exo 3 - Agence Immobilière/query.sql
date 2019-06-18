--/*------------------------------------------------------------
--*        Script SQLSERVER 
--------------------------------------------------------------*/


--/*------------------------------------------------------------
---- Table: typeProperty
--------------------------------------------------------------*/
--CREATE TABLE typeProperty(
--	id     INT IDENTITY (1,1) NOT NULL ,
--	name   VARCHAR (50) NOT NULL  ,
--	CONSTRAINT typeProperty_PK PRIMARY KEY (id)
--);


--/*------------------------------------------------------------
---- Table: property
--------------------------------------------------------------*/
--CREATE TABLE property(
--	id                INT IDENTITY (1,1) NOT NULL ,
--	name              VARCHAR (50) NOT NULL ,
--	zip               VARCHAR (50) NOT NULL ,
--	price             INT  NOT NULL ,
--	id_typeProperty   INT  NOT NULL  ,
--	CONSTRAINT property_PK PRIMARY KEY (id)

--	,CONSTRAINT property_typeProperty_FK FOREIGN KEY (id_typeProperty) REFERENCES typeProperty(id)
--);


--/*------------------------------------------------------------
---- Table: customer
--------------------------------------------------------------*/
--CREATE TABLE customer(
--	id                INT IDENTITY (1,1) NOT NULL ,
--	firstName         VARCHAR (50) NOT NULL ,
--	lastName          VARCHAR (50) NOT NULL ,
--	dateOfBirth       DATETIME NOT NULL ,
--	mail              VARCHAR (100) NOT NULL ,
--	budget            INT  NOT NULL ,
--	id_typeProperty   INT  NOT NULL  ,
--	CONSTRAINT customer_PK PRIMARY KEY (id)

--	,CONSTRAINT customer_typeProperty_FK FOREIGN KEY (id_typeProperty) REFERENCES typeProperty(id)
--);


--/*------------------------------------------------------------
---- Table: timeslot
--------------------------------------------------------------*/
--CREATE TABLE timeslot(
--	id     INT IDENTITY (1,1) NOT NULL ,
--	time   VARCHAR (50)  NOT NULL  ,
--	CONSTRAINT timeslot_PK PRIMARY KEY (id)
--);


--/*------------------------------------------------------------
---- Table: meet
--------------------------------------------------------------*/
--CREATE TABLE meet(
--	id            INT IDENTITY (1,1) NOT NULL ,
--	date          DATETIME NOT NULL ,
--	id_customer   INT  NOT NULL ,
--	id_property   INT  NOT NULL ,
--	id_timeslot   INT  NOT NULL  ,
--	CONSTRAINT meet_PK PRIMARY KEY (id)

--	,CONSTRAINT meet_customer_FK FOREIGN KEY (id_customer) REFERENCES customer(id)
--	,CONSTRAINT meet_property0_FK FOREIGN KEY (id_property) REFERENCES property(id)
--	,CONSTRAINT meet_timeslot1_FK FOREIGN KEY (id_timeslot) REFERENCES timeslot(id)
--);


--INSERT INTO [dbo].[typeProperty] ([name])
--VALUES 
--    ('Maison'),
--    ('Appartement'),
--    ('Terrain')
--GO

--INSERT INTO [dbo].[customer]([firstName], [lastName], [dateOfBirth], [mail], [budget], [id_typeProperty])
--VALUES 
--    ('Balthazar', 'STARK', '19971013 00:00:00', 'Balthazar@gmail.com', 150000, 1),
--    ('Bazile', 'RODRIGUEZ', '19960913 00:00:00', 'Bazile@gmail.com', 125000, 2),
--    ('Baudoin', 'BLANC', '19950813 00:00:00', 'Baudoin@gmail.com', 100000, 3),
--    ('Bob', 'FERNANDEZ', '19940613 00:00:00', 'Bob@gmail.com', 100000, 1),
--    ('Boubaker', 'RIVIERE', '19930513 00:00:00', 'Boubaker@gmail.com', 900000, 2),
--    ('Brandon', 'DUPUY', '19920413 00:00:00', 'Brandon@gmail.com', 125000, 3),
--    ('Zahr-Eddine', 'BONNET', '19910313 00:00:00', 'Zahr-Eddine@gmail.com', 150000, 1),
--    ('Zaid', 'SANCHEZ', '19900213 00:00:00', 'Zaid@gmail.com', 750000, 2),
--    ('Zakarya', 'FABRE', '19890113 00:00:00', 'Zakarya@gmail.com', 300000, 3),
--    ('Nabile', 'ROQUES', '19881012 00:00:00', 'Nabile@gmail.com', 275000, '3'),
--    ('Kassandra', 'DURAND', '19871011 00:00:00', 'Kassandra@gmail.com', 275000, 2),
--    ('Katharina', 'PONS', '19861016 00:00:00', 'Katharina@gmail.com', 125000, 1),
--    ('Galeane', 'PEREZ', '19851018 00:00:00', 'Galeane@gmail.com', 100000, 1),
--    ('Clémentine', 'LOPEZ', '19841010 00:00:00', 'Clémentine@gmail.com', 275000, 2),
--    ('Corentine', 'MARTINEZ', '19831013 00:00:00', 'Corentine@gmail.com', 150000, 3),
--    ('Cyrine', 'PUJOL', '19821005 00:00:00', 'Cyrine@gmail.com', 300000, 1),
--    ('Colette', 'VIDAL', '19811011 00:00:00', 'Colette@gmail.com', 125000, 2),
--    ('Quentin', 'MARTIN', '19801013 00:00:00', 'Quentin@gmail.com', 150000, 3),
--    ('Quiesie-Vanessa', 'FAURE', '19791013 00:00:00', 'Quiesie-Vanessa@gmail.com', 250000, 2),
--    ('Vanessa', 'MARTY', '19781013 00:00:00', 'Vanessa@gmail.com', 225000, 1)
--GO

--INSERT INTO [dbo].[property] ([name], [zip], [price], [id_typeProperty])
--VALUES 
--    ('Terrain-Lopez', '02300', 100000, 3),
--    ('Appartement Autreville', '02100', 100000, 2),
--    ('Maison Lannister', '02200', 350000, 1),
--    ('Terrain Blerancourt', '02240', 425000, 3),
--    ('Appartement Chauny', '02250', 789000, 2),
--    ('Maison Stark', '02400', 999999, 1),
--    ('Maison Abbecourt', '02500', 350000, 1),
--    ('Appartement Soissons', '02250', 550000, 2),
--    ('Terrain Mine', '02300', 789000, 3),
--    ('Maison Bétancourt', '02350', 350000, 1),
--    ('Appartement Audignicourt', '02250', 200000, 2),
--    ('Terrain Cuts', '02150', 550000, 3),
--    ('Appartement Pommiers', '02333', 200000, 2),
--    ('Terrain Chateau-Thierry', '02250', 425000, 3),
--    ('Maison Jordan', '02090', 200000, 1),
--    ('Appartement Blerancourt', '02250', 789000, 2),
--    ('Maison Laon', '02090', 350000, 1),
--    ('Terrain Laon', '02300', 200000, 3),
--    ('Maison Blerancourt', '02600', 550000, 1),
--    ('Appartement Bignicourt', '02250', 155000, 2),
--    ('Terrain Court', '02220', 425000, 3),
--    ('Terrain Courtcourt', '02090', 80000, 3),
--    ('Appartement gignacourt', '02250', 425000, 2),
--    ('Maison Coursevent', '02150', 80000, 1),
--    ('Maison Harrycourt', '02150', 155000, 1),
--    ('Appartement Magnicourt', '02250', 80000, 2),
--    ('Terrain Batsept', '02150', 789000, 3),
--    ('Appartement Chauny', '02090', 425000, 2),
--    ('Terain Miné', '02150', 80000, 3),
--    ('Maison Chauny', '02150', 155000, 1)
--GO

--INSERT INTO [dbo].[timeslot] ([time])
--VALUES
--    ('9H - 10H'),
--    ('10H - 11H'),
--    ('11H - 12H'),
--    ('14H - 15H'),
--    ('15H - 16H'),
--    ('16H - 17H')
--GO

--INSERT INTO [dbo].[meet] ([date], [id_customer], [id_property], [id_timeslot])
--VALUES
--    ('20190507 00:00:00', 1, 1, 1),
--    ('20190507 00:00:00', 2, 2, 2),
--    ('20190507 00:00:00', 3, 3, 3),
--    ('20190507 00:00:00', 4, 4, 4),
--    ('20190507 00:00:00', 5, 5, 5),
--    ('20190507 00:00:00', 6, 6, 6),
--    ('20190508 00:00:00', 7, 7, 1),
--    ('20190508 00:00:00', 8, 8, 2),
--    ('20190508 00:00:00', 9, 9, 3),
--    ('20190508 00:00:00', 10, 10, 4)
--GO


--EXO 1
--SELECT 
--    [dbo].[property].[name] AS [Nom bien],
--	[dbo].[typeProperty].[name] AS [Type de bien],
--    [dbo].[property].[zip] AS [Code Postal],
--    [dbo].[property].[price] AS [Prix]
--FROM
--    [dbo].[property]
--INNER JOIN
--    [dbo].[typeProperty]
--    ON [dbo].[property].[id_typeProperty] = [dbo].[typeProperty].[id]
--ORDER BY 
--	[Prix]
--GO

--EXO 2
--SELECT 
--    [dbo].[meet].[date] AS [Date RDV],
--    [dbo].[timeslot].[time] AS [Heure RDV],
--    [dbo].[property].[name] AS [Nom de la propriété],
--    [dbo].[typeProperty].[name] AS [Type de la propriété],
--    [dbo].[property].[zip] AS [Code Postal],
--    [dbo].[property].[price] AS [Prix],
--    [dbo].[customer].[lastName] AS [Nom du client],
--    [dbo].[customer].[firstName] AS [Prénom du client]
--FROM
--    [dbo].[meet]
--INNER JOIN 
--    [dbo].[timeslot]
--    ON [dbo].[timeslot].[id] = [dbo].[meet].[id_timeslot]
--INNER JOIN
--    [dbo].[property]
--    ON [dbo].[property].[id] = [dbo].[meet].[id_property]
--INNER JOIN
--    [dbo].[typeProperty]
--    ON [dbo].[typeProperty].[id] = [dbo].[property].[id_typeProperty]
--INNER JOIN 
--    [dbo].[customer]
--    ON [dbo].[customer].[id] = [dbo].[meet].[id_customer]
--ORDER BY 
--	[date],
--	[dbo].[timeslot].[id]
--GO

--EXO 3
--SELECT
--	[dbo].[customer].[firstName] AS [Prénom],
--	[dbo].[customer].[lastName] AS [Nom],
--	[dbo].[typeProperty].[name] AS [Type de bien rechercher],
--	[dbo].[customer].[budget] AS [Budget]
--FROM
--	[dbo].[customer]
--INNER JOIN
--	[dbo].[typeProperty]
--	ON [dbo].[customer].[id_typeProperty] = [dbo].[typeProperty].[id]
--WHERE
--	[dbo].[typeProperty].[id] = 1
--GO