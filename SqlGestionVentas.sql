create database GestionVentas;
go
use GestionVentas;

create table Usuario(
	Id int identity(1,1) primary key,
	Nombre varchar(100),
	NombreUsuario varchar(30),
	Contraseña varchar(50),
	Activo bit default 1
)
go
create table Articulo(
Id	int	identity(1,1) primary key,
Descripcion	varchar(100),
Impuesto  int,
PrecioVenta	money,	
Existencia	int,
Activo	bit default 1 )

create table Cliente(
Id	int identity(1,1) primary key,
NombreCompleto	varchar(250),
Rfc	varchar(15)	,
Direccion	varchar(100),
Activo	bit default 1	
)

create table TipoPago (
Id	int  identity(1,1) primary key,
Descripcion	varchar(50),
Activo	bit default 1	
)
create table FlujoNota (
Id	int  identity(1,1) primary key,
Descripcion	varchar(50),
Activo	bit default 1	
)

create table EncNotaVenta (
Id	int  identity(1,1) primary key,
FechaCreado	datetime,
Comentario	varchar(100),
IdCliente	int foreign key references Cliente(Id),
status	varchar(10)
)

create table DetNotaVenta (
Id int  identity(1,1) primary key,
IdArticulo	int foreign key references Articulo(Id),
PrecioVenta	money,
Cantidad	int,
IdEncNotaVenta	int foreign key references EncNotaVenta(Id)
)



select * from Articulo
update articulo set activo=1