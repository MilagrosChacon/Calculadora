using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class FormCalculadora : Form
    {
        double Numero1 = 0, Numero2 = 0;
        char Operador;

        public FormCalculadora()
        {
            InitializeComponent();
        }

        // Función que responde a todos los buttons
        private void agregarNumero(object sender, EventArgs e)
        {
            // Se crea una variable para castear el button y así acceder a las propiedades
            var boton = ((Button)sender); 

            // Modificar el cero cuando se escribe otro número. Si es igual a cero, se vacía
            if (txtResultado.Text == "0") 
                txtResultado.Text = ""; 

            // Y agrega el número
            txtResultado.Text += boton.Text;
        }

        //Función para almacenar el número en la variable Numero1 y guardar el operador de acuerdo al texto que tenga el button 
        private void clickOperador(object sender, EventArgs e)
        {
            // Obtener el button
            var boton = ((Button)sender);

            // Almacenar el texto del resultado en la variable
            Numero1 = Convert.ToDouble(txtResultado.Text);
            Operador = Convert.ToChar(boton.Tag);

            // Elevar al cuadrado 
            if (Operador == '²')
            {
                // La función pow recibe el número y se especifica en los parametros el número a elevar y a cuanto
                Numero1 = Math.Pow(Numero1, 2); 
                txtResultado.Text = Numero1.ToString(); 
            }
            // Raíz cuadrada 
            else if (Operador == '√') 
            {
                // Sqrt (raíz cuadrada) recibe el número y en el parametro se especifica a cuanto
                Numero1 = Math.Sqrt(Numero1); 
                txtResultado.Text = Numero1.ToString();
            }
            // Para que el resto de los operadores continúe de forma normal
            else
            {
                txtResultado.Text = "0";
            }
        }

        // Borrar el último caracter 
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            // Si el resultado es mayor a uno
            if (txtResultado.Text.Length > 1) 
            {
                // Quita el último caracter
                txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length - 1);
            }
            else
            {
                txtResultado.Text = "0";
            }
        }

        // Borrar todo
        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            Numero1 = 0;
            Numero2 = 0;
            Operador = '\0';
            txtResultado.Text = "0";
        }

        // Borrar lo último escrito
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
        }

        // Decimal
        private void btnPunto_Click(object sender, EventArgs e)
        {
            // Se deja como coma en lugar de punto para poder realizar el calculo
            if (!txtResultado.Text.Contains(","))
            {
                txtResultado.Text += ",";
            }
        }

        // Signo mas/menos 
        private void btnSigno_Click(object sender, EventArgs e)
        {
            Numero1 = Convert.ToDouble(txtResultado.Text);
            //Se multiplica el número por -1 
            Numero1 *= -1;
            txtResultado.Text = Numero1.ToString();
        }

        // Resultado
        private void btnIgual_Click(object sender, EventArgs e)
        {
            Numero2 = Convert.ToDouble(txtResultado.Text);

            // SUMA
            if (Operador == '+')
            {
                // Almacena el texto 
                txtResultado.Text = (Numero1 + Numero2).ToString(); 
                // Almacena el resultado
                Numero1 = Convert.ToDouble(txtResultado.Text);

            }
            // RESTA
            else if (Operador == '-')
            {
                txtResultado.Text = (Numero1 - Numero2).ToString();
                Numero1 = Convert.ToDouble(txtResultado.Text);
            }
            // MULTIPLICACIÓN
            else if (Operador == '*')
            {
                txtResultado.Text = ((float)Numero1 * (float)Numero2).ToString();
                Numero1 = Convert.ToDouble(txtResultado.Text);
            }
            // DIVISIÓN
            else if (Operador == '∕')
            {
                // En caso de que se intente dividir por cero
                if (Numero2 != 0)
                {
                    txtResultado.Text = (Numero1 / Numero2).ToString();
                }
                else
                {
                    txtResultado.Text = "Error";
                    MessageBox.Show("No es posible dividir por cero");
                }
            }
        }
    }
}
