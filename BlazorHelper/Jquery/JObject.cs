using System;
using System.IO;
using Microsoft.JSInterop;

namespace BlazorHelper
{
    public class JObject
    {
        private IJSRuntime  _runtime;
        public  string      Selector;

        public JObject(IJSRuntime runtime, string selector)
        {
            _runtime = runtime;
            Selector = selector;
            _runtime.InvokeVoidAsync("console.log", "hello wolrd from function dotnet helper");
        }

        public JObject CreateElement(string elementName, string id)
        {
            _runtime.InvokeVoidAsync(BHList.CreateElement, this.Selector, id);
            return new JObject(_runtime, id);
        } 
        
        public string GetHtml() => _runtime.InvokeAsync<string>(BHList.Html, this.Selector).Result;
        public string GetText() => _runtime.InvokeAsync<string>(BHList.Text, this.Selector).Result;
        public string GetVal() => _runtime.InvokeAsync<string>(BHList.Val, this.Selector).Result;
        public string GetAttr(string attr) => _runtime.InvokeAsync<string>(BHList.Attr, this.Selector, attr).Result;
        public string GetCss(string property) => _runtime.InvokeAsync<string>(BHList.Css, this.Selector, property).Result;

        public void SetHtml(string html)
        {
            _runtime.InvokeVoidAsync(BHList.SetHtml, this.Selector, html);
        }

        public void SetText(string text)
        {
            Console.WriteLine($"setting {Selector} => {text}");
            _runtime.InvokeVoidAsync(BHList.SetText, this.Selector, text);   
        }
        public void SetVal(string text) => _runtime.InvokeVoidAsync(BHList.SetVal, this.Selector, text);
        public void SetAtrr(string attr, string value) => _runtime.InvokeVoidAsync(BHList.SetAttr, this.Selector, attr, value);
        public void SetCss(string property, string value) => _runtime.InvokeVoidAsync(BHList.SetCss, this.Selector, property, value);

        public void Add(string element) => _runtime.InvokeVoidAsync(BHList.Add, this.Selector, element);
        public void Add(JObject element) => _runtime.InvokeVoidAsync(BHList.Add, this.Selector, element.Selector);
        public void AddHtml(string html) => _runtime.InvokeVoidAsync(BHList.AddHtml, this.Selector, html);

        public void Remove(string id) => _runtime.InvokeVoidAsync(BHList.RemoveChild, Selector, id);
        public void Remove() => _runtime.InvokeVoidAsync(BHList.Remove, this.Selector);
        public void Show() => _runtime.InvokeVoidAsync(BHList.Show, this.Selector);
        public void Hide() => _runtime.InvokeVoidAsync(BHList.Hide, Selector);

        public void FadeIn(int speed) => _runtime.InvokeVoidAsync(BHList.FadeIn, this.Selector, speed);
        public void FadeIn(string speed) => _runtime.InvokeVoidAsync(BHList.FadeIn, this.Selector, speed);
        
        public void FadeOut(string speed) => _runtime.InvokeVoidAsync(BHList.FadeOut, this.Selector, speed);
        public void FadeOut(int speed) => _runtime.InvokeVoidAsync(BHList.FadeOut, this.Selector, speed);
        
        public void FadeToggle(string speed) => _runtime.InvokeVoidAsync(BHList.FadeToggle, this.Selector, speed);
        public void FadeToggle(int speed) => _runtime.InvokeVoidAsync(BHList.FadeToggle, this.Selector, speed);
        
        public void FadeTo(string speed, float opacity) => _runtime.InvokeVoidAsync(BHList.FadeTo, this.Selector, speed, opacity);
        public void FadeTo(int speed, float opacity) => _runtime.InvokeVoidAsync(BHList.FadeTo, this.Selector, speed, opacity);
    }
}