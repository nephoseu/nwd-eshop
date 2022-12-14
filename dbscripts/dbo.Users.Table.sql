/****** Object:  Table [dbo].[Users]    Script Date: 9/6/2022 10:07:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Token] [nvarchar](max) NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[RefreshTokenExpiry] [datetime2](7) NULL,
	[Role] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[RegistrationCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [Token], [RefreshToken], [RefreshTokenExpiry], [Role], [Email], [Status], [RegistrationCode]) VALUES (1, N'Admin', N'Admin', N'admin', N'QPPskYHSzmS7DUtaNVZqint/rSVxzpQDlH8K+S2jC6BaOWqA', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiYWRtaW4iLCJuYmYiOjE2NjI0NTQzMTUsImV4cCI6MTY2MjQ1NDQzNSwiaWF0IjoxNjYyNDU0MzE1fQ.LCupV0Xo_Np_khMmkhYJLrOcTINQHmEWxlgTdLa3Ric', N'aRiWLWqw75vSeXDtT8HHRnI6apppG9++8hF+sb1uWRCaDCLuafYM6lPgnuU+gO56W3P8zotGlNjRbnx3UZfy8Q==', CAST(N'2022-09-13T10:51:55.0780340' AS DateTime2), N'admin', N'admin@internet.eu', N'Active', N'dLkOBhVAOMcUvwcqU7AAMHuFH8dD7eHdKuPMOld0RJspskW0vi537EdkJYbvNcIMxzExR2j6SasU904JQyg')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [Token], [RefreshToken], [RefreshTokenExpiry], [Role], [Email], [Status], [RegistrationCode]) VALUES (3, N'User', N'Usersmith', N'user', N'O5asVmwH7StHDrqecq4Q+KVoNGtixL4b78Kdd423NeO2PwLT', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiY3VzdG9tZXIiLCJuYmYiOjE2NjIzODU1MjksImV4cCI6MTY2MjM4NTY0OSwiaWF0IjoxNjYyMzg1NTI5fQ.YwYEgknPqpeOj1Cwb526G1u4sGf6qSeVSsq3O5ra0m0', N'CBAoy2vB7JRXYgmZrxN+7zu5nuxs2dOBm1/lLPmLaOZx5nT2SmM34IbSshrbY4ZsibbENQnnmNC0z4afbfkCSw==', CAST(N'2022-09-12T15:45:29.5097900' AS DateTime2), N'customer', N'user@internet.eu', N'Active', N'V10oXw5Hz9ggr6iQwwWMrhhq7frNIZY4ojdVuq9ZVLK1FSMdYqK6eLFmPq3ESNIJMY91uWcaM2ptFlgN66A')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
