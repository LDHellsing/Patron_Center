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
        public DbSet<Correccion> Correccion { get; set; }
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
                Quiz quizAux = await Quiz.Where(q => q.Id == quizId).Include(p => p.Preguntas).ThenInclude(re => re.Respuestas).FirstAsync();

                Debug.WriteLine("El quiz resultante es ---------> " + quizAux.Preguntas.ElementAt(0).Enunciado);

                return quizAux;
            }
            catch (Exception e)
            {
                Debug.WriteLine("error: " + e);
                return null;
            }
        }

        public async Task<List<CorreccionMOViewModel>> ObtenerRespuestasCorrectas (List<int> respuestasId)
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

        //Puede que esto no sea necesario
        //public async Task<Curso> getCursoByUnidad (int unidadId)
        //{
        //    Unidad unidad = null;

        //    try
        //    {
        //        unidad = await Unidad.Where(u => u.Id == unidadId).Include(c => c.Curso).FirstAsync();
        //        return unidad.Curso;
        //    }
        //    catch (InvalidOperationException e)
        //    {
        //        Debug.WriteLine(e);
        //        return null;
        //    };
        //}

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
                    FechaFinalizacion = DateTime.Now,
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
                    Texto = "Introduccion a Patrones de Diseño",
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
                    Texto = "TEMARIO: \r\n\r\n - Historia\r\n - Definición de patrones\r\n - Tipos \r\n - Clasificación \r\n - Objetivos",
                    Orden = 2,
                    Eliminado = false,
                    UnidadId = 1
                }
                );
            modelBuilder.Entity<Diapositiva>().HasData(
                new Diapositiva
                {
                    Id = 3,
                    Texto = "HISTORIA:\r\n\r\nSurgen inspirados en los patrones arquitectónicos, que aparecen a fines de los años 70, con el fin de organizar y sistematizar las soluciones que diferentes arquitectos e ingenieros iban encontrando a problemas constructivos similares.\r\nSe formalizan a partir del libro “Design Patterns” de los autores Gamma, Helm, Johnsony Vlisides, llamados “la pandilla de los 4” (Gang Of Four, o simplificado GoF), en 1995.\r\nEn el libro se detalla la estructura que recomiendan emplear para la descripción de los patrones(estructura un poco más compleja de la que empleamos en este curso), y se formalizan más de 20 patrones de diseño, identificados por GoF en ese momento y todavía altamente vigentes al día de hoy.",
                    Orden = 3,
                    Eliminado = false,
                    UnidadId = 1
                }
                );
             modelBuilder.Entity<Diapositiva>().HasData(
                new Diapositiva
                {
                    Id = 4,
                    Texto = "DEFINICION DE PATRONES:\r\n\r\nLos Patrones Definen soluciones a problemas comunes del desarrollo de software.\r\nEstos deben cumplir con dos cosas:\r\n 1) Debe comprobarse como efectivo en la resolución de un problema\r\n 2) Debe ser reutilizable. \r\n\r\nExisten diferencias entre patrones de diseño y arquitectónicos las cuales son: \r\n (1) Los patrones arquitectónicos son mas abstractos \r\n (2) Los patrones arquitectónicos apoyan en el cumplimiento de atributos de calidad(Rendimiento, disponibilidad,etc).",
                    Orden = 4,
                    Eliminado = false,
                    UnidadId = 1
                }
                );
            modelBuilder.Entity<Diapositiva>().HasData(
                new Diapositiva
                {
                    Id = 5,
                    Texto = "OBJETIVOS:\r\n\r\nQue persiguen:\r\nCrear una biblioteca de módulos, elementos reutilizables, No reinventar la rueda, tener soluciones a problemas ya conocidos, Hablar un lenguaje común entre diseñadores y arquitectos, Estandarizar diseños, Facilitar el aprendizaje de técnicas a los nuevos diseñadores. \r\n\r\nQue no buscan: \r\nImponer una solución como la mejor, Eliminar la creatividad o el uso de otras opciones. \r\n\r\nNo es obligación utilizarlos pero simplifican el trabajo de diseño.",
                    Orden = 5,
                    Eliminado = false,
                    UnidadId = 1
                }
                );
            modelBuilder.Entity<Diapositiva>().HasData(
                 new Diapositiva
                 {
                     Id = 6,
                     Texto = "TIPOS DE PATRONES:\r\n\r\n\r\n 1)Arquitectónicos: Básicos, representan esquemas estructurales para la construcción de los sistemas(en muchos casos apoyan el cumplimiento de requerimientos no funcionales).\r\n\r\n\r\n 2)Diseño: Apoyan en la definición de estructuras de diseño y sus relaciones(implementación). \r\n\r\n\r\n 3)Dialectos: Patrones específicos de un lenguaje. \r\n\r\n4) Interacción: Patrones para diseñar interfaces web de usuario.",
                     Orden = 6,
                     Eliminado = false,
                     UnidadId = 1
                 }
                 );
             
            modelBuilder.Entity<Diapositiva>().HasData(
                 new Diapositiva
                 {
                     Id = 7,
                     Texto = "CLASIFICACION DE PATRONES:\r\n\r\n1) De Creación: participan en el momento de crear objetos, en general abstrayendo la forma en que se crean, y haciendo abstracta la referencia a que clase es que que se instancia. Ej: Singleton, Factory.\r\n\r\n2) Estructurales: tienen que ver con la forma en que las clases y los objetos son agrupados para formar grandes estructuras.Ej: Facade, Composite.\r\n\r\n3) De Comportamiento: se utilizan para modelar diferentes formas de interactuar entre los objetos para mejorar la performance del sistema.Ej: Observer, Strategy.",
                     Orden = 7,
                     Eliminado = false,
                     UnidadId = 1
                 }
                 );
            modelBuilder.Entity<Diapositiva>().HasData(
                new Diapositiva
                {
                    Id = 8,
                    Texto = "ESTRUCTURA DE PATRONES:\r\n\r\n 1) Nombre\r\n 2) Intención –> Que resuelve\r\n 3) Motivación –> Caso ilustrando el problema\r\n 4) Aplicabilidad –> Cuando aplicarlo\r\n 5) Estructura –> Diagrama de clases \r\n 6) Participantes –> Que objetos interactúan\r\n 7) Colaboraciones –> Secuencia de mensajes\r\n 8) Consecuencias –> Ventajas y desventajas\r\n 9) Técnica de implementación\r\n 10) Usos conocidos –> En que sistemas se usa \r\n 11) Patrones relacionados",
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
                    Puntaje = 5,
                    Evaluacion = TipoQuiz.Ejercicio,
                    Ejercicio = TipoEjercicio.Multiple_Opcion,
                    Eliminado = false,
                    Nombre = "Quiz de Prueba"
                }
                );
            // Creacion de Preguntas
            modelBuilder.Entity<Pregunta>().HasData(
                new Pregunta
                {
                    Id = 1,
                    QuizId = 1,
                    Puntaje = 5,
                    Eliminado = false,
                    Orden = 1,
                    Enunciado = "Esta pregunta no es mas que una prueba"
                }
                );
            modelBuilder.Entity<Pregunta>().HasData(
                new Pregunta
                {
                    Id = 2,
                    QuizId = 1,
                    Puntaje = 10,
                    Eliminado = false,
                    Orden = 2,
                    Enunciado = "Esta pregunta no es mas que otra una prueba"
                }
                );
            // Creacion de Respuestas
            modelBuilder.Entity<Respuesta>().HasData(
                new Respuesta
                {
                    Id = 1,
                    PreguntaId = 1,
                    RespuestaCorrecta = false,
                    Seleccionada = false,
                    Eliminado = false,
                    Enunciado = "Esta respuesta no es correcta y no esta seleccionada"
                }
                );
            modelBuilder.Entity<Respuesta>().HasData(
                new Respuesta
                {
                    Id = 2,
                    PreguntaId = 1,
                    RespuestaCorrecta = true,
                    Seleccionada = true,
                    Eliminado = false,
                    Enunciado = "Esta respuesta es correcta y esta seleccionada"
                }
                );
            modelBuilder.Entity<Respuesta>().HasData(
                new Respuesta
                {
                    Id = 3,
                    PreguntaId = 2,
                    RespuestaCorrecta = true,
                    Seleccionada = false,
                    Eliminado = false,
                    Enunciado = "Esta respuesta es correcta y no esta seleccionada"
                }
                );
            modelBuilder.Entity<Respuesta>().HasData(
                new Respuesta
                {
                    Id = 4,
                    PreguntaId = 2,
                    RespuestaCorrecta = false,
                    Seleccionada = true,
                    Eliminado = false,
                    Enunciado = "Esta respuesta no es correcta y esta seleccionada"
                }
                );

            //unidad 2
            modelBuilder.Entity<Unidad>().HasData(
                new Unidad
                {
                    Id = 2,
                    CursoId = 1,
                    Nombre = "2- Patron Singleton",
                    Descripcion = "En esta unidad se describe al Patron Singleton, sus funciones, sus características y para que se usa.",
                    Eliminado = false
                }
                );
            modelBuilder.Entity<Diapositiva>().HasData(
               new Diapositiva
               {
                   Id = 9,
                   Texto = "Patron Singleton",
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
                  Texto = "Problema:\r\n\r\n -> Debemos tener una única instancia de la clase y esta debe ser accesible desde todo el sistema.\r\n\r\n ->Se debe poder extender dicha clase por medio de herencia.",
                  Orden = 2,
                  Eliminado = false,
                  UnidadId = 2,
                  
              }
              );
            modelBuilder.Entity<Diapositiva>().HasData(
               new Diapositiva
               {
                   Id = 11,
                   Texto = "Solución:\r\n\r\n\r\n -> El constructor de la clase debe ser privado.\r\n -> Se declara un atributo privado y estático del mismo tipo de la clase.\r\n -> Se declara un método público y estático que permite acceso a la instancia privada de la clase.",
                   Orden = 3,
                   Eliminado = false,
                   UnidadId = 2,
                   
               }
               );
            modelBuilder.Entity<Diapositiva>().HasData(
               new Diapositiva
               {
                   Id = 12,
                   Texto = "Consecuencias:\r\n\r\n -> Se garantiza acceso a una única instancia de la clase(objeto).\r\n\r\n -> La instancia es visible en todo el sistema(global).\r\n\r\n -> Se mantiene el polimorfismo en la clase, es decir, no todos lo métodos son estáticos y por lo tanto pueden ser sobrescritos en clases derivadas.",
                   Orden = 4,
                   Eliminado = false,
                   UnidadId = 2,
                   
               }
               );
            modelBuilder.Entity<Diapositiva>().HasData(
               new Diapositiva
               {
                   Id = 13,
                   Texto = "Ejemplo:\r\n\r\nEn un parque de diversiones se desea contar los números de las entradas. Para esto se debe realizar un generador que adicionalmente brinda funcionalidades como: \r\n -> Generar un número nuevo mayor a los anteriores\r\n -> Dada una hora devolver la cantidad de números generados en la hora parámetro.",
                   Orden = 5,
                   Eliminado = false,
                   UnidadId = 2,
                 
               }
               );
        }


    }
}
