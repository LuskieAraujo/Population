USE [Population]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[population]') AND type in (N'U'))
DROP TABLE [dbo].[population]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- criação de tabela por importação de arquivo
CREATE TABLE [dbo].[population](
	[Entity] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Year] [smallint] NULL,
	[Population] [nvarchar](50) NOT NULL,
	[column5] [nvarchar](50) NULL
) ON [PRIMARY]
GO

update	dbo.population
set		year = Population
,		Population = column5
where	year is null
go

ALTER TABLE [dbo].[population] DROP COLUMN [column5]
go