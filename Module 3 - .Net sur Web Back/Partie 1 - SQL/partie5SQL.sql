--Exo 1:
--SELECT *
--  FROM [webDevelopment].[dbo].[languages]
--GO

--Exo 2:
--SELECT [id], [language], [version]
--  FROM [webDevelopment].[dbo].[languages]
--  WHERE [language] = 'PHP'
--  GO

--Exo 3:
--SELECT [id], [language], [version]
--  FROM [webDevelopment].[dbo].[languages]
--  WHERE [language] = 'PHP'
--  OR [language] = 'JavaScript'
--  GO

--Exo 4:
--  SELECT [id], [language], [version]
--  FROM [webDevelopment].[dbo].[languages]
--  WHERE [id] = 3
--  OR [id] = 5
--  OR [id] = 7
--  GO

--Exo 5:
--SELECT TOP 2 [id], [language], [version]
--  FROM [webDevelopment].[dbo].[languages]
--  WHERE [language] = 'JavaScript'
--GO

--Exo 6:
--SELECT [id], [language], [version]
--  FROM [webDevelopment].[dbo].[languages]
--  WHERE [language] != 'PHP'
--GO

--Exo 7:
--SELECT [id], [language], [version]
--  FROM [webDevelopment].[dbo].[languages]
--  ORDER BY [language]
--GO