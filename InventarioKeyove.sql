use ProductosBD;
go 
create table Categorias(
	Id  int primary key identity (1,1),
	Nombre varchar(100),
	Descripcion varchar(100)
)

CREATE TABLE IngresosAlmacen (
    IdIngreso INT IDENTITY(1,1) PRIMARY KEY,
    AlmacenDestino NVARCHAR(100),
    TipoMotivo NVARCHAR(100),
    Comprobante NVARCHAR(100),
    NroComprobante NVARCHAR(50),
    FechaComprobante DATE,
    RUCProveedor NVARCHAR(20),
    RazonSocial NVARCHAR(150)
);

 CREATE TABLE DetalleIngreso (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdIngreso INT NOT NULL,
    DescripcionArticulo NVARCHAR(100),
    Cantidad DECIMAL(10,2),
    UnidadMedida NVARCHAR(20),
    PrecioUnit DECIMAL(10,2),
    SubTotal AS (Cantidad * PrecioUnit) PERSISTED,
    Marca NVARCHAR(50),
    FOREIGN KEY (IdIngreso) REFERENCES IngresosAlmacen(IdIngreso)
);

CREATE TABLE productos (
	idproducto int identity(1,1) primary key,
	Nombre varchar(100),
	descripcion varchar(250),
	precio decimal (10,2),
	stock int 
    
);

select*from productos;
select*from Categorias;
select*from DetalleIngreso;
select*from IngresosAlmacen;

