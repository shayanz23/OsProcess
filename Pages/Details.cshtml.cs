using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace OsProcess.Pages
{
    public class DetailsModel : PageModel
    {
        public void OnGet(int id)
        {
            ViewData["P"] = Process.GetProcessById(id);
        }
    }
}
