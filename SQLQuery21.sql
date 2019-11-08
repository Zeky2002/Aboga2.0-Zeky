USE [Aboga2.0]
GO
/****** Object:  StoredProcedure [dbo].[SP_EVE_CONT]    Script Date: 18/10/2019 12:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_EVE_CONT]

@Titulo varchar(80),
@Descripcion varchar(50),
@Fecha datetime,

@idcont int

as
insert into EVENTO(TITULO,FECHA,DESCRIPCION,ID_CONTACTO)values(@Titulo,@Fecha,@Descripcion,@idcont)
