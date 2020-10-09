# BlazorHelpers
Helpers to interact with javascript apis using blazor

## Documentation Here
[Go to Documentation](https://github.com/litch0/BlazorHelpers/wiki)

## instalation
[Nuguet](https://www.nuget.org/packages/BlazorHelper/)

## How to use?
### JQuery
in the `_layour.cshtml` or `index.html` add the following scripts depending on what you want to do:
```HTML
<script src="_content/BlazorHelper/jquery-3.5.1.min.js"></script>
<script src="_content/BlazorHelper/JqueryInterop.js"></script>
```

in the component you want to use
```CSHTML
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
in the `_layour.cshtml` or `index.html` add the following scripts depending on what you want to do:
```HTML
<script src="_content/BlazorHelper/DOMInterop.js"></script>
```

in the component you want to use
```CSHTML
protected override async Task OnInitializedAsync()
{
    await base.OnInitializedAsync();
    await Dom.SetLocalStorage("hello", "secondHello");
}
```
