CREATE TABLE [dbo].[NotificationRegistration]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Email] NVARCHAR(500),
	[SearchText] NVARCHAR(500),
	[NotifyOnOpen] BIT,
	[NotifyOnClose] BIT,
	[NotifyOnModified] BIT,
)
