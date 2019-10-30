IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE TABLE [Calificacion] (
        [Id] int NOT NULL IDENTITY,
        [IdAlumno] int NOT NULL,
        [IdUnidad] int NOT NULL,
        [IdCurso] int NOT NULL,
        [Fecha] nvarchar(max) NULL,
        [Nota] int NOT NULL,
        CONSTRAINT [PK_Calificacion] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE TABLE [RespuestaAlumno] (
        [Id] int NOT NULL IDENTITY,
        [UsuarioId] int NOT NULL,
        [DocenteId] int NOT NULL,
        [PreguntaId] int NOT NULL,
        [CursoId] int NOT NULL,
        [UnidadId] int NOT NULL,
        [RespuestaDesarrollo] nvarchar(max) NULL,
        [PuntajeObtenido] int NULL,
        CONSTRAINT [PK_RespuestaAlumno] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE TABLE [Usuario] (
        [Id] int NOT NULL IDENTITY,
        [Documento] nvarchar(450) NOT NULL,
        [Nombre] nvarchar(max) NOT NULL,
        [Apellido] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [TipoUsuario] int NOT NULL,
        [Eliminado] bit NOT NULL,
        CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id]),
        CONSTRAINT [Documento] UNIQUE ([Documento])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE TABLE [Curso] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NOT NULL,
        [Descripcion] nvarchar(max) NOT NULL,
        [FechaFinalizacion] datetime2 NOT NULL,
        [Eliminado] bit NOT NULL,
        [DocenteId] int NOT NULL,
        [AlumnosId] int NULL,
        CONSTRAINT [PK_Curso] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Curso_Usuario_AlumnosId] FOREIGN KEY ([AlumnosId]) REFERENCES [Usuario] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Curso_Usuario_DocenteId] FOREIGN KEY ([DocenteId]) REFERENCES [Usuario] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE TABLE [CursoUsuario] (
        [Id] int NOT NULL IDENTITY,
        [UsuarioId] int NOT NULL,
        [CursoId] int NOT NULL,
        CONSTRAINT [PK_CursoUsuario] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CursoUsuario_Curso_CursoId] FOREIGN KEY ([CursoId]) REFERENCES [Curso] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_CursoUsuario_Usuario_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE TABLE [Unidad] (
        [Id] int NOT NULL IDENTITY,
        [CursoId] int NOT NULL,
        [Nombre] nvarchar(max) NOT NULL,
        [Descripcion] nvarchar(max) NOT NULL,
        [Eliminado] bit NOT NULL,
        CONSTRAINT [PK_Unidad] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Unidad_Curso_CursoId] FOREIGN KEY ([CursoId]) REFERENCES [Curso] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE TABLE [Diapositiva] (
        [Id] int NOT NULL IDENTITY,
        [Texto] nvarchar(max) NOT NULL,
        [UrlVideo] nvarchar(max) NULL,
        [Orden] int NOT NULL,
        [Eliminado] bit NOT NULL,
        [UnidadId] int NOT NULL,
        CONSTRAINT [PK_Diapositiva] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Diapositiva_Unidad_UnidadId] FOREIGN KEY ([UnidadId]) REFERENCES [Unidad] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE TABLE [Quiz] (
        [Id] int NOT NULL IDENTITY,
        [UnidadId] int NOT NULL,
        [Puntaje] int NOT NULL,
        [Evaluacion] int NOT NULL,
        [Ejercicio] int NOT NULL,
        [Eliminado] bit NOT NULL,
        [Nombre] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Quiz] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Quiz_Unidad_UnidadId] FOREIGN KEY ([UnidadId]) REFERENCES [Unidad] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE TABLE [Pregunta] (
        [Id] int NOT NULL IDENTITY,
        [QuizId] int NOT NULL,
        [Puntaje] int NOT NULL,
        [Eliminado] bit NOT NULL,
        [Orden] int NOT NULL,
        [Enunciado] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Pregunta] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Pregunta_Quiz_QuizId] FOREIGN KEY ([QuizId]) REFERENCES [Quiz] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE TABLE [Respuesta] (
        [Id] int NOT NULL IDENTITY,
        [PreguntaId] int NOT NULL,
        [RespuestaCorrecta] bit NOT NULL,
        [Eliminado] bit NOT NULL,
        [Enunciado] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Respuesta] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Respuesta_Pregunta_PreguntaId] FOREIGN KEY ([PreguntaId]) REFERENCES [Pregunta] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apellido', N'Documento', N'Eliminado', N'Email', N'Nombre', N'Password', N'TipoUsuario') AND [object_id] = OBJECT_ID(N'[Usuario]'))
        SET IDENTITY_INSERT [Usuario] ON;
    INSERT INTO [Usuario] ([Id], [Apellido], [Documento], [Eliminado], [Email], [Nombre], [Password], [TipoUsuario])
    VALUES (1, N'Administrador', N'1', 0, N'admin@patroncenter.com', N'Administrador', N'YWRtaW4=', 2),
    (2, N'Docente', N'2', 0, N'docente@patroncenter.com', N'Docente', N'YWRtaW4=', 1),
    (3, N'Alumno', N'3', 0, N'alumno@patroncenter.com', N'Alumno', N'YWRtaW4=', 0),
    (4, N'Alumno', N'4', 1, N'alumno@patroncenter.com', N'Alumno Eliminado', N'YWRtaW4=', 0),
    (5, N'Docente', N'5', 1, N'docente@patroncenter.com', N'Docecente Eliminado', N'YWRtaW4=', 1);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apellido', N'Documento', N'Eliminado', N'Email', N'Nombre', N'Password', N'TipoUsuario') AND [object_id] = OBJECT_ID(N'[Usuario]'))
        SET IDENTITY_INSERT [Usuario] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AlumnosId', N'Descripcion', N'DocenteId', N'Eliminado', N'FechaFinalizacion', N'Nombre') AND [object_id] = OBJECT_ID(N'[Curso]'))
        SET IDENTITY_INSERT [Curso] ON;
    INSERT INTO [Curso] ([Id], [AlumnosId], [Descripcion], [DocenteId], [Eliminado], [FechaFinalizacion], [Nombre])
    VALUES (1, NULL, N'Aqui se dicta un curso destinado al manejo y el aprendisaje de patrones de diseño.', 2, 0, '2019-12-31T00:00:00.0000000', N'Patrones de Diseño');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AlumnosId', N'Descripcion', N'DocenteId', N'Eliminado', N'FechaFinalizacion', N'Nombre') AND [object_id] = OBJECT_ID(N'[Curso]'))
        SET IDENTITY_INSERT [Curso] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CursoId', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[CursoUsuario]'))
        SET IDENTITY_INSERT [CursoUsuario] ON;
    INSERT INTO [CursoUsuario] ([Id], [CursoId], [UsuarioId])
    VALUES (1, 1, 3);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CursoId', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[CursoUsuario]'))
        SET IDENTITY_INSERT [CursoUsuario] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CursoId', N'Descripcion', N'Eliminado', N'Nombre') AND [object_id] = OBJECT_ID(N'[Unidad]'))
        SET IDENTITY_INSERT [Unidad] ON;
    INSERT INTO [Unidad] ([Id], [CursoId], [Descripcion], [Eliminado], [Nombre])
    VALUES (1, 1, N'Unidadad introductoria para Patrones de diseño.', 0, N'1- Introduccion'),
    (2, 1, N'En esta unidad se describe al Patron Singleton, sus funciones, sus características y para que se usa.', 0, N'2- Patrón Singleton'),
    (3, 1, N'En esta unidad se describe al Patron Facade, sus funciones, sus características y para que se usa.', 0, N'3- Patrón Facade');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CursoId', N'Descripcion', N'Eliminado', N'Nombre') AND [object_id] = OBJECT_ID(N'[Unidad]'))
        SET IDENTITY_INSERT [Unidad] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Eliminado', N'Orden', N'Texto', N'UnidadId', N'UrlVideo') AND [object_id] = OBJECT_ID(N'[Diapositiva]'))
        SET IDENTITY_INSERT [Diapositiva] ON;
    INSERT INTO [Diapositiva] ([Id], [Eliminado], [Orden], [Texto], [UnidadId], [UrlVideo])
    VALUES (1, 0, 1, N'Introducción a Patrones de Diseño', 1, N'bx5WqFEndoo'),
    (16, 0, 1, N'Solución:

                    Crear una clase Facade que provea todos los métodos necesarios para ejecutar operaciones del subsistema.', 3, NULL),
    (15, 0, 1, N'
                    Problema:

                    - Se necesita una interfaz de métodos unificados que provean un punto de acceso a un subsistema.

                    - Se desea bajar el acoplamiento entre clases de un subsistema y las clases externas que la utilizan.

                    - Mejorar la separación de capas entre subsistemas.', 3, NULL),
    (14, 0, 1, N'Patrón Facade', 3, NULL),
    (13, 0, 5, N'Ejemplo:

                    En un parque de diversiones se desea contar los números de las entradas. Para esto se debe realizar un generador que adicionalmente brinda funcionalidades como:
                    - Generar un número nuevo mayor a los anteriores

                    - Dada una hora devolver la cantidad de números generados en la hora parámetro.', 2, NULL),
    (12, 0, 4, N'Consecuencias:

                    - Se garantiza acceso a una única instancia de la clase (objeto).

                    - La instancia es visible en todo el sistema (global).

                    - Se mantiene el polimorfismo en la clase, es decir, no todos lo métodos son estáticos y por lo tanto pueden ser sobrescritos en clases derivadas.', 2, NULL),
    (11, 0, 3, N'Solución:

                    1- El constructor de la clase debe ser privado.

                    2- Se declara un atributo privado y estático del mismo tipo de la clase.

                    3- Se declara un método público y estático que permite acceso a la instancia privada de la clase.', 2, NULL),
    (10, 0, 2, N'Problema:

                    - Debemos tener una única instancia de la clase y esta debe ser accesible desde todo el sistema.

                    - Se debe poder extender dicha clase por medio de herencia.', 2, NULL),
    (17, 0, 1, N'Motivación:

                    - Estructurar un sistema en subsistemas ayuda a reducir la complejidad.

                    - Una meta común de diseño es reducir el número de dependencias entre subsistemas.

                    - Una forma de lograr esto es introducir un objeto fachada, una única y simple fachada de servicios generales del subsistemas.', 3, NULL),
    (9, 0, 1, N'Patrón Singleton', 2, N'gocJeOHtj9w'),
    (8, 0, 8, N'ESTRUCTURA DE PATRONES:

                    1) Nombre
                    2) Intención –> Que resuelve.
                    3) Motivación –> Caso ilustrando el problema.
                    4) Aplicabilidad –> Cuando aplicarlo.
                    5) Estructura –> Diagrama de clases.
                    6) Participantes –> Que objetos interactúan.
                    7) Colaboraciones –> Secuencia de mensajes.
                    8) Consecuencias –> Ventajas y desventajas.
                    9) Técnica de implementación.
                    10) Usos conocidos –> En que sistemas se usa.
                    11) Patrones relacionados.', 1, NULL),
    (7, 0, 7, N'CLASIFICACION DE PATRONES:

                    1) De Creación:
                    Participan en el momento de crear objetos, en general abstrayendo la forma en que se crean, y haciendo abstracta la referencia a que clase es que que se instancia. Ej: Singleton, Factory.

                    2) Estructurales:
                    Tienen que ver con la forma en que las clases y los objetos son agrupados para formar grandes estructuras.Ej: Facade, Composite.

                    3) De Comportamiento:
                    Se utilizan para modelar diferentes formas de interactuar entre los objetos para mejorar la performance del sistema.Ej: Observer, Strategy.', 1, NULL),
    (6, 0, 6, N'TIPOS DE PATRONES:

                    1) Arquitectónicos:
                    Básicos, representan esquemas estructurales para la construcción de los sistemas (en muchos casos apoyan el cumplimiento de requerimientos no funcionales).

                    2) Diseño:
                    Apoyan en la definición de estructuras de diseño y sus relaciones (implementación).

                    3) Dialectos:
                    Patrones específicos de un lenguaje.

                    4) Interacción:
                    Patrones para diseñar interfaces web de usuario.', 1, NULL),
    (5, 0, 5, N'OBJETIVOS:

                    Que persiguen?
                    - Crear una biblioteca de módulos.
                    - Elementos reutilizables.
                    - No reinventar la rueda.
                    - Tener soluciones a problemas ya conocidos.
                    - Hablar un lenguaje común entre diseñadores y arquitectos.
                    - Estandarizar diseños.
                    - Facilitar el aprendizaje de técnicas a los nuevos diseñadores.

                    Que no buscan?
                    - Imponer una solución como la mejor.
                    - Eliminar la creatividad o el uso de otras opciones.

                    No es obligación utilizarlos pero simplifican el trabajo de diseño.', 1, NULL),
    (4, 0, 4, N'DEFINICION DE PATRONES:

                    Los Patrones Definen soluciones a problemas comunes del desarrollo de software.
                    Estos deben cumplir con dos cosas:
                    1) Debe comprobarse como efectivo en la resolución de un problema.
                    2) Debe ser reutilizable.

                    Existen diferencias entre patrones de diseño y arquitectónicos las cuales son:
                    1) Los patrones arquitectónicos son mas abstractos.
                    2) Los patrones arquitectónicos apoyan en el cumplimiento de atributos de calidad (rendimiento, disponibilidad, etc).', 1, NULL),
    (3, 0, 3, N'HISTORIA:

                    Surgen inspirados en los patrones arquitectónicos, que aparecen a fines de los años 70, con el fin de organizar y sistematizar las soluciones que diferentes arquitectos e ingenieros iban encontrando a problemas constructivos similares.

                    Se formalizan a partir del libro “Design Patterns” de los autores Gamma, Helm, Johnsony Vlisides, llamados “la pandilla de los 4” (Gang Of Four, o simplificado GoF), en 1995.

                    En el libro se detalla la estructura que recomiendan emplear para la descripción de los patrones(estructura un poco más compleja de la que empleamos en este curso), y se formalizan más de 20 patrones de diseño, identificados por GoF en ese momento y todavía altamente vigentes al día de hoy.', 1, NULL),
    (2, 0, 2, N'TEMARIO:

                    - Historia
                    - Definición de patrones
                    - Tipos de patrones
                    - Clasificación de patrones
                    - Objetivos', 1, NULL);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Eliminado', N'Orden', N'Texto', N'UnidadId', N'UrlVideo') AND [object_id] = OBJECT_ID(N'[Diapositiva]'))
        SET IDENTITY_INSERT [Diapositiva] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Ejercicio', N'Eliminado', N'Evaluacion', N'Nombre', N'Puntaje', N'UnidadId') AND [object_id] = OBJECT_ID(N'[Quiz]'))
        SET IDENTITY_INSERT [Quiz] ON;
    INSERT INTO [Quiz] ([Id], [Ejercicio], [Eliminado], [Evaluacion], [Nombre], [Puntaje], [UnidadId])
    VALUES (1, 0, 0, 0, N'Introducción a Patrones de diseño', 10, 1),
    (2, 1, 0, 0, N'Patrón Singleton', 10, 2),
    (4, 0, 0, 1, N'Ejercicio Introducción a Patrones de diseño', 10, 1),
    (3, 1, 0, 0, N'Patrón Singleton', 10, 3);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Ejercicio', N'Eliminado', N'Evaluacion', N'Nombre', N'Puntaje', N'UnidadId') AND [object_id] = OBJECT_ID(N'[Quiz]'))
        SET IDENTITY_INSERT [Quiz] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Eliminado', N'Enunciado', N'Orden', N'Puntaje', N'QuizId') AND [object_id] = OBJECT_ID(N'[Pregunta]'))
        SET IDENTITY_INSERT [Pregunta] ON;
    INSERT INTO [Pregunta] ([Id], [Eliminado], [Enunciado], [Orden], [Puntaje], [QuizId])
    VALUES (1, 0, N'¿Que persiguen los patrones de diseño?', 1, 25, 1),
    (2, 0, N'¿Cual de los siguientes tipos NO es un tipo de patrón de diseño?', 2, 25, 1),
    (3, 0, N'Los patrones de Creación participan en el momento de crear objetos...', 3, 25, 1),
    (4, 0, N'Los patrones de Comportamiento empeoran la performance del sistema...', 4, 25, 1),
    (11, 0, N'¿en que décadas aparecen los primeros patrones de diseño?', 1, 20, 4),
    (12, 0, N'¿Que no persigue un patrón de diseño?', 2, 40, 4),
    (13, 0, N'¿Que debe cumplir un patron de diseño?', 3, 40, 4),
    (5, 0, N'¿Que soluciona el patron Singleton?', 4, 50, 2),
    (6, 0, N'¿Que garantiza el patron Singleton?', 4, 25, 2),
    (7, 0, N'Describa brevemente un ejemplo de utilización del patron Singleton', 4, 25, 2),
    (8, 0, N'¿Que soluciona el patron Facade?', 4, 50, 3),
    (9, 0, N'¿Que motiva utilizar el patron Facade?', 4, 25, 3),
    (10, 0, N'¿Mejora la separación en capas el patron Facade? Explique', 4, 25, 3);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Eliminado', N'Enunciado', N'Orden', N'Puntaje', N'QuizId') AND [object_id] = OBJECT_ID(N'[Pregunta]'))
        SET IDENTITY_INSERT [Pregunta] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Eliminado', N'Enunciado', N'PreguntaId', N'RespuestaCorrecta') AND [object_id] = OBJECT_ID(N'[Respuesta]'))
        SET IDENTITY_INSERT [Respuesta] ON;
    INSERT INTO [Respuesta] ([Id], [Eliminado], [Enunciado], [PreguntaId], [RespuestaCorrecta])
    VALUES (1, 0, N'Estandarizar diseños', 1, 1),
    (19, 0, N'Ser reutilizable y comprobarse como efectivo en la resolución de un problema', 13, 1),
    (18, 0, N'Estandarizar diseños', 12, 0),
    (17, 0, N'Imponer una solución como la mejor', 12, 0),
    (16, 0, N'Eliminar la creatividad, uso de otras opciones', 12, 1),
    (15, 0, N'90', 11, 0),
    (14, 0, N'80', 11, 0),
    (13, 0, N'70', 11, 1),
    (12, 0, N'Verdadero', 4, 0),
    (20, 0, N'No importa si es reutilizable, solo debe ser efectivo en la resolución de un problema', 13, 0),
    (11, 0, N'Falso', 4, 1),
    (9, 0, N'Verdadero', 3, 1),
    (8, 0, N'Interacción', 2, 0),
    (7, 0, N'Dialectos', 2, 0),
    (6, 0, N'Arquitectónico', 2, 0),
    (5, 0, N'Definición', 2, 1),
    (4, 0, N'Reinventar la rueda', 1, 0),
    (3, 0, N'Eliminar la creatividad, uso de otras opciones', 1, 0),
    (2, 0, N'Imponer una solución como la mejor', 1, 0),
    (10, 0, N'Falso', 3, 0),
    (21, 0, N'Debe ser reutilizable, e imponer una solución como la mejor', 13, 0);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Eliminado', N'Enunciado', N'PreguntaId', N'RespuestaCorrecta') AND [object_id] = OBJECT_ID(N'[Respuesta]'))
        SET IDENTITY_INSERT [Respuesta] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE INDEX [IX_Curso_AlumnosId] ON [Curso] ([AlumnosId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE INDEX [IX_Curso_DocenteId] ON [Curso] ([DocenteId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE INDEX [IX_CursoUsuario_CursoId] ON [CursoUsuario] ([CursoId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE INDEX [IX_CursoUsuario_UsuarioId] ON [CursoUsuario] ([UsuarioId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE INDEX [IX_Diapositiva_UnidadId] ON [Diapositiva] ([UnidadId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE INDEX [IX_Pregunta_QuizId] ON [Pregunta] ([QuizId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE INDEX [IX_Quiz_UnidadId] ON [Quiz] ([UnidadId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE INDEX [IX_Respuesta_PreguntaId] ON [Respuesta] ([PreguntaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    CREATE INDEX [IX_Unidad_CursoId] ON [Unidad] ([CursoId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191029000647_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191029000647_Initial', N'2.2.6-servicing-10079');
END;

GO

