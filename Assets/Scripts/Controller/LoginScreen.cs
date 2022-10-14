using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject ContainerBtnMarket;

    [SerializeField]
    private GameObject ContainerBtnImport;

    [SerializeField]
    private GameObject ContainerBtnCreate;

    [SerializeField]
    private Button btnImport;

    [SerializeField]
    private Button btnCreate;

    [SerializeField]
    private Button btnViewMartket;

    [SerializeField]
    private InputField inputKey;

    [SerializeField]
    private Text viewUser;


    public void Awake()
    {
        ContainerBtnMarket.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {

        btnImport.onClick.AddListener(onLickImport);
        btnCreate.onClick.AddListener(onLickCreate);
        btnViewMartket.onClick.AddListener(onViewMartket);
    }

    public  void onLickImport()
    {
        //0x621069999bf3fc57c9be981a96913fbb6ed2f68e78fb05a4d1952ae79d57d485
        funtionWeb3.importPrivate(inputKey.text.ToString());
        setDataLocals(Users.address, Users.privateKey);
        viewUser.text = "Add :" + Users.address + "\n" + " PrKey :" + Users.privateKey;
        setHide();
        Debug.Log("addressUser : " + Users.address);

    }

    public void onLickCreate()
    {
        Debug.Log("onLickCreate : ");
        funtionWeb3.cretateAccount();
        viewUser.text = "Add :" + Users.address + "\n" + " PrKey :" + Users.privateKey;
        setDataLocals(Users.address, Users.privateKey);

        setHide();
    }

    public void onViewMartket()
    {
        SceneManager.LoadScene("Martket");
    }

    public void setHide()
    {
        ContainerBtnImport.SetActive(false);
        ContainerBtnCreate.SetActive(false);
        ContainerBtnMarket.SetActive(true);
    }

    public void setDataLocals(string address, string prKey)
    {
        functionStorage.saveData(Users.PRVIATE_KEY, prKey);
        functionStorage.saveData(Users.ACCOUNT, address);
    }

    public async void onLickSend()
    {
       
        //Debug.Log("inputAddressTo.text.ToString() : " + inputAddressTo.text.ToString());
        //Debug.Log(" Users.address : " + Users.address);

        //float balance =await funtionWeb3.getBalance(Users.address);
        //if(balance > float.Parse(inputValeSend.text.ToString()))
        //{
        //    funtionWeb3.sendTransaction(
        //            Users.address,
        //            Users.privateKey,
        //            inputAddressTo.text.ToString(),
        //            float.Parse("0.001")
        //        );
        //}
        //else
        //{
           
        //}
           
    }
}
