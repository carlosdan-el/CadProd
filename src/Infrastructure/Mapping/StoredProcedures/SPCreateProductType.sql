USE CadProd

CREATE PROCEDURE SPCreateProductType
@Name VARCHAR(250),
@Description VARCHAR(500),
@ProductCategoryId VARCHAR(36),
@CreatedBy VARCHAR(36),
@UpdatedBy VARCHAR(36)
AS

INSERT INTO tbProductType(Id, Name, Description, ProductCategoryId, CreatedBy
, CreatedAt, UpdatedBy, UpdatedAt)
VALUES(NEWID(), @Name, @Description, @ProductCategoryId, @CreatedBy, GETDATE(),
@UpdatedBy, GETDATE())

GO