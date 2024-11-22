using MIGHTVR_VS.Models;
using MIGHTVR_VS.ORM2;

namespace MIGHTVR_VS.Repositorio
{
    public class ServicoRepositorio
    {
        private BdMightvrContext _context;
        public ServicoRepositorio(BdMightvrContext context)
        {
            _context = context;
        }
        public bool InserirServico(string tipoServico, decimal Valor)
        {
            try
            {
                TbServico servico = new TbServico();
                servico.Valor = Valor;
                servico.TipoServico = tipoServico;

                _context.TbServicos.Add(servico);  // Supondo que _context.TbUsuarios seja o DbSet para a entidade de usuários
                _context.SaveChanges();

                return true;  // Retorna true para indicar sucesso
            }
            catch (Exception ex)
            {
                // Trate o erro ou faça um log do ex.Message se necessário
                return false;  // Retorna false para indicar falha
            }
        }

        public List<Servico> ListarServicos()
        {
            List<Servico> listFun = new List<Servico>();

            var listTb = _context.TbServicos.ToList();

            foreach (var item in listTb)
            {
                var servicos = new Servico
                {
                    Id = item.Id,
                    Valor = item.Valor,
                    TipoServico = item.TipoServico,
                };

                listFun.Add(servicos);
            }

            return listFun;
        }

        public bool AtualizarServico(int id, decimal valor, string tipoServico)
        {
            var servico = _context.TbServicos.Find(id); // Usando o Find para pegar o serviço pelo ID

            if (servico == null)
            {
                return false; // Retorna false se o serviço não for encontrado
            }

            servico.TipoServico = tipoServico;
            servico.Valor = valor;

            _context.SaveChanges(); // Persiste as mudanças no banco de dados
            return true; // Retorna true após a atualização
        }


        public bool ExcluirServico(int idServico)
        {
            var servico = _context.TbServicos.Find(idServico); // Busca o serviço
            if (servico == null)
            {
                return false;  // Retorna falso se o serviço não for encontrado
            }

            _context.TbServicos.Remove(servico); // Remove o serviço
            _context.SaveChanges(); // Persiste as mudanças no banco de dados
            return true;  // Retorna true após a exclusão
        }



    }
}

