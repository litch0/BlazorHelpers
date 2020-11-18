using System;
using System.Threading.Tasks;
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
        
        public async Task<string> GetText() => await _runtime.InvokeAsync<string>(JqueryList.Text, this.Selector);
        public async Task<string> GetHtml() => await  _runtime.InvokeAsync<string>(JqueryList.Html, this.Selector);
        public async Task<string> GetVal() => await _runtime.InvokeAsync<string>(JqueryList.Val, this.Selector);
        public async Task<string> GetAttr(string attr) => await _runtime.InvokeAsync<string>(JqueryList.Attr, this.Selector, attr);
        public async Task<string> GetCss(string property) => await _runtime.InvokeAsync<string>(JqueryList.Css, this.Selector, property);

        public async Task SetHtml(string html) => await _runtime.InvokeVoidAsync(JqueryList.SetHtml, this.Selector, html);
        public async Task SetText(string text) => await _runtime.InvokeVoidAsync(JqueryList.SetText, this.Selector, text);   
        public async Task SetVal(string text) => await _runtime.InvokeVoidAsync(JqueryList.SetVal, this.Selector, text);
        public async Task SetAtrr(string attr, string value) => await _runtime.InvokeVoidAsync(JqueryList.SetAttr, this.Selector, attr, value);
        public async Task SetCss(string property, string value) => await _runtime.InvokeVoidAsync(JqueryList.SetCss, this.Selector, property, value);

        public async Task Add(string element) => await _runtime.InvokeVoidAsync(JqueryList.Add, this.Selector, element);
        public async Task Add(JObject element) => await _runtime.InvokeVoidAsync(JqueryList.Add, this.Selector, element.Selector);
        public async Task AddHtml(string html) => await  _runtime.InvokeVoidAsync(JqueryList.AddHtml, this.Selector, html);

        public async Task Remove(string id) => await _runtime.InvokeVoidAsync(JqueryList.RemoveChild, Selector, id);
        public async Task Remove() => await _runtime.InvokeVoidAsync(JqueryList.Remove, this.Selector);
        public async Task Show() => await _runtime.InvokeVoidAsync(JqueryList.Show, this.Selector);
        public async Task Hide() => await _runtime.InvokeVoidAsync(JqueryList.Hide, Selector);

        public async Task FadeIn(int speed) => await _runtime.InvokeVoidAsync(JqueryList.FadeIn, this.Selector, speed);
        public async Task FadeIn(string speed) => await _runtime.InvokeVoidAsync(JqueryList.FadeIn, this.Selector, speed);
        
        public async Task FadeOut(string speed) => await _runtime.InvokeVoidAsync(JqueryList.FadeOut, this.Selector, speed);
        public async Task FadeOut(int speed) => await _runtime.InvokeVoidAsync(JqueryList.FadeOut, this.Selector, speed);
        
        public async Task FadeToggle(string speed) => await _runtime.InvokeVoidAsync(JqueryList.FadeToggle, this.Selector, speed);
        public async Task FadeToggle(int speed) =>  await _runtime.InvokeVoidAsync(JqueryList.FadeToggle, this.Selector, speed);
        
        public async Task FadeTo(string speed, float opacity) => await _runtime.InvokeVoidAsync(JqueryList.FadeTo, this.Selector, speed, opacity);
        public async Task FadeTo(int speed, float opacity) => await _runtime.InvokeVoidAsync(JqueryList.FadeTo, this.Selector, speed, opacity);
    }
}
