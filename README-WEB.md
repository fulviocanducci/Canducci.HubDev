# Canducci HubDev

[![Version](https://img.shields.io/nuget/v/Canducci.HubDev.Web.svg?style=plastic&label=version)](https://www.nuget.org/packages/Canducci.HubDev.Web/)
[![NuGet](https://img.shields.io/nuget/dt/Canducci.HubDev.Web.svg)](https://www.nuget.org/packages/Canducci.HubDev.Web/) [![NuGet Packages](https://github.com/fulviocanducci/Canducci.HubDev/actions/workflows/pack.yml/badge.svg)](https://github.com/fulviocanducci/Canducci.HubDev/actions/workflows/pack.yml)

##### _Pacote .NET para integraçao com a API do site:_ `https://www.hubdodesenvolvedor.com.br`

#### Instalação do Pacote

```bash
dotnet add package Canducci.HubDev.Web
```

#### Configurar esse pacote é uma aplicação Web.

Utilize a importação da seguinte forma:

```csharp
using Canducci.HubDev.Web.Extensions;
```

Depois de: `var builder = WebApplication.CreateBuilder(args);` configure mais uma linha dessa forma:

```csharp
public static void Main(string[] args)
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    // Add services Canducci HubDev
    builder.Services.AddCanducciHubDevService("seu token aqui");
    var app = builder.Build();

    ...
}
```

Agora em qualquer `controller`

```csharp
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHubDevService _hubDevService;

    public HomeController(ILogger<HomeController> logger, IHubDevService hubDevService)
    {
        _logger = logger;
        _hubDevService = hubDevService;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Zip = await _hubDevService.ZipSearch.GetAsync("seu cep");
        return View();
    }

    ...
```

#### [`A documentação do pacote e seus retornos nesse link`](https://github.com/fulviocanducci/Canducci.HubDev/blob/master/README.md).
