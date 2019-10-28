using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Patron_Center.Models;

namespace Patron_Center.Models
{
    public class Patron_CenterContext : DbContext
    {
        public Patron_CenterContext(DbContextOptions<Patron_CenterContext> options)
            : base(options)
        {
        }

        public DbSet<Patron_Center.Models.Usuario> Usuario { get; set; }
        public DbSet<Patron_Center.Models.Curso> Curso { get; set; }
        public DbSet<CursoUsuario> CursoUsuario { get; set; }
        public DbSet<Respuesta> Respuesta { get; set; }
        public DbSet<Pregunta> Pregunta { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<Calificacion> Calificacion { get; set; }
        public DbSet<RespuestaAlumno> RespuestaAlumno { get; set; }

        public DbSet<Patron_Center.Models.Unidad> Unidad { get; set; }
        public DbSet<Patron_Center.Models.Diapositiva> Diapositiva { get; set; }

        //FindUserByDocument(string document)
        public async Task<Usuario> FindUserByDocumentAsync(string document)
        {
            Usuario user = null;
            try
            {
                user = await Usuario.Where(u => u.Documento == document).FirstAsync();
                return user;
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(e);
                return user = null;
            };
        }

        //Validar Usuario
        public async Task<UsuarioValidoDTO> ValidarUsuario(LoginViewModel usuario)
        {
            Usuario user = null;
            UsuarioValidoDTO usuaruoDTO = null;
            user = await FindUserByDocumentAsync(usuario.User);

            //Encripto password
            var PasswordToBytes = System.Text.Encoding.UTF8.GetBytes(usuario.Password);
            usuario.Password = System.Convert.ToBase64String(PasswordToBytes);

            if (user != null && user.Password == usuario.Password && user.Eliminado == false)
            {
                //El usuario existe en la BD
                usuaruoDTO = new UsuarioValidoDTO(user.Id, user.Nombre, user.Documento, user.TipoUsuario.ToString(), true);
            }
            else
            {
                //El usuario NO existe en la BD
                usuaruoDTO = new UsuarioValidoDTO(false);
            }
            return usuaruoDTO;
        }

        public async Task<Quiz> CreateQuiz(int quizId)
        {
            try
            {

                var quizAux = await Quiz.Where(q => q.Id == quizId && q.Eliminado == false).FirstAsync();

                var preguntasAux = await Pregunta.Where(p => p.QuizId == quizId && p.Eliminado == false).ToListAsync();
                quizAux.Preguntas = preguntasAux;

                foreach (var pregunta in preguntasAux)
                {
                    var respuestas = await Respuesta.Where(r => r.PreguntaId == pregunta.Id && r.Eliminado == false).ToListAsync();
                    pregunta.Respuestas = respuestas;
                }

                return quizAux;
            }
            catch (Exception e)
            {
                Debug.WriteLine("error: " + e);
                return null;
            }
        }

        public async Task<List<CorreccionMOViewModel>> GetCorrectAnswersAsync(List<int> respuestasId)
        {
            try
            {
                var coleccionRespuestas = new List<CorreccionMOViewModel>();
                var resultado = new List<Respuesta>();

                resultado = await Respuesta.Where(r => respuestasId.Contains(r.Id)).Include(p => p.Pregunta).ToListAsync();

                foreach (var respuesta in resultado)
                {
                    var respuestaCorrecta = new CorreccionMOViewModel(respuesta.Pregunta.Enunciado, respuesta.Pregunta.Orden, respuesta.Id, respuesta.RespuestaCorrecta, respuesta.Pregunta.Puntaje);
                    coleccionRespuestas.Add(respuestaCorrecta);
                }

                return coleccionRespuestas;
            }
            catch (Exception e)
            {
                Debug.WriteLine("error: " + e);
                return null;
            }
        }

        public async Task<Curso> GetCourseByUnitAsync(int unidadId)
        {
            Unidad unidad = null;

            try
            {
                unidad = await Unidad.Where(u => u.Id == unidadId).Include(c => c.Curso).FirstAsync();
                return unidad.Curso;
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(e);
                return null;
            };
        }

        // traer todas las calificaciones
        public List<CalificacionesViewModel> GetEvaluationScores(string tipoUsuario, int IdUsuario)
        {

            var listaCalificaciones = new List<CalificacionesViewModel>();

            if (tipoUsuario == "Alumno")
            {
                var calificaciones = from ca in Calificacion
                                     join u in Usuario on ca.IdAlumno equals u.Id
                                     join cu in Curso on ca.IdCurso equals cu.Id
                                     join uni in Unidad on ca.IdUnidad equals uni.Id
                                     where ca.IdAlumno == IdUsuario
                                     select new
                                     {
                                         id = ca.Id,
                                         fecha = ca.Fecha,
                                         nota = ca.Nota,
                                         nombreCompleto = $"{u.Nombre} {u.Apellido} ({u.Documento})",
                                         nombreCurso = cu.Nombre,
                                         nombreUnidad = uni.Nombre

                                     };

                foreach (var ca in calificaciones)
                {
                    var calificacion = new CalificacionesViewModel();

                    calificacion.Id = ca.id;
                    calificacion.NombreCompletoAlumno = ca.nombreCompleto;
                    calificacion.NombreCurso = ca.nombreCurso;
                    calificacion.NombreUnidad = ca.nombreUnidad;
                    calificacion.Fecha = ca.fecha;
                    calificacion.Nota = ca.nota;

                    listaCalificaciones.Add(calificacion);
                }
                return listaCalificaciones;
            }
            else
            {
                if (tipoUsuario == "Docente")
                {
                    var calificaciones = from ca in Calificacion
                                         join u in Usuario on ca.IdAlumno equals u.Id
                                         join cu in Curso on ca.IdCurso equals cu.Id
                                         join uni in Unidad on ca.IdUnidad equals uni.Id
                                         where cu.DocenteId == IdUsuario
                                         select new
                                         {
                                             id = ca.Id,
                                             fecha = ca.Fecha,
                                             nota = ca.Nota,
                                             nombreCompleto = $"{u.Nombre} {u.Apellido} ({u.Documento})",
                                             nombreCurso = cu.Nombre,
                                             nombreUnidad = uni.Nombre

                                         };

                    foreach (var ca in calificaciones)
                    {
                        var calificacion = new CalificacionesViewModel();

                        calificacion.Id = ca.id;
                        calificacion.NombreCompletoAlumno = ca.nombreCompleto;
                        calificacion.NombreCurso = ca.nombreCurso;
                        calificacion.NombreUnidad = ca.nombreUnidad;
                        calificacion.Fecha = ca.fecha;
                        calificacion.Nota = ca.nota;

                        listaCalificaciones.Add(calificacion);
                    }
                    return listaCalificaciones;
                }
                else
                {
                    var calificaciones = from ca in Calificacion
                                         join u in Usuario on ca.IdAlumno equals u.Id
                                         join cu in Curso on ca.IdCurso equals cu.Id
                                         join uni in Unidad on ca.IdUnidad equals uni.Id
                                         select new
                                         {
                                             id = ca.Id,
                                             fecha = ca.Fecha,
                                             nota = ca.Nota,
                                             nombreCompleto = $"{u.Nombre} {u.Apellido} ({u.Documento})",
                                             nombreCurso = cu.Nombre,
                                             nombreUnidad = uni.Nombre

                                         };

                    foreach (var ca in calificaciones)
                    {
                        var calificacion = new CalificacionesViewModel();

                        calificacion.Id = ca.id;
                        calificacion.NombreCompletoAlumno = ca.nombreCompleto;
                        calificacion.NombreCurso = ca.nombreCurso;
                        calificacion.NombreUnidad = ca.nombreUnidad;
                        calificacion.Fecha = ca.fecha;
                        calificacion.Nota = ca.nota;

                        listaCalificaciones.Add(calificacion);
                    }
                }
                return listaCalificaciones;
            }
        }

        //Obtener todos los Ids de los cursos que tienen alguna correccion pendiente
        public async Task<List<int>> GetCoursesWithPendingCorrectionsAsync(int idDocente)
        {
            var idsCursos = await RespuestaAlumno.Where(d => d.DocenteId == idDocente && d.PuntajeObtenido == null).Select(c => c.CursoId).Distinct().ToListAsync();


            foreach (var curso in idsCursos)
            {
                Console.WriteLine("idCurso " + curso);
            }
            return idsCursos;
        }

        //Obtener todos los ids de las unidades que tienen una correccion pendiente para un curso especifico y un docente especifico
        public async Task<List<int>> GetUnitsWithPendingCorrectionsAsync(int idCurso, int idDocente)
        {
            var idsUnidades = await RespuestaAlumno.Where(c => c.CursoId == idCurso && c.DocenteId == idDocente && c.PuntajeObtenido == null).Select(u => u.UnidadId).Distinct().ToListAsync();

            foreach (var unidad in idsUnidades)
            {
                Console.WriteLine("idUnidad " + unidad);
            }
            return idsUnidades;
        }

        //Obtener todos los ids de los alumnos que tienen una correccion pendiente para una unidad especifica
        public async Task<List<int>> GetStudentsWithPendingCorrectionsAsync(int idUnidad, int idDocente)
        {
            var idsAlumnos = await RespuestaAlumno.Where(u => u.UnidadId == idUnidad && u.DocenteId == idDocente && u.PuntajeObtenido == null).Select(a => a.UsuarioId).Distinct().ToListAsync();


            foreach (var alumno in idsAlumnos)
            {
                Console.WriteLine("IdAlumno" + alumno);
            }
            return idsAlumnos;
        }

        //Obtener la correccion pendiente para un alumno en especifico
        public CorreccionDesarrolloViewModel GetPendingCorrection(int idAlumno, int idDocente, int idUnidad)
        {
            var correccionPendiente = new CorreccionDesarrolloViewModel();
            var correcciones = from r in RespuestaAlumno
                               join u in Usuario on r.UsuarioId equals u.Id
                               join p in Pregunta on r.PreguntaId equals p.Id
                               join q in Quiz on p.QuizId equals q.Id
                               where r.UsuarioId == idAlumno && r.DocenteId == idDocente && r.UnidadId == idUnidad && r.PuntajeObtenido == null
                               select new
                               {
                                   id = r.Id,
                                   enunciadoPregunta = p.Enunciado,
                                   respuestaAlumno = r.RespuestaDesarrollo,
                                   nombreCompleto = $"{u.Nombre} {u.Apellido} ({u.Documento})",
                                   nombreQuiz = q.Nombre,
                                   puntajePregunta = p.Puntaje,
                                   alumnoId = r.UsuarioId,
                                   cursoId = r.CursoId,
                                   unidadId = r.UnidadId

                               };
            foreach (var elemento in correcciones)
            {
                var aux = new CorreccionDesarrollo();

                correccionPendiente.NombreAlumno = elemento.nombreCompleto;
                correccionPendiente.NombreQuiz = elemento.nombreQuiz;
                correccionPendiente.IdAlumno = elemento.alumnoId;
                correccionPendiente.IdCurso = elemento.cursoId;
                correccionPendiente.IdUnidad = elemento.unidadId;
                aux.Id = elemento.id;
                aux.EnunciadoPregunta = elemento.enunciadoPregunta;
                aux.RespuestaAlumno = elemento.respuestaAlumno;
                aux.PuntajeMaximoPregunta = elemento.puntajePregunta;
                correccionPendiente.Correcciones.Add(aux);

                Console.WriteLine($" alumno {elemento.nombreCompleto} quiz {elemento.nombreQuiz} idCorreccion {elemento.id} enunciado {elemento.enunciadoPregunta} respuesta {elemento.respuestaAlumno}");
            }

            return correccionPendiente;
        }


        //Relacion muchos a muchos Curso Usuario

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CursoUsuario>()
                    .HasKey(cu => new { cu.Id });

            modelBuilder.Entity<CursoUsuario>()
                    .HasOne<Usuario>(sc => sc.Usuario)
                    .WithMany(s => s.CursoUsuario)
                    .HasForeignKey(sc => sc.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CursoUsuario>()
                    .HasOne<Curso>(sc => sc.Curso)
                    .WithMany(s => s.CursoUsuario)
                    .HasForeignKey(sc => sc.CursoId)
                    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Usuario>()
                .HasAlternateKey(u => u.Documento)
                .HasName("Documento");

            //Seeding de datos
            //Creación de Usuarios
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Documento = "1",
                    Nombre = "Administrador",
                    Apellido = "Administrador",
                    Email = "admin@patroncenter.com",
                    Password = "YWRtaW4=",
                    TipoUsuario = TipoUsuario.Administrador,
                    Eliminado = false
                }
                );
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 2,
                    Documento = "2",
                    Nombre = "Docente",
                    Apellido = "Docente",
                    Email = "docente@patroncenter.com",
                    Password = "YWRtaW4=",
                    TipoUsuario = TipoUsuario.Docente,
                    Eliminado = false
                }
                );
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 3,
                    Documento = "3",
                    Nombre = "Alumno",
                    Apellido = "Alumno",
                    Email = "alumno@patroncenter.com",
                    Password = "YWRtaW4=",
                    TipoUsuario = TipoUsuario.Alumno,
                    Eliminado = false
                }
                );
            modelBuilder.Entity<Usuario>().HasData(
              new Usuario
              {
                  Id = 4,
                  Documento = "4",
                  Nombre = "Alumno Eliminado",
                  Apellido = "Alumno",
                  Email = "alumno@patroncenter.com",
                  Password = "YWRtaW4=",
                  TipoUsuario = TipoUsuario.Alumno,
                  Eliminado = true
              }
              );
            modelBuilder.Entity<Usuario>().HasData(
               new Usuario
               {
                   Id = 5,
                   Documento = "5",
                   Nombre = "Docecente Eliminado",
                   Apellido = "Docente",
                   Email = "docente@patroncenter.com",
                   Password = "YWRtaW4=",
                   TipoUsuario = TipoUsuario.Docente,
                   Eliminado = true
               }
               );
            modelBuilder.Entity<Usuario>().HasData(
             new Usuario
             {
                 Id = 6,
                 Documento = "49077339",
                 Nombre = "Agustin",
                 Apellido = "Gonzalez",
                 Email = "agustingonzalezata@gmail.com",
                 Password = "YWRtaW4=",
                 TipoUsuario = TipoUsuario.Alumno,
                 Eliminado = false
             }
             );
            //Creación de Cursos
            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    Id = 1,
                    Nombre = "Patrones de Diseño",
                    Descripcion = "Aqui se dicta un curso destinado al manejo y el aprendisaje de patrones de diseño.",
                    FechaFinalizacion = DateTime.Parse("2019-12-31"),
                    Eliminado = false,
                    DocenteId = 2
                }
                );
            //Creación de relacion Alumno Curso
            modelBuilder.Entity<CursoUsuario>().HasData(
                new CursoUsuario
                {
                    Id = 1,
                    CursoId = 1,
                    UsuarioId = 3
                }
                );
            modelBuilder.Entity<CursoUsuario>().HasData(
              new CursoUsuario
              {
                  Id = 2,
                  CursoId = 1,
                  UsuarioId = 6
              }
              );
            //Creación de Unidades
            modelBuilder.Entity<Unidad>().HasData(
                new Unidad
                {
                    Id = 1,
                    CursoId = 1,
                    Nombre = "1- Introduccion",
                    Descripcion = "Unidadad introductoria para Patrones de diseño.",
                    Eliminado = false
                }
                );

            //Creación de Diapositivas
            modelBuilder.Entity<Diapositiva>().HasData(
                new Diapositiva
                {
                    Id = 1,
                    Texto = "Introducción a Patrones de Diseño",
                    Orden = 1,
                    Eliminado = false,
                    UnidadId = 1,
                    UrlVideo = "bx5WqFEndoo",
                }
                );
            modelBuilder.Entity<Diapositiva>().HasData(
                new Diapositiva
                {
                    Id = 2,
                    Texto = @"TEMARIO:

- Historia
- Definición de patrones
- Tipos de patrones
- Clasificación de patrones
- Objetivos",
                    Orden = 2,
                    Eliminado = false,
                    UnidadId = 1
                }
                );
            modelBuilder.Entity<Diapositiva>().HasData(
                new Diapositiva
                {
                    Id = 3,
                    Texto = @"HISTORIA:

Surgen inspirados en los patrones arquitectónicos, que aparecen a fines de los años 70, con el fin de organizar y sistematizar las soluciones que diferentes arquitectos e ingenieros iban encontrando a problemas constructivos similares.

Se formalizan a partir del libro “Design Patterns” de los autores Gamma, Helm, Johnsony Vlisides, llamados “la pandilla de los 4” (Gang Of Four, o simplificado GoF), en 1995.

En el libro se detalla la estructura que recomiendan emplear para la descripción de los patrones(estructura un poco más compleja de la que empleamos en este curso), y se formalizan más de 20 patrones de diseño, identificados por GoF en ese momento y todavía altamente vigentes al día de hoy.",
                    Orden = 3,
                    Eliminado = false,
                    UnidadId = 1
                }
                );
            modelBuilder.Entity<Diapositiva>().HasData(
               new Diapositiva
               {
                   Id = 4,
                   Texto = @"DEFINICION DE PATRONES:

Los Patrones Definen soluciones a problemas comunes del desarrollo de software.
Estos deben cumplir con dos cosas:
1) Debe comprobarse como efectivo en la resolución de un problema.
2) Debe ser reutilizable.

