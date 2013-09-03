USE [SAPE] 
INSERT INTO [dbo].[Pais] ([Nombre])VALUES('Costa Rica')
INSERT INTO [dbo].[Provincia] ([Nombre], [FK_Pais])VALUES('San Jose', 1)
INSERT INTO [dbo].[Provincia] ([Nombre], [FK_Pais])VALUES('Heredia', 1) 
INSERT INTO [dbo].[Provincia] ([Nombre], [FK_Pais])VALUES('Guanacaste', 1) 
INSERT INTO [dbo].[Provincia] ([Nombre], [FK_Pais])VALUES('Alajuela', 1)
INSERT INTO [dbo].[Provincia] ([Nombre], [FK_Pais])VALUES('Limon', 1) 
INSERT INTO [dbo].[Provincia] ([Nombre], [FK_Pais])VALUES('Cartago', 1) 
INSERT INTO [dbo].[Provincia] ([Nombre], [FK_Pais])VALUES('Puntarenas', 1) 
INSERT INTO [dbo].[Ciudad] ([Nombre], [FK_Provincia])VALUES('Cartago', 6) 


INSERT INTO [dbo].[Curso] ([Nombre])VALUES('Inteligencia Artificial')
INSERT INTO [dbo].[Curso] ([Nombre])VALUES('Investigacion de Operaciones')
INSERT INTO [dbo].[Curso] ([Nombre])VALUES('Principios de Sistemas Operativos')
INSERT INTO [dbo].[Curso] ([Nombre])VALUES('Diseño de Software')
INSERT INTO [dbo].[Curso] ([Nombre])VALUES('Sistemas de Informacion Administravios')
INSERT INTO [dbo].[Curso] ([Nombre])VALUES('Redes Locales')
INSERT INTO [dbo].[Curso] ([Nombre])VALUES('Administracion de la Funcion de Informacion')
INSERT INTO [dbo].[Curso] ([Nombre])VALUES('Proyecto')
INSERT INTO [dbo].[Curso] ([Nombre])VALUES('Computacion y Sociedad')
INSERT INTO [dbo].[Curso] ([Nombre])VALUES('Electiva 1')
INSERT INTO [dbo].[Curso] ([Nombre])VALUES('Estadistica')


INSERT INTO [dbo].[TipoContacto] ([Nombre]) VALUES ('Telefono')
INSERT INTO [dbo].[TipoContacto] ([Nombre]) VALUES ('E-mail')

GO