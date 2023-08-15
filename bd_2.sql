create database biblioteca
go

use biblioteca
go

create table dbo.Usuario (
	Identificador INT Primary key  not null,
	Nombres varchar(40)not null,
	ApePa varchar(40)not null,
	ApeMa varchar(40),	
	Calle varchar(40)null,
	Colonia varchar(40)null,
	NroCasa varchar(10)null,
	tipo varchar(10) not null,
	Contraseña varchar (16) not null,
	Id_Lector varchar (16)not null,
);

Create table dbo.Libro(
	No_Adquisicion INT Primary key not null,
	Titulo varchar (40) not null,
	Fecha_adquisicion date null,
	IBSN varchar(18) not null,
	Clasificacion varchar(20) not null,
	No_Estante int null,
	Cantidad int null,
	Estatus varchar(40) not null,
	Procedencia varchar(20)  null,
	No_factura varchar(20) null 
); 

create table dbo.Prestamo(
	Id_Prestamo INT Primary key identity (1,1)  not null,
	Identificador int not null,
	Fecha_prestamo date not null,
	Fecha_devolucion date not null,
	No_Adquisicion int not null,
	constraint fk_Prestamo_Usuario foreign key (Identificador)
	references dbo.Usuario(Identificador),
	constraint fk_Prestamo_lIBRO foreign key (No_Adquisicion)
	references dbo.Libro(No_Adquisicion)
);
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
	@Contraseña varchar (16)  null,
	@Id_Lector varchar (16) null
	)
	as BEGIN
	 update dbo.Usuario set 
	@Nombres=@Nombres,
	@ApePa= @ApePa,
	@ApeMa=@ApeMa,
	@Calle=@Calle,
	@Colonia=@Colonia,
	@NroCasa=@NroCasa,
	@tipo=@tipo,
	@Contraseña=@Contraseña,
	@Id_Lector=@Id_Lector
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
	@Contraseña varchar (16)  null,
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
