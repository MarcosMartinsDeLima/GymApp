using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Repository
{
    public static class InitialSeed
    {
        public static async Task AplicarSeed(TreinoRepository treinoDb)
        {
            var treinos = await treinoDb.GetTreinosAsync();

            if (treinos.Any())
                return; 

            // ---------------- Treino A ----------------
            var treinoA = new Treino
            {
                Letra = "A",
                Grupo = "Upper 1"
            };
            await treinoDb.SaveTreinoAsync(treinoA);

            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Supino Reto com halteres", Series = 2, Peso = "26kg", TreinoId = treinoA.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Fly", Series = 2, Peso = "Na", TreinoId = treinoA.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Puxada triangulo", Series = 2, Peso = "sla", TreinoId = treinoA.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Remada Alta", Series = 2, Peso = "sla", TreinoId = treinoA.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Elevação lateral polia", Series = 3, Peso = "sla", TreinoId = treinoA.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Triceps Polia", Series = 3, Peso = "sla", TreinoId = treinoA.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Rosca banco inclinado", Series = 2, Peso = "14kg", TreinoId = treinoA.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Flexão de punho", Series = 2, Peso = "sla", TreinoId = treinoA.Id });


            // ---------------- Treino B ----------------
            var treinoB = new Treino
            {
                Letra = "B",
                Grupo = "Lower 1"
            };
            await treinoDb.SaveTreinoAsync(treinoB);

            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Agachamemnto no smith", Series = 2, Peso = "25kg", TreinoId = treinoB.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Extensora", Series = 3, Peso = "110kg", TreinoId = treinoB.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Flexora", Series = 2, Peso = "110kg", TreinoId = treinoB.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "mesa flexora uni", Series = 2, Peso = "???kg", TreinoId = treinoB.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Panturrilha", Series = 3, Peso = "25kg", TreinoId = treinoB.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Abdominal ?", Series = 3, Peso = "sla", TreinoId = treinoB.Id });


            // ---------------- Treino C ----------------
            var treinoC = new Treino
            {
                Letra = "C",
                Grupo = "Upper 2"
            };
            await treinoDb.SaveTreinoAsync(treinoC);

            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Remada curvada peg sup", Series = 2, Peso = "50kg", TreinoId = treinoC.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Remada baixa triangulo", Series = 2, Peso = "sla", TreinoId = treinoC.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Supino inclinado com halteres", Series = 2, Peso = "26g", TreinoId = treinoC.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Triceps Frances cross uni", Series = 3, Peso = "10kg", TreinoId = treinoC.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Desenvolvimento maquina", Series = 2, Peso = "sla", TreinoId = treinoC.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Elevação lateral", Series = 3, Peso = "sla", TreinoId = treinoC.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Rosca Scoot", Series = 3, Peso = "14kg", TreinoId = treinoC.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Rosca martelo com haltere", Series = 3, Peso = "16kg", TreinoId = treinoC.Id });


            // ---------------- Treino D ----------------
            var treinoD = new Treino
            {
                Letra = "D",
                Grupo = "Lower 2"
            };
            await treinoDb.SaveTreinoAsync(treinoD);

            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "leg press", Series = 2, Peso = "sla", TreinoId = treinoD.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "stiff", Series = 2, Peso = "sla", TreinoId = treinoD.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "mesa flexora", Series = 2, Peso = "sla", TreinoId = treinoD.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Extensora", Series = 2, Peso = "sla", TreinoId = treinoD.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Panturrilha", Series = 3, Peso = "30kg", TreinoId = treinoD.Id });
            await treinoDb.SaveExercicioAsync(new Exercicio { Nome = "Abdominal", Series = 3, Peso = "sla", TreinoId = treinoD.Id });
        }
    }
}
