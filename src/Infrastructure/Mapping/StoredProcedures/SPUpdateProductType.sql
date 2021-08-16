USE CadProd
GO
ALTER PROCEDURE SPUpdateProductType
@Id VARCHAR(36),
@Name VARCHAR(255),
@ProductCategoryId VARCHAR(36),
@Description VARCHAR(5000),
@UpdatedBy VARCHAR(36)
AS

UPDATE tbProductType
SET
Name = @Name,
ProductCategoryId = @ProductCategoryId,
Description = @Description,
UpdatedBy = @UpdatedBy,
UpdatedAt = GETDATE()
WHERE Id = @Id

GO