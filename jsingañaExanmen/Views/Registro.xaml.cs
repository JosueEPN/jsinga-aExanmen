namespace jsingañaExanmen.Views;

public partial class Registro : ContentPage
{
	string user;
    double costoCurso = 1500.00;

    double GloMontoInicial;
    double GloCuotaMensual;
    double GloPagoTotal;

    public Registro()
	{
		InitializeComponent();
	}

    public Registro(string nombre)
    {
        InitializeComponent();
        user = nombre;
        txtUsuario.Text = user;
    }

    private void btn_calcularMonto_Clicked(object sender, EventArgs e)
    {
        
        string montoInicialTexto = montoInicialEntry.Text;

        if (string.IsNullOrWhiteSpace(montoInicialTexto) || !double.TryParse(montoInicialTexto, out double montoInicial))
        {
            DisplayAlert("Error", "Ingrese un monto inicial válido (solo números).", "OK");
            return;
        }

        if (montoInicial < 1 || montoInicial >= costoCurso)
        {
            DisplayAlert("Error", "El monto inicial debe ser mayor a $1 y menor a $1500.", "OK");
            return;
        }

        double restante = costoCurso - montoInicial;
        double cuotaMensual = (restante / 4) * 1.04;
        pagoMensualEntry.Text = cuotaMensual.ToString("F2");

        double pagoTotal = montoInicial + (cuotaMensual * 4);

        GloCuotaMensual = cuotaMensual;
        GloMontoInicial = montoInicial;
        GloPagoTotal = pagoTotal;

      


    }

    private void btn_Resume_Clicked(object sender, EventArgs e)
    {
        string NomEstudiante = txtNombre.Text;
        string apellido = txtApellido.Text;
        string edad = txtEdad.Text;
        string fecha = fechaPicker.Date.ToString("yyyy-MM-dd");
        string pais = paisPicker.SelectedIndex != -1 ? paisPicker.Items[paisPicker.SelectedIndex] : string.Empty;
        string ciudad = ciudadPicker.SelectedIndex != -1 ? ciudadPicker.Items[ciudadPicker.SelectedIndex] : string.Empty;

        if (string.IsNullOrWhiteSpace(NomEstudiante))
        {
            DisplayAlert("Error", "Por favor, ingrese el nombre del estudiante.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(apellido))
        {
            DisplayAlert("Error", "Por favor, ingrese el apellido del estudiante.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(edad))
        {
            DisplayAlert("Error", "Por favor, ingrese la edad del estudiante.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(fecha))
        {
            DisplayAlert("Error", "Por favor, seleccione una fecha.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(pais))
        {
            DisplayAlert("Error", "Por favor, seleccione un país.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(ciudad))
        {
            DisplayAlert("Error", "Por favor, seleccione una ciudad.", "OK");
            return;
        }

        
        Navigation.PushAsync(new Resumen(user, NomEstudiante, apellido, edad, fecha, pais, ciudad, GloMontoInicial, GloCuotaMensual, GloPagoTotal));
    }

}