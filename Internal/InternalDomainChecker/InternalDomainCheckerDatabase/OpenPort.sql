CREATE TABLE [dbo].[OpenPort]
(
	[OpenPortId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[DomainIpAddressId] INT NOT NULL,
	[Port] INT NOT NULL
)
