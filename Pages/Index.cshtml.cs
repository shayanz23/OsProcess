using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace OsProcess.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Process[] processes = Process.GetProcesses();
        ViewData["P"] = processes;
        double totalRam = 0;
        double totalCPU = 0;
        cupuusage(processes, ref totalRam, ref totalCPU);
        ViewData["totalRam"] = totalRam;
        ViewData["totalCPU"] = totalCPU;
    }

    void cupuusage(Process[] processes, ref double total, ref double totalCPU)
    {
        foreach (Process process in processes)
        {
            try
            {
                total += process.WorkingSet64/1000000;
                totalCPU += process.TotalProcessorTime.TotalHours;
            }
            catch (Exception)
            {
                // ignored
            }
        }
        return;
    }
}
