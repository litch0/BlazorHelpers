window.BH = {
    CreateElement: (ParrentElement, elementName, id) => {
        let element = document.createElement(elementName);

        element.id = id;
        $(ParrentElement).append($(element));
        return $(element);
    },

    // get values
    Html: (elementSelector) => $(elementSelector).html(),
    Text: (elementSelector) => $(elementSelector).text(),
    Val: (elementSelector) => $(elementSelector).val(),
    Css: (elementSelector, property) => $(elementSelector).css(property),
    Attr: (elementSelector, attribute) => $(elementSelector).attr(attribute),

    // set values
    SetHtml: (elementSelector, html)=>  { console.log(`JS: setting ${html} to ${$(elementSelector)}`); $(elementSelector).html(html);  },
    SetText: (elementSelector, text)=>  { console.log("setting text"); $(elementSelector).text(text); },
    SetVal: (elementSelector, text) => { return $(elementSelector).val(text); },
    SetAttr: (elementSelector, attribute, value) => $(elementSelector).attr(attribute, value),
    SetCss: (elementSelector,  property, value) => $(elementSelector).css(property, value),

    // append stuff to parrent
    Add: (elementSelector, element) => $(elementSelector).append( $(element) ),
    AddHtml: (elementSelector, textHtml) => $(elementSelector).append(textHtml),

    // free the parrent
    Remove: (elementSelector) => $(elementSelector).remove(),
    RemoveChild: (elementSelector, elementToRemove) => $(elementSelector).remove(elementToRemove),
    Empty: (elementSelector) => $(elementSelector).empty(),
    
    // stuff to add
    Show: (elementSelector) =>  $(elementSelector).show(),
    Hide: (elementSelector) =>  $(elementSelector).hide(),

    FadeIn: (elementSelector, speed) =>  $(elementSelector).fadeIn(speed),
    FadeOut: (elementSelector, agrs) =>  $(elementSelector).fadeOut(agrs),
    FadeToggle: (elementSelector) => $(elementSelector).fadeToggle(),
    FadeTo: (elementSelector, speed, opacity) => { $(elementSelector).fadeTo(speed, opacity) },

    SlideDown: (elementSelector, speed) => { $(elementSelector).SlideDown(speed)},
    SlideUp: (elementSelector, speed) => { $(elementSelector).slideUp(speed) },
    SlideToggle: (elementSelector, speed) => { $(elementSelector).slideToggle(speed) },

    //Animate: (elementSelector, params) => { $(elementSelector).animate(JSON.parse(params)) },
    CallJqueryFunc: (elementSelector, funcName, ...args) => $(elementSelector)[funcName](args),
    Test: () => console.log("Hello wolrd"),
}