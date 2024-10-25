namespace jsingañaExanmen.Views;

public partial class Login : ContentPage
{
    // Matriz para almacenar usuarios y contraseñas
    string[,] credenciales = {
        { "estudiante", "moviles" },
        { "uisrael", "2024" }
    };

    public Login()
	{
		InitializeComponent();
	}

    private void btnIniciar_Clicked(object sender, EventArgs e)
    {
        
        string usuarioIngresado = txtUsuario.Text;
        string contraseñaIngresada = txtContrasena.Text;

       
        bool usuarioValido = false;

        
        for (int i = 0; i < credenciales.GetLength(0); i++)  
        {
            if (usuarioIngresado == credenciales[i, 0] && contraseñaIngresada == credenciales[i, 1])
            {
                usuarioValido = true;
                
                DisplayAlert("Bienvenido", $"Bienvenido, {credenciales[i, 0]}", "OK");

       
                Navigation.PushAsync(new Views.Registro(credenciales[i, 0]));
                break;
            }
        }

        
        if (!usuarioValido)
        {
            DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
        }

    }
}