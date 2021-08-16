USE CadProd
GO
CREATE PROCEDURE SPGETProductSize
AS

SELECT Id
,Name
,Description
,(SELECT Name FROM tbUser WITH (NOLOCK) WHERE Id = tbProductSize.CreatedBy) AS CreatedBy
,FORMAT(tbProductSize.CreatedAt, 'yyyy-MM-dd HH:mm:ss') AS CreatedAt
,(SELECT Name FROM tbUser WITH (NOLOCK) WHERE Id = tbProductSize.UpdatedBy) AS UpdatedBy
,FORMAT(tbProductSize.UpdatedAt, 'yyyy-MM-dd HH:mm:ss') AS UpdatedAt
FROM tbProductSize WITH (NOLOCK)
ORDER BY Name

GO