using SQLite;

namespace Gym.Models
{
    public class Exercicio
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public int TreinoId { get; set; }
        public string? Nome { get; set; }
        public int Series { get; set; }
        public string? Peso { get; set; }
    }
}
