USE master;
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'NEBULOUS')
BEGIN
    DROP DATABASE NEBULOUS;
END
GO
CREATE DATABASE NEBULOUS;
GO
USE [NEBULOUS]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovementType](
	[id] [int] NOT NULL,
	[movementType] [varchar](6) NOT NULL,
 CONSTRAINT [PK_MovementType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[id] [int] NOT NULL,
	[supplier] [varchar](100) NOT NULL,
	[details] [varchar](150) NOT NULL,
	[date] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[id] [int] NOT NULL,
	[category] [varchar](70) NOT NULL,
	[details] [varchar](150) NOT NULL,
 CONSTRAINT [PK_CategoryProducts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSubCategory](
	[id] [int] NOT NULL,
	[idProductCategory] [int] NOT NULL,
	[product] [varchar](70) NOT NULL,
	[details] [varchar](150) NOT NULL,
 CONSTRAINT [PK_CategorySubProducts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
CONSTRAINT [FK_IdProductCategory] FOREIGN KEY ([idProductCategory]) REFERENCES [dbo].[ProductCategory] ([id]),
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductBrands](
	[id] [int] NOT NULL,
	[idSupplier] [int] NOT NULL,
	[brand] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ProductBrands] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
CONSTRAINT [FK_IdSupplier_Brands] FOREIGN KEY ([idSupplier]) REFERENCES [dbo].[Supplier] ([id]),
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] NOT NULL,
	[idProductSubCategory] [int] NOT NULL,
	[idBrand] [int] NOT NULL,
	[unity] [varchar](50) NOT NULL,
	[extent] [float] NOT NULL,
	[idCategory] [int] NOT NULL,
	[date] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
CONSTRAINT [FK_IdProductSubCategory] FOREIGN KEY ([idProductSubCategory]) REFERENCES [dbo].[ProductSubCategory] ([id]),
CONSTRAINT [FK_IdBrand] FOREIGN KEY ([idBrand]) REFERENCES [dbo].[ProductBrands] ([id]),
CONSTRAINT [FK_IdCategory] FOREIGN KEY ([idCategory]) REFERENCES [dbo].[ProductCategory] ([id]),
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operation](
	[id] [int] NOT NULL,
	[idMovementType] [int] NOT NULL,
	[idSupplier] [int] NOT NULL,
	[concept] [varchar](150) NOT NULL,
	[total] [float] NULL,
	[date] [varchar](10) NOT NULL,
	[codeReference] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Operation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
CONSTRAINT [FK_IdMovementType] FOREIGN KEY ([idMovementType]) REFERENCES [dbo].[MovementType] ([id]),
CONSTRAINT [FK_IdSupplier_Operation] FOREIGN KEY ([idSupplier]) REFERENCES [dbo].[Supplier] ([id]),
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationDetail](
	[id] [int] NOT NULL,
	[codeReferenceOperation] [varchar](30) NOT NULL,
	[idProduct] [int] NOT NULL,
	[unityCost] [float] NOT NULL,
	[unityPrice] [float] NOT NULL,
	[amount] [float] NOT NULL,
	[subTotal] [float] NOT NULL,
	[date] [varchar](10) NOT NULL,
 CONSTRAINT [PK_OperationDetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
CONSTRAINT [FK_IdProduct_OperationDetail] FOREIGN KEY ([idProduct]) REFERENCES [dbo].[Product] ([id])
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[id] [int] NOT NULL,
	[idProduct] [int] NOT NULL,
	[unityPrice] [float] NOT NULL,
	[stock] [int] NOT NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
CONSTRAINT [FK_IdProduct_Store] FOREIGN KEY ([idProduct]) REFERENCES [dbo].[Product] ([id]),
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_](
	[id] [int] NOT NULL,
	[firstName] [varchar](50) NOT NULL,
	[lastName] [varchar](50) NOT NULL,
	[state] [varchar](9) NULL,
	[date] [varchar](10) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[id] [int] NOT NULL,
	[userType] [varchar](15) NOT NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSession](
	[id] [int] NOT NULL,
	[idUser] [int] NOT NULL,
	[user_] [varchar](70) NOT NULL,
	[password_] [varchar](50) NOT NULL,
	[idUserType] [int] NULL,
	[state] [varchar](10) NULL,
	[date] [varchar](10) NOT NULL,
 CONSTRAINT [PK_UserSession] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	CONSTRAINT [FK_IdUser] FOREIGN KEY ([idUser]) REFERENCES [dbo].[User_] ([id]),
    CONSTRAINT [FK_IdUserType] FOREIGN KEY ([idUserType]) REFERENCES [dbo].[UserType] ([id])
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User_] ADD  DEFAULT ('Activo') FOR [state]
GO
ALTER TABLE [dbo].[UserSession] ADD  DEFAULT ((2)) FOR [idUserType]
GO
ALTER TABLE [dbo].[UserSession] ADD  DEFAULT ('Inactivo') FOR [state]
GO
ALTER TABLE [dbo].[Operation] ADD  DEFAULT ((0)) FOR [total]
GO
INSERT INTO [dbo].[UserType] (id, userType) VALUES (1, 'Administrador')
GO
INSERT INTO [dbo].[UserType] (id, userType) VALUES (2, 'Usuario')
GO
INSERT INTO [dbo].[MovementType] (id, movementType) VALUES (1, 'Compra')
GO
INSERT INTO [dbo].[MovementType] (id, movementType) VALUES (2, 'Venta')
GO