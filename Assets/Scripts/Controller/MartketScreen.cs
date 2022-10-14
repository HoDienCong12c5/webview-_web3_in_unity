using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MartketScreen : MonoBehaviour
{

    [SerializeField]
    private Button btnViewMartket;

    [SerializeField]
    private Button btnViewLocals;

    private UniWebView webView;

    public void Awake()
    {
      
    }
    // Start is called before the first frame update
    void Start()
    {
        UniWebView.SetAllowJavaScriptOpenWindow(true);
        ////webView.SetCalloutEnabled(true);
        UniWebView.SetAllowAutoPlay(true);

        var webViewGameObject = new GameObject("WebView");
        webView = webViewGameObject.AddComponent<UniWebView>();

        webView.SetShowToolbarNavigationButtons(true);
        webView.SetShowSpinnerWhileLoading(true);
        webView.SetShowToolbar(true);
        webView.SetVerticalScrollBarEnabled(true);
        webView.SetBackButtonEnabled(true);
        webView.SetToolbarGoBackButtonText("back");
        webView.SetAllowFileAccess(true);
        webView.SetLoadWithOverviewMode(true);
        var color = new Color(0.263f, 0.627f, 0.278f);

        webView.SetToolbarTintColor(color);


        webView.Frame = new Rect(0, 150, Screen.width, Screen.height-300); // 1
        btnViewMartket.onClick.AddListener(onViewMartket);
        btnViewLocals.onClick.AddListener(onViewLocals);
        Debug.Log("Users.address"+ Users.address.ToString());
    }

    // Update is called once per frame
    public void onViewLocals()
    {
        webView.Hide();

    }
    public  void onViewMartket()
   {
        webView.Load("https://demo-nftgame.w3w.app/");

         functionForWeb.addFunBasic(webView);
        functionForWeb.setLocals(webView, Users.PRVIATE_KEY,Users.privateKey);
        functionForWeb.setLocals(webView, Users.ACCOUNT, Users.address);
        webView.Show();
        
        
   }
}
