

use biblioteca
go

-----Procesos almacenados------
create procedure Sp_Modificar_Usuario
(	
	@Identificador INT null,
	@Nombres varchar(40) null,
	@ApePa varchar(40) null,
	@ApeMa varchar(40) null,
	@Correo varchar(30),
	@Calle varchar(40)null,
	@Colonia varchar(40)null,
	@NroCasa varchar(10)null,
	@tipo varchar(10)  null,
	@Contraseña varchar (50)  null,
	@Usuario varchar (16) null
	)
	as BEGIN
	 update dbo.Usuario set 
	Nombres=@Nombres,
	ApePa= @ApePa,
	ApeMa=@ApeMa,
	Correo=@Correo,
	Calle=@Calle,
	Colonia=@Colonia,
	NroCasa=@NroCasa,
	tipo=@tipo,
	Contraseña=@Contraseña,
	Usuario=@Usuario
	where Identificador = @Identificador
	end
	go
--###########################################################################################--

create procedure Sp_Buscar_Usuario(
@Identificador int null
)
as
begin
select * from Usuario where Identificador = @Identificador
end
go
--###########################################################################################--

create procedure sp_Listar_Usuario
as
begin
select * from Usuario 
end
go
--###########################################################################################--
	create procedure SP_Eliminar_Usuario
	(
		@Identificador int=null
	)
	as 
	begin  
	delete from Usuario where Identificador = @Identificador
	end
	go
--###########################################################################################--
	create procedure SP_Registrar_Usuario
	(
	@Identificador INT  null,
	@Nombres varchar(40) null,
	@ApePa varchar(40) null,
	@ApeMa varchar(40) null,
	@Correo varchar(30) null,
	@Calle varchar(40)null,
	@Colonia varchar(40)null,
	@NroCasa varchar(10)null,
	@tipo varchar(10)  null,
	@Contraseña varchar (50)  null,
	@Usuario varchar (16) null
	)
	as BEGIN
	insert into dbo.Usuario values (
	@Identificador,
	@Nombres,
	@ApePa,
	@ApeMa,
	@Correo,
	@Calle,
	@Colonia,
	@NroCasa,
	@tipo,
	@Contraseña,
	@Usuario
	)
	end
	go
