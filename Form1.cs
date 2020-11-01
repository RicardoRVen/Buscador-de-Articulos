using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buscador_de_Articulos
{
    public partial class Form1 : Form
    {
        //Instancia de la clase Leer
        leerArchivo leer = new leerArchivo();
        //Alamcena la ruta del archivo .txt
        public string sArchivo = "";
        public string sRuta = "";
        public string sfila = "";
        public string sValor = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            txtBuscar.CharacterCasing = CharacterCasing.Upper;

            leerArchivo.Leer_datos();
           lblRuta.Text= leerArchivo.rutaGenerada;
            leer.lecturaArchivo(dataGridView1, '	', leerArchivo.rutaGenerada); 
        }

        //Abre el openFileDialog y captura la ruta del bloc de notas
        public void cargarArchivo()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.Filter = "Archivos txt |*.csv";
                ofd.ShowDialog();
                sRuta= ofd.FileName;

                lblRuta.Text = sRuta;

                leerArchivo.Escribe_datos(sRuta);

                if (!string.IsNullOrEmpty(ofd.FileName))
                {
                    sArchivo = ofd.FileName;
                   
                    //Hacemos instancia a la clase para llenar el datagrid pasandole los argumentos
                    leer.lecturaArchivo(dataGridView1, '	', sArchivo);

                }

            }
            catch (Exception )
            {
                Mensajes.Error("Verifica que el archivo tenga el formato correcto");
            }
        }

       
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            cargarArchivo();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
            dataGridView1.CurrentCell= dataGridView1.Rows[0].Cells[0];

            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                sfila = Row.Index.ToString();
                sValor = Convert.ToString(Row.Cells[0].Value);
                dataGridView1.Rows[Convert.ToInt16(sfila)].DefaultCellStyle.BackColor = Color.White;
                if (sValor == this.txtBuscar.Text)
                {
                    dataGridView1.Rows[Convert.ToInt16(sfila)].DefaultCellStyle.BackColor = Color.Yellow;
                    dataGridView1.CurrentCell = dataGridView1.Rows[Convert.ToInt16(sfila)].Cells[0];

                }
                else
                {
                    dataGridView1.Rows[Convert.ToInt16(sfila)].DefaultCellStyle.BackColor = Color.White;
             
                }
              
            }
          
        }

        private void chkMayus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMayus.Checked )
            {
                txtBuscar.CharacterCasing = CharacterCasing.Upper;

            }else
            {
                txtBuscar.CharacterCasing = CharacterCasing.Lower;
            }
        }
    }
}
