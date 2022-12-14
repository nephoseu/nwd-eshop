/****** Object:  Table [dbo].[Items]    Script Date: 9/6/2022 10:07:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Items] ON 

INSERT [dbo].[Items] ([Id], [Name], [Price], [Category], [Description]) VALUES (1, N'1st product', CAST(11.00 AS Decimal(18, 2)), N'Shoes', N'Our very first product')
INSERT [dbo].[Items] ([Id], [Name], [Price], [Category], [Description]) VALUES (2, N'The finest item we have', CAST(57.00 AS Decimal(18, 2)), N'Clothes', N'Look no more further')
INSERT [dbo].[Items] ([Id], [Name], [Price], [Category], [Description]) VALUES (3, N'third product', CAST(3.00 AS Decimal(18, 2)), N'Glasses', N'the name says it all')
INSERT [dbo].[Items] ([Id], [Name], [Price], [Category], [Description]) VALUES (4, N'surprise item', CAST(956.00 AS Decimal(18, 2)), N'Glasses', N'what could this be')
INSERT [dbo].[Items] ([Id], [Name], [Price], [Category], [Description]) VALUES (5, N'strap', CAST(3.00 AS Decimal(18, 2)), N'Clothes', N'a simple strap')
INSERT [dbo].[Items] ([Id], [Name], [Price], [Category], [Description]) VALUES (6, N'buggy', CAST(6850.00 AS Decimal(18, 2)), N'Shoes', N'explore the wilderness')
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
