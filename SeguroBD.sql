USE [master]
GO
/****** Object:  Database [BDseguros]    Script Date: 8/3/2025 08:45:15 ******/
CREATE DATABASE [BDseguros]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDseguros', FILENAME = N'C:\Users\addys\BDseguros.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDseguros_log', FILENAME = N'C:\Users\addys\BDseguros_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BDseguros] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDseguros].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDseguros] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDseguros] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDseguros] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDseguros] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDseguros] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDseguros] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BDseguros] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDseguros] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDseguros] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDseguros] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDseguros] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDseguros] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDseguros] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDseguros] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDseguros] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BDseguros] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDseguros] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDseguros] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDseguros] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDseguros] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDseguros] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDseguros] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDseguros] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BDseguros] SET  MULTI_USER 
GO
ALTER DATABASE [BDseguros] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDseguros] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDseguros] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDseguros] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDseguros] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDseguros] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BDseguros] SET QUERY_STORE = OFF
GO
USE [BDseguros]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/3/2025 08:45:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 8/3/2025 08:45:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[Dni] [nvarchar](13) NOT NULL,
	[Rtn] [nvarchar](14) NOT NULL,
	[FecNacimiento] [date] NOT NULL,
	[TipoPersona] [int] NOT NULL,
	[celular] [nvarchar](8) NOT NULL,
	[Telefono] [nvarchar](8) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[FecRegistro] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cobertura]    Script Date: 8/3/2025 08:45:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cobertura](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NombreCobertura] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](200) NOT NULL,
	[FecRegistro] [datetime2](7) NOT NULL,
	[ramoId] [int] NOT NULL,
	[Deducible] [float] NOT NULL,
 CONSTRAINT [PK_Cobertura] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Corredor]    Script Date: 8/3/2025 08:45:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Corredor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[Dni] [nvarchar](13) NOT NULL,
	[celular] [nvarchar](8) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[CodCorredor] [nvarchar](8) NOT NULL,
	[FecRegistro] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Corredor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Poliza]    Script Date: 8/3/2025 08:45:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Poliza](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[clienteId] [int] NOT NULL,
	[corredorId] [int] NOT NULL,
	[ramoId] [int] NOT NULL,
	[montoAsegurar] [decimal](18, 2) NOT NULL,
	[montoNeto] [decimal](18, 2) NOT NULL,
	[comision] [decimal](18, 2) NOT NULL,
	[impuesto] [decimal](18, 2) NOT NULL,
	[totalPagar] [decimal](18, 2) NOT NULL,
	[prima] [decimal](18, 2) NOT NULL,
	[cuota] [decimal](18, 2) NOT NULL,
	[FecRegistro] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Poliza] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ramo]    Script Date: 8/3/2025 08:45:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ramo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NombreRamos] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](200) NOT NULL,
	[FecRegistro] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Ramo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 8/3/2025 08:45:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [nvarchar](max) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[Rol] [int] NOT NULL,
	[FecRegistro] [datetime2](7) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250302012357_ModeloRamo', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250302012742_UpdateRamo', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250302013912_ModeloCobertura', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250302032620_UpdateRamos2', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250302062327_updatedeCobertura', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250302124010_ModeloCorredor', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250302194519_mModelUsuario', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250302194619_Usuario', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250302201615_User', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250302211159_User2', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250303101834_TablaClientes', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250303101942_TablaClientes2', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250304051611_actualizarcliente', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250304055546_actualizarclient2', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250304063337_ModeloPoliza', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250304064941_UpPoliza', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250308135638_BDSEGUROS', N'8.0.6')
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([id], [Nombre], [Apellido], [Dni], [Rtn], [FecNacimiento], [TipoPersona], [celular], [Telefono], [Email], [Direccion], [FecRegistro]) VALUES (3, N'Angel', N'string', N'3640409660671', N'29828718562411', CAST(N'2025-03-04' AS Date), 0, N'91155819', N'33935538', N'string', N'string', CAST(N'2025-03-03T22:44:39.5026217' AS DateTime2))
INSERT [dbo].[Cliente] ([id], [Nombre], [Apellido], [Dni], [Rtn], [FecNacimiento], [TipoPersona], [celular], [Telefono], [Email], [Direccion], [FecRegistro]) VALUES (8, N'Angel', N'Guzman', N'0545012151545', N'15151545848845', CAST(N'2025-03-13' AS Date), 1, N'63636363', N'54336363', N'manuel.calderon@gmail.com', N'Tegucigalpa', CAST(N'2025-03-04T00:04:10.2084885' AS DateTime2))
INSERT [dbo].[Cliente] ([id], [Nombre], [Apellido], [Dni], [Rtn], [FecNacimiento], [TipoPersona], [celular], [Telefono], [Email], [Direccion], [FecRegistro]) VALUES (1011, N'string', N'string', N'6407740867751', N'47386586033966', CAST(N'2025-03-08' AS Date), 0, N'82038861', N'33155938', N'string', N'string', CAST(N'2025-03-08T04:07:02.7642907' AS DateTime2))
INSERT [dbo].[Cliente] ([id], [Nombre], [Apellido], [Dni], [Rtn], [FecNacimiento], [TipoPersona], [celular], [Telefono], [Email], [Direccion], [FecRegistro]) VALUES (1012, N'string', N'string', N'0025581635975', N'42596722121477', CAST(N'2025-03-08' AS Date), 0, N'83890364', N'83959317', N'string', N'string', CAST(N'2025-03-08T07:44:22.2259104' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Cobertura] ON 

INSERT [dbo].[Cobertura] ([id], [NombreCobertura], [Descripcion], [FecRegistro], [ramoId], [Deducible]) VALUES (3, N'Robo', N'El robo total del automóvil asegurado', CAST(N'2025-03-03T18:30:28.7016147' AS DateTime2), 4, 5)
INSERT [dbo].[Cobertura] ([id], [NombreCobertura], [Descripcion], [FecRegistro], [ramoId], [Deducible]) VALUES (4, N'HUELGAS Y ALBOROTOS POPULARES', N'Los daños materiales que sufra el automóvil asegurado, causado directamente por huelguistas', CAST(N'2025-03-03T18:30:45.9954086' AS DateTime2), 4, 2.5)
INSERT [dbo].[Cobertura] ([id], [NombreCobertura], [Descripcion], [FecRegistro], [ramoId], [Deducible]) VALUES (1002, N'Muerte', N'Cualquier tipo de muerte', CAST(N'2025-03-04T15:48:13.3522316' AS DateTime2), 1011, 5)
SET IDENTITY_INSERT [dbo].[Cobertura] OFF
GO
SET IDENTITY_INSERT [dbo].[Corredor] ON 

INSERT [dbo].[Corredor] ([id], [Nombre], [Apellido], [Dni], [celular], [Email], [CodCorredor], [FecRegistro]) VALUES (1007, N'svfdb', N'frfg', N'2424242525869', N'25252525', N'dfrgtyhytu25y', N'700003', CAST(N'2025-03-07T22:32:31.8304897' AS DateTime2))
INSERT [dbo].[Corredor] ([id], [Nombre], [Apellido], [Dni], [celular], [Email], [CodCorredor], [FecRegistro]) VALUES (1008, N'svfdb', N'frfg', N'2424242525869', N'25252525', N'dfrgtyhytu25y', N'700003', CAST(N'2025-03-07T22:32:31.8304887' AS DateTime2))
INSERT [dbo].[Corredor] ([id], [Nombre], [Apellido], [Dni], [celular], [Email], [CodCorredor], [FecRegistro]) VALUES (1009, N'Manuel', N'Soto', N'5555555555555', N'63636536', N'thththyjyjjjj', N'700004', CAST(N'2025-03-07T22:33:18.7004976' AS DateTime2))
INSERT [dbo].[Corredor] ([id], [Nombre], [Apellido], [Dni], [celular], [Email], [CodCorredor], [FecRegistro]) VALUES (1010, N'Sofia', N'Torrez', N'0501200109815', N'87852254', N'sofia.torrez@gmail.com', N'700005', CAST(N'2025-03-08T08:01:32.9672587' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Corredor] OFF
GO
SET IDENTITY_INSERT [dbo].[Ramo] ON 

INSERT [dbo].[Ramo] ([id], [NombreRamos], [Descripcion], [FecRegistro]) VALUES (4, N'Seguros de Autos', N'Cubre las perdidas de daños sufridos por el uso de un automóvil, motocicleta, cabezal, u otro vehículo.', CAST(N'2025-03-03T17:10:26.0545708' AS DateTime2))
INSERT [dbo].[Ramo] ([id], [NombreRamos], [Descripcion], [FecRegistro]) VALUES (8, N'Seguro Vivienda', N'Seguro proporciona seguridad a tu casa', CAST(N'2025-03-03T08:36:53.4055698' AS DateTime2))
INSERT [dbo].[Ramo] ([id], [NombreRamos], [Descripcion], [FecRegistro]) VALUES (9, N'Seguro Vida', N'Procurar el bienestar de la persona', CAST(N'2025-03-03T11:12:07.2859009' AS DateTime2))
INSERT [dbo].[Ramo] ([id], [NombreRamos], [Descripcion], [FecRegistro]) VALUES (11, N'Seguro provicial', N'Seguro proporciona seguridad a tu casa', CAST(N'2025-03-04T09:13:44.1442180' AS DateTime2))
INSERT [dbo].[Ramo] ([id], [NombreRamos], [Descripcion], [FecRegistro]) VALUES (12, N'Seguro Transporte Pesado', N'Para equipo pesado', CAST(N'2025-03-04T13:34:36.9262456' AS DateTime2))
INSERT [dbo].[Ramo] ([id], [NombreRamos], [Descripcion], [FecRegistro]) VALUES (1011, N'Seguro de Medico', N'Procurar el bienestar de la personas en la comunidad', CAST(N'2025-03-04T15:47:37.1877748' AS DateTime2))
INSERT [dbo].[Ramo] ([id], [NombreRamos], [Descripcion], [FecRegistro]) VALUES (1015, N'Seguros prueba', N'fdfdvgfdvbf', CAST(N'2025-03-06T22:53:56.1349472' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Ramo] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id], [usuario], [password], [Rol], [FecRegistro], [Nombre]) VALUES (1, N'ADDYSE', N'fcea920f7412b5da7be0cf42b8c93759', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Addys Espinoza')
INSERT [dbo].[Usuario] ([id], [usuario], [password], [Rol], [FecRegistro], [Nombre]) VALUES (2, N'SHIRLEY', N'fcea920f7412b5da7be0cf42b8c93759', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Shirley Espinoza')
INSERT [dbo].[Usuario] ([id], [usuario], [password], [Rol], [FecRegistro], [Nombre]) VALUES (3, N'RICARDOL', N'fcea920f7412b5da7be0cf42b8c93759', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Ricardo Lago')
INSERT [dbo].[Usuario] ([id], [usuario], [password], [Rol], [FecRegistro], [Nombre]) VALUES (4, N'CARLOSA', N'9068ee8ca86ae9b67401b9f12fca6d95', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Carlos Albeto')
INSERT [dbo].[Usuario] ([id], [usuario], [password], [Rol], [FecRegistro], [Nombre]) VALUES (7, N'MANUELS', N'9cf6f9edb58e7f3dadc1f65fdbe58b7a', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Manuel Soto')
INSERT [dbo].[Usuario] ([id], [usuario], [password], [Rol], [FecRegistro], [Nombre]) VALUES (8, N'DAVIDM', N'fcea920f7412b5da7be0cf42b8c93759', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'David Manchado')
INSERT [dbo].[Usuario] ([id], [usuario], [password], [Rol], [FecRegistro], [Nombre]) VALUES (9, N'VALERIAC', N'fcea920f7412b5da7be0cf42b8c93759', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Valeria Contreras')
INSERT [dbo].[Usuario] ([id], [usuario], [password], [Rol], [FecRegistro], [Nombre]) VALUES (10, N'CRISTIANR', N'25f9e794323b453885f5181f1b624d0b', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Cristian Robles')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
/****** Object:  Index [IX_Cobertura_ramoId]    Script Date: 8/3/2025 08:45:15 ******/
CREATE NONCLUSTERED INDEX [IX_Cobertura_ramoId] ON [dbo].[Cobertura]
(
	[ramoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Poliza_clienteId]    Script Date: 8/3/2025 08:45:15 ******/
CREATE NONCLUSTERED INDEX [IX_Poliza_clienteId] ON [dbo].[Poliza]
(
	[clienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Poliza_corredorId]    Script Date: 8/3/2025 08:45:15 ******/
CREATE NONCLUSTERED INDEX [IX_Poliza_corredorId] ON [dbo].[Poliza]
(
	[corredorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Poliza_ramoId]    Script Date: 8/3/2025 08:45:15 ******/
CREATE NONCLUSTERED INDEX [IX_Poliza_ramoId] ON [dbo].[Poliza]
(
	[ramoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cobertura] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Deducible]
GO
ALTER TABLE [dbo].[Poliza] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [FecRegistro]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT (N'') FOR [Nombre]
GO
ALTER TABLE [dbo].[Cobertura]  WITH CHECK ADD  CONSTRAINT [FK_Cobertura_Ramo_ramoId] FOREIGN KEY([ramoId])
REFERENCES [dbo].[Ramo] ([id])
GO
ALTER TABLE [dbo].[Cobertura] CHECK CONSTRAINT [FK_Cobertura_Ramo_ramoId]
GO
ALTER TABLE [dbo].[Poliza]  WITH CHECK ADD  CONSTRAINT [FK_Poliza_Cliente_clienteId] FOREIGN KEY([clienteId])
REFERENCES [dbo].[Cliente] ([id])
GO
ALTER TABLE [dbo].[Poliza] CHECK CONSTRAINT [FK_Poliza_Cliente_clienteId]
GO
ALTER TABLE [dbo].[Poliza]  WITH CHECK ADD  CONSTRAINT [FK_Poliza_Corredor_corredorId] FOREIGN KEY([corredorId])
REFERENCES [dbo].[Corredor] ([id])
GO
ALTER TABLE [dbo].[Poliza] CHECK CONSTRAINT [FK_Poliza_Corredor_corredorId]
GO
ALTER TABLE [dbo].[Poliza]  WITH CHECK ADD  CONSTRAINT [FK_Poliza_Ramo_ramoId] FOREIGN KEY([ramoId])
REFERENCES [dbo].[Ramo] ([id])
GO
ALTER TABLE [dbo].[Poliza] CHECK CONSTRAINT [FK_Poliza_Ramo_ramoId]
GO
USE [master]
GO
ALTER DATABASE [BDseguros] SET  READ_WRITE 
GO
