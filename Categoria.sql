
create table Categoria
(
Idtipo int primary key identity (1,1),
Tipo varchar(50))

go

create procedure sp_ListarCategoria
as
begin
	select * from Categoria
end
go

create procedure sp_ListarSinCategoria
as 
begin 
	select * from Contacto
end;
go

create procedure sp_ObtenerCategoria
(
@Idtipo int
)
as
begin
select * from Categoria where Idtipo = @Idtipo
end
go

create procedure sp_GuardarCategoria
(
@Tipo varchar(50)
)
as
begin
	insert into Categoria values (@Tipo)
end
go

create procedure sp_EditarCategoria
(
@Idtipo int,
@Tipo varchar(50)
)
as
begin
	update Categoria set  NombreCategoria=@Tipo where Idtipo=@Idtipo
end
go

create procedure sp_EliminarCategoria
(
@Idtipo int
)
as
begin
	update Usuario set Idtipo=null where Idtipo=@Idtipo
	delete from Categoria where Idtipo=@Idtipo
end
go