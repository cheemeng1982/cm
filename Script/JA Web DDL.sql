------------------------------------------------------
-- Web Services - JobApply Web
-- DDL and DML Script for JobApply Web
-- Date: September 2017
-- Author: Mak Chee Meng, Cliff 
------------------------------------------------------

-- Create database "DBJAWeb"

USE master
GO
if db_id('DBJAWeb') IS NOT NULL
	BEGIN
		DROP DATABASE DBJAWeb
		PRINT '*** DATABASE DBJAWeb DROPPED ***'
	END
GO

CREATE DATABASE DBJAWeb
GO
PRINT '*** CREATED DATABASE DBJAWeb ***'


-- Create the tables
Use DBJAWeb


-- TABLE LookupIndustry
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbl_LookupIndustry]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tbl_LookupIndustry]
GO
CREATE TABLE [dbo].[tbl_LookupIndustry] (
	[IndustryID] int IDENTITY (1, 1) NOT NULL,
	[IndustryName] nvarchar (80),
	[LastModifiedDate] datetime NOT NULL DEFAULT (SYSDATETIME()),
	CONSTRAINT [PK_LookupCountries] PRIMARY KEY CLUSTERED 
	(
		[IndustryID]
	)
) 
GO
PRINT '*** CREATED TABLE tbl_LookupIndustry ***'


-- TABLE LookupSalaryRange
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbl_LookupSalaryRange]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tbl_LookupSalaryRange]
GO
CREATE TABLE [dbo].[tbl_LookupSalaryRange] (
	[SalaryRangeID] int IDENTITY (1, 1) NOT NULL,
	[Display] nvarchar (100),
	[LastModifiedDate] datetime NOT NULL DEFAULT (SYSDATETIME()),
	CONSTRAINT [PK_LookupSalaryRange] PRIMARY KEY CLUSTERED 
	(
		[SalaryRangeID]
	)
) 
GO
PRINT '*** CREATED TABLE tbl_LookupSalaryRange ***'


-- TABLE LookupLocation
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbl_LookupLocation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tbl_LookupLocation]
GO
CREATE TABLE [dbo].[tbl_LookupLocation] (
	[LocationID] int IDENTITY (1, 1) NOT NULL,
	[LocationName] nvarchar (100),
	[LastModifiedDate] datetime NOT NULL DEFAULT (SYSDATETIME()),
	CONSTRAINT [PK_LookupLocation] PRIMARY KEY CLUSTERED 
	(
		[LocationID]
	)
) 
GO
PRINT '*** CREATED TABLE tbl_LookupLocation ***'

-- TABLE LookupSubLocation
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbl_LookupSubLocation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tbl_LookupSubLocation]
GO
CREATE TABLE [dbo].[tbl_LookupSubLocation] (
	[SubLocationID] int IDENTITY (1, 1) NOT NULL,
	[SubLocationName] nvarchar (100),
	[LocationID] int,
	[LastModifiedDate] datetime NOT NULL DEFAULT (SYSDATETIME()),
	CONSTRAINT [PK_LookupSubLocation] PRIMARY KEY CLUSTERED 
	(
		[SubLocationID]
	)
) 
GO
PRINT '*** CREATED TABLE tbl_LookupLocation ***'


-- TABLE Applicant
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbl_Applicant]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tbl_Applicant]
GO
CREATE TABLE [dbo].[tbl_Applicant] (
	[ApplicantID] int IDENTITY (1, 1) NOT NULL,
	[FirstName] nvarchar (100),
	[LastName] nvarchar (100),
	[CompanyName] nvarchar (200),
	[Phone] nvarchar (100),
	[Email] nvarchar (150),
	[CorrespondenceAddress] nvarchar (500),
	[JobTitle] nvarchar (150),
	[JobSpecification] nvarchar (150),
	[LocationId] int,
	[SubLocationId] int,
	[IndustryId] int,
	[SalaryRangeId] int,
	[CreationDate] datetime NOT NULL DEFAULT (SYSDATETIME()),
	CONSTRAINT [PK_Applicant] PRIMARY KEY CLUSTERED 
	(
		[ApplicantID]
	)
) 
GO
PRINT '*** CREATED TABLE tbl_Applicant ***'


-------------------------------------------------------
--	Referential Integrity
-------------------------------------------------------

ALTER TABLE [tbl_LookupSubLocation]  WITH CHECK ADD  CONSTRAINT [FK_tbl_LookupSubLocation_tbl_LookupLocation] FOREIGN KEY([LocationId])
REFERENCES [tbl_LookupLocation] ([LocationId])
GO
ALTER TABLE [tbl_LookupSubLocation] CHECK CONSTRAINT [FK_tbl_LookupSubLocation_tbl_LookupLocation]
GO

ALTER TABLE [tbl_Applicant]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Applicant_tbl_LookupIndustry] FOREIGN KEY([IndustryId])
REFERENCES [tbl_LookupIndustry] ([IndustryId])
GO
ALTER TABLE [tbl_Applicant] CHECK CONSTRAINT [FK_tbl_Applicant_tbl_LookupIndustry]
GO

