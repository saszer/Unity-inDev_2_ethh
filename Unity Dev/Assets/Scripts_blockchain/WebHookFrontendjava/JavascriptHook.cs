﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//Webhook between game and html interface for web3 - connect to wallet. 
public class JavascriptHook : NetworkBehaviour
{
    public PlayerSpawn playerspawn;
    private bool spawned;

    public Text AddressUI;
    public Text AddressUIinGame;
    public AlphaBlinking DisableStartUiblnkingText;
    PlayerListUi plyruicntrl;

    [SyncVar]public string address;
    void Start()
    {
        spawned = false;
        address = "0x";

        GameObject startque;
        startque = GameObject.Find("Start : QueStart");
        plyruicntrl = startque.GetComponent<PlayerListUi>();
    }


    public void WebHookSpawn(string recievedaddress) //called from frontend webgl html.
    {
        servercall(recievedaddress);
        address = recievedaddress;
        AddressUI.text = address;
        AddressUIinGame.text = address;
        DisableStartUiblnkingText.enabled = false;
    }

    void servercall(string recievedaddress)
    {
        CmdWebhookRecieve(recievedaddress);
    }

    [Command]
    public void CmdWebhookRecieve(string recievedaddress)
    {

            address = recievedaddress;
            Debug.Log("Connected:");
            Debug.Log(recievedaddress);
            plyruicntrl.Cmdupdateui();

    }

    [ClientRpc]
    public void RpcGameStartSpawn()
    {
        if (this.isLocalPlayer)
        {
          //  if (spawned == !true)
          //  {
                if (address != "0x") //check if wallet is connected /came through webhookspawn>^ //enable in live environment.
                {
                    playerspawn.Spawn(address);
                    spawned = true;
                }
            //}
        }
        playerspawn.AfterQueOverFn();

    }


    //below for debugging only. 
    /*
    void Update()
    {
        if (this.isLocalPlayer)
        {
         //   if (spawned == !true)
           // {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    playerspawn.Spawn(address);
                    spawned = true;
                }
           // }
        }

    } 
    */
}
