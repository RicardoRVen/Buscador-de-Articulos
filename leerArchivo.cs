using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Buscador_de_Articulos
{
    class leerArchivo
    {
        public static string rutaGenerada;

        public void lecturaArchivo(DataGridView tabla, char caracter, string ruta)
        {
            StreamReader objReader = new StreamReader(ruta);
            string sLine = "";
            int fila = 0;
            tabla.Rows.Clear();
            tabla.AllowUserToAddRows = false;

            do
            {
                sLine = objReader.ReadLine();
                if ((sLine != null))
                {
                    if (fila == 0)
                    {
                        tabla.ColumnCount = sLine.Split(caracter).Length;
                        nombrarTitulo(tabla, sLine.Split(caracter));
                        fila += 1;
                    }
                    else
                    {
                        agregarFilaDatagridview(tabla, sLine, caracter);
                        fila += 1;
                    }

                }
            }

            while (!(sLine == null));
            objReader.Close();
        }

        //Agregar el HeaderText al datagridview(SON LOS TITULOS)'
        public static void nombrarTitulo(DataGridView tabla, string[] titulos)
        {
            int x = 0;
            for (x = 0; x <= tabla.ColumnCount - 1; x++)
            {
                tabla.Columns[x].HeaderText = titulos[x];
            }
        }

        //Agrega una fila por cada linea de Bloc de notas :D'
        public static void agregarFilaDatagridview(DataGridView tabla, string linea, char caracter)
        {
            string[] arreglo = linea.Split(caracter);
            tabla.Rows.Add(arreglo);
        }



        public static void Escribe_datos(string sSruta)
        {

            //metodo que genera el archivo de texto Datos en la ruta de ejecucion del programa

            string gsPathGral = Path.GetDirectoryName(Application.ExecutablePath);


            StreamWriter write = new StreamWriter(gsPathGral + "\\ruta.txt");

            write.Write(sSruta);
          
            write.Close();
        }

        public static void Leer_datos()
        {
            string gsPathGral = Path.GetDirectoryName(Application.StartupPath);
          
            // metodo para leer los datos del archivo de texto datos .txt con el comando streamReader
            StreamReader reader = new StreamReader(gsPathGral + "\\ruta.txt");
        string sRuta= reader.ReadLine();
            reader.Close();
            rutaGenerada = sRuta;
            //return reader;
        }   
    }
}
