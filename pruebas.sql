insert into Pais(Nombre) values('Costa Rica');

insert into Provincia(Nombre, FK_Pais) values ('Heredia',1);

insert into Ciudad(Nombre, FK_Provincia) values('San Rafael', 1);


select * from Ciudad

insert into Persona(Nombre, Apellido1, Apellido2) values('Rodrigo', 'Ugalde', 'Valerio');
insert into Contacto(Valor, FK_TipoContacto, FK_Persona) values('22222222', 1, 1);
insert into Estudiante(FK_Persona, Carnet) values (1, 200949576);

insert into Persona(Nombre, Apellido1, Apellido2) values('Ignacio', 'Esquivel', 'Valerio');
insert into Contacto(Valor, FK_TipoContacto, FK_Persona) values('88332211', 1, 2);
insert into Estudiante(FK_Persona, Carnet) values (2, 201344552);

select * from Persona