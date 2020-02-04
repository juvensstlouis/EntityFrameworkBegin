using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mappings
{
    internal class VagaMapConfig : EntityTypeConfiguration<Vaga>
    {
        public VagaMapConfig()
        {
            //Definimos o nome da tabela que está vinculada a entidade descrita lá em cima
            this.ToTable("VAGAS");
        }
    }
}