Existen diferencias entre patrones de diseño y arquitectónicos las cuales son:
1) Los patrones arquitectónicos son mas abstractos.
2) Los patrones arquitectónicos apoyan en el cumplimiento de atributos de calidad (rendimiento, disponibilidad, etc).",
                   Orden = 4,
                   Eliminado = false,
                   UnidadId = 1
               }
               );
            modelBuilder.Entity<Diapositiva>().HasData(
                new Diapositiva
                {
                    Id = 5,
                    Texto = @"OBJETIVOS:

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

No es obligación utilizarlos pero simplifican el trabajo de diseño.",
                    Orden = 5,
                    Eliminado = false,
                    UnidadId = 1
                }
                );
            modelBuilder.Entity<Diapositiva>().HasData(
                 new Diapositiva
                 {
                     Id = 6,
                     Texto = @"TIPOS DE PATRONES:

1) Arquitectónicos:
Básicos, representan esquemas estructurales para la construcción de los sistemas (en muchos casos apoyan el cumplimiento de requerimientos no funcionales).

2) Diseño:
Apoyan en la definición de estructuras de diseño y sus relaciones (implementación).

3) Dialectos:
Patrones específicos de un lenguaje.

4) Interacción:
Patrones para diseñar interfaces web de usuario.",
                     Orden = 6,
                     Eliminado = false,
                     UnidadId = 1
                 }
                 );

            modelBuilder.Entity<Diapositiva>().HasData(
                 new Diapositiva
                 {
                     Id = 7,
                     Texto = @"CLASIFICACION DE PATRONES:

1) De Creación:
Participan en el momento de crear objetos, en general abstrayendo la forma en que se crean, y haciendo abstracta la referencia a que clase es que que se instancia. Ej: Singleton, Factory.

2) Estructurales:
Tienen que ver con la forma en que las clases y los objetos son agrupados para formar grandes estructuras.Ej: Facade, Composite.

