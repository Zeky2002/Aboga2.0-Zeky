USE [Aboga2.0]
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_EXPEARCHIVO]    Script Date: 17/10/2019 14:10:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_INSERTAR_EXPEARCHIVO] 

@ID_EXPEDIENTE int
AS
		
	insert into EXPEARCHIVO(ID_EXPEDIENTE) values(@ID_EXPEDIENTE);

       