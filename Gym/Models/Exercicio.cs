using SQLite;

namespace Gym.Models
{
    public class Exercicio
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public int IdTreino { get; set; }
        public string? Nome { get; set; }
        public string? Series { get; set; }
        public string? Peso { get; set; }
    }
}
