using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Cidade
    {
        #region Propriedades

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int IdEstado { get; set; }
        public int IdPais { get; set; }
        #endregion
    }
}