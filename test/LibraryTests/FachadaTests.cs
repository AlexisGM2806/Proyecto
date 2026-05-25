using NUnit.Framework;
using Library;
using System.Collections.Generic;
using System.Linq;

namespace LibraryTests
{
    public class FachadaTests
    {
        private Fachada fachada {get; set;}
        
        [SetUp]
        public void Setup()
        {
            fachada = new Fachada();

            List<Usuario> usuarios = new List<Usuario>();

            usuarios.Add(new Usuario("Prueba1", null, null));
            usuarios.Add(new Usuario("Prueba2", null, null));
            usuarios.Add(new Usuario("Prueba3", null, null));

            List<IItem> items = new List<IItem>();

            items.Add(new Musica("Musica1", "Artista1", 1980, "Genero1"));
            items.Add(new Musica("Musica2", "Artista2", 1981, "Genero1"));
            items.Add(new Musica("Musica3", "Artista2", 1990, "Genero1"));
            items.Add(new Musica("Musica4", "Artista3", 1995, "Genero2"));
            items.Add(new Musica("Musica5", "Artista3", 2000, "Genero3"));
            items.Add(new Musica("Musica6", "Artista3", 2010, "Genero2"));

            List<Interaccion> interacciones = new List<Interaccion>();

            interacciones.Add(new Interaccion(usuarios[0], items[0]));
            interacciones.Add(new Interaccion(usuarios[0], items[1]));
            interacciones.Add(new Interaccion(usuarios[0], items[2]));
            interacciones.Add(new Interaccion(usuarios[1], items[0]));
            interacciones.Add(new Interaccion(usuarios[1], items[1]));
            interacciones.Add(new Interaccion(usuarios[1], items[2]));
            interacciones.Add(new Interaccion(usuarios[1], items[3]));
            interacciones.Add(new Interaccion(usuarios[2], items[2]));
            interacciones.Add(new Interaccion(usuarios[2], items[4]));

            List<string> generos1 = new List<string>(){"Genero1"};
            List<string> generos2 = new List<string>(){"Genero1","Genero2"};
            List<string> generos3 = new List<string>(){"Genero1","Genero3"};
            List<string> generos4 = new List<string>(){"Genero2"};
            List<string> generos5 = new List<string>(){"Genero3"};

            List<string> artistas1 = new List<string>(){"Artista1"};
            List<string> artistas2 = new List<string>(){"Artista3"};

            List<int> decadas1 = new List<int>(){1980,1990};
            List<int> decadas2 = new List<int>(){2010};
            
            IPreferencia megusta1 = new Preferencia_Musica(generos1, artistas1, decadas1, true);
            IPreferencia megusta2 = new Preferencia_Musica(generos2, null, null, true);
            IPreferencia megusta3 = new Preferencia_Musica(generos3, null, null, true);

            IPreferencia nomegusta1 = new Preferencia_Musica(generos4, artistas2, decadas2, false);
            IPreferencia nomegusta2 = new Preferencia_Musica(generos5, null, null, false);
            IPreferencia nomegusta3 = new Preferencia_Musica(null, null, null, false);

            usuarios[0].ActualizarGustos(megusta1);
            usuarios[0].ActualizarDisgustos(nomegusta1);

            usuarios[1].ActualizarGustos(megusta2);
            usuarios[1].ActualizarDisgustos(nomegusta2);            

            usuarios[2].ActualizarGustos(megusta3);
            usuarios[2].ActualizarDisgustos(nomegusta3);

            Controlador.Inicializar(usuarios, items, interacciones);
        }

        [Test]
        public void AñadirUsuario_AñadeUsuario_Test()
        {
            Usuario nuevoUsuario = new Usuario("NuevoUsuario", null, null);
            
            fachada.AñadirUsuario(nuevoUsuario);

            int resultado = fachada.GetUsuarios().Count(u => u.Equals(nuevoUsuario));

            Assert.That(resultado == 1);
        }
        
        [Test]
        public void AñadirUsuario_NoAñadeUsuarioDuplicado_Test()
        {
            Usuario nuevoUsuario = new Usuario("Prueba1", null, null);
            
            fachada.AñadirUsuario(nuevoUsuario);

            int resultado = fachada.GetUsuarios().Count(u => u.Equals(nuevoUsuario));

            Assert.That(resultado == 1);
        }
        
