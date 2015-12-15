/*************
*Programmers    : Connor McQuade & Brandon Erb
*Professor      : Ed Barsalou
*Date           : 12/15/2015
*
*FILE           : ButtonControl.cs
**************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Net.Sockets;
using System;
using System.IO;

public class ButtonControl : MonoBehaviour {
    public CardManipulator cardMaker;
    public List<int> cardValues = new List<int>();
    public static ClientConnection conn2 = new ClientConnection();
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}

    //this is enacted when the level loads. it allows changes to happen just as a scene loads
    void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            //set the players name to the name given by the server
            Text playerName = GameObject.Find("PlayerName").GetComponent<Text>();
            playerName.text = MainMenuControl.username;

            //set the players balance to the one the server states
            Text playerBalance = GameObject.Find("PlayerBalance").GetComponent<Text>();
            playerName.text = MainMenuControl.balance.ToString();
        }

    }
    /*
    * Returns   : Nothing
    * Takes     : Nothing
    * Purpose   : This method is envoked when the "HIT" button is clicked
                : It will make a HIT request to the server instance
                : The Server will return a value from 0-52 which indicates which card was drawn
    */
    private int suit;
    private int card;
    private List<int> deck = new List<int>();
    private int deckNum = 6;

    /*
* Returns   : Nothing
* Takes     : Nothing
* Purpose   : This is the onclick for the hit button
            : it calls the game server with a request to "HIT"
            : the server then gives it back a new card value to add to its cards
*/
    public void Hit_Click()
    {

        int card = 0;
        //call the service to get a value for the drawn card
        suit = UnityEngine.Random.Range(1, 4);
        card = UnityEngine.Random.Range(1, 13);
        /*
        conn2.setupSocket();
        conn2.writeSocket("HIT");
        //card = Convert.ToInt32 (MainMenuControl.conn.readSocket());
        string cardd = conn2.readSocket().ToString();
        Text playerName = GameObject.Find("PlayerName").GetComponent<Text>();
        playerName.text = cardd;
        //call card maker to create a card based on the servers value
        if (false)
        {
            
            
        }
        */
        cardMaker.AddCard(card * suit -1, true);
        cardValues.Add(card);
    }

    /*
    * Returns   : Nothing
    * Takes     : Nothing
    * Purpose   : This method is envoked when the "STAND" button is clicked
                : It wil make a STAND request to the server instance
    */
    public void Stand_Click()
    {
        int cardTotal = 0;
        string standSuccess = "";
        foreach (int card in cardValues)
        {
            if (card == 1)
            {
                cardTotal += 11;
            }
            else
            {
                cardTotal += card;
            }
            
        }

        if (cardTotal > 21)
        {
            cardTotal = 0;
            foreach (int card in cardValues)
            {
                cardTotal += card;
            }
        }

        //SEND THE FINAL CARD TOTAL TO THE SERVER
        do
        {
            MainMenuControl.conn.writeSocket("HIT");
            standSuccess = MainMenuControl.conn.readSocket();
        } while (standSuccess != "SUCCESS");
        
    }

    /*
    * Returns   : Nothing
    * Takes     : Nothing
    * Purpose   : This method is envoked when the "LEAVE TABLE" button is clicked
                : It will make a LEAVE call to the server and then exit the user out of the game
    */
    public void Leave_Click()
    {

    }
    /*
* Returns   : Nothing
* Takes     : Nothing
* Purpose   : This is the onclick for the BET button
            : it allows the user to bet a sum of money to the game they are in
            : it bases the money on 5 chip increments.
*/
    public void Bet_Click()
    {
        //SEND BET REQUEST WITH A VALUE OF 5
    }
    
}
