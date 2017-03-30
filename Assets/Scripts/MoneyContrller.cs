using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyContrller : MonoBehaviour {
    public Text moneyText;
    public GameObject serverRequestOBJ;
    public GameObject buttonOBJ;
    public class RecievedData
    {
        public string money;
    }
    private ServerRequest serverRequest;
    private Button buyButton;
    private int mMoney;
	// Use this for initialization
	void Start () {
        //Setup components
        serverRequest = serverRequestOBJ.GetComponent<ServerRequest>();
        buyButton = buttonOBJ.GetComponent<Button>();
        buyButton.onClick.AddListener(ButtonOnclick);
        //buyButton.interactable = false;

        //Read money from server
        UpdateMoney();
    }

    // Update is called once per frame
    void Update () {
        /*if(mMoney >= 10)
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
        }*/
	}
    void ButtonOnclick()
    {
        /*mMoney -= 10;

        //Sub money from server
        SubMoney(10);

        //Read money from server
        UpdateMoney();*/

        UpdateMoney();

    }

    void UpdateMoney()
    {
        StartCoroutine(serverRequest.DownMoney((returnValue) => {
            //mMoney = returnValue;
            moneyText.text = returnValue;
        }));
    }

    void AddMoney()
    {
        StartCoroutine(serverRequest.AddMoney());
    }

    void SubMoney(int amount)
    {
        StartCoroutine(serverRequest.SubMoney(amount));
    }
}
