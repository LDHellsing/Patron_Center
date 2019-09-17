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
                List<CorreccionMOViewModel> coleccionRespuestas = new List<CorreccionMOViewModel>();
                CorreccionMOViewModel respuestaCorrecta = new CorreccionMOViewModel();
                List<Respuesta> resultado = new List<Respuesta>();

                resultado = await Respuesta.Where(r => respuestasId.Contains(r.Id)).ToListAsync();

                foreach (var respuesta in resultado)
                {
                    respuestaCorrecta.EnunciadoPregunta = respuesta.Pregunta.Enunciado;
                    respuestaCorrecta.OrdenPregunta = respuesta.Pregunta.Orden;
                    respuestaCorrecta.IdRespuesta = respuesta.Id;
                    respuestaCorrecta.RespuestaCorrecta = respuesta.RespuestaCorrecta;
                    coleccionRespuestas.Add(respuestaCorrecta);
                };

                Debug.WriteLine("respuestas resultante es ---------> " + coleccionRespuestas);

                return coleccionRespuestas;
            }
            catch (Exception e)
            {
                Debug.WriteLine("error: " + e);
                return null;
            }
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
            //Creación de Cursos
            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    Id = 1,
                    Nombre = "Curso de Prueba",
                    Descripcion = "Descripción de curso de prueba",
                    FechaFinalizacion = DateTime.Now,
                    Eliminado = false,
                    DocenteId = 2
                }
                );
            //Creación de Unidades
            modelBuilder.Entity<Unidad>().HasData(
                new Unidad
                {
                    Id = 1,
                    CursoId = 1,
                    Nombre = "1- Unidad de prueba 1",
                    Descripcion = "Descripción de Unidad de prueba 1",
                    Eliminado = false
                }
                );
            modelBuilder.Entity<Unidad>().HasData(
                new Unidad
                {
                    Id = 2,
                    CursoId = 1,
                    Nombre = "2- Unidad de prueba 2",
                    Descripcion = "Descripción de Unidad de prueba 2",
                    Eliminado = false
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
            //Creación de Diapositivas
            modelBuilder.Entity<Diapositiva>().HasData(
                new Diapositiva
                {
                    Id = 1,
                    Texto = "La diapositiva, transparencia, filmina o slide es una fotografía positiva (de colores reales) creada en un soporte transparente por medios fotoquímicos. Comparación entre los formatos fotográficos: Fotografía(propiamente dicha), foto, impresión fotográfica o positivo: Imagen opaca y positiva(de colores reales).Negativo: Imagen transparente y negativa(de colores invertidos). Diapositiva, filmina y película de cine: Imagen transparente y positiva(de colores reales). A las diapositivas se las llama también filminas porque se obtienen de recortar los cuadros de una filmina y colocarlos en sendos marcos cuadrados(en el caso de película de 35 mm, los marcos son de 5 cm de lado).",
                    Orden = 1,
                    Eliminado = false,
                    UnidadId = 1
                }
                );
            modelBuilder.Entity<Diapositiva>().HasData(
                new Diapositiva
                {
                    Id = 2,
                    Texto = "El proceso más antiguo de la fotografía en color fue el Autocromo. Este era un método de síntesis aditiva que producía diapositivas en colores, pero con baja definición y una resolución cromática limitada. Por el contrario, el proceso de síntesis sustractiva Kodachrome brindaba transparencias de colores brillantes. La película constaba de tres emulsiones, cada una de ellas sensible a una zona del espectro cromático. Y después del proceso aparecían los colorantes amarillo, magenta y cían. Introducido en 1935, fue ofrecido en un formato de 16 milímetros para películas cinematográficas, 35 mm para diapositivas y 8 mm para películas caseras. Aunque se utilizó originalmente para reportajes, ganó popularidad gradualmente. A comienzos de los años 1940, algunos aficionados usaban Kodachrome para tomar fotografías familiares, otros utilizaban adaptadores de rollos de película con cámaras de 4x5 pulgadas. En esta época, las películas en color tenían muchos defectos, eran costosas y las impresiones no duraban mucho tiempo.",
                    Orden = 2,
                    Eliminado = false,
                    UnidadId = 1
                }
                );
            modelBuilder.Entity<Diapositiva>().HasData(
                new Diapositiva
                {
                    Id = 3,
                    Texto = "Emulsiones más eficaces como Ektachrome y Fujichrome fueron sustituyendo a las de Kodachrome. Los aficionados las utilizaron hasta los años 1970, en que la impresión de copias en colores comenzó a desplazarla.En los últimos años del siglo XX, las transparencias en color fueron extensamente utilizadas en la fotografía publicitaria, documental, deportiva, de stock y de naturaleza. Los medios digitales han reemplazado gradualmente las transparencias en muchas de estas aplicaciones y su uso es, en la actualidad, infrecuente.",
                    Orden = 3,
                    Eliminado = false,
                    UnidadId = 1
                }
                );
            modelBuilder.Entity<Diapositiva>().HasData(
                new Diapositiva
                {
                    Id = 4,
                    Texto = "Por lo general, las diapositivas son preferidas por profesionales y muchos aficionados al momento de trabajar con la fotografía tradicional. Esto se debe, en parte, a su nitidez y a su reproducción cromática. La duración de las transparencias es mayor a las impresiones en color, de hecho, el proceso Kodachrome es reconocido por sus cualidades archivísticas y por brindar colores que no se atenúan con el tiempo. El proceso K-14 de Kodachrome es extremadamente difícil de llevar a cabo, ya que una mínima desviación de las especificaciones puede afectar la calidad del producto final. Es un método naturalmente imperfecto. Pequeñas cantidades de contaminación en las capas de color producen un efecto específico e irreproducible.",
                    Orden = 4,
                    Eliminado = false,
                    UnidadId = 1
                }
                );
            modelBuilder.Entity<Diapositiva>().HasData(
                new Diapositiva
                {
                    Id = 5,
                    Texto = "Esta unidad tiene solo una diapositiva.",
                    Orden = 1,
                    Eliminado = false,
                    UnidadId = 2
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
        }


    }
}
