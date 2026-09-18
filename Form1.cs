#nullable disable
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConversorMonedas
{
    public partial class Form1 : Form
    {
        private TextBox txtMonto;
        private ComboBox cmbOrigen;
        private ComboBox cmbDestino;
        private Button btnConvertir;
        private Button btnLimpiar;
        private Label lblResultado;

        public Form1()
        {
            this.Text = "Conversor de Monedas";
            this.Size = new Size(350, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            Label lblMonto = new Label() { Text = "Monto:", Location = new Point(20, 20), AutoSize = true };
            txtMonto = new TextBox() { Location = new Point(120, 20), Width = 150 };

            Label lblOrigen = new Label() { Text = "De:", Location = new Point(20, 60), AutoSize = true };
            cmbOrigen = new ComboBox() { Location = new Point(120, 60), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblDestino = new Label() { Text = "A:", Location = new Point(20, 100), AutoSize = true };
            cmbDestino = new ComboBox() { Location = new Point(120, 100), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };

            string[] monedas = { "DOP", "USD", "EUR" };
            cmbOrigen.Items.AddRange(monedas);
            cmbDestino.Items.AddRange(monedas);
            cmbOrigen.SelectedIndex = 0;
            cmbDestino.SelectedIndex = 1;

            btnConvertir = new Button() { Text = "Convertir", Location = new Point(20, 150), Width = 120 };
            btnConvertir.Click += BtnConvertir_Click;

            btnLimpiar = new Button() { Text = "Limpiar", Location = new Point(150, 150), Width = 120 };
            btnLimpiar.Click += BtnLimpiar_Click;

            lblResultado = new Label() { Text = "Resultado: 0.00", Location = new Point(20, 200), AutoSize = true, Font = new Font("Arial", 11, FontStyle.Bold) };

            this.Controls.Add(lblMonto);
            this.Controls.Add(txtMonto);
            this.Controls.Add(lblOrigen);
            this.Controls.Add(cmbOrigen);
            this.Controls.Add(lblDestino);
            this.Controls.Add(cmbDestino);
            this.Controls.Add(btnConvertir);
            this.Controls.Add(btnLimpiar);
            this.Controls.Add(lblResultado);
        }

        private void BtnConvertir_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtMonto.Text, out double monto) || monto < 0)
            {
                MessageBox.Show("Por favor, ingrese un monto numérico válido.", "Monto inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string origen = cmbOrigen.SelectedItem.ToString();
            string destino = cmbDestino.SelectedItem.ToString();

            double resultado = Conversor.Convertir(monto, origen, destino);
            lblResultado.Text = $"Resultado: {resultado:N2} {destino}";
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtMonto.Clear();
            cmbOrigen.SelectedIndex = 0;
            cmbDestino.SelectedIndex = 1;
            lblResultado.Text = "Resultado: 0.00";
            txtMonto.Focus();
        }
    }
}
