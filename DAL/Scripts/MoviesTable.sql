CREATE TABLE [dbo].[Movies](
	[Release_Date] [DATETIME] NOT NULL,
	[Title] [VARCHAR](60) NOT NULL,
	[Overview] [VARCHAR](335) NULL,
	[Popularity] [VARCHAR](315) NULL,
	[Vote_Count] [VARCHAR](345) NULL,
	[Vote_Average] [VARCHAR](282) NULL,
	[Original_Language] [VARCHAR](237) NULL,
	[Genre] [VARCHAR](172) NULL,
	[Poster_Url] [VARCHAR](341) NULL,
PRIMARY KEY CLUSTERED 
(
	[Release_Date] ASC,
	[Title] ASC
))