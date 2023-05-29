using Konyvtar.Contracts;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace Konyvtar.Librarian.Pages
{
    public partial class AddMember : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Member Member{ get; set; } = new Member();

        protected override async Task OnInitializedAsync()
        {
            Member.BirthDate = DateTime.Now;    
        }

			private async Task SubmitForm()
        {
            await HttpClient.PostAsJsonAsync("member", Member);
            NavigationManager.NavigateTo("members");
        }
    }
}