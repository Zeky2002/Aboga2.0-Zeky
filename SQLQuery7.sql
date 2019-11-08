create Procedure sp_traerEvento

@id_evento int 
as

select * from EVENTO
where ID_EVENTO = @id_evento