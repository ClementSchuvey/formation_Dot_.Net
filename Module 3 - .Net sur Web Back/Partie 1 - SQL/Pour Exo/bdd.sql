-- Création de la base
CREATE DATABASE [development]
GO

-- On se positione dans la base nouvellement créée
USE [development]
GO

-- Création de la table languages
CREATE TABLE [dbo].[languages](
	[id] SMALLINT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[name] NVARCHAR(40) NOT NULL,
)
GO

-- Création de la table frameworks qui contient une clé étrangère
CREATE TABLE [dbo].[frameworks](
	[id] SMALLINT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[name] VARCHAR(40) NOT NULL,
	[languagesId] INT NOT NULL,
)
GO

-- Insertion des données dans la table languages
INSERT INTO [dbo].[languages] ([name]) VALUES ('Assembleur');
INSERT INTO [dbo].[languages] ([name]) VALUES ('C');
INSERT INTO [dbo].[languages] ([name]) VALUES ('C++');
INSERT INTO [dbo].[languages] ([name]) VALUES ('Java');
INSERT INTO [dbo].[languages] ([name]) VALUES ('HTML');
INSERT INTO [dbo].[languages] ([name]) VALUES ('CSS');
INSERT INTO [dbo].[languages] ([name]) VALUES ('JavaScript');
INSERT INTO [dbo].[languages] ([name]) VALUES ('PHP');
INSERT INTO [dbo].[languages] ([name]) VALUES ('C#');
INSERT INTO [dbo].[languages] ([name]) VALUES ('VB');
INSERT INTO [dbo].[languages] ([name]) VALUES ('Python');
INSERT INTO [dbo].[languages] ([name]) VALUES ('Ruby');
INSERT INTO [dbo].[languages] ([name]) VALUES ('Swift');

-- Insertion des données dans la table frameworks
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Qt',3);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('SDK Android',4);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Bootstrap',6);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Foundation',6);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('KNACSS',6);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Avalanche',6);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Miligram',6);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Skeleton',6);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Hoisin',6);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Inuit',6);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Mimic',6);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Ministrap',6);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Lotus',6);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Jquery',7);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Angular',7);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('ReactJS',7);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Vue.js',7);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Ember.js',7);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Meteor.js',7);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Laravel',8);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Symfony',8);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('CodeIgniter',8);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Yii',8);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Phalcon',8);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Lumen',8);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Silex',8);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Slim',8);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('.NET',9);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('.NET',10);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Django',11);
INSERT INTO [dbo].[frameworks] ([name],[languagesId]) VALUES ('Ruby On Rails',12);
