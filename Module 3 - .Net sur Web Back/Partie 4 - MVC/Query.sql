/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: brokers
------------------------------------------------------------*/
CREATE TABLE brokers(
	id            INT IDENTITY (1,1) NOT NULL ,
	lastName      VARCHAR (50) NOT NULL ,
	firstName     VARCHAR (50) NOT NULL ,
	mail          VARCHAR (100) NOT NULL ,
	phoneNumber   VARCHAR (10) NOT NULL  ,
	CONSTRAINT brokers_PK PRIMARY KEY (id)
);


/*------------------------------------------------------------
-- Table: customers
------------------------------------------------------------*/
CREATE TABLE customers(
	id            INT IDENTITY (1,1) NOT NULL ,
	lastName      VARCHAR (50) NOT NULL ,
	firstName     VARCHAR (50) NOT NULL ,
	mail          VARCHAR (100) NOT NULL ,
	phoneNumber   VARCHAR (10) NOT NULL ,
	budget        INT  NOT NULL  ,
	CONSTRAINT customers_PK PRIMARY KEY (id)
);


/*------------------------------------------------------------
-- Table: appointments
------------------------------------------------------------*/
CREATE TABLE appointments(
	id             INT IDENTITY (1,1) NOT NULL ,
	dateHour       DATETIME  NOT NULL ,
	subject        TEXT  NOT NULL ,
	id_brokers     INT  NOT NULL ,
	id_customers   INT  NOT NULL  ,
	CONSTRAINT appointments_PK PRIMARY KEY (id)

	,CONSTRAINT appointments_brokers_FK FOREIGN KEY (id_brokers) REFERENCES brokers(id)
	,CONSTRAINT appointments_customers0_FK FOREIGN KEY (id_customers) REFERENCES customers(id)
);



