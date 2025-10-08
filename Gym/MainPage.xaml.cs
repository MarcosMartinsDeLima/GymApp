using Gym.Models;
using Gym.Repository;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Gym
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public ObservableCollection<Treino> Treinos { get; set; } = new();
        private readonly TreinoRepository _treinoRepository;

        public ICommand ItemSelectedCommand { get; }

        public MainPage(TreinoRepository treinoRepository)
        {
            InitializeComponent();
            _treinoRepository = treinoRepository;

            ItemSelectedCommand = new Command<int>(OnItemSelected);

            BindingContext = this;

            CarregarTreinos();
        }


        private async void CarregarTreinos()
        {
            var treinos = await _treinoRepository.GetTreinosAsync();

            if (treinos.Count != 0)
            {
                Treinos = new ObservableCollection<Treino>(treinos);
                OnPropertyChanged(nameof(Treinos));
            }
            
        }

        private async void OnItemSelected(int treinoId)
        {
            await Navigation.PushAsync(new TreinoPage(_treinoRepository, treinoId),false);
        }
    }
}
