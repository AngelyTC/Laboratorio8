using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Laboratorio8
{
    public partial class Contact : Page
    {
        static List<jugadores> juga = new List<jugadores>();
        static List<ingresos> ingre = new List<ingresos>();
       static List<datosJugador> ingre3 = new List<datosJugador>();
        protected void Page_Load(object sender, EventArgs e)
        {
          
         
            
        }
        private void Leerjugador()
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
        private void LeerIngreso()
        {
            string fileName = Server.MapPath("~/Ingresos.txt");
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1) //el -1 significa la ultima linea que no existe demostrando el final del archivo
            {
               ingresos dato1 = new ingresos();
                dato1.NoJugador = Convert.ToInt16(reader.ReadLine());
                dato1.Fecha = Convert.ToDateTime(reader.ReadLine());
                dato1.NombreEquipo = reader.ReadLine();
                dato1.Goles = Convert.ToInt32(reader.ReadLine());
                //agregar a lista
                ingre.Add(dato1);
            }

            reader.Close();
        }
        protected void btnCargar_Click(object sender, EventArgs e)
        {
            Leerjugador();
            LeerIngreso();

            for (int i = 0; i < ingre.Count; ++i)
            {
                
                for (int j = 0; j < juga.Count; j++)
                {
                    if (ingre[i].NoJugador == juga[j].NoJugador)
                    {
                        datosJugador mostrar2 = new datosJugador();
                        mostrar2.Nombre = juga[j].Nombre;
                        mostrar2.Goles = ingre[i].Goles;
                        ingre3.Add(mostrar2);
                    }
                }
                

                ingre3 = ingre3.OrderByDescending(n => n.Goles).ToList();
                GridView1.DataSource = ingre3;
                GridView1.DataBind();

                var totalTemp = ingre3.Sum(x => x.Goles);
                for (int k = 0; k < ingre3.LongCount(); k++)
                {
                    Label1.Text = (totalTemp / ingre.LongCount()).ToString();
                }

            }
        }
    }
}