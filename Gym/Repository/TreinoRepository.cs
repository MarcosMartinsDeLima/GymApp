using Gym.Models;
using SQLite;

namespace Gym.Repository
{
    public class TreinoRepository
    {
        readonly SQLiteAsyncConnection _db;

        public TreinoRepository(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);

            _db.CreateTableAsync<Treino>().Wait();
            _db.CreateTableAsync<Exercicio>().Wait();
        }

        public Task<List<Treino>> GetTreinosAsync()
        {
            return _db.Table<Treino>().ToListAsync();
        }

        public Task<Treino> GetTreinoAsync(int id)
        {
            return _db.Table<Treino>().Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveTreinoAsync(Treino treino)
        {
            if (treino.Id != 0)
                return _db.UpdateAsync(treino);
            else
                return _db.InsertAsync(treino);
        }

        public Task<int> DeleteTreinoAsync(Treino treino)
        {
            return _db.DeleteAsync(treino);
        }

        #region Exercicios
        public Task<List<Exercicio>> GetExerciciosByTreinoAsync(int treinoId)
        {
            return _db.Table<Exercicio>().Where(e => e.TreinoId == treinoId).ToListAsync();
        }

        public Task<int> SaveExercicioAsync(Exercicio exercicio)
        {
            if (exercicio.Id != 0)
                return _db.UpdateAsync(exercicio);
            else
                return _db.InsertAsync(exercicio);
        }

        public Task<int> DeleteExercicioAsync(Exercicio exercicio)
        {
            return _db.DeleteAsync(exercicio);
        }

        
        public async Task<Treino> GetTreinoComExerciciosAsync(int treinoId)
        {
            var treino = await GetTreinoAsync(treinoId);
            if (treino != null)
            {
                treino.Exercicios = await GetExerciciosByTreinoAsync(treinoId);
            }
            return treino;
        }

        public async Task AtualizarPeso(int exercicioId, int novoPeso)
        {
            var exercicio = await _db.Table<Exercicio>()
                                          .FirstOrDefaultAsync(e => e.Id == exercicioId);

            if (exercicio == null)
                throw new InvalidOperationException($"Exercício com Id {exercicioId} não encontrado.");

            exercicio.Peso = novoPeso.ToString();
            await _db.UpdateAsync(exercicio);
        }

        #endregion
    }
}
