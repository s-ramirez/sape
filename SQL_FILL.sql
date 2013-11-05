insert into Pais (Nombre) values('Costa Rica');

insert into Provincia (Nombre, FK_Pais) values ('San Jose',1);
insert into Provincia (Nombre, FK_Pais) values ('Alajuela',1);
insert into Provincia (Nombre, FK_Pais) values ('Cartago',1);
insert into Provincia (Nombre, FK_Pais) values ('Heredia',1);
insert into Provincia (Nombre, FK_Pais) values ('Guanacaste',1);
insert into Provincia (Nombre, FK_Pais) values ('Puntarenas',1);
insert into Provincia (Nombre, FK_Pais) values ('Limon',1);

insert into Ciudad (Nombre, FK_Provincia) values('Escazu',1 );
insert into Ciudad (Nombre, FK_Provincia) values('Santa Ana', 1);
insert into Ciudad (Nombre, FK_Provincia) values('Belen', 4);
insert into Ciudad (Nombre, FK_Provincia) values('Barrial', 4);
insert into Ciudad (Nombre, FK_Provincia) values('Tibas', 1);
insert into Ciudad (Nombre, FK_Provincia) values('Uruca', 1);
insert into Ciudad (Nombre, FK_Provincia) values('Guadalupe', 1);
insert into Ciudad (Nombre, FK_Provincia) values('Moravia', 1);
insert into Ciudad (Nombre, FK_Provincia) values('Paseo Colon', 1);
insert into Ciudad (Nombre, FK_Provincia) values('Sabana', 1);
insert into Ciudad (Nombre, FK_Provincia) values('San Jose Centro', 1);
insert into Ciudad (Nombre, FK_Provincia) values('Curridabat', 1);
insert into Ciudad (Nombre, FK_Provincia) values('San Pedro', 1);
insert into Ciudad (Nombre, FK_Provincia) values('Cartago', 3);

insert into TipoContacto (Nombre) values ('Telefono');
insert into TipoContacto (Nombre) values ('E-mail');

insert into TipoEvaluacion (Nombre) values ('Primer Informe de empresa');
insert into TipoEvaluacion (Nombre) values ('Segundo Informe de empresa');
insert into TipoEvaluacion (Nombre) values ('Tercer Informe de empresa');
insert into TipoEvaluacion (Nombre) values ('Primer Informe de profesor');
insert into TipoEvaluacion (Nombre) values ('Segundo Informe de profesor');
insert into TipoEvaluacion (Nombre) values ('Tercer Informe de profesor');
insert into TipoEvaluacion (Nombre) values ('Nota del paper');
insert into TipoEvaluacion (Nombre) values ('Nota de la presentacion');
insert into TipoEvaluacion (Nombre) values ('Nota de la coordinacion');

insert into Curso (Nombre) values ('Inteligencia Artificial');
insert into Curso (Nombre) values ('Investigacion de Operaciones');
insert into Curso (Nombre) values ('Principios de Sistemas Operativos');
insert into Curso (Nombre) values ('Diseño de Software');
insert into Curso (Nombre) values ('Sistemas de Informacion Administravios');
insert into Curso (Nombre) values ('Redes Locales');
insert into Curso (Nombre) values ('Administracion de la Funcion de Informacion');
insert into Curso (Nombre) values ('Proyecto');
insert into Curso (Nombre) values ('Computacion y Sociedad');
insert into Curso (Nombre) values ('Electiva 3');
insert into Curso (Nombre) values ('Estadistica');

insert into EstadoProyecto (Nombre) values ('Pendiente');
insert into EstadoProyecto (Nombre) values ('Rechazado');
insert into EstadoProyecto (Nombre) values ('Aprobado');

insert into TipoUsuario (Nombre, Permisos) values ('Administrador', 1);

insert into Persona (Nombre, Apellido1, Apellido2) values('Administrador', 'Administrador', 'Administrador');
insert into Usuario (Nombre, Contrasena, FK_idPersona, FK_TipoUsuario) values ('Administrador', 'admin123', 1, 1);
