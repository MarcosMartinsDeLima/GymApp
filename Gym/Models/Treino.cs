using SQLite;

namespace Gym.Models
{
    public class Treino
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string? Letra { get; set; }
        public string? Grupo { get; set; }

        [Ignore]
        public List<Exercicio> Exercicios { get; set; }
    }
}
