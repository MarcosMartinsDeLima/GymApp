using Gym.Models;
using Gym.Repository;
using System.Collections.ObjectModel;

namespace Gym;

public partial class TreinoPage : ContentPage
{
    public ObservableCollection<Exercicio> Exercicios { get; set; } = new();
    public string TreinoLetra { get; set; } = "";
    private readonly TreinoRepository _treinoRepository;
    private readonly int _treinoId;

    public TreinoPage(TreinoRepository treinoRepository, int treinoId)
    {
        InitializeComponent();

        _treinoRepository = treinoRepository;
        _treinoId = treinoId;

        BindingContext = this;

        CarregarExercicios();
    }

    private async void CarregarExercicios()
    {
        var treino = await _treinoRepository.GetTreinoComExerciciosAsync(_treinoId);

        TreinoLetra = treino.Letra;

        foreach (var ex in treino.Exercicios)
        {
            Exercicios.Add(ex);
        }
    }
}