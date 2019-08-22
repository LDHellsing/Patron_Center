IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    CREATE TABLE [Correccion] (
        [Id] int NOT NULL IDENTITY,
        [IdQuiz] int NOT NULL,
        [IdAlumno] int NOT NULL,
        [Resultado] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Correccion] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    CREATE TABLE [Pregunta] (
        [Id] int NOT NULL IDENTITY,
        [QuizId] int NOT NULL,
        [Puntaje] int NOT NULL,
        [Eliminado] bit NOT NULL,
        [ComentarioDocente] nvarchar(max) NULL,
        [MultipleOpcion] bit NOT NULL,
        [Orden] int NOT NULL,
        [Enunciado] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Pregunta] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Pregunta_Quiz_QuizId] FOREIGN KEY ([QuizId]) REFERENCES [Quiz] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    CREATE TABLE [Respuesta] (
        [Id] int NOT NULL IDENTITY,
        [PreguntaId] int NOT NULL,
        [RespuestaCorrecta] bit NOT NULL,
        [Seleccionada] bit NOT NULL,
        [Eliminado] bit NOT NULL,
        [Enunciado] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Respuesta] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Respuesta_Pregunta_PreguntaId] FOREIGN KEY ([PreguntaId]) REFERENCES [Pregunta] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apellido', N'Documento', N'Eliminado', N'Email', N'Nombre', N'Password', N'TipoUsuario') AND [object_id] = OBJECT_ID(N'[Usuario]'))
        SET IDENTITY_INSERT [Usuario] ON;
    INSERT INTO [Usuario] ([Id], [Apellido], [Documento], [Eliminado], [Email], [Nombre], [Password], [TipoUsuario])
    VALUES (1, N'Administrador', N'1', 0, N'admin@patroncenter.com', N'Administrador', N'YWRtaW4=', 2),
    (2, N'Docente', N'2', 0, N'docente@patroncenter.com', N'Docecente', N'YWRtaW4=', 1),
    (3, N'Alumno', N'3', 0, N'alumno@patroncenter.com', N'Alumno', N'YWRtaW4=', 0),
    (4, N'Alumno', N'4', 1, N'alumno@patroncenter.com', N'Alumno Eliminado', N'YWRtaW4=', 0),
    (5, N'Docente', N'5', 1, N'docente@patroncenter.com', N'Docecente Eliminado', N'YWRtaW4=', 1);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apellido', N'Documento', N'Eliminado', N'Email', N'Nombre', N'Password', N'TipoUsuario') AND [object_id] = OBJECT_ID(N'[Usuario]'))
        SET IDENTITY_INSERT [Usuario] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AlumnosId', N'Descripcion', N'DocenteId', N'Eliminado', N'FechaFinalizacion', N'Nombre') AND [object_id] = OBJECT_ID(N'[Curso]'))
        SET IDENTITY_INSERT [Curso] ON;
    INSERT INTO [Curso] ([Id], [AlumnosId], [Descripcion], [DocenteId], [Eliminado], [FechaFinalizacion], [Nombre])
    VALUES (1, NULL, N'Descripción de curso de prueba', 2, 0, '2019-08-21T22:29:34.9103144-03:00', N'Curso de Prueba');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AlumnosId', N'Descripcion', N'DocenteId', N'Eliminado', N'FechaFinalizacion', N'Nombre') AND [object_id] = OBJECT_ID(N'[Curso]'))
        SET IDENTITY_INSERT [Curso] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CursoId', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[CursoUsuario]'))
        SET IDENTITY_INSERT [CursoUsuario] ON;
    INSERT INTO [CursoUsuario] ([Id], [CursoId], [UsuarioId])
    VALUES (1, 1, 3);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CursoId', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[CursoUsuario]'))
        SET IDENTITY_INSERT [CursoUsuario] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CursoId', N'Descripcion', N'Eliminado', N'Nombre') AND [object_id] = OBJECT_ID(N'[Unidad]'))
        SET IDENTITY_INSERT [Unidad] ON;
    INSERT INTO [Unidad] ([Id], [CursoId], [Descripcion], [Eliminado], [Nombre])
    VALUES (1, 1, N'Descripción de Unidad de prueba 1', 0, N'1- Unidad de prueba 1');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CursoId', N'Descripcion', N'Eliminado', N'Nombre') AND [object_id] = OBJECT_ID(N'[Unidad]'))
        SET IDENTITY_INSERT [Unidad] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CursoId', N'Descripcion', N'Eliminado', N'Nombre') AND [object_id] = OBJECT_ID(N'[Unidad]'))
        SET IDENTITY_INSERT [Unidad] ON;
    INSERT INTO [Unidad] ([Id], [CursoId], [Descripcion], [Eliminado], [Nombre])
    VALUES (2, 1, N'Descripción de Unidad de prueba 2', 0, N'2- Unidad de prueba 2');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CursoId', N'Descripcion', N'Eliminado', N'Nombre') AND [object_id] = OBJECT_ID(N'[Unidad]'))
        SET IDENTITY_INSERT [Unidad] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Eliminado', N'Orden', N'Texto', N'UnidadId', N'UrlVideo') AND [object_id] = OBJECT_ID(N'[Diapositiva]'))
        SET IDENTITY_INSERT [Diapositiva] ON;
    INSERT INTO [Diapositiva] ([Id], [Eliminado], [Orden], [Texto], [UnidadId], [UrlVideo])
    VALUES (1, 0, 1, N'La diapositiva, transparencia, filmina o slide es una fotografía positiva (de colores reales) creada en un soporte transparente por medios fotoquímicos. Comparación entre los formatos fotográficos: Fotografía(propiamente dicha), foto, impresión fotográfica o positivo: Imagen opaca y positiva(de colores reales).Negativo: Imagen transparente y negativa(de colores invertidos). Diapositiva, filmina y película de cine: Imagen transparente y positiva(de colores reales). A las diapositivas se las llama también filminas porque se obtienen de recortar los cuadros de una filmina y colocarlos en sendos marcos cuadrados(en el caso de película de 35 mm, los marcos son de 5 cm de lado).', 1, NULL),
    (2, 0, 2, N'El proceso más antiguo de la fotografía en color fue el Autocromo. Este era un método de síntesis aditiva que producía diapositivas en colores, pero con baja definición y una resolución cromática limitada. Por el contrario, el proceso de síntesis sustractiva Kodachrome brindaba transparencias de colores brillantes. La película constaba de tres emulsiones, cada una de ellas sensible a una zona del espectro cromático. Y después del proceso aparecían los colorantes amarillo, magenta y cían. Introducido en 1935, fue ofrecido en un formato de 16 milímetros para películas cinematográficas, 35 mm para diapositivas y 8 mm para películas caseras. Aunque se utilizó originalmente para reportajes, ganó popularidad gradualmente. A comienzos de los años 1940, algunos aficionados usaban Kodachrome para tomar fotografías familiares, otros utilizaban adaptadores de rollos de película con cámaras de 4x5 pulgadas. En esta época, las películas en color tenían muchos defectos, eran costosas y las impresiones no duraban mucho tiempo.', 1, NULL),
    (3, 0, 3, N'Emulsiones más eficaces como Ektachrome y Fujichrome fueron sustituyendo a las de Kodachrome. Los aficionados las utilizaron hasta los años 1970, en que la impresión de copias en colores comenzó a desplazarla.En los últimos años del siglo XX, las transparencias en color fueron extensamente utilizadas en la fotografía publicitaria, documental, deportiva, de stock y de naturaleza. Los medios digitales han reemplazado gradualmente las transparencias en muchas de estas aplicaciones y su uso es, en la actualidad, infrecuente.', 1, NULL),
    (4, 0, 4, N'Por lo general, las diapositivas son preferidas por profesionales y muchos aficionados al momento de trabajar con la fotografía tradicional. Esto se debe, en parte, a su nitidez y a su reproducción cromática. La duración de las transparencias es mayor a las impresiones en color, de hecho, el proceso Kodachrome es reconocido por sus cualidades archivísticas y por brindar colores que no se atenúan con el tiempo. El proceso K-14 de Kodachrome es extremadamente difícil de llevar a cabo, ya que una mínima desviación de las especificaciones puede afectar la calidad del producto final. Es un método naturalmente imperfecto. Pequeñas cantidades de contaminación en las capas de color producen un efecto específico e irreproducible.', 1, NULL),
    (5, 0, 1, N'Esta unidad tiene solo una diapositiva.', 2, NULL);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Eliminado', N'Orden', N'Texto', N'UnidadId', N'UrlVideo') AND [object_id] = OBJECT_ID(N'[Diapositiva]'))
        SET IDENTITY_INSERT [Diapositiva] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Ejercicio', N'Eliminado', N'Evaluacion', N'Nombre', N'Puntaje', N'UnidadId') AND [object_id] = OBJECT_ID(N'[Quiz]'))
        SET IDENTITY_INSERT [Quiz] ON;
    INSERT INTO [Quiz] ([Id], [Ejercicio], [Eliminado], [Evaluacion], [Nombre], [Puntaje], [UnidadId])
    VALUES (1, 0, 0, 1, N'Quiz de Prueba', 5, 1);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Ejercicio', N'Eliminado', N'Evaluacion', N'Nombre', N'Puntaje', N'UnidadId') AND [object_id] = OBJECT_ID(N'[Quiz]'))
        SET IDENTITY_INSERT [Quiz] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ComentarioDocente', N'Eliminado', N'Enunciado', N'MultipleOpcion', N'Orden', N'Puntaje', N'QuizId') AND [object_id] = OBJECT_ID(N'[Pregunta]'))
        SET IDENTITY_INSERT [Pregunta] ON;
    INSERT INTO [Pregunta] ([Id], [ComentarioDocente], [Eliminado], [Enunciado], [MultipleOpcion], [Orden], [Puntaje], [QuizId])
    VALUES (1, NULL, 0, N'Esta pregunta no es mas que una prueba', 1, 1, 5, 1);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ComentarioDocente', N'Eliminado', N'Enunciado', N'MultipleOpcion', N'Orden', N'Puntaje', N'QuizId') AND [object_id] = OBJECT_ID(N'[Pregunta]'))
        SET IDENTITY_INSERT [Pregunta] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ComentarioDocente', N'Eliminado', N'Enunciado', N'MultipleOpcion', N'Orden', N'Puntaje', N'QuizId') AND [object_id] = OBJECT_ID(N'[Pregunta]'))
        SET IDENTITY_INSERT [Pregunta] ON;
    INSERT INTO [Pregunta] ([Id], [ComentarioDocente], [Eliminado], [Enunciado], [MultipleOpcion], [Orden], [Puntaje], [QuizId])
    VALUES (2, NULL, 0, N'Esta pregunta no es mas que otra una prueba', 1, 2, 10, 1);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ComentarioDocente', N'Eliminado', N'Enunciado', N'MultipleOpcion', N'Orden', N'Puntaje', N'QuizId') AND [object_id] = OBJECT_ID(N'[Pregunta]'))
        SET IDENTITY_INSERT [Pregunta] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Eliminado', N'Enunciado', N'PreguntaId', N'RespuestaCorrecta', N'Seleccionada') AND [object_id] = OBJECT_ID(N'[Respuesta]'))
        SET IDENTITY_INSERT [Respuesta] ON;
    INSERT INTO [Respuesta] ([Id], [Eliminado], [Enunciado], [PreguntaId], [RespuestaCorrecta], [Seleccionada])
    VALUES (1, 0, N'Esta respuesta no es correcta y no esta seleccionada', 1, 0, 0),
    (2, 0, N'Esta respuesta es correcta y esta seleccionada', 1, 1, 1),
    (3, 0, N'Esta respuesta es correcta y no esta seleccionada', 2, 1, 0),
    (4, 0, N'Esta respuesta no es correcta y esta seleccionada', 2, 0, 1);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Eliminado', N'Enunciado', N'PreguntaId', N'RespuestaCorrecta', N'Seleccionada') AND [object_id] = OBJECT_ID(N'[Respuesta]'))
        SET IDENTITY_INSERT [Respuesta] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    CREATE INDEX [IX_Curso_AlumnosId] ON [Curso] ([AlumnosId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    CREATE INDEX [IX_Curso_DocenteId] ON [Curso] ([DocenteId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    CREATE INDEX [IX_CursoUsuario_CursoId] ON [CursoUsuario] ([CursoId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    CREATE INDEX [IX_CursoUsuario_UsuarioId] ON [CursoUsuario] ([UsuarioId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    CREATE INDEX [IX_Diapositiva_UnidadId] ON [Diapositiva] ([UnidadId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    CREATE INDEX [IX_Pregunta_QuizId] ON [Pregunta] ([QuizId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    CREATE INDEX [IX_Quiz_UnidadId] ON [Quiz] ([UnidadId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    CREATE INDEX [IX_Respuesta_PreguntaId] ON [Respuesta] ([PreguntaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    CREATE INDEX [IX_Unidad_CursoId] ON [Unidad] ([CursoId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190822012935_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190822012935_Initial', N'2.2.6-servicing-10079');
END;

GO

