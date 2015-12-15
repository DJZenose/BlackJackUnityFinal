/*************
*Programmers    : Connor McQuade & Brandon Erb
*Professor      : Ed Barsalou
*Date           : 12/15/2015
*
*FILE           : CardManipulator.cs
**************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardManipulator : MonoBehaviour {
    public GameObject card;
    public Sprite SP1;
    private GameObject[] cardArray = new GameObject[22];
    private int cardArrayIndex = 0;
    private float playerOffSet = 0.5f, opponentOffSet = 0.25f;//offset and counter for the cards being added
    private int playerCardNumber = 0, opponentCardNumber = 0;
    private bool dealerTurnFlag = false;
    public float playerPosX = 0, playerPosY = 0;//positions to place the new player card at;
    public float opponentPosX = 0, opponentPosY = 0; //positions to place the new opponent card at
    public Sprite[] sprites;
    // Use this for initialization
    enum cardReference
    {
        card1 = 1
    };
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (dealerTurnFlag)
        {
            DealerCall();
        }
	}
    /*
* Returns   : Nothing
* Takes     : Nothing
* Purpose   : This method is envoked when it is called at the start of a game
            : it will place two cards for each player and then allow a user to play in turns
*/
    private void DealerCall()
    {
        

        /*
        GameObject stand = GameObject.Find("StandButton");

        //disable users controls so the dealer can draw
        hit.SetActive(false);
        stand.SetActive(false);

        //call the service to get a value for the drawn card


        //add the card to the game
        AddCard(1, false);


        //re-enable the users controls
        hit.SetActive(true);
        stand.SetActive(true);

        //set the flag to the players turn
        dealerTurnFlag = false;
        */
    }

    /*
    * Returns   : Nothing
    * Takes     : Nothing
    * Purpose   : This method is envoked when it is called given a card number and the player type
                : it will 
    */
    public void AddCard(int cardValue, bool isPlayer)
    {
        if (playerCardNumber < 22 && isPlayer == true || opponentCardNumber < 22 && isPlayer == false)
        {
            
            SpriteRenderer tempSprite;
            Transform tempTransform;
            Button hit = GameObject.Find("HitButton").GetComponent<Button>();
            Button stand = GameObject.Find("StandButton").GetComponent<Button>();


            card = GameObject.FindGameObjectWithTag("CardPrefab");
            cardArray[cardArrayIndex] = Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

            //grab the transform component of the object we are making
            tempTransform = cardArray[cardArrayIndex].GetComponent<Transform>();

            //if the player is drawing a card, assign details based on the players area
            if (isPlayer)
            {

                tempTransform.localScale = new Vector3(1f, 1f, 0);//modify the transform SCALE to be the standard of the cards
                tempTransform.localPosition = new Vector3(playerPosX += playerOffSet, playerPosY, 0); //place the card at the players row
                playerCardNumber++;
            }
            //otherwise the dealer is drawing, assign based on dealers area (on players screen)
            else
            {
                tempTransform.localScale = new Vector3(.5f, .5f, 0);//modify the transform SCALE to be the standard of the cards
                tempTransform.localPosition = new Vector3(opponentPosX += opponentOffSet, opponentPosY, 0); // place the card at the opponents row
                opponentCardNumber++;
            }

            //grab the Sprite component of the object we are making
            tempSprite = cardArray[cardArrayIndex].GetComponent<SpriteRenderer>();


            tempSprite.sprite = sprites[cardValue];//assign the appropriate card texture to the object

            //make it so the user has to wait to hit again (until all other players/dealer has finished)
            //hit.interactable = false;

            //wait until the other players have gone before giving control again
            stand.interactable = false;
        }
    }
}
