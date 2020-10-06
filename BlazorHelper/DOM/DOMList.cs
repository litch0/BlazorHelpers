namespace BlazorHelper.DOM
{
    public static class DOMHList
    {
        private const string BaseName = "DOMHelper.";
        
        public static readonly string SetLocalStorage    = $"{BaseName}SetLocalStorage";
        public static readonly string GetLocalStorage    = $"{BaseName}GetLocalStorage";
        public static readonly string SetCookie          = $"{BaseName}SetCookie"; 
        public static readonly string GetCookie          = $"{BaseName}GetCookie";
        public static readonly string SetSessionStorage  = $"{BaseName}SetSessionStorage";
        public static readonly string GetSessionStorage  = $"{BaseName}GetSessionStorage";
        public static readonly string GetNaviGeoLocal    = $"{BaseName}GetNaviGeoLocal";
        public static readonly string GetNaviOnline      = $"{BaseName}GetNaviOnline";
        public static readonly string GetUserAgent       = $"{BaseName}GetUserAgent";
    }
}