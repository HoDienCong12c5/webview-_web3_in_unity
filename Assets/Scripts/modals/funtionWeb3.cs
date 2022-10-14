using System;
using System.Threading.Tasks;
using UnityEngine;

public class funtionWeb3 
{
    int chainBNB = 97;
    static string chain = "binance";
    static string network = "testnet";
    static string rpc = "https://data-seed-prebsc-1-s1.binance.org:8545/";
    // Start is called before the first frame update
    static public async void sendTransaction(string addUser, string prUser, string addressTo,float value)
    {
        string chainId = await EVM.ChainId(chain, network, rpc);
        string gasPrice = await getGasPrice();
        string data = "";
        string gasLimit = "21000";
        string transaction = await EVM.CreateTransaction(
                                        chain,
                                        network,
                                        addUser,
                                        addressTo,
                                        value.ToString(),
                                        data,
                                        gasPrice,
                                        gasLimit,
                                        rpc
                                       );
        string signature = Web3PrivateKey.SignTransaction(prUser, transaction, chainId);
        string response = await EVM.BroadcastTransaction(chain, network, addUser, addressTo, value.ToString(), data, signature, gasPrice, gasLimit, rpc);
        Debug.Log("response:" + response);
    }

    static public void cretateAccount()
    {

        byte[] array = new byte[255];
        System.Random random = new System.Random();
        random.NextBytes(array);
        string prKeyTemp = "0x";
        int i = 1;
        foreach (var variableName in array)
        {
            if (i == 32)
            {
                break;
            }
            else
            {
                prKeyTemp += variableName.ToString("x");
                i++;
            }

        }
        Users.privateKey = prKeyTemp;
        importPrivate(prKeyTemp);

    }
    static public void importPrivate(string privateKey)
    {
        string account = Web3PrivateKey.Address(privateKey);
        Users.address = account;
        Users.privateKey = privateKey;
    }
    static public async Task<string> getGasPrice()
    {
        string gasPrice = await EVM.GasPrice(chain, network, rpc);
        return gasPrice;
    }
    static public async Task<float> getGasLimit(string addressTo, float value)
    {
        string gasLimit = await EVM.GasLimit(
                chain,
                network,
                addressTo,
                value.ToString(),
                "",
                rpc
            );
        return float.Parse(gasLimit);
    }
    static public async Task<float> getBalance(string account)
    {
        string balance = await EVM.BalanceOf(chain, network, account);

        return convertWEI(float.Parse(balance));


    }

    static public async Task<int> getNonce()
    {
        string nonce = await EVM.Nonce(chain, network, Users.address);
        return int.Parse(nonce);
    }

    static public float convertWEI(float value)
    {
        float eth = value;
        float decimals = 1000000000000000000; // 18 decimals
        float wei = eth / decimals;
        return ((float)Convert.ToDecimal(wei));
    }
    static public string enCrypt(string salt, string text)
    {
        //int number = 3;
        //string[] splitText = text.Split("");
        //string textToChars = splitText[0];
        //string nHex = "0" + number.toString("x")).substr(-2)
        return "";
    }
}
