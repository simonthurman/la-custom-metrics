using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using la_metric.Models;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace la_metric.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private TelemetryClient _telemetryClient;

    public HomeController(TelemetryClient telemetryClient, ILogger<HomeController> logger)
    {
        _logger = logger;
        _telemetryClient = telemetryClient;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        _telemetryClient.TrackEvent("Turn on the light");

        var myMetric = new MetricTelemetry();
        myMetric.Name = "product";
        myMetric.Sum = 2;


        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
