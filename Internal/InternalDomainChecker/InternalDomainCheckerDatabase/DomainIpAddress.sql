CREATE TABLE [dbo].[DomainIpAddress]
(
	[DomainIpAddressId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[DomainId] INT NOT NULL,
	[IpAddress] VARCHAR(39)
)
