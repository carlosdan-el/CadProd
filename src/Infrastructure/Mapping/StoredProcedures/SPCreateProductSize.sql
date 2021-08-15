CREATE PROCEDURE SPCreateProductSize
@Name VARCHAR(255),
@Description VARCHAR(500),
@CreatedBy VARCHAR(36),
@UpdatedBy VARCHAR(36)
AS

INSERT INTO tbProductSize(Id, Name, Description, CreatedBy, CreatedAt, UpdatedBy
, UpdatedAt)
VALUES(NEWID(), @Name, @Description, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE())

GO