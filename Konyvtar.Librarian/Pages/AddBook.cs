using Konyvtar.Contracts;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace Konyvtar.Librarian.Pages
{
    public partial class AddBook : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Book Book { get; set; } = new Book();

    
        private async Task SubmitForm()
        {
            await HttpClient.PostAsJsonAsync("book", Book);
            NavigationManager.NavigateTo("books");
        }
    }
}
