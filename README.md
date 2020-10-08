# BlazorHelpers
Helpers to interact with javascript apis using blazor

## Documentation Here
[Go to Documentation](https://github.com/litch0/BlazorHelpers/wiki)

## instalation
[Nuguet](https://www.nuget.org/packages/BlazorHelper/)

## How to use?
in the `_layour.cshtml` or `index.html` add the following scripts depending on what you want to do:
```HTML
<script src="_content/BlazorHelper/jquery-3.5.1.min.js"></script> <!--If you want to use Jquery functions this needs to be first-->
<script src="_content/BlazorHelper/JqueryInterop.js"></script> <!--If you want to use Jquery-->
<script src="_content/BlazorHelper/DOMInterop.js" ></script> <!--if you want to use Cookies, sessionStorage, localStorage, navigator apis, etc-->
```

in the component you want to use
```CSHTML
@inject IJSRuntime JsRun <!--DO NOT FORGET THIS-->

<p>Welcome to your new app.</p>
<div id="mycustomIdSuperCool" style="overflow: auto; height: 100px; width: 100%; background: #1861ac;">
</div>


<button class="btn btn-secondary"  @onclick=" e => AddElements()" >Add Elements by adding to list</button><br/>
<button class="btn btn-primary"    @onclick="() => Empty()" >Hide</button>
@code
{
    JObject div;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        div = new JObject(JsRun, $"#mycustomIdSuperCool");
        div.SetCss("background", "black");
        JsRun.InvokeVoidAsync("TestRuntime", "OnInitialized");
    }

    void AddElements()
    {
        for (int i = 0; i < 1000; i++)
        {    //         div.CreateElement("ELEMENTNAME", UNIQUEID);
            JObject j = div.CreateElement("p", Guid.NewGuid().ToString()); // Note that this elements are created in the parrent element so you don't need to add them
        }
    }

    void Hide() => div.Hide();

    void Show() => div.Show();

    void Empty() => div.empty();
}
```
Look that wen referencing elements from the DOM you need to reference it on `OnInitialized()` after `base.OnInitialized();` because before that the JSRuntime is not available
