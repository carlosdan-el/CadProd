USE CadProd
GO
ALTER PROCEDURE SPUpdateProductSize
@Id VARCHAR(36),
@Name VARCHAR(255),
@Description VARCHAR(5000),
@UpdatedBy VARCHAR(36)
AS

UPDATE tbProductSize
SET
Name = @Name,
Description = @Description,
UpdatedBy = @UpdatedBy,
UpdatedAt = GETDATE()
WHERE Id = @Id

GO