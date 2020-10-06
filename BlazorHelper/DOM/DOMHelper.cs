using Microsoft.JSInterop;
using Newtonsoft.Json;
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
        public void   SetCookie(string key, string val, int hoursToExpire, string domain) => _runtime.InvokeVoidAsync(Lst.SetCookie, key, val, hoursToExpire, domain);
        public string GetCookie(string key) => _runtime.InvokeAsync<string>(Lst.GetCookie, key).Result;
        public void   SetSessionStorage(string key, string val) => _runtime.InvokeVoidAsync(Lst.SetSessionStorage, key, val);
        public string GetSessionStorage(string key) => _runtime.InvokeAsync<string>(Lst.GetSessionStorage, key).Result;
        public string GetNaviGeoLocal() => _runtime.InvokeAsync<string>(Lst.GetNaviGeoLocal).Result;
        public bool GetNaviOnline() => _runtime.InvokeAsync<bool>(Lst.GetNaviOnline).Result;
        public string GetNaviUserAgent() => _runtime.InvokeAsync<string>(Lst.GetUserAgent).Result;


        private string Serialize(object data) => JsonConvert.SerializeObject(data);
        private T Deserialize<T>(string data) => JsonConvert.DeserializeObject<T>(data);

        public void SetLocalStorage<T>(string key, object value) => SetLocalStorage(key, Serialize(value));
        public void GetLocalStorage<T>(string key) => Deserialize<T>(this.GetLocalStorage(key));

        public void SetCookie<T>(string key, object value, int hours, string domain) => SetCookie(key, Serialize(value), hours, domain);
        public void GetCookie<T>(string key) => Deserialize<T>(GetCookie(key));

        public void SetSessionStorage<T>(string key, object value) => SetSessionStorage(key, Serialize(value));
        public void GetSessionStorage<T>(string key, object value) => Deserialize<T>(GetSessionStorage(key));

    }
}