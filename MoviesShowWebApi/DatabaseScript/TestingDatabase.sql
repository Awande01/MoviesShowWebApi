USE [TestingDatabase]
GO
/****** Object:  Table [dbo].[Profile]    Script Date: 2023/09/26 05:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profile](
	[ProfileId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[ProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Show]    Script Date: 2023/09/26 05:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Show](
	[ShowId] [int] IDENTITY(1,1) NOT NULL,
	[ProfileId] [int] NOT NULL,
	[ImdbId] [varchar](20) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[TitleType] [varchar](15) NOT NULL,
	[ReleasedYear] [bigint] NOT NULL,
	[ImageUrl] [varchar](500) NULL,
	[RunningTimeInMinutes] [int] NULL,
	[NextEpisodeId] [varchar](20) NULL,
	[NumberOfEpisodes] [int] NULL,
	[IsWatched] [bit] NULL,
	[Episode] [int] NULL,
	[Season] [int] NULL,
	[ParentImdbId] [varchar](20) NULL,
	[ParentTitle] [varchar](50) NULL,
	[ParentTitleType] [nchar](10) NULL,
	[ParentImageUrl] [varchar](500) NULL,
	[ParentReleasedYear] [bigint] NULL,
	[EpisodeNumber] [int] NULL,
 CONSTRAINT [PK_Show] PRIMARY KEY CLUSTERED 
(
	[ShowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Profile] ON 

INSERT [dbo].[Profile] ([ProfileId], [UserName], [Password]) VALUES (1, N'mbalid', N'1234')
SET IDENTITY_INSERT [dbo].[Profile] OFF
GO
SET IDENTITY_INSERT [dbo].[Show] ON 

INSERT [dbo].[Show] ([ShowId], [ProfileId], [ImdbId], [Title], [TitleType], [ReleasedYear], [ImageUrl], [RunningTimeInMinutes], [NextEpisodeId], [NumberOfEpisodes], [IsWatched], [Episode], [Season], [ParentImdbId], [ParentTitle], [ParentTitleType], [ParentImageUrl], [ParentReleasedYear], [EpisodeNumber]) VALUES (3, 1, N'tt1198138', N'Obsessed', N'movie', 2009, N'https://m.media-amazon.com/images/M/MV5BMjAwOTM2MzE5MF5BMl5BanBnXkFtZTcwMjM0NTcyMg@@._V1_.jpg', 108, N'', 0, 1, 0, 0, N'', N'', N'          ', N'', NULL, 0)
INSERT [dbo].[Show] ([ShowId], [ProfileId], [ImdbId], [Title], [TitleType], [ReleasedYear], [ImageUrl], [RunningTimeInMinutes], [NextEpisodeId], [NumberOfEpisodes], [IsWatched], [Episode], [Season], [ParentImdbId], [ParentTitle], [ParentTitleType], [ParentImageUrl], [ParentReleasedYear], [EpisodeNumber]) VALUES (4, 1, N'tt3303730', N'Obsessed', N'movie', 2014, N'https://m.media-amazon.com/images/M/MV5BZTdjZTZiOWYtYWY3Yi00NjcwLWJlNzYtYjUwYTZhOGJjYmQ1XkEyXkFqcGdeQXVyNjQ3NjUzMzA@._V1_.jpg', 132, N'', 0, 1, 0, 0, N'', N'', N'          ', N'', NULL, 0)
INSERT [dbo].[Show] ([ShowId], [ProfileId], [ImdbId], [Title], [TitleType], [ReleasedYear], [ImageUrl], [RunningTimeInMinutes], [NextEpisodeId], [NumberOfEpisodes], [IsWatched], [Episode], [Season], [ParentImdbId], [ParentTitle], [ParentTitleType], [ParentImageUrl], [ParentReleasedYear], [EpisodeNumber]) VALUES (5, 1, N'tt28104766', N'Squid Game: The Challenge', N'tvSeries', 2023, N'https://m.media-amazon.com/images/M/MV5BNGFlOTBhMzYtYmU5OC00OGE2LWJkNzAtYzljOTk4ZjJlZjg2XkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_.jpg', 0, N'tt28105669', 10, NULL, 0, 0, N'/title/tt28105669/', N'', N'          ', N'', NULL, 0)
INSERT [dbo].[Show] ([ShowId], [ProfileId], [ImdbId], [Title], [TitleType], [ReleasedYear], [ImageUrl], [RunningTimeInMinutes], [NextEpisodeId], [NumberOfEpisodes], [IsWatched], [Episode], [Season], [ParentImdbId], [ParentTitle], [ParentTitleType], [ParentImageUrl], [ParentReleasedYear], [EpisodeNumber]) VALUES (6, 1, N'tt2531336', N'Lupin', N'tvSeries', 2021, N'https://m.media-amazon.com/images/M/MV5BMDdlNGMyZjktYzM0Yi00ZWE3LTk0NTEtMmU1OWIxNmU4OWQ2XkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_.jpg', 45, N'tt11366908', 11, 1, 0, 0, N'/title/tt11366908/', N'', N'          ', N'', NULL, 0)
SET IDENTITY_INSERT [dbo].[Show] OFF
GO
ALTER TABLE [dbo].[Show]  WITH CHECK ADD  CONSTRAINT [FK_Show_Profile] FOREIGN KEY([ProfileId])
REFERENCES [dbo].[Profile] ([ProfileId])
GO
ALTER TABLE [dbo].[Show] CHECK CONSTRAINT [FK_Show_Profile]
GO
