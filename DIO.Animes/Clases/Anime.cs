using System;

namespace DIO.Animes
{
    public class Anime : EntidadBase
    {

        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descripcion { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Anime(int id,Genero genero, string titulo, string descripcion, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descripcion = descripcion;
            this.Ano = ano;
            this.Excluido = false;
        }


        public override string ToString ()
        {
            string retorno = "";
            retorno += "Género: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descripción: " + this.Descripcion + Environment.NewLine;
            retorno += "Año: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo ()
        {
            return this.Titulo;
        }

        public int retornaId ()
        {
            return this.Id;
        }

        public bool retornaExcluido ()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}