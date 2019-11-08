create PROCEDURE SP_INSERTAR_EVE_EXP

@Titulo int,
@Descripcion varchar(50),
@Fecha date,
@idexp int


as
insert into EVENTO(TITULO,FECHA,DESCRIPCION,ID_EXPEDIENTE,ID_CONTACTO)values(@Titulo,@Descripcion,@Fecha,@idexp,0)
