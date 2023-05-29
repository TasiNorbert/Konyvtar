using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Konyvtar.Contracts;
using System;
using System.Net;


namespace Konyvtar.Librarian.Pages
{
    public partial class MembersList : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public Member[]? Members { get; set; }

        public string SearchText = "";

        protected override async Task OnInitializedAsync()
        {
            Members = await HttpClient.GetFromJsonAsync<Member[]>("member");
            await base.OnInitializedAsync();
        }

        private async Task UpdateRentalStatus(long BookID, Book Book)
        {
            Book.IsBorrowed = false;
            await HttpClient.PutAsJsonAsync($"book/{BookID}", Book);
        }
    }
}