3) De Comportamiento:
Se utilizan para modelar diferentes formas de interactuar entre los objetos para mejorar la performance del sistema.Ej: Observer, Strategy.",
                     Orden = 7,
                     Eliminado = false,
                     UnidadId = 1
                 }
                 );
            modelBuilder.Entity<Diapositiva>().HasData(
                new Diapositiva
                {
                    Id = 8,
                    Texto = @"ESTRUCTURA DE PATRONES:

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
11) Patrones relacionados.",
                    Orden = 8,
                    Eliminado = false,
                    UnidadId = 1
                }
                );
            // Creacion de quizes
            modelBuilder.Entity<Quiz>().HasData(
                new Quiz
                {
                    Id = 1,
                    UnidadId = 1,
                    Puntaje = 10,
                    Evaluacion = TipoQuiz.Ejercicio,
                    Ejercicio = TipoEjercicio.Multiple_Opcion,
                    Eliminado = false,
                    Nombre = "Introducción a Patrones de diseño"
                }
                );
            // Creacion de Preguntas
            modelBuilder.Entity<Pregunta>().HasData(
                new Pregunta
                {
                    Id = 1,
                    QuizId = 1,
                    Puntaje = 25,
                    Eliminado = false,
                    Orden = 1,
                    Enunciado = "¿Que persiguen los patrones de diseño?"
                }
                );
            modelBuilder.Entity<Pregunta>().HasData(
                new Pregunta
                {
                    Id = 2,
                    QuizId = 1,
                    Puntaje = 25,
                    Eliminado = false,
                    Orden = 2,
                    Enunciado = "¿Cual de los siguientes tipos NO es un tipo de patrón de diseño?"
                }
                );
            modelBuilder.Entity<Pregunta>().HasData(
                new Pregunta
                {
                    Id = 3,
                    QuizId = 1,
                    Puntaje = 25,
                    Eliminado = false,
                    Orden = 3,
                    Enunciado = "Los patrones de Creación particicipan en el momento de crear obejetos..."
                }
                );
            modelBuilder.Entity<Pregunta>().HasData(
               new Pregunta
               {
                   Id = 4,
                   QuizId = 1,
                   Puntaje = 25,
                   Eliminado = false,
                   Orden = 4,
                   Enunciado = "Los patrones de Comportamiento empeoran la performance del sistema..."
               }
               );
            // Creacion de Respuestas
            modelBuilder.Entity<Respuesta>().HasData(
                new Respuesta
                {
                    Id = 1,
                    PreguntaId = 1,
                    RespuestaCorrecta = true,
                    Eliminado = false,
                    Enunciado = "Estandarizar diseños"
                }
                );
            modelBuilder.Entity<Respuesta>().HasData(
                new Respuesta
                {
                    Id = 2,
                    PreguntaId = 1,
                    RespuestaCorrecta = false,
                    Eliminado = false,
                    Enunciado = "Imponer una solución como la mejor"
                }
                );
            modelBuilder.Entity<Respuesta>().HasData(
                new Respuesta
                {
                    Id = 3,
                    PreguntaId = 1,
                    RespuestaCorrecta = false,
                    Eliminado = false,
                    Enunciado = "Eliminar la creatividad, uso de otras opciones"
                }
                );
            modelBuilder.Entity<Respuesta>().HasData(
                new Respuesta
                {
                    Id = 4,
                    PreguntaId = 1,
                    RespuestaCorrecta = false,
                    Eliminado = false,
                    Enunciado = "Reinventar la rueda"
                }
                );
            modelBuilder.Entity<Respuesta>().HasData(
                new Respuesta
                {
                    Id = 5,
                    PreguntaId = 2,
                    RespuestaCorrecta = true,
                    Eliminado = false,
                    Enunciado = "Definicón"
                }
                );
            modelBuilder.Entity<Respuesta>().HasData(
                new Respuesta
                {
                    Id = 6,
                    PreguntaId = 2,
                    RespuestaCorrecta = false,
                    Eliminado = false,
                    Enunciado = "Arquitectónico"
                }
                );
            modelBuilder.Entity<Respuesta>().HasData(
                new Respuesta
                {
                    Id = 7,
                    PreguntaId = 2,
                    RespuestaCorrecta = false,
                    Eliminado = false,
                    Enunciado = "Dialectos"
                }
                );
            modelBuilder.Entity<Respuesta>().HasData(
                new Respuesta
                {
                    Id = 8,
                    PreguntaId = 2,
                    RespuestaCorrecta = false,
                    Eliminado = false,
                    Enunciado = "Interacción"
                }
                );
            modelBuilder.Entity<Respuesta>().HasData(
                new Respuesta
                {
                    Id = 9,
                    PreguntaId = 3,
                    RespuestaCorrecta = true,
                    Eliminado = false,
                    Enunciado = "Verdadero"
                }
                );
            modelBuilder.Entity<Respuesta>().HasData(
                new Respuesta
                {
                    Id = 10,
                    PreguntaId = 3,
                    RespuestaCorrecta = false,
                    Eliminado = false,
                    Enunciado = "Falso"
                }
                );
            modelBuilder.Entity<Respuesta>().HasData(
               new Respuesta
               {
                   Id = 11,
                   PreguntaId = 4,
                   RespuestaCorrecta = true,
                   Eliminado = false,
                   Enunciado = "Falso"
               }
               );
            modelBuilder.Entity<Respuesta>().HasData(
              new Respuesta
              {
                  Id = 12,
                  PreguntaId = 4,
                  RespuestaCorrecta = false,
                  Eliminado = false,
                  Enunciado = "Verdadero"
              }
              );

            //unidad 2
            modelBuilder.Entity<Unidad>().HasData(
                new Unidad
                {
                    Id = 2,
                    CursoId = 1,
                    Nombre = "2- Patrón Singleton",
                    Descripcion = "En esta unidad se describe al Patron Singleton, sus funciones, sus características y para que se usa.",
                    Eliminado = false
                }
                );
            modelBuilder.Entity<Diapositiva>().HasData(
               new Diapositiva
               {
                   Id = 9,
                   Texto = "Patrón Singleton",
                   Orden = 1,
                   Eliminado = false,
                   UnidadId = 2,
                   UrlVideo = "gocJeOHtj9w",
               }
               );
            modelBuilder.Entity<Diapositiva>().HasData(
              new Diapositiva
              {
                  Id = 10,
                  Texto = @"Problema:

- Debemos tener una única instancia de la clase y esta debe ser accesible desde todo el sistema.

- Se debe poder extender dicha clase por medio de herencia.",
                  Orden = 2,
                  Eliminado = false,
                  UnidadId = 2,

              }
              );
            modelBuilder.Entity<Diapositiva>().HasData(
               new Diapositiva
               {
                   Id = 11,
                   Texto = @"Solución:

1- El constructor de la clase debe ser privado.

2- Se declara un atributo privado y estático del mismo tipo de la clase.

3- Se declara un método público y estático que permite acceso a la instancia privada de la clase.",
                   Orden = 3,
                   Eliminado = false,
                   UnidadId = 2,

               }
               );
            modelBuilder.Entity<Diapositiva>().HasData(
               new Diapositiva
               {
                   Id = 12,
                   Texto = @"Consecuencias:

- Se garantiza acceso a una única instancia de la clase (objeto).

- La instancia es visible en todo el sistema (global).

- Se mantiene el polimorfismo en la clase, es decir, no todos lo métodos son estáticos y por lo tanto pueden ser sobrescritos en clases derivadas.",
                   Orden = 4,
                   Eliminado = false,
                   UnidadId = 2,

               }
               );
            modelBuilder.Entity<Diapositiva>().HasData(
               new Diapositiva
               {
                   Id = 13,
                   Texto = @"Ejemplo:

En un parque de diversiones se desea contar los números de las entradas. Para esto se debe realizar un generador que adicionalmente brinda funcionalidades como:
- Generar un número nuevo mayor a los anteriores

- Dada una hora devolver la cantidad de números generados en la hora parámetro.",
                   Orden = 5,
                   Eliminado = false,
                   UnidadId = 2,

               }
               );
            //unidad 3
            modelBuilder.Entity<Unidad>().HasData(
                new Unidad
                {
                    Id = 3,
                    CursoId = 1,
                    Nombre = "3- Patrón Facade",
                    Descripcion = "En esta unidad se describe al Patron Facade, sus funciones, sus características y para que se usa.",
                    Eliminado = false
                }
                );
            modelBuilder.Entity<Diapositiva>().HasData(
               new Diapositiva
               {
                   Id = 14,
                   Texto = "Patrón Singleton",
                   Orden = 1,
                   Eliminado = false,
                   UnidadId = 3,
               }
               );
            modelBuilder.Entity<Diapositiva>().HasData(
               new Diapositiva
               {
                   Id = 15,
                   Texto = @"
Problema:

- Se necesita una interfaz de métodos unificados que provean un punto de acceso a un subsistema.

- Se desea bajar el acoplamiento entre clases de un subsistema y las clases externas que la utilizan.

- Mejorar la separación de capas entre subsistemas.",
                   Orden = 1,
                   Eliminado = false,
                   UnidadId = 3,
               }
               );
            modelBuilder.Entity<Diapositiva>().HasData(
              new Diapositiva
              {
                  Id = 16,
                  Texto = @"Solución:

Crear una clase Facade que provea todos los métodos necesarios para ejecutar operaciones del subsistema.",
                  Orden = 1,
                  Eliminado = false,
                  UnidadId = 3,
              }
              );
            modelBuilder.Entity<Diapositiva>().HasData(
              new Diapositiva
              {
                  Id = 17,
                  Texto = @"Motivación:

- Estructurar un sistema en subsistemas ayuda a reducir la complejidad.

- Una meta común de diseño es reducir el número de dependencias entre subsistemas.

- Una forma de lograr esto es introducir un objeto fachada, una única y simple fachada de servicios generales del subsistemas.",
                  Orden = 1,
                  Eliminado = false,
                  UnidadId = 3,
              }
  );
        }


    }
}
