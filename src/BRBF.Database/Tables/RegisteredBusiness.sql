﻿CREATE TABLE [dbo].[RegisteredBusiness]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[AccountNumber] VARCHAR(250) NULL,
	[AccountName] VARCHAR(250) NULL,
	[LegalName] VARCHAR(250) NULL,
	[AccountLocationCode] VARCHAR(250) NULL,
	[AccountLocation] VARCHAR(250) NULL,
	[ContactPerson] VARCHAR(250) NULL,
	[BusinessOpenDate] DATE NULL, 
	[BusinessStatus] VARCHAR(250) NULL,
	[BusinessCloseDate] DATE NULL,
	[OwnershipType] VARCHAR(250) NULL,
	[AccountTypeCode] VARCHAR(250) NULL,
	[AccountType] VARCHAR(250) NULL,
	[NAICSCode] VARCHAR(250) NULL,
	[NAICSCategory] VARCHAR(250) NULL,
	[NAICSGroup] VARCHAR(250) NULL,
	[ABCStatusCode] VARCHAR(250) NULL,
	[ABCStatus] VARCHAR(250) NULL,
	[ConsolidatedFiler] BIT NULL,
	[MailingAddressLine1] VARCHAR(250) NULL,
	[MailingAddressLine2] VARCHAR(250) NULL,
	[MailingAddressCity] VARCHAR(250) NULL,
	[MailingAddressState] VARCHAR(250) NULL,
	[MailingAddressZipCode] VARCHAR(250) NULL,
	[PhysicalAddressLine1] VARCHAR(250) NULL,
	[PhysicalAddressLine2] VARCHAR(250) NULL,
	[PhysicalAddressCity] VARCHAR(250) NULL,
	[PhysicalAddressState] VARCHAR(250) NULL,
	[PhysicalAddressZipCode] VARCHAR(250) NULL,
	[Geolocation] VARCHAR(500) NULL, 
    [Revision] ROWVERSION NULL,
	CONSTRAINT [PK_RegisteredBusiness_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
)
GO

CREATE INDEX [IX_RegisteredBusiness_AccountNumber] ON [dbo].[RegisteredBusiness] ([AccountNumber])
GO

CREATE FULLTEXT CATALOG RegisteredBusinessCatalog AS DEFAULT
GO
CREATE FULLTEXT INDEX ON [dbo].[RegisteredBusiness](
	[AccountNumber],
	[AccountName],
	[LegalName],
	[AccountLocationCode],
	[AccountLocation],
	[ContactPerson],
	[BusinessStatus],
	[OwnershipType],
	[AccountTypeCode],
	[AccountType],
	[NAICSCode],
	[NAICSCategory],
	[NAICSGroup],
	[ABCStatusCode],
	[ABCStatus],
	[MailingAddressLine1],
	[MailingAddressLine2],
	[MailingAddressCity],
	[MailingAddressState],
	[MailingAddressZipCode],
	[PhysicalAddressLine1],
	[PhysicalAddressLine2],
	[PhysicalAddressCity],
	[PhysicalAddressState],
	[PhysicalAddressZipCode],
	[Geolocation]
) KEY INDEX [PK_RegisteredBusiness_Id]
GO
