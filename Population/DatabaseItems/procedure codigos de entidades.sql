USE [Population]
GO

DROP PROCEDURE [dbo].[ListarCodigosEntidades]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ==================================================================
-- Author:		Lucas Araujo
-- Create date: 12/Ago/2024
-- Description:	Faz select de c�digos de pa�ses ordenando pelo c�digo
-- ==================================================================
CREATE PROCEDURE [dbo].[ListarCodigosEntidades] 
AS
BEGIN
	select distinct
		coalesce(code, '_') as code
	,	entity
	from
		dbo.population
	order by
		code
END
GO