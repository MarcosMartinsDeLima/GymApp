using Gym.Models;
using Gym.Repository;

namespace Gym
{
    public partial class App : Application
    {
        private readonly TreinoRepository _treinoDb;
        public App(TreinoRepository treinoDb)
        {
            InitializeComponent();
            _treinoDb = treinoDb;

            _ = InitialSeed.AplicarSeed(treinoDb);

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell(_treinoDb));
        }

    }
}