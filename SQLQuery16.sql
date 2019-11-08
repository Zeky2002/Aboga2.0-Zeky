USE [Aboga2.0]
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_EVE_EXP]    Script Date: 18/10/2019 12:03:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_INSERTAR_EVE_EXP]

@Titulo varchar(80),
@Descripcion varchar(50),
@Fecha datetime,
@idexp int


as
insert into EVENTO(TITULO,FECHA,DESCRIPCION,ID_EXPEDIENTE)values(@Titulo,@Fecha,@Descripcion,@idexp)
