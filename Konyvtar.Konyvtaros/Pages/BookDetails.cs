﻿using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Konyvtar.Contracts;

namespace Konyvtar.Librarian.Pages
{
    public partial class BookDetails : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string BookID { get; set; }

        public Book Book { get; set; } = new Book();

        protected override async Task OnInitializedAsync()
        {
            Book = await HttpClient.GetFromJsonAsync<Book>($"book/{BookID}");
            await base.OnInitializedAsync();
        }

        private async Task DeleteBook()
        {
            await HttpClient.DeleteAsync($"book/{BookID}");
            NavigationManager.NavigateTo("books");
        }
    }
}
