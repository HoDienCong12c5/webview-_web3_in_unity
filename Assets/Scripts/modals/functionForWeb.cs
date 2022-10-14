using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class functionForWeb 
{

    static public void setLocals(UniWebView webView,string key, string value)
    {
        webView.OnPageStarted += (view, ur) => {
            webView.EvaluateJavaScript("enCrypto('salt'," + value + ");", (payload) => {
                webView.EvaluateJavaScript("setLocal(" + key + "," + payload.data + ");", (payload) => {
                    Debug.Log("setLocals : " + payload.resultCode);
                });
            });
           
        };
    }
    static public void addFunBasic(UniWebView webView)
    {
        webView.OnPageStarted += (view, ur) => {
            webView.AddJavaScript("function enCrypto(salt, text) { " +
                "const textToChars = (text) => text.split('').map((c) => c.charCodeAt(0));" +
               "const byteHex = (n) => ('0' + Number(n).toString(16)).substr(-2);" +
               "const applySaltToChar = (code) => textToChars(salt).reduce((a, b) => a ^ b, code);" +
               "return text.split('').map(textToChars).map(applySaltToChar).map(byteHex).join('');" +
               "}"
               ,null);
            webView.AddJavaScript("function setLocal(key, value) { localStorage.setItem(key, value);}", null);
        };
    }
}
