using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTextoCifrado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnCifrado_Click(object sender, EventArgs e)
        {
            string texto;
            try
            {
                texto = txtTexto.Text;
                var DLL = new DLLCifrado.ClaseCifrado();
                txtCifrado.Text = DLL.Cifrado(texto);
            }
            catch (Exception ex)
            {
                txtTexto.Text = ex.Message;
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string Usuario;
            string Contraseña;
            try
            {
                Usuario = txtUsuario.Text;
                Contraseña = txtCifrado.Text;
                var DLL = new DLLCifrado.ClaseCifrado();
                if (DLL.Guardar(Usuario,Contraseña))
                    MessageBox.Show("Guardado Correctamente");
                else
                    MessageBox.Show("No Guardado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
