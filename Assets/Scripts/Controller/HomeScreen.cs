using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScreen : MonoBehaviour
{
    public Button btnLogin;
    public Text user;
    // Start is called before the first frame update
    void Start()
    {
        btnLogin.onClick.AddListener(Login);
    }
    public void Login()
    {
        Debug.Log("login");
        if (Users.address != "")
        {
            SceneManager.LoadScene("Martket");
        }
        else
        {
            SceneManager.LoadScene("Login");

        }
    }
    public void Awake()
    {
        string myPrKey = PlayerPrefs.GetString(Users.PRVIATE_KEY);
        string myAccount= PlayerPrefs.GetString(Users.ACCOUNT);
        if(myPrKey!= null && myAccount!=null & myPrKey != "")
        {
            Users.address = myAccount;
            Users.privateKey = myPrKey;
            user.text = "Add :" + myAccount + "\n" + " PrKey :" + myPrKey;
        }
        else
        {
            user.text = "Your account is null";
        }
    }

}
