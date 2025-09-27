using Gym.Repository;

namespace Gym
{
    public partial class AppShell : Shell
    {
        private readonly TreinoRepository _treinoDb;
        public AppShell(TreinoRepository treinoDb)
        {
            InitializeComponent();
            _treinoDb = treinoDb;

            // Registrar rota para TreinoPage
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(TreinoPage), typeof(TreinoPage));
        }
    }
}
