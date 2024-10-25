namespace jsingañaExanmen.Views;

public partial class Resumen : ContentPage
{
	public Resumen()
	{
		InitializeComponent();
	}

    public Resumen(string user ,string NomEstudiante, string apellido, string edad, string fecha, string ciudad, string pais, double montoInicial, double pagoMensual, double pagoTotal)
    {
        InitializeComponent();
        txtUsuario.Text = user;
        txtNombre.Text = NomEstudiante;
        txtApellido.Text = apellido;
        txtEdad.Text = edad;
        txtFecha.Text = fecha;
        txtCiudad.Text = ciudad;
        txtPais.Text = pais;
        txtMontoInicial.Text = montoInicial.ToString("F2");
        txtPagoMensual.Text = pagoMensual.ToString("F2");
        txtPagoTotal.Text = pagoTotal.ToString("F2");
    }
}