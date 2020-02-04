using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mappings
{

    //Configuração LOCAL
    internal class ClienteMapConfig : EntityTypeConfiguration<Cliente>
    {

        public ClienteMapConfig()
        {
            //Definimos o nome da tabela que está vinculada a entidade descrita lá em cima
            this.ToTable("CLIENTES");
            //Configura a propriedade Nome a ser VARCHAR(50) NOT NULL

            //IsRequired => NOT NULL
            //IsUnicode  => VARCHAR/CHAR
            //IsFixedLenght => Utilizamos pro EF criar um CHAR ao inves de VARCHAR
            this.Property(c => c.Nome).HasMaxLength(50);

            //Não é mais necessário informar IsRequired e IsUnicode(false)
            //pois há uma configuração global que determina que a string é assim ^_^
            this.Property(c => c.CPF).IsFixedLength().HasMaxLength(14);
                             
            //O IsRequired não é obrigatório, este método foi chamado apenas
            //para tornar o código mais descritivo
            this.Property(c => c.DataNascimento).HasColumnType("date").IsRequired();
        }
    }
}
