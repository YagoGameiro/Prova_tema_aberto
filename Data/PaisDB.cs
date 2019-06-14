using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Data
{
    public class PaisDB
    {
        private Conexao conexao;

        public List<Pais> All()
        {
            using (conexao = new Conexao())
            {
                var sql = "SELECT Id, Descricao FROM TB_Pais";
                var retorno = conexao.ExecutaComandoRetorno(sql);
                return TransformaSQLReaderEmList(retorno);
            }
        }

        private List<Pais> TransformaSQLReaderEmList(SqlDataReader retorno)
        {
            var listPais = new List<Pais>();

            while (retorno.Read())
            {
                var item = new Pais()
                {
                    Id = Convert.ToInt32(retorno["Id"]),
                    Descricao = retorno["Descricao"].ToString()
                };

                listPais.Add(item);
            }
            return listPais;
        }
    }
}
