using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebView : MonoBehaviour
{
    public Button btnView;
    public Button btnSenPrKey;

    UniWebView webView;
    // Start is called before the first frame update
    void Start()
    {

        int myint = PlayerPrefs.GetInt("key");
        print("get local" + myint);
        UniWebView.SetAllowJavaScriptOpenWindow(true);

        var webViewGameObject = new GameObject("WebView");
        webView = webViewGameObject.AddComponent<UniWebView>();
        webView.SetShowToolbar(
          true,  // Show or hide?         true  = show
          false, // With animation?       false = no animation
          true,  // Is it on top?         true  = top
          true // Should adjust insets? true  = avoid overlapping to web view
        );

        btnView.onClick.AddListener(viewWeb);
        btnSenPrKey.onClick.AddListener(setPrivateKey);
        //webView.SetTransparencyClickingThroughEnabled(true);

    }
    public void TriggerEvent(string name, string data)
    {

    }
    public void viewWeb()
    {
        PlayerPrefs.SetInt("key", 5);

        webView.Frame = new Rect(0, 0, Screen.width-200, Screen.height- 800); // 1
        webView.Load("https://okok-zeta.vercel.app/");
        webView.OnPageStarted += (view, ur) =>{
            webView.AddJavaScript("function setLocal() {  localStorage.setItem( 'key', '5' );}", (payload) => {
                webView.EvaluateJavaScript("setLocal();", (payload) => {
                    print("setLocal : " + payload.resultCode);
                });
            });
        };
            webView.Show();
        setPrivateKey();



    }
    public void setPrivateKey()
    {
        webView.OnPageFinished += (view, statusCode, url) => {
            webView.AddJavaScript("function getLocal() {   return localStorage.getItem('key'); }", (payload) => {
                webView.EvaluateJavaScript("getLocal();", (payload) => {
                    print("getLocal :" + payload.data);
                });
            });
        };
        webView.AddJavaScript("function getLocal() {   return localStorage.getItem('key'); }", (payload) => {
            webView.EvaluateJavaScript("getLocal();", (payload) => {
                print("getLocal :" + payload.data);
            });
        });
        int myint = PlayerPrefs.GetInt("key");
        print("get local" + myint);


    }
    public  void saveDSata()
    {
        int x = Application.persistentDataPath.Length;
        PlayerPrefs.SetInt("myPref", 5);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
