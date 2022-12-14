/****** Object:  Table [dbo].[Addresses]    Script Date: 9/6/2022 10:07:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Street] [nvarchar](max) NOT NULL,
	[Zip] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([Id], [UserId], [FirstName], [LastName], [Street], [Zip], [City], [Country]) VALUES (1, 1, N'Admin', N'Admin', N'Admin Street 1', N'10000', N'Admin City', N'Admin Republic')
INSERT [dbo].[Addresses] ([Id], [UserId], [FirstName], [LastName], [Street], [Zip], [City], [Country]) VALUES (2, 3, N'User', N'Usersmith', N'User Street 2', N'82000', N'User Town', N'Userland')
SET IDENTITY_INSERT [dbo].[Addresses] OFF
GO
