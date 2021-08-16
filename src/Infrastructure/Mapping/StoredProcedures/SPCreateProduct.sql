USE CadProd
GO

ALTER PROCEDURE SPCreateProduct
@Name VARCHAR(255),
@Description VARCHAR(5000),
@CategoryId VARCHAR(36),
@TypeId VARCHAR(36),
@SizeId VARCHAR(36),
@Price MONEY,
@Tags VARCHAR(5000),
@ImagePath VARCHAR(1000),
@CreatedBy VARCHAR(36),
@UpdatedBy VARCHAR(36)
AS

INSERT INTO tbProduct(Id, Name, Description, CategoryId, TypeId, SizeId, Price,
Tags, ImagePath, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt)
VALUES (NEWID(), @Name, @Description, @CategoryId, @TypeId, @SizeId, @Price,
@Tags, @ImagePath, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE())

GO