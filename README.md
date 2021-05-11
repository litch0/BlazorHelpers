# BlazorHelpers [![Build Status](https://travis-ci.com/litch0/BlazorHelpers.svg?branch=main)](https://travis-ci.com/litch0/BlazorHelpers)
Helpers to interact with javascript apis using blazor

## Next Plan
Add Support for Bootstrap 5 with callbacks for events. see the [Bootstrap Branch](https://github.com/litch0/BlazorHelpers/tree/BootstrapSupport) to track progress.  

## Documentation Here
[Go to Documentation](https://github.com/litch0/BlazorHelpers/wiki)

## instalation
[Nuguet](https://www.nuget.org/packages/BlazorHelper/)

## How to use?
You can see the [Test app](https://github.com/litch0/BlazorHelpers/tree/main/blazorHelperTest) to get inspiration 
### JQuery
in program.cs
```C#
public static async Task Main(string[] args)
{
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("app");
        
    builder.Services
        .AddJquery() // to use Jquery
        .AddDOMHelper() // To use DOM
        .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
}
```

in the `_layour.cshtml` or `index.html` add the following scripts:
```HTML
<script src="_content/BlazorHelper/jquery-3.5.1.min.js"></script>
<script src="_content/BlazorHelper/JqueryInterop.js"></script>
```

in the component you want to use
```CSHTML
@inject Jquery Jquery

// Jquery methods are not available on Initialize Functions
protected override Task OnAfterRenderAsync(bool firstRender)
{
    if (firstRender)
    {    
        new JObject("#H").SetCss("color", "red");
    }
    return base.OnAfterRenderAsync(firstRender);
}
```

### DOM
in the `_layour.cshtml` or `index.html` add the following scripts:
```HTML
<script src="_content/BlazorHelper/DOMInterop.js"></script>
```

in the component you want to use
```CSHTML
@inject DOMHelper Dom

protected override async Task OnInitializedAsync()
{
    await base.OnInitializedAsync();
    await Dom.SetLocalStorage("hello", "secondHello");
}
```
