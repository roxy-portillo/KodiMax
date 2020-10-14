using System;
using System.Collections.Generic;

namespace Proyecto_POO
{
    class MovieListings : Movie
    {
        public List<Movie> NowShowing = new List<Movie>();

        public void MovieList()
        {
            Movie movie1 = new Movie("MI1", "Mision Imposible", 110, "Acción");
            NowShowing.Add(movie1);
            Movie movie2 = new Movie("LCF2", "Los Cazafantasmas", 107, "Comedia");
            NowShowing.Add(movie2);
            Movie movie3 = new Movie("SW3", "Star Wars", 121, "Ciencia Ficción");
            NowShowing.Add(movie3);
            Movie movie4 = new Movie("TS4", "Toy Story", 81, "Animada");
            NowShowing.Add(movie4);
            Movie movie5 = new Movie("EA5", "El Aro", 105, "Suspenso");
            NowShowing.Add(movie5);
        }

        public void Print()
        {
            Console.Clear();
            if (NowShowing.Count == 0)
            {
                MovieList();
            }
            Console.WriteLine("\tEn Cartelera\n---------------------------------------------\n");
            foreach (Movie m in NowShowing)
            {
                if (m != null)
                {
                    Console.WriteLine(m);
                }
            }
        }
    }
}
