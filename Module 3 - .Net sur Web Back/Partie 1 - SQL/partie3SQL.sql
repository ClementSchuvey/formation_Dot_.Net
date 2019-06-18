--Exo 1:
--ALTER TABLE [dbo].[languages]
--ADD [versions] NVARCHAR;

--Exo 2:
--Clique droit sur les colonnes et on ajoute la colonne

--Exo 3:
--EXECUTE sp_rename 'dbo.languages.versions', 'version';
--GO

--Exo 4:
--Clique droit sur l'élément dans l'explorateur d'objet puis modifier et on met la bonne valeur

--Exo 5:
--ALTER TABLE [dbo].[frameworks]
--   ALTER COLUMN [version] NVARCHAR(10)
--GO

--TP:
--ALTER TABLE [dbo].[clients] DROP COLUMN secondPhoneNumber;
--EXECUTE sp_rename 'dbo.clients.firstPhoneNumber', 'phoneNumber';
--ALTER TABLE [dbo].[clients] ALTER COLUMN [phoneNumber] NVARCHAR;
--ALTER TABLE [dbo].[clients] ADD [zipCode] NVARCHAR , [city] NVARCHAR;
