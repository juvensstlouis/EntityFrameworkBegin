using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class EstacionamentoTesteStrategy : DropCreateDatabaseAlways<EstacionamentoDbContext>
    {
        protected override void Seed(EstacionamentoDbContext context)
        {
            //Código pra criar dados de testes quando a base for recriada
            using (context)
            {
                Cliente c = new Cliente()
                {
                    Nome = "Necão Bernart",
                    Ativo = true,
                    CPF = "901.917.069-41",
                    DataNascimento = DateTime.Now.AddYears(-55)
                };
                context.Clientes.Add(c);
                context.SaveChanges();
            }

            base.Seed(context);
        }


    }
}
