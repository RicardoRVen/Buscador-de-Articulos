using System.Windows.Forms;

namespace Buscador_de_Articulos
{
    class Mensajes
    {
        public static void Aviso(string sTexto)
        {
            MessageBox.Show(sTexto, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public static void Error(string sTexto)
        {
            MessageBox.Show(sTexto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public static bool Pregunta(string sTexto)
        {
            bool bRespuesta;
            DialogResult drRespuresta;

            drRespuresta = MessageBox.Show(sTexto, "Pregunta?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            bRespuesta = (drRespuresta == DialogResult.Yes);


            return bRespuesta;


        }

    }
}
