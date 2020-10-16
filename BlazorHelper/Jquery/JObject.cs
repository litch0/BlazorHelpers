using System;
using System.IO;
using Microsoft.JSInterop;

namespace BlazorHelper.Jquery
{
    public class JObject
    {
        private IJSRuntime _runtime = Jquery.Runtime;
        public  string     Selector;

        public JObject(string selector)
        {
            _runtime.InvokeVoidAsync("Test");
            if(_runtime == null)
                throw new NullReferenceException("You must add Jquery to your serivces");
            Selector = selector;
        }

        public JObject CreateElement(string elementName, string id)
        {
            _runtime.InvokeVoidAsync(JqueryList.CreateElement, this.Selector, id);
            return new JObject(id);
        } 
        
        public string GetHtml() => _runtime.InvokeAsync<string>(JqueryList.Html, this.Selector).Result;
        public string GetText() => _runtime.InvokeAsync<string>(JqueryList.Text, this.Selector).Result;
        public string GetVal() => _runtime.InvokeAsync<string>(JqueryList.Val, this.Selector).Result;
        public string GetAttr(string attr) => _runtime.InvokeAsync<string>(JqueryList.Attr, this.Selector, attr).Result;
        public string GetCss(string property) => _runtime.InvokeAsync<string>(JqueryList.Css, this.Selector, property).Result;

        public void SetHtml(string html) => _runtime.InvokeVoidAsync(JqueryList.SetHtml, this.Selector, html);

        public void SetText(string text) => _runtime.InvokeVoidAsync(JqueryList.SetText, this.Selector, text);   
        public void SetVal(string text) => _runtime.InvokeVoidAsync(JqueryList.SetVal, this.Selector, text);
        public void SetAtrr(string attr, string value) => _runtime.InvokeVoidAsync(JqueryList.SetAttr, this.Selector, attr, value);
        public void SetCss(string property, string value) => _runtime.InvokeVoidAsync(JqueryList.SetCss, this.Selector, property, value);

        public void Add(string element) => _runtime.InvokeVoidAsync(JqueryList.Add, this.Selector, element);
        public void Add(JObject element) => _runtime.InvokeVoidAsync(JqueryList.Add, this.Selector, element.Selector);
        public void AddHtml(string html) => _runtime.InvokeVoidAsync(JqueryList.AddHtml, this.Selector, html);

        public void Remove(string id) => _runtime.InvokeVoidAsync(JqueryList.RemoveChild, Selector, id);
        public void Remove() => _runtime.InvokeVoidAsync(JqueryList.Remove, this.Selector);
        public void Show() => _runtime.InvokeVoidAsync(JqueryList.Show, this.Selector);
        public void Hide() => _runtime.InvokeVoidAsync(JqueryList.Hide, Selector);

        public void FadeIn(int speed) => _runtime.InvokeVoidAsync(JqueryList.FadeIn, this.Selector, speed);
        public void FadeIn(string speed) => _runtime.InvokeVoidAsync(JqueryList.FadeIn, this.Selector, speed);
        
        public void FadeOut(string speed) => _runtime.InvokeVoidAsync(JqueryList.FadeOut, this.Selector, speed);
        public void FadeOut(int speed) => _runtime.InvokeVoidAsync(JqueryList.FadeOut, this.Selector, speed);
        
        public void FadeToggle(string speed) => _runtime.InvokeVoidAsync(JqueryList.FadeToggle, this.Selector, speed);
        public void FadeToggle(int speed) => _runtime.InvokeVoidAsync(JqueryList.FadeToggle, this.Selector, speed);
        
        public void FadeTo(string speed, float opacity) => _runtime.InvokeVoidAsync(JqueryList.FadeTo, this.Selector, speed, opacity);
        public void FadeTo(int speed, float opacity) => _runtime.InvokeVoidAsync(JqueryList.FadeTo, this.Selector, speed, opacity);
    }
}
