CREATE PROCEDURE SPCreateCategory
@Name VARCHAR(255),
@Description VARCHAR(5000),
@CreatedBy VARCHAR(36),
@UpdatedBy VARCHAR(36)
AS

INSERT INTO tbCategory(Id, Name, Description, CreatedBy, CreatedAt, UpdatedBy
,UpdatedAt)
VALUES(NEWID(), @Name, @Description, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE())

GO