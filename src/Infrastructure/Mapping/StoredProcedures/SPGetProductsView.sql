USE CadProd
GO
CREATE PROCEDURE SPGetProductsView
AS

SELECT tbProduct.Id
,tbProduct.Name
,tbProduct.Description
,tbProductCategory.Name AS Category
,tbProductType.Name AS Type
,tbProductSize.Name AS Size
,Price
,Tags
,tbProduct.ImagePath
,(SELECT Name FROM tbUser WITH (NOLOCK) WHERE Id = tbProduct.CreatedBy) AS CreatedBy
,FORMAT(tbProduct.CreatedAt, 'yyyy-MM-dd HH:mm:ss') AS CreatedAt
,(SELECT Name FROM tbUser WITH (NOLOCK) WHERE Id = tbProduct.UpdatedBy) AS UpdatedBy
,FORMAT(tbProduct.UpdatedAt, 'yyyy-MM-dd HH:mm:ss') AS UpdatedAt
FROM tbProduct WITH (NOLOCK)
INNER JOIN tbProductCategory WITH (NOLOCK)
ON tbProduct.CategoryId = tbProductCategory.Id
INNER JOIN tbProductType WITH (NOLOCK)
ON tbProduct.TypeId = tbProductType.Id
INNER JOIN tbProductSize WITH (NOLOCK)
ON tbProduct.SizeId = tbProductSize.Id
ORDER BY tbProduct.Name

GO