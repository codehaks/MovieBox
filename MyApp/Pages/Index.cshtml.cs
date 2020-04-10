using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp
{
    public class IndexModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {

            await LongRunningProccess();

            return Page();
        }

        private async Task LongRunningProccess()
        {
            await Task.Delay(3000);

            throw new Exception("Error!");
        }
    }
}