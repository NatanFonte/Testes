using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MIGHTVR_VS.Models;
using MIGHTVR_VS.Repositorio;
using System.Diagnostics;

namespace MIGHTVR_VS.Controllers
{
    public class ServicoController : Controller
    {
        private readonly ServicoRepositorio _servicoRepositorio;
        private readonly ILogger<ServicoController> _logger;
        public ServicoController(ServicoRepositorio servicoRepositorio, ILogger<ServicoController> logger)
        {
            _servicoRepositorio = servicoRepositorio;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<SelectListItem> tipoServico = new List<SelectListItem>
              {
                  new SelectListItem { Value = "0", Text = "Consultoria" },
                  new SelectListItem { Value = "1", Text = "Desenvolvimento de Software" },
                  new SelectListItem { Value = "2", Text = "Design Gr�fico" },
                  new SelectListItem { Value = "3", Text = "Marketing Digital" },
                  new SelectListItem { Value = "4", Text = "Deenvolvimento Web" },
                  new SelectListItem { Value = "5", Text = "Redesign de Sites" },
              };

            ViewBag.lstTipoServico = new SelectList(tipoServico, "Value", "Text");
            var Servicos = _servicoRepositorio.ListarServicos();
            return View(Servicos);
        }

        public IActionResult InserirServico(decimal Valor, string TipoServico)
        {
            try
            {
                // Chama o m�todo do reposit�rio que realiza a inser��o no banco de dados
                var resultado = _servicoRepositorio.InserirServico(TipoServico, Valor);

                // Verifica o resultado da inser��o
                if (resultado)
                {
                    // Se o resultado for verdadeiro, significa que o usu�rio foi inserido com sucesso
                    return Json(new { success = true, message = "Servi�o inserido com sucesso!" });
                }
                else
                {
                    // Se o resultado for falso, significa que houve um erro ao tentar inserir o usu�rio
                    return Json(new { success = false, message = "Erro ao inserir o servi�o. Tente novamente." });
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro inesperado, captura e exibe o erro
                return Json(new { success = false, message = "Erro ao processar a solicita��o. Detalhes: " + ex.Message });
            }
        }

        public IActionResult AtualizarServico(int id, decimal Valor, string TipoServico)
        {
            try
            {
                // Chama o reposit�rio para atualizar o usu�rio
                var resultado = _servicoRepositorio.AtualizarServico(id, Valor, TipoServico);

                if (resultado)
                {
                    return Json(new { success = true, message = "Servi�o atualizado com sucesso!" });
                }
                else
                {
                    return Json(new { success = false, message = "Erro ao atualizar o usu�rio. Verifique se o servi�o existe." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Erro ao processar a solicita��o. Detalhes: " + ex.Message });
            }
        }

        public IActionResult ExcluirServico(int id)
        {
            try
            {
                // Chama o reposit�rio para excluir o usu�rio
                var resultado = _servicoRepositorio.ExcluirServico(id);

                if (resultado)
                {
                    return Json(new { success = true, message = "Servi�o exclu�do com sucesso!" });
                }
                else
                {
                    return Json(new { success = false, message = "Erro ao excluir o servi�o. Verifique se o servi�o existe." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Erro ao processar a solicita��o. Detalhes: " + ex.Message });
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}