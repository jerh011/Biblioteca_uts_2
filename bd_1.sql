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



-----Procesos almacenados------
create procedure Sp_Modificar_Libro
(	
	@No_Adquisicion int = null,
	@Titulo varchar (40)=null,
	@Fecha_adquisicion date= null,
	@IBSN varchar(18)=null,
	@Clasificacion varchar(20)=null,
	@No_Estante int =null,
	@Cantidad int =null,
	@Estatus varchar(40) = null,
	@Procedencia varchar(20)=null,
	@No_factura varchar(20) =null 

	)
	as BEGIN
	 update dbo.Libro set 
	Titulo=@Titulo,
	Fecha_adquisicion=@Fecha_adquisicion,
	IBSN=@IBSN,
	Clasificacion=@Clasificacion,
	No_Estante=@No_Estante,
	Cantidad=@Cantidad,
	Estatus=@Estatus,
	Procedencia=@Procedencia,
	No_factura=@No_factura
	where No_Adquisicion = @No_Adquisicion
	end
	go
--###########################################################################################--

create procedure Sp_Buscar_Libro(
@No_Adquisicion int null
)
as
begin
select * from Libro where No_Adquisicion = @No_Adquisicion 
end
go
--###########################################################################################--

create procedure sp_Listar_Libro
as
begin
select * from Libro 
end
go

--###########################################################################################--

	create procedure SP_Eliminar_Libro
	(
		@No_Adquisicion int=null
	)
	as 
	begin  
	delete from Libro where No_Adquisicion=@No_Adquisicion
	end
	go
--###########################################################################################--
	create procedure SP_Registrar_Libro
(
	@No_Adquisicion INT = null,
	@Titulo varchar (40)=null,
	@Fecha_adquisicion date= null,
	@IBSN varchar(18)=null,
	@Clasificacion varchar(20)=null,
	@No_Estante int =null,
	@Cantidad int =null,
	@Estatus varchar(40)= null,
	@Procedencia varchar(20)  null,
	@No_factura varchar(20) null 
	
	)
	as BEGIN
	insert into dbo.Libro values (
	@No_Adquisicion,
	@Titulo,
	@Fecha_adquisicion,
	@IBSN,
	@Clasificacion,
	@No_Estante,
	@Cantidad, 
	@Estatus,
	@Procedencia,
	@No_factura 
	)
	end
	go
