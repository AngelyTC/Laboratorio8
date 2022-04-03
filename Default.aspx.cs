using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Laboratorio8
{
    public partial class _Default : Page
    {
       static List<jugadores> juga = new List<jugadores>();
       static List<ingresos> ingre = new List<ingresos>();
        //List<Ingresos1> ingre2 = new List<Ingresos1>();

        private void Leer1()
        {
            string fileName = Server.MapPath("~/jugadores1.txt");

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1) //el -1 significa la ultima linea que no existe demostrando el final del archivo
            {
                jugadores ju1 = new jugadores();
                ju1.NoJugador = Convert.ToInt32(reader.ReadLine());
                ju1.Nombre = reader.ReadLine();
                ju1.NombreEquipo = reader.ReadLine();
                //agregar a lista
                juga.Add(ju1);           
            }

            reader.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Leer1();
            cmbLista.DataValueField = "NoJugador";
            cmbLista.DataMember = "Nombre";

            cmbLista.DataSource = juga;
            cmbLista.DataBind();
        }

        private void Guardar1()
        {
            string fileName = Server.MapPath("~/Ingresos.txt");

            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var ingreso in ingre)
            {
                writer.WriteLine(ingreso.NoJugador);
                writer.WriteLine(ingreso.Fecha);
                writer.WriteLine(ingreso.NombreEquipo);
                writer.WriteLine(ingreso.Goles);
            }

            writer.Close();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ingresos ingresos2 = new ingresos();
            ingresos2.NoJugador = Convert.ToInt16(cmbLista.SelectedValue);
            ingresos2.Fecha = Calendar1.SelectedDate;
            ingresos2.NombreEquipo = txtEquipo.Text;
            ingresos2.Goles = Convert.ToInt32(txtGoles.Text);

            ingre.Add(ingresos2);
            Guardar1();
        }
    }
}