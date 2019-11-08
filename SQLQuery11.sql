CREATE PROCEDURE SP_EVE_CONT

@Titulo int,
@Descripcion varchar(50),
@Fecha date,

@idcont int

as
insert into EVENTO(TITULO,FECHA,DESCRIPCION,ID_EXPEDIENTE,ID_CONTACTO)values(@Titulo,@Descripcion,@Fecha,0,@idcont)
