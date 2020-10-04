using Microsoft.JSInterop;
using Lst = BlazorHelper.DOM.DOMHList;

namespace BlazorHelper.DOM
{
    public class DOMHelper
    {
        private IJSRuntime _runtime;
        public DOMHelper(IJSRuntime runtime)
        {
            _runtime = runtime;
        }

        public void   SetLocalStorage(string key, string value) => _runtime.InvokeVoidAsync(Lst.SetLocalStorage, key, value);
        public string GetLocalStorage(string key) => _runtime.InvokeAsync<string>(Lst.GetCookie, key).Result;
        public void   SetCookie(string key, string val, int hoursToExpire) => _runtime.InvokeVoidAsync(Lst.SetCookie, key, val, hoursToExpire);
        public string GetCookie(string key) => _runtime.InvokeAsync<string>(Lst.GetCookie, key).Result;
        public void   SetSessionStorage(string key, string val) => _runtime.InvokeVoidAsync(Lst.SetSessionStorage, key, val);
        public string GetSessionStorage(string key) => _runtime.InvokeAsync<string>(Lst.GetSessionStorage, key).Result;
        
    }
}