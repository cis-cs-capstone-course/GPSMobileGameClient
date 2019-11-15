﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


[CreateAssetMenu(menuName ="Card")]
public class Card : ScriptableObject, ICardInterface
{
    [SerializeField] private int id;
    [SerializeField] private string cardName;
    [SerializeField] private string cardDetail;
    [SerializeField] private string cardFlavor;
    public Sprite art;
    [SerializeField] private int level;
    [SerializeField] private int memoryCost;
    


    public int Id { get => id; set => id = value; }
    public string Name { get => cardName; set => cardName = value; }
    public string Detail { get => cardDetail; set => cardDetail = value; }
    public string Flavor { get => cardFlavor; set => cardFlavor = value; }
    public int Level { get => level; set => level = value; }
    public int MemoryCost { get => memoryCost; set => memoryCost = value; }
    // public int PP { get => pp; set => pp = value; }

    // Constructor for empty card
    public Card()
    {
        id = -1;
        Name = "";
        Level = 0;
        MemoryCost = 0;
    }

    // Constructor for a filled in card
    public Card(int id, string name, string detail, string cardFlavor, int level, int mem_cost)
    {
        Id = id;
        Name = name;
        Detail = detail;
        Flavor = cardFlavor;
        Level = level;
        MemoryCost = mem_cost;
    }

    public virtual void playCard(Player p, Enemy e) { }

    public Card(){

    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public bool Card_pp(string CardName, bool isRefresh)
    {
        string json = "\"cardname\": " + CardName + ",\n\"isrefresh\": " + isRefresh.ToString();
        StartCoroutine(PostRequest("https://gps-mobile-game-server.herokuapp.com/user/deck", json));
    }
    IEnumerator PostRequest(string uri, string json)
    {
        var uwr = new UnityWebRequest(uri, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
            pp = Int32.Parse(uwr.downloadHandler.text);
        }
    }
}
