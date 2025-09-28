using CommunityToolkit.Maui.Views;

namespace Gym.View;

public partial class AlterarPesoPopup : Popup
{
    private readonly int _exercicioId;

    public AlterarPesoPopup(int exercicioId)
    {
        InitializeComponent();
        _exercicioId = exercicioId;
    }

    private void Cancelar_Clicked(object sender, EventArgs e)
    {
        Close(null);
    }

    private void Confirmar_Clicked(object sender, EventArgs e)
    {
        Close(PesoEntry.Text);

    }
}