ALTER PROCEDURE [dbo].[SP_INSERTAR_ARCHIVO]   
	@NOMBRE varchar(MAX)  
AS  
SET NOCOUNT ON
insert into ARCHIVOS 
	(NOMBRE) 
values
	(@NOMBRE);
  
SELECT @@IDENTITY
  

GO
exec [SP_INSERTAR_ARCHIVO]   'test'