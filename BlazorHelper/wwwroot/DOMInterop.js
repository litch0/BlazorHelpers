window.DOMHelper = {
    // Local storage
    SetLocalStorage(key, val){localStorage.setItem(key, val);},
    GetLocalStorage(key){return localStorage.getItem(key);},

    // Cookies
    SetCookie(key, val, hoursToExpire, domain){setCookie(key, val, hoursToExpire, domain)},
    GetCookie(name){return getCookie(name)},

    // Session Storage
    SetSessionStorage(key, val){sessionStorage.setItem(key, val);},
    GetSessionStorage(key){return sessionStorage.getItem(key);},
    
    // navigator
    GetNaviGeoLocal() {return navigator.geolocation().toString()},
    GetNaviOnline() { return navigator.onLine},
    GetUserAgent() {return navigator.userAgent.toString()},
    AddScript(pathToScript) { let scrpt = document.createElement("script"); scrpt.src = pathToScript; document.head.append(scrpt); },
    AddStyle(pathToStylesheet) {var link = document.createElement("link"); link.type = "text/css"; link.rel = "stylesheet"; link.href = pathToStylesheet; document.head.append(link);},
    Test() {console.log("DOM: hello")}
    
}

function setCookie(cname,cvalue,hours, domain) {
    let d = new Date();
    d.setTime(d.getTime() + (hours*60*60*1000));
    let expires = "expires=" + d.toGMTString();
    document.cookie = `${cname}=${cvalue};${expires};path=/;domain=${domain};secure`
}

function getCookie(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for(let i = 0; i <ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) === ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) === 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}