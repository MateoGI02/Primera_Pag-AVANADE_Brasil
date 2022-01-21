using System;
using System.Collections.Generic;
using DIO.Animes.Interfaces;

namespace DIO.Animes
{
    public class AnimeRepositorio : IRepositorio<Anime>
    {
        private List<Anime> listaAnime = new List<Anime>();
        public void Actualiza(int id, Anime entidade)
        {
            listaAnime[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaAnime[id].Excluir();
        }

        public void Insere(Anime entidade)
        {
            listaAnime.Add(entidade);
        }

        public List<Anime> Lista()
        {
            return listaAnime;
        }

        public int ProximoId()
        {
            return listaAnime.Count;
        }

        public Anime RetornaPorId(int Id)
        {
            return listaAnime[Id];
        }
    }
}