﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerListUi : MonoBehaviour
{
    // static ExamplePlayerListGUI s_instance;
    //List<JavascriptHook> m_players = new List<JavascriptHook>();

    public PlayerListUIClientcall listclientcall;
<<<<<<< HEAD
    int totalgamers = -1; //minus server
=======
    int totalgamers = 0;
>>>>>>> ce24e986d402135ef5daeb185007506715384315
    int i;
    string connectedwallets;

    void Start()
    {
       // if (!isServer) return;
       // StartCoroutine(Run());
        Debug.Log("0");
    } 

    
    public void AddPlayer()
    {
       // if (!isServer) return;
        totalgamers = totalgamers + 1;
        Cmdupdateui();
    }

    public void RemovePlayer()
    {
       // if (!isServer) return;
        totalgamers = totalgamers - 1;
        Cmdupdateui();
    }
    
    /*
    private IEnumerator Run()
    {
        while (true)
        {
            Debug.Log("1");
            yield return new WaitForSeconds(30);
            Cdupdateui();
            Debug.Log("2");
            StartCoroutine(Run());
        }
        
    }
    */

   // [Command]
    public void Cmdupdateui()
    {
        listclientcall.RpcUpdateUi(totalgamers, i);
    }


}

