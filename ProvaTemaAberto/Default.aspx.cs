using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProvaTemaAberto
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPais();
                LoadEstado(1);
                LoadCidade(1, 1);
            }
            
        }

        private void LoadCidade(int idE, int idP)
        {
            list_cidade.DataSource = new CidadeDB().All(idE, idP);
            list_cidade.DataTextField = "Descricao";
            list_cidade.DataValueField = "Id";
            list_cidade.DataBind();
        }

        protected void list_pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEstado(int.Parse(list_pais.SelectedValue));
        }
        protected void list_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCidade(int.Parse(list_estado.SelectedValue), int.Parse(list_pais.SelectedValue));
        }

        private void LoadEstado(int id)
        {
            list_estado.DataSource = new EstadoDB().All(id);
            list_estado.DataTextField = "Descricao";
            list_estado.DataValueField = "Id";
            list_estado.DataBind();
        }

        private void LoadPais()
        {
            list_pais.DataSource = new PaisDB().All();
            list_pais.DataTextField = "Descricao";
            list_pais.DataValueField = "Id";
            list_pais.DataBind();
        }

        protected void list_cidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

    }
}