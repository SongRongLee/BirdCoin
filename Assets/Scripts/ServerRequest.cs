using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerRequest : MonoBehaviour {

    private string cookie = "__test=f4a6cec44cd3e9ce11d8a04659bf3a3f;expires=N/A;path=N/A";
    private string disURL = "http://hub12345.yabi.me/";

    public class RecievedData
    {
        public int money;
    }

    public IEnumerator DownMoney(System.Action<string> callback)
    {
        //set content
        WWWForm form = new WWWForm();
        form.AddField("user", "rabbit");

        //set headers
        Dictionary<string, string> headers = form.headers;
        headers["Cookie"] = cookie;

        //Send post
        WWW www = new WWW(disURL + "down_money.php", form.data, headers);
        yield return www;

        if (www.error != null)
        {
            Debug.Log(www.error);
            callback(www.error);
        }
        else
        {
            RecievedData tempData = JsonUtility.FromJson<RecievedData>(www.text);
            Debug.Log("DownMoney Success with money = " + tempData.money);
            callback("success");
        }
    }

    public IEnumerator AddMoney()
    {
        //set content
        WWWForm form = new WWWForm();
        form.AddField("user", "rabbit");

        //set headers
        Dictionary<string, string> headers = form.headers;
        headers["Cookie"] = cookie;

        //Send post
        WWW www = new WWW(disURL + "add_money.php", form.data, headers);
        yield return www;

        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Add money success!!");
        }
    }

    public IEnumerator SubMoney(int amount)
    {
        //set content
        WWWForm form = new WWWForm();
        form.AddField("amount", amount);

        //set headers
        Dictionary<string, string> headers = form.headers;
        headers["Cookie"] = cookie;

        //Send post
        WWW www = new WWW(disURL + "sub_money.php", form.data, headers);
        yield return www;

        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Sub " + amount + " money success!!");
        }
    }
}
