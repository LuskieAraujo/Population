USE [Population]
GO

DROP PROCEDURE [dbo].[ListarPopulacaoEntidade]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ================================================================
-- Author:		Lucas Araujo
-- Create date: 12/Ago/2024
-- Description:	Faz select filtrando pelo país e ordenando pelo ano
-- ================================================================
create PROCEDURE [dbo].[ListarPopulacaoEntidade] 
	@InvalidCode bit
,	@Value nvarchar(50)
AS
BEGIN
	if @InvalidCode = 0
		select		Code, Entity, Year, Population
		from		dbo.population
		where		Code = @Value
		order by	year
	else
		select		Code, Entity, Year, Population
		from		dbo.population
		where		Entity = @Value
		order by	year
END
GO