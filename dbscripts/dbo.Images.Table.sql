/****** Object:  Table [dbo].[Images]    Script Date: 9/6/2022 10:07:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NOT NULL,
	[FileName] [nvarchar](max) NULL,
	[FileType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [ItemId], [FileName], [FileType]) VALUES (1, 1, N'1.jpeg', N'jpeg')
INSERT [dbo].[Images] ([Id], [ItemId], [FileName], [FileType]) VALUES (2, 2, N'2.jpeg', N'jpeg')
INSERT [dbo].[Images] ([Id], [ItemId], [FileName], [FileType]) VALUES (3, 3, N'3.jpg', N'jpg')
INSERT [dbo].[Images] ([Id], [ItemId], [FileName], [FileType]) VALUES (4, 4, N'4.jpg', N'jpg')
INSERT [dbo].[Images] ([Id], [ItemId], [FileName], [FileType]) VALUES (5, 5, N'5.jpg', N'jpg')
INSERT [dbo].[Images] ([Id], [ItemId], [FileName], [FileType]) VALUES (6, 6, N'6.jpg', N'jpg')
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Items_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Items_ItemId]
GO
