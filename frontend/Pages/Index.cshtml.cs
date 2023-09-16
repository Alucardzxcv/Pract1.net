using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace frontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public GiftenorResult[] GiftenorResults { get; set; }
        public string ErrorMessage { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet([FromServices]GiftenorClient client)
        {
            GiftenorResults = await client.GetGiftenorAsync();

            if (GiftenorResults.Length == 0)
                ErrorMessage = "No Giftenor results found.";
            else
                ErrorMessage = string.Empty;
        }
    }
}
