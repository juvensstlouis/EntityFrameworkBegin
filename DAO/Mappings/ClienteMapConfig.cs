using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mappings
{
    internal class ClienteMapConfig : EntityTypeConfiguration<Cliente>
    {
        //Configuração LOCAL
        public ClienteMapConfig()
        {
            //Definimos o nome da tabela que está vinculada a entidade descrita lá em cima
            this.ToTable("CLIENTES");

            //IsRequired => NOT NULL
            //IsUnicode => VARCHAR/CHAR
            //IsFixedLength => Utilizamos pro EF criar um CHAR ao invés de VARCHAR

            //O IsRequired() e IsUnicode() não são obrigatórios, se forem configurados

            //Configura a propriedade Nome a ser  VARCHAR(50) NOT NULL
            //this.Property(c => c.Nome).HasColumnType("VARCHAR(50)").IsRequired();
            this.Property(c => c.Nome).HasMaxLength(50);//.IsRequired().IsUnicode(false);
            
            //Configura a propriedade CPF a ser CHAR(14) NOT NULL
            this.Property(c => c.CPF).IsFixedLength().HasMaxLength(14);//.IsUnicode(false).IsRequired();
            
            //O ISRequired não é obrigatório, este método foi chamado apenas
            //para tornar o código mais descritivo
            this.Property(c => c.DataNascimento).HasColumnType("DATE").IsRequired();
        }
    }
}
