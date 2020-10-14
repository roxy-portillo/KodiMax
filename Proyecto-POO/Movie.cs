namespace Proyecto_POO
{
    class Movie
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string MovieGenre { get; set; }

        public Movie(string id, string name, int duration, string movieGenre)
        {
            ID = id;
            Name = name;
            Duration = duration;
            MovieGenre = movieGenre;
        }
        public Movie()
        {

        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}, {2}min, {3}\n", ID, Name, Duration, MovieGenre);
        }
    }
}