        [Test]
        public void AñadirItem_AñadeItem_Test()
        {
            IItem nuevoItem = new Musica("NuevaMusica", "null", 0, "null");
            
            fachada.AñadirItem(nuevoItem);

            int resultado = fachada.GetItems().Count(u => u.Equals(nuevoItem));

            Assert.That(resultado == 1);
        }

        [Test]
        public void AñadirItem_NoAñadeItemDuplicado_Test()
        {
            IItem nuevoItem = new Musica("Musica1", "Artista1", 1980, "Genero1");
            
            fachada.AñadirItem(nuevoItem);

            int resultado = fachada.GetItems().Count(u => u.Equals(nuevoItem));

            Assert.That(resultado == 1);
        }
        
        [Test]
        public void AñadirInteraccion_AñadeInteraccion_Test()
        {
            Usuario nuevoUsuario = new Usuario("Prueba1", null, null);

            IItem nuevoItem = new Musica("Musica6", "Artista3", 2010, "Genero2");
            
            Interaccion nuevaInteraccion = new Interaccion (nuevoUsuario, nuevoItem);

            fachada.AñadirInteraccion(nuevaInteraccion);

            int resultado = fachada.GetInteracciones().Count(u => u.Equals(nuevaInteraccion));

            Assert.That(resultado == 1);
        }

        [Test]
        public void AñadirInteraccion_NoAñadeInteraccionUsuarioInexistente_Test()
        {
            Usuario nuevoUsuario = new Usuario("Prueba10", null, null);

            IItem nuevoItem = new Musica("Musica6", "Artista3", 2010, "Genero2");
            
            Interaccion nuevaInteraccion = new Interaccion (nuevoUsuario, nuevoItem);

            fachada.AñadirInteraccion(nuevaInteraccion);

            int resultado = fachada.GetInteracciones().Count(u => u.Equals(nuevaInteraccion));

            Assert.That(resultado == 0);
        }                 

        [Test]
        public void AñadirInteraccion_NoAñadeInteraccionItemInexistente_Test()
        {
            Usuario nuevoUsuario = new Usuario("Prueba1", null, null);

            IItem nuevoItem = new Musica("Musica60", "Artista3", 2010, "Genero2");
            
            Interaccion nuevaInteraccion = new Interaccion (nuevoUsuario, nuevoItem);

            fachada.AñadirInteraccion(nuevaInteraccion);

            int resultado = fachada.GetInteracciones().Count(u => u.Equals(nuevaInteraccion));

            Assert.That(resultado == 0);
        }      

        [Test]
        public void AñadirInteraccion_NoAñadeInteraccionDuplicada_Test()
        {
            Usuario nuevoUsuario = new Usuario("Prueba1", null, null);

            IItem nuevoItem = new Musica("Musica1", "Artista1", 1980, "Genero1");
            
            Interaccion nuevaInteraccion = new Interaccion (nuevoUsuario, nuevoItem);

            fachada.AñadirInteraccion(nuevaInteraccion);

            int resultado = fachada.GetInteracciones().Count(u => u.Equals(nuevaInteraccion));

            Assert.That(resultado == 1);
        }

        [Test]
        public void RankingPorInteracciones_Test()
        {
            List<IItem> esperado = new List<IItem>();

            esperado.Add(new Musica("Musica3", "Artista2", 1990, "Genero1"));
            esperado.Add(new Musica("Musica1", "Artista1", 1980, "Genero1"));
            esperado.Add(new Musica("Musica2", "Artista2", 1981, "Genero1"));
            esperado.Add(new Musica("Musica4", "Artista3", 1995, "Genero2"));
            esperado.Add(new Musica("Musica5", "Artista3", 2000, "Genero3"));
            esperado.Add(new Musica("Musica6", "Artista3", 2010, "Genero2"));

            List<IItem> resultado = fachada.RankingPorInteracciones();

            bool iguales = true;
            for (int i = 0; i < 6 ; i++)
            {
                iguales = iguales && esperado[i].Equals(resultado[i]);
            }

            Assert.That(iguales);
        }     

