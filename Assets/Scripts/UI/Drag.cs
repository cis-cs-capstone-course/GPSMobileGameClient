﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform returnParent = null;

    private CombatController co;

    private CardManager myCard;

    private GameObject player;
    private Player p;

    private GameObject enemy;
    private Enemy e;

    private void Awake()
    {

    }

    private void Start()
    {
        co = GameObject.Find("CombatUtils").GetComponent<CombatController>();

        myCard = gameObject.GetComponent<CardManager>();

        player = co.PlayerGO;
        enemy = co.EnemyGO;

        p = player.GetComponent<Player>();
        e = enemy.GetComponent<Enemy>();
    }

    public void OnBeginDrag(PointerEventData data)
    {
        returnParent = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData data)
    {
        this.transform.position = data.position;

    }

    public void OnEndDrag(PointerEventData data)
    {
        this.transform.SetParent(returnParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if(returnParent.name == "PlayZone")
        {
            myCard.handleCard(p, e);
            gameObject.Destroy();
        }
    }
    
}
