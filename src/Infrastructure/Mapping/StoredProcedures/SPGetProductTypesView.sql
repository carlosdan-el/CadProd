USE CadProd
GO
ALTER PROCEDURE SPGetProductTypesView
AS

SELECT tbProductType.Id
,tbProductType.Name
,tbProductType.Description
,tbProductCategory.Name AS Category
,(SELECT Name FROM tbUser WITH (NOLOCK) WHERE Id = tbProductType.CreatedBy) AS CreatedBy
,FORMAT(tbProductType.CreatedAt, 'yyyy-MM-dd HH:mm:ss') AS CreatedAt
,(SELECT Name FROM tbUser WITH (NOLOCK) WHERE Id = tbProductType.UpdatedBy) AS UpdatedBy
,FORMAT(tbProductType.UpdatedAt, 'yyyy-MM-dd HH:mm:ss') AS UpdatedAt
FROM tbProductType WITH (NOLOCK)
INNER JOIN tbProductCategory WITH (NOLOCK)
ON tbProductType.ProductCategoryId = tbProductCategory.Id
ORDER BY tbProductType.Name

GO