ALTER TABLE [tbl_Applicant]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Applicant_tbl_LookupSalaryRange] FOREIGN KEY([SalaryRangeId])
REFERENCES [tbl_LookupSalaryRange] ([SalaryRangeId])
GO
ALTER TABLE [tbl_Applicant] CHECK CONSTRAINT [FK_tbl_Applicant_tbl_LookupSalaryRange]
GO

ALTER TABLE [tbl_Applicant]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Applicant_tbl_LookupLocation] FOREIGN KEY([LocationId])
REFERENCES [tbl_LookupLocation] ([LocationId])
GO
ALTER TABLE [tbl_Applicant] CHECK CONSTRAINT [FK_tbl_Applicant_tbl_LookupLocation]
GO


-------------------------------------------------------
--	The below DDL insert records to the dbo.[Tables]s
-------------------------------------------------------

DECLARE @DateTime DATETIME
SET @DateTime = SYSDATETIME()


/*-----------------LookupIndustry-----------------*/
PRINT 'Start adding data into dbo.tbl_LookupIndustry'

SET NOCOUNT ON

DELETE FROM dbo.tbl_LookupIndustry

INSERT INTO dbo.tbl_LookupIndustry (IndustryName,LastModifiedDate)
VALUES('Engineering', @DateTime)

INSERT INTO dbo.tbl_LookupIndustry (IndustryName,LastModifiedDate)
VALUES('Business & Marketing', @DateTime)

INSERT INTO dbo.tbl_LookupIndustry (IndustryName,LastModifiedDate)
VALUES('Information Technology', @DateTime)

INSERT INTO dbo.tbl_LookupIndustry (IndustryName,LastModifiedDate)
VALUES('Others', @DateTime)

SET NOCOUNT OFF

PRINT 'Finished adding data into dbo.tbl_LookupIndustry'


/*-----------------LookupLocation-----------------*/
PRINT 'Start adding data into dbo.tbl_LookupLocation'

SET NOCOUNT ON

DELETE FROM dbo.tbl_LookupLocation

INSERT INTO dbo.tbl_LookupLocation (LocationName,LastModifiedDate)
VALUES('Kuala Lumpur', @DateTime)

INSERT INTO dbo.tbl_LookupLocation (LocationName,LastModifiedDate)
VALUES('Selangor', @DateTime)

INSERT INTO dbo.tbl_LookupLocation (LocationName,LastModifiedDate)
VALUES('Perak', @DateTime)

INSERT INTO dbo.tbl_LookupLocation (LocationName,LastModifiedDate)
VALUES('Peneng', @DateTime)

SET NOCOUNT OFF

PRINT 'Finished adding data into dbo.tbl_LookupLocation'


/*-----------------LookupSubLocation-----------------*/
PRINT 'Start adding data into dbo.tbl_LookupSubLocation'

SET NOCOUNT ON

DELETE FROM dbo.tbl_LookupSubLocation

INSERT INTO dbo.tbl_LookupSubLocation (SubLocationName,LocationId, LastModifiedDate)
VALUES('Kuala Lumpur', 1, @DateTime)

INSERT INTO dbo.tbl_LookupSubLocation (SubLocationName,LocationId, LastModifiedDate)
VALUES('Petaling Jaya', 2, @DateTime)

INSERT INTO dbo.tbl_LookupSubLocation (SubLocationName,LocationId, LastModifiedDate)
VALUES('Subang Jaya', 2, @DateTime)

INSERT INTO dbo.tbl_LookupSubLocation (SubLocationName,LocationId, LastModifiedDate)
VALUES('Cyberjaya', 2, @DateTime)

INSERT INTO dbo.tbl_LookupSubLocation (SubLocationName,LocationId, LastModifiedDate)
VALUES('Ipoh', 3, @DateTime)

INSERT INTO dbo.tbl_LookupSubLocation (SubLocationName,LocationId, LastModifiedDate)
VALUES('Georgetown', 4, @DateTime)

INSERT INTO dbo.tbl_LookupSubLocation (SubLocationName,LocationId, LastModifiedDate)
VALUES('Bayan Lepas', 4, @DateTime)

SET NOCOUNT OFF

PRINT 'Finished adding data into dbo.tbl_LookupSubLocation'


/*-----------------LookupSalaryRange-----------------*/
PRINT 'Start adding data into dbo.tbl_LookupSalaryRange'

SET NOCOUNT ON

DELETE FROM dbo.tbl_LookupSalaryRange

INSERT INTO dbo.tbl_LookupSalaryRange (Display,LastModifiedDate)
VALUES('0 - 5000', @DateTime)

INSERT INTO dbo.tbl_LookupSalaryRange (Display,LastModifiedDate)
VALUES('5001 - 10000', @DateTime)

INSERT INTO dbo.tbl_LookupSalaryRange (Display,LastModifiedDate)
VALUES('10001 - 15000', @DateTime)

INSERT INTO dbo.tbl_LookupSalaryRange (Display,LastModifiedDate)
VALUES('15001 - 20000', @DateTime)

INSERT INTO dbo.tbl_LookupSalaryRange (Display,LastModifiedDate)
VALUES('Above 20000', @DateTime)

SET NOCOUNT OFF

PRINT 'Finished adding data into dbo.tbl_LookupSalaryRange'