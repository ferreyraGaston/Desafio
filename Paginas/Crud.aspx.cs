using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DesafioRevista.Paginas
{
    
    public partial class Crud : System.Web.UI.Page
    {
        string cCon = "Server=localhost;UserID=root;Database=revista_suscripcion;Password=13231414;";
        string DatosDni;

        public static string sID = "-1";
        public static string sOpc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarDatos();
            // para que no se recarge la pagina
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"]!=null)
                {
                    sID= Request.QueryString["id"].ToString();
                    CargarDatos();
                }
                else
                {
                    TipoDoc();
                    tbdni.Text = MP.global;
                }
                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch(sOpc)
                    {
                        case "C":
                            this.lbltitulo.Text = "Ingresar nuevo Suscriptor";
                            this.btnCreate.Visible= true;
                            break;
                        case "D":
                            this.lbltitulo.Text = "Eliminar datos del Suscriptor";
                            this.btnDelete.Visible= true;
                            esconderDatos();
                            break;
                        case "U":
                            this.lbltitulo.Text = "Modificar datos del Suscriptor";
                            this.btnUpdate.Visible= true;   
                            break;
                        case "R":
                            this.lbltitulo.Text = "Consulta de datos del Suscriptor";
                            esconderDatos();
                            break;


                    }
                }
            }
        }
        void TipoDoc()
        {
            using (var con = new MySqlConnection(cCon))
            {
                con.Open();
                using (var cmd = new MySqlCommand("SELECT * FROM tipodocumento", con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        drop_TipoDocum.DataSource = reader;
                        drop_TipoDocum.DataValueField = "idTipodocumento";
                        drop_TipoDocum.DataTextField = "Documento";
                        drop_TipoDocum.DataBind();
                    }
                }
                con.Close();
            }
        }
        void BuscarTipoDoc()
        {
            using (var con = new MySqlConnection(cCon))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT Documento FROM suscriptor L, tipodocumento P WHERE L.TipoDocumento=P.idTipodocumento AND L.NumeroDocumento='" + tbdni.Text + "'", con))
                {


                    MySqlDataReader srd = cmd.ExecuteReader();

                    while (srd.Read())
                    {
                        DatosDni = srd.GetValue(0).ToString();
                    }
                }
                con.Close();
            }

        }
        void CargarDatos()
        {

            drop_TipoDocum.Visible= false;
            tbtipodni.Visible= true;
            using (var con = new MySqlConnection(cCon))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM suscriptor WHERE idSuscriptor='" + sID + "'", con))
                {
                    
                    
                    MySqlDataReader srd = cmd.ExecuteReader();

                    while (srd.Read())
                    {
                        tbnombre.Text = srd.GetValue(1).ToString();
                        tbapellido.Text = srd.GetValue(2).ToString();
                        tbdni.Text = srd.GetValue(3).ToString();
                        BuscarTipoDoc();
                        tbtipodni.Text = DatosDni;
                        tbdireccion.Text = srd.GetValue(5).ToString();
                        tbemail.Text = srd.GetValue(7).ToString();
                        tbtelefono.Text = srd.GetValue(6).ToString();
                        tbusuario.Text = srd.GetValue(8).ToString();
                        tbcontrasena.Text = srd.GetValue(9).ToString();
                        tbestado.Text = "Suscripto";
                    }
                }
                con.Close();
            }
        }

        void IngresarDatos()
        {
            string hashpass = sha256_hash(tbcontrasena.Text);
            DateTime fechahoy=DateTime.Now;
            using (var con = new MySqlConnection(cCon))
            {
                con.Open();
                MySqlCommand cmd2 = new MySqlCommand("insert into suscriptor (Nombre,Apellido,NumeroDocumento,TipoDocumento,Direccion,Telefono,Email,NombreUsuario,Contrasena) values  ('" + tbnombre.Text + "','" + tbapellido.Text + "','" + tbdni.Text + "', '" + drop_TipoDocum.Text + "','" + tbdireccion.Text + "','" + tbtelefono.Text + "','" + tbemail.Text + "','" + tbusuario.Text + "','" + hashpass + "');", con);
                cmd2.ExecuteNonQuery();
                MySqlCommand cmd3 = new MySqlCommand("INSERT INTO suscripcion (FechaAlta)value(@value);", con);
                cmd3.Parameters.AddWithValue("@value", fechahoy);
                cmd3.ExecuteNonQuery();
                con.Close();
            }
        }

        public static String sha256_hash(String value)
        {
            using (SHA256 hash= SHA256Managed.Create())
            {
                return String.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(value)).Select(item => item.ToString("x2")));

            }
        }
            void ActualizarDatos()
        {
            using (var con = new MySqlConnection(cCon))
            {
                con.Open();
                //int tipoDoc = Convert.ToInt32(tbtipodni.Text);
                MySqlCommand cmd2 = new MySqlCommand("UPDATE suscriptor SET Nombre='" + tbnombre.Text + "',Apellido='" + tbapellido.Text +"',Direccion='" + tbdireccion.Text +"',Telefono='" + tbtelefono.Text +"',Email='" + tbemail.Text +"',NombreUsuario='" + tbusuario.Text +"',Contrasena='" + tbcontrasena.Text +"' WHERE idSuscriptor='" + sID +"';", con);

                cmd2.ExecuteNonQuery();

                con.Close();
            }
        }

        void EliminarDatos()
        {
            using (var con = new MySqlConnection(cCon))
            {
                con.Open();
                MySqlCommand cmd2 = new MySqlCommand("DELETE FROM suscriptor WHERE idSuscriptor='" + sID + "';", con);
                cmd2.ExecuteNonQuery();
                MySqlCommand cmd3 = new MySqlCommand("DELETE FROM suscripcion WHERE IdAsociacion='" + sID + "';", con);
                cmd3.ExecuteNonQuery();
                con.Close();
            }
        }
        void LimpiarDatos()
        {
            tbnombre.Text = "";
            tbapellido.Text = "";
            tbdni.Text = "";
            tbtipodni.Text = "";
            tbdireccion.Text = "";
            tbemail.Text = "";
            tbtelefono.Text = "";
            tbusuario.Text = "";
            tbcontrasena.Text = "";
            tbestado.Text = "";
        }
        void esconderDatos()
        {
            tbnombre.Enabled = false;
            tbapellido.Enabled = false;
            tbdireccion.Enabled = false;
            tbemail.Enabled = false;
            tbtelefono.Enabled = false;
            tbusuario.Enabled = false;
            tbcontrasena.Enabled = false;
            tbestado.Enabled = false;
            btnCreate.Enabled = false;
        }

        void MostrarDatos()
        {
            tbnombre.Enabled = true;
            tbapellido.Enabled = true;
            tbdireccion.Enabled = true;
            tbemail.Enabled = true;
            tbtelefono.Enabled = true;
            tbusuario.Enabled = true;
            tbcontrasena.Enabled = true; 
            tbestado.Enabled = true;
            btnCreate.Enabled = true;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            IngresarDatos();

            if (tbnombre.Text==""|| tbapellido.Text == "" || tbdireccion.Text == "" || tbemail.Text == "" || tbtelefono.Text == "" || tbusuario.Text == "" || tbcontrasena.Text == "")
            {
                String msg = "Todos los cmpos deben estar completos..";
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('" + msg + "');Windows.location='Crud.aspx';", true);
            }
            else { 
            String msg = "El Usuario " + tbnombre.Text + " y la contraseña: "+ tbcontrasena.Text + " se registro con Exito";
            ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('" + msg + "');Windows.location='Crud.aspx';", true);

            esconderDatos();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ActualizarDatos();

           
            String msg = tbnombre.Text+":  Los datos han sido Modificado con Exito";
            ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('" + msg + "');Windows.location='Crud.aspx';", true);
           
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            EliminarDatos();

            String msg = "El Usuario: "+tbnombre.Text + " se elimino con Exito";
            ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('" + msg + "');Windows.location='Crud.aspx';", true);

            Response.Redirect("~/Paginas/Index.aspx");

        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Index.aspx");
        
        }

     
    }
}