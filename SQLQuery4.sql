USE [Aboga2.0]
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_ARCHIVO]    Script Date: 11/10/2019 10:23:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_INSERTAR_ARCHIVO] 


@NOMBRE varchar(MAX)

AS
		insert into ARCHIVOS(NOMBRE) values(@NOMBRE);

       