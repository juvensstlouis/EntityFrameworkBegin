using BLL.Interfaces;
using DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClienteService : IClienteService
    {
        public void Insert(Cliente cliente)
        {
            //Validar

            using (EstacionamentoDbContext db = new EstacionamentoDbContext())
            {
                //Ao buscar um dado de entity, existe um mecanismo conhecido
                //como TRACKING. Este mecanismo observa as alterações feitas 
                //no objeto e, quando o método SaveChanges é chamado na base,
                //ele efetuará um umpdate de tudo que foi alterado.
                Cliente c = db.Clientes.Find(5);
                c.Nome += " Bernart";
                db.SaveChanges();

                //Update sem a necessidade de ir no banco a primeira vez para buscar pelo id
                Vaga VagaASerAtualizada = new Vaga();
                //Necessário para ser atualizado
                VagaASerAtualizada.ID = 5;
                //------------------------------
                VagaASerAtualizada.EhCoberta = true;
                VagaASerAtualizada.EhPreferencial = true;
                db.Entry<Vaga>(VagaASerAtualizada).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                //DELETE
                Vaga VagaASerExcluida = new Vaga();
                //Necessário para ser excluido
                VagaASerExcluida.ID = 5;
                //------------------------------
                db.Entry<Vaga>(VagaASerExcluida).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                //O ToList que faz a pesquisa no banco
                //É importante que seja o último comando
                //para não pegar todos os registros

                //Exemplo de pesquisa de clientes que contenham a letra 'a' no nome, 
                //ordenados por nome descrescentemente e; caso os nomes sejam iguais, ordena por id.
                List<Cliente> clientes = db.Clientes.Where(cli => cli.Nome.Contains("a"))
                                                    .OrderByDescending(cli => cli.Nome)
                                                    .ThenBy(cli => cli.ID)
                                                    .ToList();

                //Devolve o valor total já pago pelo cliente em todas as movimentações do primeiro 
                //cliente que tenha a letra "a" no nome
                //double valor = clientes.First().Movimentacoes.Sum(m => m.ValorTotal);
                double valor = clientes[0].Movimentacoes.Sum(m => m.ValorTotal);

                //Exemplo de pesquisa de vaga por ID
                //EXTREMAMENTE COMUM
                //O Find é mais performático que o FirstOrDefault
                Vaga vv = db.Vagas.Find(6);

                db.Movimentacoes.Where(m => m.DataEntrada.Date == DateTime.Now.Date && 
                                       m.Vaga.TipoVaga == Entity.Enums.TipoVeiculo.Helicoptero)
                                .ToList();

                Cliente c = new Cliente()
                {
                    Nome = "Danizinho Bernart",
                    Ativo = true,
                    CPF = "901.917.069-49",
                    DataNascimento = DateTime.Now.AddYears(-25)
                };
                Vaga v = new Vaga()
                {
                    EhCoberta = true,
                    EhPreferencial = true,
                    TipoVaga = Entity.Enums.TipoVeiculo.Helicoptero,
                    VagaLivre = true
                };
                
                db.Clientes.Add(c);
                db.Vagas.Add(v);
                db.SaveChanges();

                
            }
        }
    }
}
