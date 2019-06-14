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
    public class CidadeDB
    {
        private Conexao conexao;

        public List<Cidade> All(int idE, int idP)
        {
            using (conexao = new Conexao())
            {
                var sql = "SELECT Id, Descricao FROM TB_CIDADE WHERE IdEstado = " + idE +" AND IdPais = "+ idP;
                var retorno = conexao.ExecutaComandoRetorno(sql);
                return TransformaSQLReaderEmList(retorno);
            }
        }

        private List<Cidade> TransformaSQLReaderEmList(SqlDataReader retorno)
        {
            var listCidade = new List<Cidade>();

            while (retorno.Read())
            {
                var item = new Cidade()
                {
                    Id = Convert.ToInt32(retorno["Id"]),
                    Descricao = retorno["Descricao"].ToString()
                };

                listCidade.Add(item);
            }
            return listCidade;
        }
    }
}
