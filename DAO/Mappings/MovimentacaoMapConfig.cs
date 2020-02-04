using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mappings
{
    internal class MovimentacaoMapConfig : EntityTypeConfiguration<Movimentacao>
    {
        public MovimentacaoMapConfig()
        {
            //Definimos o nome da tabela que está vinculada a entidade descrita lá em cima
            this.ToTable("MOVIMENTACOES");

            //O IsRequired() e IsUnicode() não são obrigatórios, se forem configurados

            this.Property(m => m.Placa).IsFixedLength().HasMaxLength(7);//.IsUnicode(false).IsRequired();
            this.Property(m => m.Modelo).HasMaxLength(30);//.IsUnicode(false).IsRequired();

        }
    }
}
