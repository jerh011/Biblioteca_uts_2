
-----Procesos almacenados------
create procedure Sp_Modificar_Prestamos
(	
	@Id_Prestamo INT ,
	@Identificador int ,
	@Fecha_prestamo date,
	@Fecha_devolucion date ,
	@No_Adquisicion int 
	)
	as BEGIN
	 update Prestamo set 
	Identificador=@Identificador,
	Fecha_prestamo=@Fecha_prestamo,
	Fecha_devolucion=@Fecha_devolucion,
	No_Adquisicion=@No_Adquisicion
	where Id_Prestamo =@Id_Prestamo
	end
	go
--###########################################################################################--

create procedure Sp_Buscar_Prestamos
(
@Id_Prestamo int null
)
as
begin
select * from Prestamo where Id_Prestamo = @Id_Prestamo 
end
go
--###########################################################################################--

create procedure sp_Listar_Prestamos
as
begin
select * from Prestamo 
end
go

--###########################################################################################--

	create procedure SP_Eliminar_Prestamos
	(
		@Id_Prestamo int=null
	)
	as 
	begin  
	delete from Prestamo where Id_Prestamo=@Id_Prestamo
	end
	go
--###########################################################################################--
	create procedure SP_Registrar_Prestamos
(
	@Identificador int ,
	@Fecha_prestamo date,
	@Fecha_devolucion date ,
	@No_Adquisicion int 
	
	)
	as BEGIN
	insert into Prestamo values (
	@Identificador,
	@Fecha_prestamo,
	@Fecha_devolucion,
	@No_Adquisicion 
	)
	end
	go
--###########################################################################################--

create view View_Prestamo 
as
select Pre.Id_Prestamo, Us.Identificador,Us.Nombres,Us.ApePa,Pre.Fecha_prestamo,Pre.Fecha_devolucion,
Lib.Titulo,Lib.Clasificacion,Lib.IBSN from  Usuario as Us
inner join Prestamo as Pre
on Us.Identificador=Pre.Identificador 
inner join Libro as Lib
on Pre.No_Adquisicion=Lib.No_Adquisicion

go

create procedure Sp_Prestamo
 as 
 select * from View_Prestamo
 
 exec Sp_Prestamo

 select * from Prestamo
--###########################################################################################--
create trigger TR_CambiarAEstadoOcupado
on Prestamo
for INSERT
as begin
Declare @No_Adquisicion int
select @No_Adquisicion =No_Adquisicion from inserted 
 update dbo.Libro
    SET Estatus = 'Ocupado'
    WHERE No_Adquisicion=@No_Adquisicion

end
go


create trigger TR_CambiarAEstadoDisponible
on Prestamo
for Delete
as begin
Declare @No_Adquisicion int
select @No_Adquisicion =No_Adquisicion from deleted
 update dbo.Libro
    SET Estatus = 'Disponible'
    WHERE No_Adquisicion=@No_Adquisicion

end
go




