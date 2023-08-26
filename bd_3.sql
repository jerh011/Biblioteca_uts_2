use biblioteca
go
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
select Pre.Id_Prestamo ,Us.Identificador,Us.Nombres,Us.ApePa,Pre.Fecha_prestamo,Pre.Fecha_devolucion,
Lib.Titulo,Lib.Clasificacion,Lib.IBSN from  Usuario as Us
inner join Prestamo as Pre
on Us.Identificador=Pre.Identificador 
inner join Libro as Lib
on Pre.No_Adquisicion=Lib.No_Adquisicion

go

create procedure Sp_Prestamo
 as 
 select * from View_Prestamo
 
go
--###########################################################################################--
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

--######################Cantidad de libros########-----
create trigger TR_CantidaLibros
on Libro
for INSERT
as begin
Declare @Cantidad int,@ibsen varchar(18)

select @ibsen=IBSN from  inserted

select @Cantidad=COUNT(*) from  Libro
where IBSN = @ibsen

 update Libro
    SET Cantidad = @Cantidad
   where IBSN = @ibsen

end
go
--##posiblemente esto este mal#############################################################--
drop trigger TR_CantidaLibros_elimnados
on Libro
for Delete
as begin
Declare @Cantidad int,@ibsen varchar(18)

select @ibsen=IBSN from  deleted

select @Cantidad=COUNT(*) from  Libro
where IBSN = @ibsen

 update Libro
    SET Cantidad = @Cantidad
   where IBSN = @ibsen

end
go
---########vista usuario#############----

create procedure Sp_Usuario_P
(
@Identificador int
)
 as 
select Us.Identificador, Pre.Id_Prestamo, Lib.No_Adquisicion ,Lib.Titulo ,Lib.IBSN ,Lib.Clasificacion, Lib.No_Estante
 from  Usuario as Us
inner join Prestamo as Pre
on Us.Identificador=Pre.Identificador 
inner join Libro as Lib
on Pre.No_Adquisicion=Lib.No_Adquisicion
 where Us.Identificador=@Identificador
 go

 --==========================================login======================================================
 create procedure sp_ValidarUsuario(
@Usuario varchar (50),
@Contraseña varchar (50)
)
as
begin
	select * from Usuario where Usuario=@Usuario and Contraseña=@Contraseña
end
go

create procedure sp_ValidarUsuario_existente
(
@Usuario varchar (50))
as
begin
	select * from Usuario where Usuario=@Usuario;
end
go

create procedure sp_CambiarClave
(
@Usuario varchar (50),
@Contraseña varchar (50)
)
as
begin
	update Usuario set Contraseña=@Contraseña where Usuario=@Usuario
end
---########################################--

create  database encriptacion 

use encriptacion 
--SE CREA LA LLAVE MKAESTRA PARA LA ENCRIPTACION
create MASTER KEY ENCRYPTION BY PASSWORD ='JERH011';
GO
--###################################################----
--SE CREA UNA LLAVE SIMETRICA  CON EL ALGORITMO "AES_256"
cREATE SYMMETRIC KEY JERH011---ESTO VA EN EL PARENTESIS QUE ESTA MAS ABAJO EN EL PASO 3
with algorithm = AES_256
ENCRYPTION  BY PASSWORD ='JERH011';
GO


--##########################################################-----
-- Cifrar datos usando ENCRYPTBYKEY
--DECLARAMOS VARIABLES
DECLARE @NUMEROTARGETA NVARCHAR(100) ='1234-5678-9012-3456';
DECLARE @NUMERTARJETACIFRADA VARBINARY (200);
--ABRIMOS LA SIMETRRIA DE DE LLAVES?
OPEN SYMMETRIC KEY JERH011 
	DECRYPTION BY PASSWORD ='JERH011';
	SET @NUMERTARJETACIFRADA=ENCRYPTBYKEY(KEY_GUID('JERH011'),@NUMEROTARGETA);--ESTE
	
SELECT @NUMERTARJETACIFRADA AS NUMERTARJETACIFRADA;
GO 
--############################################################---
--PASOS PARA DESIFRAR 
DECLARE @NUMEROTARJETACIFRADA VARBINARY(200)=0x0018E4C5AA0E204784F166246530DECC020000003534F72692C25DC1C44BBE65541AC8B45BB97ADE995C6EA5873F536EB305C42219DF3295D5478B125175FE333EBA1CCEB0C3B9AB15F6DBD234F179652BEFFCE4; 
DECLARE @NUMEROTARJETADECIFRADA NVARCHAR(100);
OPEN SYMMETRIC KEY JERH011
	DECRYPTION BY PASSWORD='JERH011';
SET @NUMEROTARJETADECIFRADA=CONVERT(nvarchar(100),
DECRYPTBYKEY(@NUMEROTARJETACIFRADA));
SELECT @NUMEROTARJETADECIFRADA AS NUMEROTARGETADECIFRADA;
--######################################################--
create procedure sp_ValidarUsuario_con_correo
(
@Correo varchar (50),
@Contraseña varchar (50)
)
as
begin
	select * from Usuario where Correo=@Correo and Contraseña=@Contraseña
end
go

create procedure sp_ValidarCorreo(
@Correo varchar (50))
as
begin
	select * from Usuario where Correo=@Correo;
end
go
--####################################
