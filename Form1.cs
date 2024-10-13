using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace ArquitecturaDelComputador
{
    public partial class Form1 : Form
    {
        SerialPort ArduinoUno;
        int intentosFallidos = 0;

        public Form1()
        {
            InitializeComponent();
            ArduinoUno = new SerialPort();

            ArduinoUno.PortName = "COM6";
            ArduinoUno.BaudRate = 9600;
            ArduinoUno.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            try
            {
                ArduinoUno.Open();
                progressBar1.Maximum = 100;  // Establece el valor máximo del ProgressBar
                progressBar1.Value = 0;      // Inicializa el ProgressBar en 0
                MessageBox.Show("Puerto COM abierto correctamente.");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Acceso denegado al puerto COM. Ejecuta como administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el puerto COM: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para recibir datos del Arduino
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string data = ArduinoUno.ReadLine();

            this.Invoke(new Action(() =>
            {
                MessageBox.Show($"Datos recibidos: {data}");  // Depuración

                if (data.Contains("Contraseña incorrecta"))
                {
                    // Si el dato recibido contiene el número de intentos fallidos
                    string[] parts = data.Split(':');
                    if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int intentosArduino))
                    {
                        intentosFallidos = intentosArduino;  // Actualiza los intentos fallidos con el dato del Arduino
                        progressBar1.Value = Math.Min(intentosFallidos * 25, 100);  // Actualiza el ProgressBar
                        MessageBox.Show($"Intentos fallidos: {intentosFallidos}, Progreso: {progressBar1.Value}%");  // Depuración
                    }
                }
                else if (data.Contains("Contraseña correcta"))
                {
                    intentosFallidos = 0;
                    progressBar1.Value = 0;  // Restablece el progreso si la contraseña es correcta
                }
            }));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ArduinoUno.IsOpen)
            {
                ArduinoUno.Close();
                MessageBox.Show("Puerto COM cerrado correctamente.");
            }
        }
        private void EnviarDatosSiCompleto()
        {
            if (textBoxPassword.Text.Length == 4)
            {
                ArduinoUno.Write(textBoxPassword.Text);  // Envía los 4 dígitos al Arduino
                MessageBox.Show($"Enviando contraseña: {textBoxPassword.Text}");  // Depuración: muestra lo que envías
                textBoxPassword.Clear();  // Limpia el campo para el siguiente ingreso
            }
        }

        // Eventos para botones de números y letras
        private void btn1_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text += "*";
            ArduinoUno.Write("1");
            EnviarDatosSiCompleto();
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text += "*";
            ArduinoUno.Write("2");
            EnviarDatosSiCompleto();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text += "*";
            ArduinoUno.Write("3");
            EnviarDatosSiCompleto();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text += "*";
            ArduinoUno.Write("A");
            EnviarDatosSiCompleto();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text += "*";
            ArduinoUno.Write("4");
            EnviarDatosSiCompleto();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text += "*";
            ArduinoUno.Write("5");
            EnviarDatosSiCompleto();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text += "*";
            ArduinoUno.Write("6");
            EnviarDatosSiCompleto();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text += "*";
            ArduinoUno.Write("7");
            EnviarDatosSiCompleto();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text += "*";
            ArduinoUno.Write("8");
            EnviarDatosSiCompleto();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text += "*";
            ArduinoUno.Write("9");
            EnviarDatosSiCompleto();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text += "*";
            ArduinoUno.Write("0");
            EnviarDatosSiCompleto();
        }

        private void btn_michi_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text += "*";
            ArduinoUno.Write("*");
            EnviarDatosSiCompleto();
        }

        private void btn_numeral_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text += "*";
            ArduinoUno.Write("#");
            EnviarDatosSiCompleto();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text += "*";
            ArduinoUno.Write("C");
            EnviarDatosSiCompleto();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text += "*";
            ArduinoUno.Write("D");
            EnviarDatosSiCompleto();
        }

        private void btnB_Click_1(object sender, EventArgs e)
        {
            textBoxPassword.Text += "*";
            ArduinoUno.Write("B");
            EnviarDatosSiCompleto();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Opcional: código que quieras ejecutar al cargar el formulario
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            // Opcional: código que quieras ejecutar al interactuar con el ProgressBar
        }

    }
}