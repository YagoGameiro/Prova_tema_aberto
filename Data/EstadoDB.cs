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
    public class EstadoDB
    {
        private Conexao conexao;

        public List<Estado> All(int id)
        {
            using (conexao = new Conexao())
            {
                var sql = "SELECT Id, Descricao FROM TB_Estado WHERE IdPais = " + id;
                var retorno = conexao.ExecutaComandoRetorno(sql);
                return TransformaSQLReaderEmList(retorno);
            }
        }

        private List<Estado> TransformaSQLReaderEmList(SqlDataReader retorno)
        {
            var listEstado = new List<Estado>();

            while (retorno.Read())
            {
                var item = new Estado()
                {
                    Id = Convert.ToInt32(retorno["Id"]),
                    Descricao = retorno["Descricao"].ToString()
                };

                listEstado.Add(item);
            }
            return listEstado;
        }
    }
}
