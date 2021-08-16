USE CadProd

GO

CREATE PROCEDURE SPUpdateProduct
@Id VARCHAR(36),
@Name VARCHAR(255),
@Description VARCHAR(5000),
@CategoryId VARCHAR(36),
@TypeId VARCHAR(36),
@SizeId VARCHAR(36),
@Price MONEY,
@Tags VARCHAR(5000),
@UpdatedBy VARCHAR(36)
AS

UPDATE tbProduct
SET
Name = @Name,
Description = @Description,
CategoryId = @CategoryId,
TypeId = @TypeId,
SizeId = @SizeId,
Price = @Price,
Tags = @Tags,
UpdatedBy = @UpdatedBy,
UpdatedAt = GETDATE()
WHERE Id = @Id

GO