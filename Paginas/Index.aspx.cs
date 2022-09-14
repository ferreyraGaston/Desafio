using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DesafioRevista.Paginas
{

    public partial class Index : System.Web.UI.Page
    {
        string cCon = "Server=localhost;UserID=root;Database=revista_suscripcion;Password=13231414;";

        string DatosDni;
        protected void Page_Load(object sender, EventArgs e)
        {

            CargarTabla();
        }
        void CargarTabla()
        {
            using (var con = new MySqlConnection(cCon))
            {
                con.Open();
                using (var cmd = new MySqlCommand("SELECT IdAsociacion,Nombre,Apellido, Documento ,NumeroDocumento,FechaAlta FROM suscripcion L, suscriptor P, tipodocumento T WHERE L.IdAsociacion=P.idSuscriptor AND P.TipoDocumento=T.idTipodocumento AND P.idSuscriptor>0 ORDER BY P.idSuscriptor ASC", con))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);    
                    DataTable dt = new DataTable(); 
                    da.Fill(dt);
                    gvusuarios.DataSource = dt;
                    gvusuarios.DataBind();  
                    
                }
                con.Close();
            }
        }
        protected void btnRead_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar=(Button)sender;
            GridViewRow selectedrow= (GridViewRow)BtnConsultar.NamingContainer;
            id= selectedrow.Cells[1].Text;
            Response.Redirect("~/Paginas/Crud.aspx?id="+id+"&op=R");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Paginas/Crud.aspx?id=" + id + "&op=U");
        }

        protected void btnDelet_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Paginas/Crud.aspx?id=" + id + "&op=D");
        }

     

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbindexdni.Text!="")
            {
                BuscarDoc();
                BuscarTipoDoc();
                //tbindexdni.Text = "";
            }
            else
            {
                btnCreate1.Visible = false;
                lblBuscarDni.Visible = false;
              }

        }

        


        void BuscarDoc()
        {
            using (var con = new MySqlConnection(cCon))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT count(*) FROM suscriptor WHERE NumeroDocumento='" + tbindexdni.Text + "'", con))
                {
                    int dni = Convert.ToInt32(cmd.ExecuteScalar());
                    if (dni < 1)
                    {
                        btnCreate1.Visible = true;
                        lblBuscarDni.Visible = false;
                        String msg = "No se encuentra registrado, por favor Registrese";
                        ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "alert",
                            "alert('" + msg + "');Windows.location='Index.aspx';", true);
                    }
                    else
                    {
                        
                        btnCreate1.Visible = false;
                        lblBuscarDni.Visible = true;    
                        lblBuscarDni.Text = "El Usuario ya esta registrado";
                        BuscarTipoDoc();
                        
                        String msg = "El Usuario con "+DatosDni + ": " + tbindexdni.Text + " esta registrado";
                        ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "alert",
                            "alert('" + msg + "');Windows.location='Index.aspx';", true);
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
                using (MySqlCommand cmd = new MySqlCommand("SELECT Documento FROM suscriptor L, tipodocumento P WHERE L.TipoDocumento=P.idTipodocumento AND L.NumeroDocumento='" + tbindexdni.Text + "'", con))
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

        protected void btnCreate1_Click(object sender, EventArgs e)
        {
            MP.global = tbindexdni.Text;
            Response.Redirect("~/Paginas/Crud.aspx?op=C");
            
        }
    }
}