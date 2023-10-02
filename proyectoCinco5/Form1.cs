using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoCinco5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Obtener datos de los Texbox
            string nombres = tbnombre.Text;
            string apellidos = tbapellido.Text;
            string edad = tbedad.Text;
            string estatura = tbestatura.Text;
            string telefono = tbtelefono.Text;

            //Obtener el genero seleccionado
            string genero = "";
            if (rbHombre.Checked)
            {
                genero = "Hombre";
            }
            else if (rbMujer.Checked)
            {
                genero = "Mujer";
            }
            //Crear una cadena de los datos
            string datos = $"Nombres:{nombres}\r\nApellidos: {apellidos}\r\ntelefono: {telefono} \r\nestatura: {estatura} mc\r\nedad: {edad} años\r\ngenero: {genero}";

            //Guardar los datos en un archivo de texto 
            string rutaArchivo = "C:/Users/rodo1/PRO/IZI.txt";
            //File.WriteAllText(rutaArchivo, datos);

            //Verificar si el archivo existe 
            bool archivoExiste = File.Exists(rutaArchivo); 
            //console.writeLine(ArchivoExiste);
            if(archivoExiste==false)
            {
                File.WriteAllText(rutaArchivo, datos);
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
                {
                    if (archivoExiste)
                    {
                        writer.WriteLine();
                    }

                    writer.WriteLine(datos);
                }
            }

            //mostrar mensajes con los datos capturados 
            MessageBox.Show("Datos guardados con exito:\n\n"+datos,"informacion",MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btborrar_Click(object sender, EventArgs e)
        {
            //Limpiar los controles despues de guardar 
           tbnombre.Clear();
           tbapellido.Clear();
           tbedad.Clear();
           tbestatura.Clear();
           tbtelefono.Clear();
            rbHombre.Checked = false;
            rbMujer.Checked = false;
        }
    }
}
