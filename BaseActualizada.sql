USE [master]
GO
/****** Object:  Database [SAPE]    Script Date: 26/10/2013 12:44:17 ******/
CREATE DATABASE [SAPE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SAPE', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SAPE.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SAPE_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SAPE_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SAPE] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SAPE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SAPE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SAPE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SAPE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SAPE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SAPE] SET ARITHABORT OFF 
GO
ALTER DATABASE [SAPE] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SAPE] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SAPE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SAPE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SAPE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SAPE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SAPE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SAPE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SAPE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SAPE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SAPE] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SAPE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SAPE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SAPE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SAPE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SAPE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SAPE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SAPE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SAPE] SET RECOVERY FULL 
GO
ALTER DATABASE [SAPE] SET  MULTI_USER 
GO
ALTER DATABASE [SAPE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SAPE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SAPE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SAPE] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SAPE', N'ON'
GO
USE [SAPE]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ciudad](
	[idCiudad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](15) NOT NULL,
	[FK_Provincia] [int] NOT NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[idCiudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contacto]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contacto](
	[idContacto] [int] IDENTITY(1,1) NOT NULL,
	[Valor] [varchar](20) NOT NULL,
	[FK_TipoContacto] [int] NOT NULL,
	[FK_Persona] [int] NOT NULL,
 CONSTRAINT [PK_Contacto] PRIMARY KEY CLUSTERED 
(
	[idContacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Curso](
	[idCurso] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[idCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CursoXEstudiante]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CursoXEstudiante](
	[FK_Estudiante] [int] NOT NULL,
	[FK_Curso] [int] NOT NULL,
	[Cursado] [varchar](2) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empresa](
	[idEmpresa] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[FK_Persona] [int] NOT NULL,
	[FK_Direccion] [int] NOT NULL,
	[Interesada] [varchar](2) NULL,
	[Cant_Practicantes] [int] NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[idEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EstadoProyecto]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EstadoProyecto](
	[idEstado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
 CONSTRAINT [PK_EstadoProyecto] PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante](
	[idEstudiante] [int] IDENTITY(1,1) NOT NULL,
	[FK_Persona] [int] NOT NULL,
	[FK_Proyecto] [int] NULL,
	[Carnet] [int] NOT NULL,
 CONSTRAINT [PK_Estudiante] PRIMARY KEY CLUSTERED 
(
	[idEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Evaluacion]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluacion](
	[idEvaluacion] [int] IDENTITY(1,1) NOT NULL,
	[Nota] [decimal](3, 0) NOT NULL,
	[FK_TipoEvaluacion] [int] NOT NULL,
	[FK_Estudiante] [int] NOT NULL,
	[Evaluador] [int] NOT NULL,
	[FK_Empresa] [int] NULL,
	[FK_Profesor] [int] NULL,
 CONSTRAINT [PK_Evaluacion] PRIMARY KEY CLUSTERED 
(
	[idEvaluacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pais]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pais](
	[idPais] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[idPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persona](
	[idPersona] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
	[Apellido1] [varchar](20) NOT NULL,
	[Apellido2] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PreferenciaDireccion]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreferenciaDireccion](
	[FK_Profesor] [int] NOT NULL,
	[FK_Direccion] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PreferenciaProfesor]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PreferenciaProfesor](
	[idPreferencia] [int] IDENTITY(1,1) NOT NULL,
	[FK_Estudiante] [int] NOT NULL,
	[FK_Profesor] [int] NOT NULL,
	[Valor] [int] NOT NULL,
	[Comentario] [varchar](500) NULL,
 CONSTRAINT [PK_PreferenciaProfesor] PRIMARY KEY CLUSTERED 
(
	[idPreferencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[idProfesor] [int] IDENTITY(1,1) NOT NULL,
	[FK_Persona] [int] NOT NULL,
	[Asesora] [int] NOT NULL,
	[CargaMinima] [int] NULL,
	[CargaMaxima] [int] NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[idProfesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Provincia](
	[idProvincia] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
	[FK_Pais] [int] NOT NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[idProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proyecto]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proyecto](
	[idProyecto] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](400) NULL,
	[Nombre] [varchar](100) NOT NULL,
	[FK_Empresa] [int] NOT NULL,
	[FK_Estado] [int] NULL,
	[Observacion] [varchar](200) NULL,
 CONSTRAINT [PK_Proyecto] PRIMARY KEY CLUSTERED 
(
	[idProyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoContacto]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoContacto](
	[idTipoContacto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TipoContacto] PRIMARY KEY CLUSTERED 
(
	[idTipoContacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoEvaluacion]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoEvaluacion](
	[idTipoEvaluacion] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TipoEvaluacion] PRIMARY KEY CLUSTERED 
(
	[idTipoEvaluacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoUsuario]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoUsuario](
	[idTipoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Permisos] [int] NOT NULL,
 CONSTRAINT [PK_TipoUsuario] PRIMARY KEY CLUSTERED 
(
	[idTipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 26/10/2013 12:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
	[Contrasena] [varchar](50) NOT NULL,
	[FK_idPersona] [int] NOT NULL,
	[FK_TipoUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad_Provincia] FOREIGN KEY([FK_Provincia])
REFERENCES [dbo].[Provincia] ([idProvincia])
GO
ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [FK_Ciudad_Provincia]
GO
ALTER TABLE [dbo].[Contacto]  WITH CHECK ADD  CONSTRAINT [FK_Contacto_Persona1] FOREIGN KEY([FK_Persona])
REFERENCES [dbo].[Persona] ([idPersona])
GO
ALTER TABLE [dbo].[Contacto] CHECK CONSTRAINT [FK_Contacto_Persona1]
GO
ALTER TABLE [dbo].[Contacto]  WITH CHECK ADD  CONSTRAINT [FK_Contacto_TipoContacto] FOREIGN KEY([FK_TipoContacto])
REFERENCES [dbo].[TipoContacto] ([idTipoContacto])
GO
ALTER TABLE [dbo].[Contacto] CHECK CONSTRAINT [FK_Contacto_TipoContacto]
GO
ALTER TABLE [dbo].[CursoXEstudiante]  WITH CHECK ADD  CONSTRAINT [FK_CursoXEstudiante_Curso] FOREIGN KEY([FK_Curso])
REFERENCES [dbo].[Curso] ([idCurso])
GO
ALTER TABLE [dbo].[CursoXEstudiante] CHECK CONSTRAINT [FK_CursoXEstudiante_Curso]
GO
ALTER TABLE [dbo].[CursoXEstudiante]  WITH CHECK ADD  CONSTRAINT [FK_CursoXEstudiante_Estudiante] FOREIGN KEY([FK_Estudiante])
REFERENCES [dbo].[Estudiante] ([idEstudiante])
GO
ALTER TABLE [dbo].[CursoXEstudiante] CHECK CONSTRAINT [FK_CursoXEstudiante_Estudiante]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Ciudad] FOREIGN KEY([FK_Direccion])
REFERENCES [dbo].[Ciudad] ([idCiudad])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_Ciudad]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Persona] FOREIGN KEY([FK_Persona])
REFERENCES [dbo].[Persona] ([idPersona])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_Persona]
GO
ALTER TABLE [dbo].[Estudiante]  WITH CHECK ADD  CONSTRAINT [FK_Estudiante_Persona] FOREIGN KEY([FK_Persona])
REFERENCES [dbo].[Persona] ([idPersona])
GO
ALTER TABLE [dbo].[Estudiante] CHECK CONSTRAINT [FK_Estudiante_Persona]
GO
ALTER TABLE [dbo].[Estudiante]  WITH CHECK ADD  CONSTRAINT [FK_Estudiante_Proyecto] FOREIGN KEY([FK_Proyecto])
REFERENCES [dbo].[Proyecto] ([idProyecto])
GO
ALTER TABLE [dbo].[Estudiante] CHECK CONSTRAINT [FK_Estudiante_Proyecto]
GO
ALTER TABLE [dbo].[Evaluacion]  WITH CHECK ADD  CONSTRAINT [FK_Evaluacion_Empresa] FOREIGN KEY([FK_Empresa])
REFERENCES [dbo].[Empresa] ([idEmpresa])
GO
ALTER TABLE [dbo].[Evaluacion] CHECK CONSTRAINT [FK_Evaluacion_Empresa]
GO
ALTER TABLE [dbo].[Evaluacion]  WITH CHECK ADD  CONSTRAINT [FK_Evaluacion_Estudiante] FOREIGN KEY([FK_Estudiante])
REFERENCES [dbo].[Estudiante] ([idEstudiante])
GO
ALTER TABLE [dbo].[Evaluacion] CHECK CONSTRAINT [FK_Evaluacion_Estudiante]
GO
ALTER TABLE [dbo].[Evaluacion]  WITH CHECK ADD  CONSTRAINT [FK_Evaluacion_Profesor] FOREIGN KEY([FK_Profesor])
REFERENCES [dbo].[Profesor] ([idProfesor])
GO
ALTER TABLE [dbo].[Evaluacion] CHECK CONSTRAINT [FK_Evaluacion_Profesor]
GO
ALTER TABLE [dbo].[Evaluacion]  WITH CHECK ADD  CONSTRAINT [FK_Evaluacion_TipoEvaluacion] FOREIGN KEY([FK_TipoEvaluacion])
REFERENCES [dbo].[TipoEvaluacion] ([idTipoEvaluacion])
GO
ALTER TABLE [dbo].[Evaluacion] CHECK CONSTRAINT [FK_Evaluacion_TipoEvaluacion]
GO
ALTER TABLE [dbo].[PreferenciaDireccion]  WITH CHECK ADD  CONSTRAINT [FK_PreferenciaDireccion_Profesor] FOREIGN KEY([FK_Profesor])
REFERENCES [dbo].[Profesor] ([idProfesor])
GO
ALTER TABLE [dbo].[PreferenciaDireccion] CHECK CONSTRAINT [FK_PreferenciaDireccion_Profesor]
GO
ALTER TABLE [dbo].[PreferenciaDireccion]  WITH CHECK ADD  CONSTRAINT [FK_PreferenciasDireccion_Ciudad] FOREIGN KEY([FK_Direccion])
REFERENCES [dbo].[Ciudad] ([idCiudad])
GO
ALTER TABLE [dbo].[PreferenciaDireccion] CHECK CONSTRAINT [FK_PreferenciasDireccion_Ciudad]
GO
ALTER TABLE [dbo].[PreferenciaProfesor]  WITH CHECK ADD  CONSTRAINT [FK_PreferenciaProfesor_Estudiante] FOREIGN KEY([FK_Estudiante])
REFERENCES [dbo].[Estudiante] ([idEstudiante])
GO
ALTER TABLE [dbo].[PreferenciaProfesor] CHECK CONSTRAINT [FK_PreferenciaProfesor_Estudiante]
GO
ALTER TABLE [dbo].[PreferenciaProfesor]  WITH CHECK ADD  CONSTRAINT [FK_PreferenciaProfesor_Profesor] FOREIGN KEY([FK_Profesor])
REFERENCES [dbo].[Profesor] ([idProfesor])
GO
ALTER TABLE [dbo].[PreferenciaProfesor] CHECK CONSTRAINT [FK_PreferenciaProfesor_Profesor]
GO
ALTER TABLE [dbo].[Profesor]  WITH CHECK ADD  CONSTRAINT [FK_Profesor_Persona] FOREIGN KEY([FK_Persona])
REFERENCES [dbo].[Persona] ([idPersona])
GO
ALTER TABLE [dbo].[Profesor] CHECK CONSTRAINT [FK_Profesor_Persona]
GO
ALTER TABLE [dbo].[Provincia]  WITH CHECK ADD  CONSTRAINT [FK_Provincia_Pais] FOREIGN KEY([FK_Pais])
REFERENCES [dbo].[Pais] ([idPais])
GO
ALTER TABLE [dbo].[Provincia] CHECK CONSTRAINT [FK_Provincia_Pais]
GO
ALTER TABLE [dbo].[Proyecto]  WITH CHECK ADD  CONSTRAINT [FK_Proyecto_Empresa] FOREIGN KEY([FK_Empresa])
REFERENCES [dbo].[Empresa] ([idEmpresa])
GO
ALTER TABLE [dbo].[Proyecto] CHECK CONSTRAINT [FK_Proyecto_Empresa]
GO
ALTER TABLE [dbo].[Proyecto]  WITH CHECK ADD  CONSTRAINT [FK_Proyecto_EstadoProyecto] FOREIGN KEY([FK_Estado])
REFERENCES [dbo].[EstadoProyecto] ([idEstado])
GO
ALTER TABLE [dbo].[Proyecto] CHECK CONSTRAINT [FK_Proyecto_EstadoProyecto]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Persona] FOREIGN KEY([FK_idPersona])
REFERENCES [dbo].[Persona] ([idPersona])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Persona]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TipoUsuario] FOREIGN KEY([FK_TipoUsuario])
REFERENCES [dbo].[TipoUsuario] ([idTipoUsuario])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_TipoUsuario]
GO
USE [master]
GO
ALTER DATABASE [SAPE] SET  READ_WRITE 
GO
