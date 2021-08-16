USE CadProd
GO

ALTER PROCEDURE SPGetProductCategoriesView
AS

SELECT Id
,Name
,Description
,(SELECT Name FROM tbUser WHERE Id = tbProductCategory.CreatedBy) AS CreatedBy
,FORMAT(tbProductCategory.CreatedAt, 'yyyy-MM-dd HH:mm:ss') AS CreatedAt
,(SELECT Name FROM tbUser WHERE Id = tbProductCategory.UpdatedBy) AS UpdatedBy
,FORMAT(tbProductCategory.CreatedAt, 'yyyy-MM-dd HH:mm:ss') AS UpdatedAt
FROM tbProductCategory WITH (NOLOCK)
ORDER BY tbProductCategory.Name

GO