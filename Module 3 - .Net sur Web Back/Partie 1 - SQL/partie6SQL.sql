--Avant exo j'ai exécuter le fichier Ajout.sql

--Exo 1:
--SELECT [id], [framework], [version]
--FROM [webDevelopment].[dbo].[frameworks]
--WHERE [version] LIKE '%version 2.%' ; 
--GO

--Exo 2:
--SELECT [id], [framework], [version]
--	FROM [webDevelopment].[dbo].[frameworks]
--	WHERE [id] = 1
--		OR [id] = 3
--GO

--Exo 3:
--SELECT [id], [name], [version], [date]
--	FROM [webDevelopment].[dbo].[ide]
--	WHERE [date] BETWEEN '2010-01-01' AND '2011-12-31'
--GO
