USE [SAPE] 
INSERT INTO [dbo].[Pais] ([Nombre])VALUES('Costa Rica')
INSERT INTO [dbo].[Provincia] ([Nombre], [FK_Pais])VALUES('San Jose', 1)
INSERT INTO [dbo].[Provincia] ([Nombre], [FK_Pais])VALUES('Heredia', 1) 
INSERT INTO [dbo].[Provincia] ([Nombre], [FK_Pais])VALUES('Guanacaste', 1) 
INSERT INTO [dbo].[Provincia] ([Nombre], [FK_Pais])VALUES('Alajuela', 1)
INSERT INTO [dbo].[Provincia] ([Nombre], [FK_Pais])VALUES('Limon', 1) 
INSERT INTO [dbo].[Provincia] ([Nombre], [FK_Pais])VALUES('Cartago', 1) 
INSERT INTO [dbo].[Provincia] ([Nombre], [FK_Pais])VALUES('Puntarenas', 1) 

INSERT INTO [dbo].[TipoContacto] ([Nombre]) VALUES ('Telefono')
INSERT INTO [dbo].[TipoContacto] ([Nombre]) VALUES ('E-mail')

GO