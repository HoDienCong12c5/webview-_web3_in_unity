using System;
using UnityEngine;

public class functionStorage
{
    static public void saveData(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }
    static public string getData(string key)
    {
        string data = PlayerPrefs.GetString(key);
        return data;
    }
    static public void deleteAll()
    {
         PlayerPrefs.DeleteAll();
    }
}