        [Test]
        public void RankingPorPreferencias_Correcto_Test()
        {
            List<IItem> esperado = new List<IItem>();

            esperado.Add(new Musica("Musica1", "Artista1", 1980, "Genero1"));
            esperado.Add(new Musica("Musica2", "Artista2", 1981, "Genero1"));
            esperado.Add(new Musica("Musica3", "Artista2", 1990, "Genero1"));

            Usuario usuario = fachada.GetUsuario("Prueba1");

            List<IItem> resultado = fachada.RankingPorPreferencia(usuario);

            bool iguales = true;
            for (int i = 0; i < 3 ; i++)
            {
                iguales = iguales && esperado[i].Equals(resultado[i]);
            }

            Assert.That(iguales);
        }      

        [Test]
        public void RankingPorPreferencias_UsuarioInexistente_Test()
        {
            Usuario usuario = fachada.GetUsuario("Usuario1");

            List<IItem> resultado = fachada.RankingPorPreferencia(usuario);

            Assert.That(resultado, Is.Null);
        }

        [Test]
        public void RankingPorPreferencias_GustosNull_Test()
        {
            Usuario usuario = fachada.GetUsuario("Prueba1");

            usuario.ActualizarGustos(null);

            List<IItem> resultado = fachada.RankingPorPreferencia(usuario);

            Assert.That(resultado, Is.Null);
        }

        [Test]
        public void RankingPorPreferencias_DisgustosNull_Test()
        {
            Usuario usuario = fachada.GetUsuario("Prueba1");

            usuario.ActualizarDisgustos(null);

            List<IItem> resultado = fachada.RankingPorPreferencia(usuario);

            Assert.That(resultado, Is.Null);
        }

        [Test]
        public void GetUsuario_Correcto_Test()
        {
            Usuario esperado = new Usuario ("Prueba1", null, null);

            Usuario resultado = fachada.GetUsuario("Prueba1");

            Assert.That(esperado.Equals(resultado));
        }

        [Test]
        public void GetUsuario_UsuarioInexistente_Test()
        {;
            Usuario resultado = fachada.GetUsuario("Usuario1");

            Assert.That(resultado, Is.Null);
        }

        [Test]
        public void GetItem_Correcto_Test()
        {
            IItem esperado = new Musica ("Musica1", "Artista1", 1980, "Genero1");

            IItem resultado = fachada.GetItem("Musica1");

            Assert.That(esperado.Equals(resultado));
        }

        [Test]
        public void GetItem_ItemInexistente_Test()
        {;
            IItem resultado = fachada.GetItem("Musica100");

            Assert.That(resultado, Is.Null);
        }

        [Test]
        public void GetInteraccion_Correcto_Test()
        {
            Usuario usuario = new Usuario("Prueba1", null, null);

            IItem item = new Musica ("Musica1", "Artista1", 1980, "Genero1");
            
            Interaccion esperado = new Interaccion (usuario, item);

            Interaccion resultado = fachada.GetInteraccion(usuario, item);

            Assert.That(esperado.Equals(resultado));
        }

        [Test]
        public void GetInteraccion_UsuarioNull_Test()
        {
            Usuario usuario = null;

            IItem item = new Musica ("Musica1", "Artista1", 1980, "Genero1");
            
            Interaccion resultado = fachada.GetInteraccion(usuario, item);

            Assert.That(resultado, Is.Null);
        }

        [Test]
        public void GetInteraccion_MusicaNull_Test()
        {
            Usuario usuario = new Usuario("Prueba1", null, null);

            IItem item = null;
            
            Interaccion resultado = fachada.GetInteraccion(usuario, item);

            Assert.That(resultado, Is.Null);
        }

        [Test]

        public void GetUsuarios_Test()
        {
            List<Usuario> resultado = fachada.GetUsuarios();

            Assert.That(resultado.Count == 3);
        }

        [Test]

        public void GetItems_Test()
        {
            List<IItem> resultado = fachada.GetItems();

            Assert.That(resultado.Count == 6);
        }

        [Test]

        public void GetInteracciones_Test()
        {
            List<Interaccion> resultado = fachada.GetInteracciones();

            Assert.That(resultado.Count == 9);
        }        
    }
}