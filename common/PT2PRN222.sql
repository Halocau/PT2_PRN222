USE [PT2PRN222]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 3/8/2025 12:12:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Dob] [datetime] NULL,
	[Major] [nvarchar](100) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Student] ([Id], [Name], [Dob], [Major]) VALUES (N'0c9', N'Nguyễn Văn Long', CAST(N'2024-06-08T12:08:00.000' AS DateTime), N'IA')
INSERT [dbo].[Student] ([Id], [Name], [Dob], [Major]) VALUES (N'21c', N'Nguyễn Văn An', CAST(N'2025-03-03T12:08:00.000' AS DateTime), N'AI')
INSERT [dbo].[Student] ([Id], [Name], [Dob], [Major]) VALUES (N'67f', N'2', CAST(N'2025-03-08T10:05:00.000' AS DateTime), N'2')
INSERT [dbo].[Student] ([Id], [Name], [Dob], [Major]) VALUES (N'803', N'Phan Văn Tuấn', CAST(N'2024-02-08T12:09:00.000' AS DateTime), N'SE')
INSERT [dbo].[Student] ([Id], [Name], [Dob], [Major]) VALUES (N'c28', N'Bùi Tiến Quát', CAST(N'2003-09-13T17:30:00.000' AS DateTime), N'SE')
GO
