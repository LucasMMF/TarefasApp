using Newtonsoft.Json;
using Syncfusion.Maui.DataForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Services.Helpers;
using TarefasApp.Services.Models.Requests;
using TarefasApp.Services.Models.Responses;

namespace TarefasApp.UI.Behaviors
{
    /// <summary>
    /// Classe para definir os comportamentos da página de autenticação
    /// </summary>
    public class AutenticarBehavior : Behavior<ContentPage>
    {
        // Atributos para cada elemento capturado na página
        private Button _btnAcesso;
        private SfDataForm _formAutenticar;

        /// <summary>
        /// Método para implementar os eventos da página
        /// </summary>
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);

            // Capturar o botão da página
            this._btnAcesso = bindable.FindByName<Button>("btnAcesso");

            // Criando um evento para o botão
            this._btnAcesso.Clicked += OnButtonClicked;

            // Capturar o formulário
            this._formAutenticar = bindable.FindByName<SfDataForm>("formAutenticar");
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            //verificar se os campos do formulário estão corretos
            if (this._formAutenticar.Validate())
            {
                try
                {
                    // Capturar os campos do formulário
                    var model = (AutenticarRequestModel) this._formAutenticar.DataObject;

                    // Enviando a requisição para a API...
                    var serviceHelper = new ServicesHelper();
                    var result = await serviceHelper
                        .Post<AutenticarRequestModel, AutenticarResponseModel>("autenticar", model);

                    await App.Current.MainPage.DisplayAlert
                        ($"Olá, {result.Nome}", "Sua autenticação foi realizada com sucesso, Seja bem vindo!", "OK");

                    // Gravar os dados na secure storage
                    await SecureStorage.Default.SetAsync("auth_user", JsonConvert.SerializeObject(result));

                    // Navegação para a página Dashboard
                    await Shell.Current.GoToAsync("///Dashboard");
                }
                catch(Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert
                        ("Aviso!", ex.Message, "OK");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert
                    ("Aviso!", "Ocorreram erros de validação no preenchimento do formulário, por favor verifique.", "OK");
            }
        }
    }
}
