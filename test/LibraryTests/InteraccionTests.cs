using NUnit.Framework;
using Library;
using System;

namespace LibraryTests
{
    public class InteraccionTests
    {
        private Usuario usuario {get; set;}

        private IItem item {get; set;}
        
        [SetUp]
        public void Setup()
        {
            usuario = new Usuario ("Prueba1", null, null);

            item = new Musica ("Musica1", "Artista1", 1980, "Genero1");
        }

        [Test]
        public void Constructor_Test()
        {
            Interaccion interaccion = new Interaccion(usuario, item);
            
            bool resultado = true;
            
            resultado = interaccion.Usuario.Equals(usuario);
            resultado = interaccion.Item.Equals(item) && resultado;

            Assert.That(resultado);
        }

        [Test]
        public void Equals_SonIguales_Test()
        {
            Interaccion interaccion1 = new Interaccion (usuario, item);

            Interaccion interaccion2 = new Interaccion (usuario, item);

            Assert.That(interaccion1.Equals(interaccion2));
        }

        [Test]
        public void Equals_NoSonIguales_Test()
        {
            Interaccion interaccion1 = new Interaccion (usuario, item);

            Interaccion interaccion2 = new Interaccion (new Usuario ("Prueba2", null, null), item);

            Assert.That(!interaccion1.Equals(interaccion2));
        }

        [Test]
        public void Equals_NullEsDistinto_Test()
        {
            Interaccion interaccion1 = new Interaccion (usuario, item);

            Interaccion interaccion2 = null;

            Assert.That(!interaccion1.Equals(interaccion2));
        }
        
        [Test]
        public void GetHashCode_Test()
        {
            int esperado = HashCode.Combine(usuario,item);

            Interaccion interaccion1 = new Interaccion (usuario, item);

            Assert.That(interaccion1.GetHashCode() == esperado);
        }

        [Test]
        public void ToString_Test()
        {
            string esperado = "Usuario: Prueba1 | Item: Musica1 - Artista1 (1980) Género: Genero1";

            Interaccion interaccion = new Interaccion (usuario, item);

            string resultado = interaccion.ToString();

            Assert.That(esperado.Equals(resultado, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}