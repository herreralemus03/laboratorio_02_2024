using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public class Program
    {
        static int longitud = 2;
        private static TextBox[] nombresInput;
        private static TextBox[] apellidosInput;
        private static Persona[] personas;
        
        private static Button buttonPrint;

        [STAThread]
        static void Main()
        {
            var form1 = new Form();
            nombresInput = new TextBox[longitud];
            apellidosInput = new TextBox[longitud];
            personas = new Persona[longitud];

            int initialPostion = 30;
            for (int i = 0; i < longitud; i++)
            {
                initialPostion += 50;
                personas[i] = new Persona();

                var nombreLabel = new System.Windows.Forms.Label();
                form1.Controls.Add(nombreLabel);
                nombreLabel.Location = new System.Drawing.Point(30, initialPostion);
                nombreLabel.Text = $"Nombre {i + 1}";

                initialPostion += 50;
                var nombreInput = new TextBox();
                nombreInput.Location = new System.Drawing.Point(30, initialPostion);
                nombreInput.Name = "txtNombre";
                nombreInput.Size = new System.Drawing.Size(150, 20);
                nombreInput.TabIndex = i;
                nombresInput[i] = nombreInput;
                form1.Controls.Add(nombreInput);

                initialPostion += 50;

                var apellidoLabel = new System.Windows.Forms.Label();
                apellidoLabel.Location = new System.Drawing.Point(30, initialPostion);
                form1.Controls.Add(apellidoLabel);
                apellidoLabel.Text = $"Apellido {i+1}";

                initialPostion += 50;
                var apellidoInput = new TextBox();
                apellidoInput.Location = new System.Drawing.Point(30, initialPostion);
                apellidoInput.Name = "txtNombre";
                apellidoInput.Size = new System.Drawing.Size(150, 20);
                apellidoInput.TabIndex = i+1;
                apellidosInput[i] = apellidoInput;
                form1.Controls.Add(apellidoInput);

            }

            buttonPrint = new Button();
            buttonPrint.Location = new System.Drawing.Point(30, initialPostion + 50);
            buttonPrint.Text = "Imprimir";
            buttonPrint.Size = new System.Drawing.Size(150, 20);
            buttonPrint.TabIndex = 2;
            buttonPrint.Click += new System.EventHandler(PrintInputs);
            form1.Controls.Add(buttonPrint);


            Application.EnableVisualStyles();
            Application.Run(form1);
        }


        private static void PrintInputs(object sender, EventArgs e)
        {

            for (int i = 0; i < longitud; i++)
            {
                personas[i].nombre = nombresInput[i].Text;
                personas[i].apellido = apellidosInput[i].Text;
            }
            
            var newPersonas = personas.OrderBy(a => a.nombre);

            foreach (var persona in newPersonas)
            {
                MessageBox.Show($"{persona.nombre} {persona.apellido}");
            }

        }
    }
}
