using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

[ApiController]
[Route("api/[controller]")]
public class SystemMetricsController : ControllerBase
{
    private static readonly PerformanceCounter cpuCounter;
    private static readonly PerformanceCounter memCounter;

    static SystemMetricsController()
    {
        cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        memCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
    }

    [HttpGet]
    public SystemMetrics Get()
    {
        return new SystemMetrics
        {
            CpuUsage = Math.Round(cpuCounter.NextValue(), 2),
            MemoryUsage = Math.Round(memCounter.NextValue(), 2),
            CurrentTime = DateTime.Now
        };
    }
}