INSERT INTO tbRole(Id, Name, Description, CreatedBy, CreatedAt, UpdatedBy
,UpdatedAt)
VALUES ('1', 'Admin', 'System Admin', '1', GETDATE(), '1', GETDATE())

INSERT INTO tbUser(Id, Name, Email, PhoneNumber, RoleId, CreatedBy, CreatedAt
,UpdatedBy, UpdatedAt)
VALUES ('1', 'Admin', 'admin@admin.com', '', '1', '1', GETDATE(), '1', GETDATE())

INSERT INTO tbProductCategory(Id, Name, Description, CreatedBy, CreatedAt
,UpdatedBy, UpdatedAt)
VALUES(NEWID(), 'Womens Fashion', 'Lorem Ipsum.', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Men Fashion', 'Lorem Ipsum.', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Phones & Telecommunications', 'Lorem Ipsum.', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Computer, Office & Security', 'Lorem Ipsum.', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Consumer Electronics', 'Lorem Ipsum.', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Jewelry & Watches', 'Lorem Ipsum.', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Home, Pet & Appliances', 'Lorem Ipsum.', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Bags & Shoes', 'Lorem Ipsum.', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Toys , Kids & Babies', 'Lorem Ipsum.', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Outdoor Fun & Sports', 'Lorem Ipsum.', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Beauty, Health & Hair', 'Lorem Ipsum.', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Automobiles & Motorcycles', 'Lorem Ipsum.', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Home Improvement & Tools', 'Lorem Ipsum.', '1', GETDATE(), '1', GETDATE())

INSERT INTO tbProductType(Id, Name, Description, ProductCategoryId, CreatedBy,
CreatedAt, UpdatedBy,UpdatedAt)
VALUES(NEWID(), 'Swimwear', 'Lorem ipsum.',
(SELECT Id FROM tbProductCategory WITH (NOLOCK) WHERE Name = 'Womens Fashion'),
'1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Bottoms', 'Lorem ipsum.',
(SELECT Id FROM tbProductCategory WITH (NOLOCK) WHERE Name = 'Womens Fashion'),
'1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Weddings & Events', 'Lorem ipsum.',
(SELECT Id FROM tbProductCategory WITH (NOLOCK) WHERE Name = 'Womens Fashion'),
'1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Womens Underwear', 'Lorem ipsum.',
(SELECT Id FROM tbProductCategory WITH (NOLOCK) WHERE Name = 'Womens Fashion'),
'1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Accessories', 'Lorem ipsum.',
(SELECT Id FROM tbProductCategory WITH (NOLOCK) WHERE Name = 'Womens Fashion'),
'1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Bottoms', 'Lorem ipsum.',
(SELECT Id FROM tbProductCategory WITH (NOLOCK) WHERE Name = 'Men Fashion'),
'1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Outerwear & Jackets', 'Lorem ipsum.',
(SELECT Id FROM tbProductCategory WITH (NOLOCK) WHERE Name = 'Men Fashion'),
'1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Underwear & Loungewear', 'Lorem ipsum.',
(SELECT Id FROM tbProductCategory WITH (NOLOCK) WHERE Name = 'Men Fashion'),
'1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Accessories', 'Lorem ipsum.',
(SELECT Id FROM tbProductCategory WITH (NOLOCK) WHERE Name = 'Men Fashion'),
'1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Novelty & Special Use', 'Lorem ipsum.',
(SELECT Id FROM tbProductCategory WITH (NOLOCK) WHERE Name = 'Men Fashion'),
'1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Mobile Phones', 'Lorem ipsum.',
(SELECT Id FROM tbProductCategory WITH (NOLOCK) WHERE Name = 'Phones & Telecommunications'),
'1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Hot Brands', 'Lorem ipsum.',
(SELECT Id FROM tbProductCategory WITH (NOLOCK) WHERE Name = 'Phones & Telecommunications'),
'1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Mobile Phone Accessories', 'Lorem ipsum.',
(SELECT Id FROM tbProductCategory WITH (NOLOCK) WHERE Name = 'Phones & Telecommunications'),
'1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Hot Cases & Covers', 'Lorem ipsum.',
(SELECT Id FROM tbProductCategory WITH (NOLOCK) WHERE Name = 'Phones & Telecommunications'),
'1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Featured Accessories', 'Lorem ipsum.',
(SELECT Id FROM tbProductCategory WITH (NOLOCK) WHERE Name = 'Phones & Telecommunications'),
'1', GETDATE(), '1', GETDATE()),
(NEWID(), 'Mobile Phone Parts', 'Lorem ipsum.',
(SELECT Id FROM tbProductCategory WITH (NOLOCK) WHERE Name = 'Phones & Telecommunications'),
'1', GETDATE(), '1', GETDATE())

INSERT INTO tbProductSize(Id, Name, Description, CreatedBy, CreatedAt, UpdatedBy
,UpdatedAt)
VALUES(NEWID(), 'XS', 'Lorem ipsum', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'S', 'Lorem ipsum', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'M', 'Lorem ipsum', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'L', 'Lorem ipsum', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'XL', 'Lorem ipsum', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'XXL', 'Lorem ipsum', '1', GETDATE(), '1', GETDATE()),
(NEWID(), 'XXXL', 'Lorem ipsum', '1', GETDATE(), '1', GETDATE())