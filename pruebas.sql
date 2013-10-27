insert into Pais(Nombre) values('Costa Rica');

insert into Provincia(Nombre, FK_Pais) values ('Heredia',1);

insert into Ciudad(Nombre, FK_Provincia) values('San Rafael', 1);
insert into Ciudad(Nombre, FK_Provincia) values('San Isidro', 1);
insert into Ciudad(Nombre, FK_Provincia) values('San Joaquin', 1);
insert into Ciudad(Nombre, FK_Provincia) values('San Francisco', 1);


select * from Ciudad

insert into Persona(Nombre, Apellido1, Apellido2) values('Rodrigo', 'Ugalde', 'Valerio');
insert into Contacto(Valor, FK_TipoContacto, FK_Persona) values('22222222', 1, 1);
insert into Estudiante(FK_Persona, Carnet) values (1, 200949576);

insert into Persona(Nombre, Apellido1, Apellido2) values('Ignacio', 'Esquivel', 'Valerio');
insert into Contacto(Valor, FK_TipoContacto, FK_Persona) values('88332211', 1, 2);
insert into Estudiante(FK_Persona, Carnet) values (2, 201344552);

insert into Persona(Nombre, Apellido1, Apellido2) values('Kirtein', 'Gatjens', 'Soto');
insert into Contacto(Valor, FK_TipoContacto, FK_Persona) values('66666666', 1, 3);
insert into Profesor(FK_Persona, Asesora) values (3, 0);

insert into Persona(Nombre, Apellido1, Apellido2) values('Maria', 'Estrada', 'Sanchez');
insert into Contacto(Valor, FK_TipoContacto, FK_Persona) values('12345678', 1, 4);
insert into Profesor(FK_Persona, Asesora) values (4, 0);

insert into TipoUsuario(Nombre, Permisos) values ('Administrador', 1)

insert into Usuario(Nombre, Contrasena, FK_idPersona, FK_TipoUsuario) values ('rujova','rujova', 1, 1)
select * from Persona


insert into Persona(Nombre, Apellido1, Apellido2) values('Manuel', 'Soto', 'Morales');
insert into Contacto(Valor, FK_TipoContacto, FK_Persona) values('93824301', 1, 5);

insert into Empresa(Nombre, FK_Persona, FK_Direccion, Cant_Practicantes, Interesada) values ('Avantica', 5, 1, 0, 0);

select * from Empresa


insert into EstadoProyecto(Nombre) values ('Terminado');

insert into Proyecto(Descripcion, Nombre, FK_Empresa, FK_Estado) values ('Prueba', 'PBR', 1, 1)
insert into Proyecto(Descripcion, Nombre, FK_Empresa, FK_Estado) values ('Prueba2', 'PBR2', 1, 1)


Select * from Curso

insert into CursoXEstudiante(FK_Estudiante, FK_Curso, Cursado) values (2, 5, 'No')