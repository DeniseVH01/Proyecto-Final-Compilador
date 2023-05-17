using Compilador.CompiladoresDataSet1TableAdapters;
using Compilador.CompiladoresDataSetTableAdapters;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsultaReporteLogsTableAdapter = Compilador.CompiladoresDataSet1TableAdapters.ConsultaReporteLogsTableAdapter;

namespace Compilador
{
    public partial class FRMCompilador : Form
    {
        private String token,caracter;
        private int estado = 0, posicion = 0, Direc = 0, DirPR = 0;
        private object[,] Matriz = new object[40, 40];
        private bool PR = false,errores;
        private OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
        private object[] VectorPalabrasReservadas;
        private bool verContrasena = false, verContrasenaR = false, verContrasenaRC = false;
        private bool? poder;
        private string preser, matz;
        private int? u;

        public FRMCompilador()
        {
           
            InitializeComponent();
            OpenFileDialog1 = new OpenFileDialog();            
            PBExportar.Image = Image.FromFile("..\\..\\Elementos\\enviar.png");
            PBVerContrasena.Image = Image.FromFile("..\\..\\Elementos\\ojo.png");
            PBVerContrasenaR.Image = Image.FromFile("..\\..\\Elementos\\ojo.png");
            PBVerContrasenaCR.Image = Image.FromFile("..\\..\\Elementos\\ojo.png");
            PBFiltrar.Image = Image.FromFile("..\\..\\Elementos\\filtrar.png");
            DGVSalida.Columns.Add("Token", "Token");
            DGVSalida.Columns.Add("Tipo", "Tipo");
            DGVSalida.Columns.Add("Directorio", "Directorio");
            this.usuarioTableAdapter.Fill(this.compiladoresDataSet1.Usuario);
            this.lenguajeTableAdapter.Fill(this.compiladoresDataSet1.Lenguaje);
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            PBExportar.Enabled = true;
            BTNCompilar.Enabled = true;
            LBEnteras.Items.Clear();
            DGVSalida.Rows.Clear();
            LBIden.Items.Clear();
            LBStr.Items.Clear();
            LBReal.Items.Clear();
            LBEntra.Items.Clear();
            string archivo;
            if (OpenFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            archivo = OpenFileDialog1.FileName;

            System.IO.StreamReader read = new StreamReader(archivo);
            String StringRead;

            while (!(read.EndOfStream))
            {
                StringRead = read.ReadLine();
                LBEntra.Items.Add(StringRead);
            }
}

        private void BuscaPalabraReservada()
        {
            int linea = 0;
            String palres;
            while (linea < VectorPalabrasReservadas.Length)
            {
                palres = VectorPalabrasReservadas[linea].ToString();

                if (palres.ToUpper() == token.ToUpper()) {
                    PR = true;
                    DirPR = linea + 1;
                }
                linea += 1;
            }
        }

        private void BuscaUnicas(System.Windows.Forms.ListBox txtU) {
            bool encontro;
            int renglon2;
             encontro = false;
             renglon2 = 0;
            while ((!encontro) && (renglon2 < txtU.Items.Count)) {
                txtU.SelectedIndex = renglon2;
                if (token.ToUpper() == txtU.Text.ToUpper()) {
                    encontro = true;
                    Direc = renglon2 + 1;
                }
                renglon2 = renglon2 + 1;
            }
            if (!encontro) {
                txtU.Items.Add(token);
                Direc = renglon2 + 1;
            }
        }
        private void ReconoceToken() {
            if (estado == 100) {
                errores = false;
                token = token + caracter;
                BuscaUnicas(LBStr);
                DGVSalida.Rows.Add(token, "Cte. String", Direc.ToString());
            }
            else if (estado == 101) {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " Comentario ", "");
            }
            else if (estado == 102) {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 103) {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 104) {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 105) {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 106) {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", ""); }
            else if (estado == 107) {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", ""); }
            else if (estado == 108) {
                errores = false;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
                posicion = posicion - 1; }
            else if (estado == 109)
            {
                errores = false;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
                posicion = posicion - 1; }
            else if (estado == 110)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", ""); }
            else if (estado == 112)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", ""); }
            else if (estado == 113)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", ""); }
            else if (estado == 114)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", ""); }
            else if (estado == 115)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", ""); }
            else if (estado == 116)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", ""); }
            else if (estado == 117 ){
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", ""); }
            else if (estado == 118) {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", ""); }
            else if (estado == 119 ){
                errores = false;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
                posicion = posicion - 1; }
            else if (estado == 120 ){
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", ""); }
            else if (estado == 121) {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", ""); }
            else if (estado == 122) {
                errores = false;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
                posicion = posicion - 1; }
            else if (estado == 123) {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 124) {
                errores = false;
                BuscaUnicas(LBReal);
                DGVSalida.Rows.Add(token, " Cte. Real ", Direc.ToString());
                posicion = posicion - 1; }
            else if (estado == 125) {
                errores = false;
                BuscaUnicas(LBEnteras);
                DGVSalida.Rows.Add(token, " Cte. Entera ", Direc.ToString());
                posicion = posicion - 1; }
            else if (estado == 126) {
                errores = false;
                posicion = posicion - 1;
                PR = false;
                BuscaPalabraReservada();
                if (PR == false) {
                    BuscaUnicas(LBIden);
                    DGVSalida.Rows.Add(token, "Ident.", Direc.ToString()); }
                else {
                    DGVSalida.Rows.Add(token, " PR. ", DirPR.ToString());
                }
            }
            else if (estado == 300) {
                errores = true;
                DGVSalida.Rows.Clear();
                MessageBox.Show("Expresión lógica erronea, se esperaba un &."); }
            else if (estado == 301) {
                errores = true;
                DGVSalida.Rows.Clear();
                MessageBox.Show("Identificador invalido, no puede iniciar con guión bajo."); }
            else if (estado == 302) {
                errores = true;
                DGVSalida.Rows.Clear();
                MessageBox.Show("Identificador invalido, puede iniciar solamente con una letra."); }
            else if (estado == 303) {
                errores = true;
                DGVSalida.Rows.Clear();
                MessageBox.Show("Expresión lógica invalida, se esperaba |."); }
            else if (estado == 304) {
                errores = true;
                DGVSalida.Rows.Clear();
                MessageBox.Show("Expresión lógica invalida, se esperaba =."); }
            else if (estado == 305) {
                errores = true;
                DGVSalida.Rows.Clear();
                MessageBox.Show("Identificador invalido, no puede iniciar con punto."); }
            else if (estado == 306) {
                errores = true;
                DGVSalida.Rows.Clear();
                MessageBox.Show("Identificador invalido, no puede terminar en guión bajo.");
            }
            }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogoGuardar = new SaveFileDialog();
            dialogoGuardar.Filter = "Archivos de texto (*.txt)|*.txt|Archivo de valores separados por comas de Microsoft Excel (*.csv)|*.csv|Hoja de cálculo de Microsoft Excel (*.xlsx)|*.xlsx";


            if (dialogoGuardar.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            if (dialogoGuardar.FilterIndex == 3) {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =(Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                int a = 2;
                hoja_trabajo.Cells[1, 1] = "Nombre";
                hoja_trabajo.Cells[1, 2] = "Usuario";
                hoja_trabajo.Cells[1, 3] = "Lenguaje";
                hoja_trabajo.Cells[1, 4] = "Archivo";
                hoja_trabajo.Cells[1, 5] = "Fecha_Hora";
                foreach (DataGridViewRow Fila in DGVReporte.Rows)
                {

                    if (Fila.Cells[0].Value != null)
                    {
                        
                        hoja_trabajo.Cells[a, 1] = Fila.Cells[0].Value.ToString();
                        hoja_trabajo.Cells[a, 2] = Fila.Cells[1].Value.ToString();
                        hoja_trabajo.Cells[a, 3] = Fila.Cells[2].Value.ToString();
                        hoja_trabajo.Cells[a, 4] = Fila.Cells[3].Value.ToString();
                        hoja_trabajo.Cells[a, 5] = Fila.Cells[4].Value.ToString();
                        a++;
                    }
                }
                libros_trabajo.SaveAs(dialogoGuardar.FileName);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
            else
            {
                String archivo = dialogoGuardar.FileName;
                StreamWriter sw = new StreamWriter(archivo);
                if (DGVReporte.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Fila in DGVReporte.Rows)
                    {

                        if (Fila.Cells[0].Value != null)
                        {
                            sw.WriteLine(Fila.Cells[0].Value.ToString() + ", " + Fila.Cells[1].Value.ToString() + ", " + Fila.Cells[2].Value.ToString() + ", " + Fila.Cells[3].Value.ToString() + ", " + Fila.Cells[4].Value.ToString());

                          }   }   }
                sw.Close();
            }}

        private void btnCompila_Click(object sender, EventArgs e)
        {
            PBExportar.Enabled = true;
            LBEnteras.Items.Clear();
            DGVSalida.Rows.Clear();
            LBIden.Items.Clear();
            LBStr.Items.Clear();
            LBReal.Items.Clear();
            token = "";
            estado = 0;
            posicion = 1;
            var renglon = 0;
            string items;
            string str = Console.ReadLine();
            int exporta = 0;
            while ((renglon < LBEntra.Items.Count))
            {
                LBEntra.SelectedIndex = renglon;
                items = LBEntra.SelectedItem.ToString();
                var longitud = Strings.Len(items);
                posicion = 1;
                while ((posicion <= longitud))
                {
                    caracter = Strings.Mid(items, posicion, 1);
                    estado = Convert.ToInt32(Matriz[estado, Columnas(caracter)]);
                    if (estado >= 100)
                    {
                        ReconoceToken();
                        estado = 0;
                        token = "";
                    }
                    else if (estado == 0)
                    {
                    }
                    else
                    {
                        token = token + caracter;
                    }
                    posicion = posicion + 1;
                    if (errores)
                    {
                        posicion = longitud + 1;
                        renglon = LBEntra.Items.Count;
                        exporta = 1;
                    }
                }
                if (estado != 4)
                {
                    estado = Convert.ToInt32(Matriz[estado, Columnas(" ")]);
                    ReconoceToken();
                    estado = 0;
                    token = "";
                }
                renglon = renglon + 1;
            }
            if (estado == 4)
            {
                DGVSalida.Rows.Clear();
                MessageBox.Show("Constante String invalida, se esperaba un '.");
                exporta = 1;
            }
            if (exporta == 0) {
                DateTime f = DateTime.Now;
                String archivo = Path.GetFullPath("..\\..\\Elementos\\ArchivosDeSalida\\") + "Output" + CBLenguaje.Text + TXTUsuario.Text + f.Day.ToString()
                    + f.Month.ToString() + f.Year.ToString() + "_" + f.Hour.ToString() + "-" +
                    f.Minute.ToString() + ".txt";

                StreamWriter sw = new StreamWriter(archivo);
                if (DGVSalida.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Fila in DGVSalida.Rows)
                    {

                        if (Fila.Cells["Token"].Value != null)
                        {
                            sw.WriteLine(Fila.Cells["Token"].Value.ToString() + ", " + Fila.Cells["Tipo"].Value.ToString() + ", " + Fila.Cells["Directorio"].Value.ToString());

                        }
                    }
                }
                sw.Close();
                MessageBox.Show(archivo + " exportado exitosamente");
                GBLenguaje.Enabled = false;
                GBLenguaje.Visible = false;
                GBCompilador.Enabled = false;
                GBCompilador.Visible = false;
                GBReporte.Visible = true;
                GBReporte.Enabled = true;
                query a = new query();
                a.GetUsuario(TXTUsuario.Text, ref u);
                a.InsertRegistroLog(u, (int?)CBLenguaje.SelectedValue, f, ("Output" + CBLenguaje.Text + TXTUsuario.Text + f.Day.ToString()
                    + f.Month.ToString() + f.Year.ToString() + "_" + f.Hour.ToString() + "-" +
                    f.Minute.ToString() + ".txt"));
                consultaReporteLogsTableAdapter.Fill(compiladoresDataSet1.ConsultaReporteLogs, null, null, null, null);
            }

        }
        private void LeeMatrizEstados(string archivo)
        {
            string renglon;
            string[] datosRenglon;
            StreamReader Lector = new StreamReader(archivo);
            int r = 0;
            while (!Lector.EndOfStream)
            {
                renglon = Lector.ReadLine();
                datosRenglon = renglon.Split(',');
                for (var c = 0; c <= datosRenglon.Length - 1; c++)
                    Matriz[r, c] = datosRenglon[c];
                r += 1;
            }
        }
        
        private void LeePalabrasReservadas(string archivo)
        {
            string renglon;   
            StreamReader Lector = new StreamReader(archivo);
            renglon = Lector.ReadLine();
            VectorPalabrasReservadas = renglon.Split(',');
        }

        private int Columnas(string cara)
        {
            int col;

            if ((Strings.Asc(cara) >= 65 & Strings.Asc(cara) <= 90) | (Strings.Asc(cara) >= 97 & Strings.Asc(cara) <= 122))
                col = 0;
            else if ((Strings.Asc(cara) >= 48 & Strings.Asc(cara) <= 57))
                col = 1;
            else if (cara == "'")
                col = 2;
            else if (cara == "/")
                col = 3;
            else if (cara == "+")
                col = 4;
            else if (cara == "-")
                col = 5;
            else if (cara == "#")
                col = 6;
            else if (cara == "=")
                col = 7;
            else if (cara == "<")
                col = 8;
            else if (cara == ">")
                col = 9;
            else if (cara == @"\")
                col = 10;
            else if (cara == "$")
                col = 11;
            else if (cara == "&")
                col = 12;
            else if (cara == ";")
                col = 13;
            else if (cara == ".")
                col = 14;
            else if (cara == "(")
                col = 15;
            else if (cara == ")")
                col = 16;
            else if (cara == ",")
                col = 17;
            else if (cara == "^")
                col = 18;
            else if (cara == "|")
                col = 19;
            else if (cara == "!")
                col = 20;
            else if (cara == "*")
                col = 21;
            else if (cara == "_")
                col = 22;
            else if (cara == " ")
                col = 23;
            else
                col = 24;
            return col;
        }

        private void VerContraseña_Click(object sender, EventArgs e)
        {
            if (verContrasena)
            {
                verContrasena = false;
                PBVerContrasena.Image = Image.FromFile("..\\..\\Elementos\\ojo.png");
                TXTContrasena.PasswordChar = '*';
            }
            else {
                verContrasena = true;
                PBVerContrasena.Image = Image.FromFile("..\\..\\Elementos\\invisible.png");
                TXTContrasena.PasswordChar = (char)0;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            query a = new query();
            a.GetMatriz(Convert.ToInt32(CBLenguaje.SelectedValue),ref matz, ref preser);
            GBLenguaje.Visible=true;
            GBCompilador.Enabled = true;
            LeeMatrizEstados("..\\..\\Elementos\\"+matz);
            LBPalabrasR.Items.Clear();
            LeePalabrasReservadas("..\\..\\Elementos\\"+preser);
            for (var i = 0; i <= VectorPalabrasReservadas.Length - 1; i++)
                LBPalabrasR.Items.Add(VectorPalabrasReservadas[i] + "");

        }

        private void btnVerConfirmar_Click(object sender, EventArgs e)
        {
            if (verContrasenaRC)
            {
                verContrasenaRC = false;
                PBVerContrasenaCR.Image = Image.FromFile("..\\..\\Elementos\\ojo.png");
                TXTCContrasenaRegistro.PasswordChar = '*';
            }
            else
            {
                verContrasenaRC = true;
                PBVerContrasenaCR.Image = Image.FromFile("..\\..\\Elementos\\invisible.png");
                TXTCContrasenaRegistro.PasswordChar = (char)0;
            }
        }

        private void btnVerContraNueva_Click(object sender, EventArgs e)
        {
            if (verContrasenaR)
            {
                verContrasenaR = false;
                PBVerContrasenaR.Image = Image.FromFile("..\\..\\Elementos\\ojo.png");
                TXTContrasenaRegistro.PasswordChar = '*';
            }
            else
            {
                verContrasenaR = true;
                PBVerContrasenaR.Image = Image.FromFile("..\\..\\Elementos\\invisible.png");
                TXTContrasenaRegistro.PasswordChar = (char)0;
            }
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            query a = new query();
            a.ValidarContraseña(Encriptado(TXTContrasena.Text), TXTUsuario.Text,ref poder);
            if (poder == false) {
                MessageBox.Show("Acceso Denegado");
                TXTUsuario.Clear();
                TXTContrasena.Clear();
            }
            else
            {
                TXTContrasena.Clear();
                GBLogin.Enabled = false;
                GBLogin.Visible = false;
                GBRegistro.Enabled = false;
                GBRegistro.Visible = false;
                GBLenguaje.Visible = true;
                GBLenguaje.Enabled = true;
                GBCompilador.Visible = true;
            }
        }
        private string Encriptado(string co) {
            
                using (var sha256 = new SHA256Managed())
                {
                    return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(co))).Replace("-", "");
                }
            
     }

        private void btnRegistraNuevo_Click(object sender, EventArgs e)
        {
            query a = new query();
            a.UsuarioExistente(TXTNombreRegistro.Text, TXTUsuarioRgistro.Text, Encriptado(TXTContrasenaRegistro.Text), TXTCorreoRegistro.Text, TXTTelefono.Text, ref poder);
            if (poder == true)
            {
                MessageBox.Show("Usuario registrado correctamente");
                TXTUsuario.Clear();
                TXTContrasena.Clear();
                TXTNombreRegistro.Clear();
                TXTUsuarioRgistro.Clear();
                TXTTelefono.Clear();
                TXTContrasenaRegistro.Clear();
                TXTCContrasenaRegistro.Clear();
                TXTCorreoRegistro.Clear();
            }
            else {
                MessageBox.Show("Usuario existente");
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (TXTTelefono.Text.Length > 10) {
                MessageBox.Show("Ingrese un teléfono valido");
            }
            else {
                foreach (char a in TXTTelefono.Text){
                    if (!(a > 47 && a < 58)) {
                        MessageBox.Show("Ingrese un teléfono valido");
                        break;
                    }
                } 
            }
        }

        private void CHBusuario_CheckedChanged(object sender, EventArgs e)
        {
            if (CHBUsuario.Checked)
            {
                CBFiltroUsuario.Enabled = true;
            }
            else
            {
                CBFiltroUsuario.Enabled = false;
            }
        }

        private void CHBlenguaje_CheckedChanged(object sender, EventArgs e)
        {
            if (CHBLenguaje.Checked)
            {
                CBFiltroLenguaje.Enabled = true;

            }
            else
            {
                CBFiltroLenguaje.Enabled = false;
            }
        }

        private void CHBfInicio_CheckedChanged(object sender, EventArgs e)
        {
            if (CHBFInicio.Checked)
            {
                DTFechaIn.Enabled = true;

            }
            else
            {
                DTFechaIn.Enabled = false;
            }
        }

        private void CHBfFinal_CheckedChanged(object sender, EventArgs e)
        {
            if (CHBFFinal.Checked)
            {
                DTFechaFin.Enabled = true;

            }
            else
            {
                DTFechaFin.Enabled = false;
            }
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            CBLenguaje.SelectedIndex = 0;
            GBLenguaje.Enabled = true;
            LBPalabrasR.Items.Clear();
        }

        private void PBfiltrar_Click(object sender, EventArgs e)
        {
            int? usu = null;
            int? l = null;
            DateTime? i = null;
            DateTime? fi = null;
            if (CHBUsuario.Checked)
            {
                usu = (int?)CBFiltroUsuario.SelectedValue;
            }
            if (CHBLenguaje.Checked)
            {
                l = (int?)CBFiltroLenguaje.SelectedValue;

            }
            if (CHBFInicio.Checked)
            {
                i = (DateTime?)DTFechaIn.Value;

            }
            if (CHBFFinal.Checked)
            {
                fi = (DateTime?)DTFechaFin.Value;

            }
            consultaReporteLogsTableAdapter.Fill(compiladoresDataSet1.ConsultaReporteLogs, usu, l, i, fi);
        }
    }
}
