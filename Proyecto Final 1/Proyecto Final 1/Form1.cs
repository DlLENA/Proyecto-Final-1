using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Microsoft.Office.Interop.Word;

namespace Proyecto_Final_1
{
    public partial class Form1 : Form 
    {

        string apiKey = "Clave de apikey";


        //campos 
        private int borderRadius = 30;
        private int borderSize = 2;
        private Color borderColor = Color.RoyalBlue;

        // Constructor
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle= FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
        }

        // Método para redondear los bordes del formulario
        [DllImport("user32.DLL",EntryPoint ="ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL",EntryPoint ="SendMessage")]
        private extern static void SendMenssage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; //Minimizar sin bordes desde la barra de tareas 
                return cp;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMenssage(this.Handle, 0x112, 0xF012, 0); //Mover el formulario
        }

        //Metodo para redondear los bordes del formulario
        private GraphicsPath GetRoundedPath(System.Drawing.Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void FormRegionAndBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            if (form.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(form.ClientRectangle, radius))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                using (Matrix transform = new Matrix())
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    form.Region = new Region(roundPath);
                    if (borderSize > 1)
                    {
                        System.Drawing.Rectangle rect = form.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);

                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);

                        graph.Transform = transform;
                        graph.DrawPath(penBorder, roundPath);
                    }
                }
            }
        }
   
        //Llamar los parametros del borde para el formulario
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private async Task<string> ConsultarGeminiFlash(string prompt)
        {
            string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent?key={apiKey}";

            var requestData = new
            {
                contents = new[]
                {
                    new {
                        parts = new[] {
                            new { text = prompt }
                        }
                    }
                }
            };

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);// para convertir el objeto a formato json

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");//para enviar el contenido en formato json
                var response = await client.PostAsync(url, content);// para enviar la peticion a la API
                var result = await response.Content.ReadAsStringAsync();// para leer la respuesta de la API

                if (response.IsSuccessStatusCode)
                {
                    var data = JObject.Parse(result);
                    return data["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString() ?? "Sin respuesta";// para obtener el texto de la respuesta
                }
                else
                {
                    throw new Exception($"Error en la API: {result}");
                }
            }
        }

        private async void btnInvestigar_Click_1(object sender, EventArgs e)
        {
            string tema = txtTema.Text;
            if (string.IsNullOrWhiteSpace(tema))
            {
                MessageBox.Show("Ingrese un tema.");
                return;
            }

            try
            {
                string respuesta = await ConsultarGeminiFlash(tema);
                txtResultado.Text = respuesta;

                GuardarInvestigacion(tema, tema, respuesta);// Guardar en la base de datos
                MessageBox.Show("Investigación guardada en la base de datos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void GuardarInvestigacion(string titulo, string prompt, string respuesta)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=Investigaciones; Integrated Security=True"))
           
            {
                conn.Open();// abrir la conexion a la base de datos
                string query = "INSERT INTO TEMAS (Titulo, Prompt, Respuesta) VALUES (@titulo, @prompt, @respuesta)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@titulo", titulo);
                    cmd.Parameters.AddWithValue("@prompt", prompt);
                    cmd.Parameters.AddWithValue("@respuesta", respuesta);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void CrearWord(string titulo, string contenido, string pie)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Document doc = wordApp.Documents.Add();
            wordApp.Visible = false;

            Paragraph titleParagraph = doc.Content.Paragraphs.Add();
            titleParagraph.Range.Text = titulo;
            titleParagraph.Range.Font.Bold = 1;// para poner el texto en negrita
            titleParagraph.Range.Font.Size = 15;
            titleParagraph.Format.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;// para alinear el titulo en el centro
            titleParagraph.Range.InsertParagraphAfter();

            Paragraph contentParagraph = doc.Content.Paragraphs.Add();
            contentParagraph.Range.Text = contenido;
            contentParagraph.Range.Font.Size = 12;
            contentParagraph.Format.Alignment = WdParagraphAlignment.wdAlignParagraphRight;// contenido se alinee a la derecha
            contentParagraph.Range.InsertParagraphAfter();
           
            doc.Words.Last.InsertBreak(WdBreakType.wdPageBreak);
            Paragraph footerParagraph = doc.Content.Paragraphs.Add();
            footerParagraph.Range.Text = pie;
            footerParagraph.Range.Font.Italic = 1;// para poner el texto en cursiva
            footerParagraph.Range.Font.Size = 10;
            footerParagraph.Format.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;// para alinear el pie de pagina en el centro         

            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "InvestigacionesIA", "Informe.docx");// para guardar el documento en la carpeta de documentos del usuario
            Directory.CreateDirectory(Path.GetDirectoryName(ruta));// para crear la carpeta si no existe
            doc.SaveAs2(ruta);// para guardar el documento

            doc.Close();// cerrar el documento
            wordApp.Quit();// para cerrar la aplicacion de word
            Marshal.ReleaseComObject(doc);// liberar el objeto de word
            Marshal.ReleaseComObject(wordApp);
        }

        //Para crear la presentacion en power point con le contenido de la base de datos 
        private void CrearPowerPoint(string titulo, string contenido)
        {
            var app = new Microsoft.Office.Interop.PowerPoint.Application();
            app.Visible = Microsoft.Office.Core.MsoTriState.msoTrue; 

            var pres = app.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoTrue); 
            var slide = pres.Slides.Add(1, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText);// para agregar una diapositiva con el diseño de texto


            slide.Shapes[1].TextFrame.TextRange.Text = titulo;
            slide.Shapes[2].TextFrame.TextRange.Text = contenido;

            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "InvestigacionesIA", "Presentacion.pptx");
            pres.SaveAs(ruta);
            pres.Close();
            app.Quit();// cerrar la aplicacion de power point
            Marshal.ReleaseComObject(pres);
            Marshal.ReleaseComObject(app);
        }

        private void btnGenerarword_Click(object sender, EventArgs e)
        {
            string titulo = txtTema.Text;
            string contenido = txtResultado.Text;
            if (string.IsNullOrWhiteSpace(contenido))
            {
                MessageBox.Show("No hay contenido para generar Word.");
                return;
            }

            CrearWord(titulo, contenido, "Generado automáticamente por la IA.");
            MessageBox.Show("Documento Word generado correctamente.");
        }

        private void btnGenerarPPT_Click(object sender, EventArgs e)
        {
            string titulo = txtTema.Text;
            string contenido = txtResultado.Text;
            if (string.IsNullOrWhiteSpace(contenido))
            {
                MessageBox.Show("No hay contenido para generar PowerPoint.");
                return;
            }

            CrearPowerPoint(titulo, contenido);
            MessageBox.Show("Presentación PowerPoint generada correctamente.");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtTema.Clear();//para limpiar el campo de texto
            txtResultado.Clear();//para limpiar el campo de texto de la respuesta
            txtTema.Focus();//para que el cursor se posicione en el campo de texto
        }       

    }
}



