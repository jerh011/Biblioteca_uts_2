

use biblioteca
go

-----Procesos almacenados------
create procedure Sp_Modificar_Usuario
(	
	@Identificador INT null,
	@Nombres varchar(40) null,
	@ApePa varchar(40) null,
	@ApeMa varchar(40) null,	
	@Calle varchar(40)null,
	@Colonia varchar(40)null,
	@NroCasa varchar(10)null,
	@tipo varchar(10)  null,
	@Contraseña varchar (50)  null,
	@Id_Lector varchar (16) null
	)
	as BEGIN
	 update dbo.Usuario set 
	Nombres=@Nombres,
	ApePa= @ApePa,
	ApeMa=@ApeMa,
	Calle=@Calle,
	Colonia=@Colonia,
	NroCasa=@NroCasa,
	tipo=@tipo,
	Contraseña=@Contraseña,
	Id_Lector=@Id_Lector
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
	@Calle varchar(40)null,
	@Colonia varchar(40)null,
	@NroCasa varchar(10)null,
	@tipo varchar(10)  null,
	@Contraseña varchar (50)  null,
	@Id_Lector varchar (16) null
	)
	as BEGIN
	insert into dbo.Usuario values (
	@Identificador,
	@Nombres,
	@ApePa,
	@ApeMa,	
	@Calle,
	@Colonia,
	@NroCasa,
	@tipo,
	@Contraseña,
	@Id_Lector
	)
	end
	go
