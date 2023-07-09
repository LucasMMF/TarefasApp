using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Services.Models.Requests;

namespace TarefasApp.UI.Models
{
    /// <summary>
    /// Classe para definir o modelo de dados da página de criação de conta
    /// </summary>
    public class CriarContaViewModel
    {
        // Propriedade para acessar o modelo de dados
        public CriarContaRequestModel CriarContaRequestModel { get; set; }

        // Construtor
        public CriarContaViewModel() 
        {
            this.CriarContaRequestModel = new CriarContaRequestModel();
        }
    }
}
