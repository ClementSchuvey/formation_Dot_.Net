CREATE DATABASE [repertory]
GO

USE [repertory]
GO

/*------------------------------------------------------------
-- Table: Users
------------------------------------------------------------*/
CREATE TABLE Users(
	[id]         INT IDENTITY (1,1) NOT NULL ,
	[lastname]    NVARCHAR (50) NOT NULL ,
	[firstname]  NVARCHAR (50) NOT NULL ,
	[username]    NVARCHAR (50) NOT NULL ,
	[mail]       VARCHAR (100) NOT NULL ,
	[password]    VARCHAR (250) NOT NULL  ,
	CONSTRAINT Users_PK PRIMARY KEY (id)
);


/*------------------------------------------------------------
-- Table: Contacts
------------------------------------------------------------*/
CREATE TABLE Contacts(
	[id]            INT IDENTITY (1,1) NOT NULL ,
	[lastname]      NVARCHAR (50) NOT NULL ,
	[firstname]     NVARCHAR (50) NOT NULL ,
	[mail]          VARCHAR (100) NOT NULL ,
	[phoneNumber]   VARCHAR (255) NOT NULL ,
	[address]        VARCHAR (255) NOT NULL ,
	[photo]         NVARCHAR (255)  ,
	[id_Users]      INT  NOT NULL  ,
	CONSTRAINT Contacts_PK PRIMARY KEY (id)

	,CONSTRAINT Contacts_Users_FK FOREIGN KEY (id_Users) REFERENCES Users(id)
);
