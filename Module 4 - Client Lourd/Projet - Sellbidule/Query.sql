CREATE DATABASE [Sellbidule]
GO

USE [Sellbidule]
GO


/*------------------------------------------------------------
-- Table: Category
------------------------------------------------------------*/
CREATE TABLE Category(
	id     INT IDENTITY (1,1) NOT NULL ,
	name   VARCHAR (50) NOT NULL  ,
	CONSTRAINT Category_PK PRIMARY KEY (id)
);


/*------------------------------------------------------------
-- Table: Article
------------------------------------------------------------*/
CREATE TABLE Article(
	id            INT IDENTITY (1,1) NOT NULL ,
	reference     VARCHAR (10) NOT NULL ,
	name          VARCHAR (100) NOT NULL ,
	price         REAL  NOT NULL ,
	quantity      INT  NOT NULL ,
	description   TEXT  NOT NULL ,
	picture       VARCHAR (255) NOT NULL ,
	id_Category   INT  NOT NULL  ,
	CONSTRAINT Article_PK PRIMARY KEY (id)

	,CONSTRAINT Article_Category_FK FOREIGN KEY (id_Category) REFERENCES Category(id)
);

