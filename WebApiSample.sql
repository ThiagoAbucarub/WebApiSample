﻿CREATE DATABASE WebApiSample_DB;

USE WebApiSample_DB;

CREATE TABLE Person (
	PersonId INT IDENTITY NOT NULL,
	Name VARCHAR (100) NOT NULL,
	Phone VARCHAR (20) NOT NULL,
	Email VARCHAR (50) NOT NULL,
	BornDate VARCHAR (15) NOT NULL,
	Gender VARCHAR (10) NOT NULL,
	PRIMARY KEY (PersonId));


INSERT INTO Person (Name, Phone, Email, BornDate, Gender) 
VALUES ('AAAAA', '1111-1111','aaaaa@aaa.com', '01/01/1990' , 'Male');

INSERT INTO Person (Name, Phone, Email, BornDate, Gender) 
VALUES ('BBBBB', '2222-2222','bbbbb@bbb.com', '02/02/1990' , 'Female');

INSERT INTO Person (Name, Phone, Email, BornDate, Gender) 
VALUES ('CCCCC', '3333-3333','ccccc@ccc.com', '03/03/1990' , 'Male');

INSERT INTO Person (Name, Phone, Email, BornDate, Gender) 
VALUES ('DDDDD', '4444-4444','ddddd@ddd.com', '04/04/1990' , 'Female');

INSERT INTO Person (Name, Phone, Email, BornDate, Gender) 
VALUES ('EEEEE', '5555-5555','eeeee@eee.com', '05/05/1990' , 'Male');


-- SELECT * FROM Person;

-- DROP TABLE Person;