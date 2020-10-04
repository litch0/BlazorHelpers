window.DOMHelper = {
    // Local storage
    SetLocalStorage(key, val){localStorage.setItem(key, val);},
    GetLocalStorage(key){return localStorage.getItem(key);},

    // Cookies
    SetCookie(key, val, hoursToExpire){setCookie(key, val, hoursToExpire)},
    GetCookie(name){return getCookie(name)},

    // Session Storage
    SetSessionStorage(key, val){sessionStorage.setItem(key, val);},
    GetSessionStorage(key){return sessionStorage.getItem(key);},
    
    
    // TODO: Implement
    GetNaviGeoLocal() {},
    GetNaviOnline() {},
    GetUserAgent() {},
}

function setCookie(cname,cvalue,hours) {
    let domain = ".localhost"; // TODO: Change in production
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