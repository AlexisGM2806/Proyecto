using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;

namespace LibraryTests
{
    public class Preferencia_MusicaTests
    {
        
        private Preferencia_Musica meGusta {get; set;}
        private Preferencia_Musica noMeGusta {get; set;}


        private IItem item {get; set;}

        [SetUp]
        public void Setup()
        {
            List<string> generos1 = new List<string>(){"Genero1"};
            List<string> generos4 = new List<string>(){"Genero2"};

            List<string> artistas1 = new List<string>(){"Artista1"};
            List<string> artistas2 = new List<string>(){"Artista3"};

            List<int> decadas1 = new List<int>(){1980,1990};
            List<int> decadas2 = new List<int>(){2010};
            
            meGusta = new Preferencia_Musica(generos1, artistas1, decadas1, true);

            noMeGusta = new Preferencia_Musica(generos4, artistas2, decadas2, false);

            
            item = new Musica ("Musica1", "Artistas1", 1980, "Genero1");
        }

        [Test]
        public void ValorarItem_NoMusica_Test()
        {
            IItem item = new OtroDominio();

            Preferencia_Musica preferencia = new Preferencia_Musica(null, null, null, true);

            int esperado = 0;

            int resultado = preferencia.ValorarItem(item);

            Assert.That(esperado == resultado);
        }

        [Test]
        public void ValorarItem_SinDatosPositivo_Test()
        {
            Preferencia_Musica preferencia = new Preferencia_Musica(null, null, null, true);

            int esperado = 30;

            int resultado = preferencia.ValorarItem(item);

            Assert.That(esperado == resultado);            
        }

        [Test]
        public void ValorarItem_SinDatosNegativo_Test()
        {
            Preferencia_Musica preferencia = new Preferencia_Musica(null, null, null, false);

            int esperado = 0;

            int resultado = preferencia.ValorarItem(item);

            Assert.That(esperado == resultado);            
        }
    }
}