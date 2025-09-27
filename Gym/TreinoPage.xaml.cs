using Gym.Models;
using Gym.Repository;


using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Gym;

public partial class TreinoPage : ContentPage
{
    public ObservableCollection<Exercicio> Exercicios { get; set; } = new();
    public string TreinoLetra { get; set; } = "";

    public string TempoTreino { get; set; } = "00:00";
    public string TempoDescanso { get; set; } = "00:00";
    public bool MostraDescanso { get; set; } = false;

    private readonly TreinoRepository _treinoRepository;
    private readonly int _treinoId;

    private bool _rodandoTreino = false;
    private bool _rodandoDescanso = false;
    private int _tempoTreinoMs = 0;
    private int _tempoDescansoMs = 0;

    public ICommand EditarPesoCommand { get; }

    public TreinoPage(TreinoRepository treinoRepository, int treinoId)
    {
        InitializeComponent();

        _treinoRepository = treinoRepository;
        _treinoId = treinoId;

        BindingContext = this;

        EditarPesoCommand = new Command<int>(async (exercicioId) => await EditarPeso(exercicioId));

        CarregarExercicios();
        IniciarTimers();
    }

    private async void CarregarExercicios()
    {
        var treino = await _treinoRepository.GetTreinoComExerciciosAsync(_treinoId);
        if (treino == null) return;

        TreinoLetra = treino.Letra;
        OnPropertyChanged(nameof(TreinoLetra));

        Exercicios.Clear();
        foreach (var ex in treino.Exercicios)
        {
            Exercicios.Add(ex);
        }
    }

    private void IniciarTimers()
    {
        // Timer do treino
        Dispatcher.StartTimer(TimeSpan.FromMilliseconds(100), () =>
        {
            if (_rodandoTreino)
            {
                _tempoTreinoMs += 100;
                TempoTreino = TimeSpan.FromMilliseconds(_tempoTreinoMs).ToString(@"mm\:ss");
                OnPropertyChanged(nameof(TempoTreino));
            }
            return true;
        });

        // Timer do descanso
        Dispatcher.StartTimer(TimeSpan.FromMilliseconds(100), () =>
        {
            if (_rodandoDescanso)
            {
                _tempoDescansoMs += 100;
                TempoDescanso = TimeSpan.FromMilliseconds(_tempoDescansoMs).ToString(@"mm\:ss");
                MostraDescanso = true;
                OnPropertyChanged(nameof(TempoDescanso));
                OnPropertyChanged(nameof(MostraDescanso));
            }
            return true;
        });
    }

    private void ToggleTreino(object sender, EventArgs e)
    {
        _rodandoTreino = !_rodandoTreino;
    }

    private void ToggleDescanso(object sender, EventArgs e)
    {
        _tempoDescansoMs = 0;
        _rodandoDescanso = !_rodandoDescanso;
    }

    private async Task EditarPeso(int exercicioId)
    {
        var exercicio = await _treinoRepository.GetExerciciosByTreinoAsync(_treinoId);
        var ex = exercicio.Find(x => x.Id == exercicioId);
        if (ex == null) return;

        string resultado = await DisplayPromptAsync("Editar Peso", $"Peso atual: {ex.Peso}", initialValue: ex.Peso);
        if (!string.IsNullOrWhiteSpace(resultado))
        {
            if (int.TryParse(resultado, out int novoPeso))
            {
                await _treinoRepository.AtualizarPeso(exercicioId, novoPeso);
                ex.Peso = novoPeso.ToString();
                OnPropertyChanged(nameof(Exercicios));
            }
        }
    }
}