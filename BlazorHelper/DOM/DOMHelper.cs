using System;
using System.Threading.Tasks;
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

        public async Task AddStyle(string wwwrootRelativePath)
        {
            Console.WriteLine($"adding {wwwrootRelativePath}");
            await _runtime.InvokeVoidAsync(Lst.AddStyle, wwwrootRelativePath);
        }                                         

        public async Task AddScript(string wwwrootRelativePath)
        {
            Console.WriteLine($"adding {wwwrootRelativePath}");
            await _runtime.InvokeVoidAsync(Lst.AddScript, wwwrootRelativePath);
        }                                       
        public async Task<string> GetLocalStorage(string key) =>                                            await _runtime.InvokeAsync<string>(Lst.GetCookie, key);
        public async Task<string> GetSessionStorage(string key) =>                                          await  _runtime.InvokeAsync<string>(Lst.GetSessionStorage, key);
        public async Task<string> GetCookie(string key) =>                                                  await _runtime.InvokeAsync<string>(Lst.GetCookie, key);
        public async Task<T> GetLocalStorage<T>(string key) =>                                              Deserialize<T>(await GetLocalStorage(key));
        public async Task<T> GetSessionStorage<T>(string key, object value) =>                              Deserialize<T>(await GetSessionStorage(key));
        public async Task<T> GetCookie<T>(string key) =>                                                    Deserialize<T>(await GetCookie(key));
        public async Task<bool> GetNaviOnline() =>                                                          await _runtime.InvokeAsync<bool>(Lst.GetNaviOnline);
        public async Task<string> GetNaviUserAgent() =>                                                     await _runtime.InvokeAsync<string>(Lst.GetUserAgent);
        public async Task<string> GetNaviGeoLocal() =>                                                      await _runtime.InvokeAsync<string>(Lst.GetNaviGeoLocal);

        public async void       SetLocalStorage<T>(string key, object value) =>                                   await SetLocalStorage(key, Serialize(value));
        public async Task       SetCookie<T>(string key, object value, int hours, string domain) =>               await SetCookie(key, Serialize(value), hours, domain);
        public async void       SetSessionStorage<T>(string key, object value) =>                                 await SetSessionStorage(key, Serialize(value));
        public async Task       SetLocalStorage(string key, string value) =>                                await _runtime.InvokeVoidAsync(Lst.SetLocalStorage, key, value);
        public async Task       SetCookie(string key, string val, int hoursToExpire, string domain) =>      await _runtime.InvokeVoidAsync(Lst.SetCookie, key, val, hoursToExpire, domain);
        public async Task       SetSessionStorage(string key, string val) =>                                await _runtime.InvokeVoidAsync(Lst.SetSessionStorage, key, val);


        private string Serialize(object data) => JsonConvert.SerializeObject(data);
        private T Deserialize<T>(string data) => JsonConvert.DeserializeObject<T>(data);

       

    }
}