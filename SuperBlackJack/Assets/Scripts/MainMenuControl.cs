/*************
*Programmers    : Connor McQuade & Brandon Erb
*Professor      : Ed Barsalou
*Date           : 12/15/2015
*
*FILE           : MainMenuControl.cs
**************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Encryption;
using System.Net.Sockets;

public class MainMenuControl : MonoBehaviour {

    private bool showPopUp = false;
    private string commandText = "";
    public Texture loginBackground;
    public static string username, passkey;
    public static int balance;
    public static ClientConnection conn = new ClientConnection();
    // Use this for initialization
    void Start() {
        Button hit = GameObject.Find("Sign Out").GetComponent<Button>();
        hit.interactable = false;
        conn.setupSocket();
    }

    // Update is called once per frame
    void Update() {

    }
    /*
* Returns   : Nothing
* Takes     : Nothing
* Purpose   : this is the onclick for logging in.
            : it will take a username and password and
            : send it to the service, the service will
            : validate it and give back a token for the client to use
*/
    public void Login_Click()
    {
        
        //call service to aquire data about user
        commandText = "Login";
        showPopUp = true;
        
    }
    /*
* Returns   : Nothing
* Takes     : Nothing
* Purpose   : this is the signup onclick, it will allow
            : a user to enter a username and password and will
            : query the server to have the user added to the db
*/
    public void Signup_Click()
    {
        //call service to aquire data about user
        commandText = "Sign Up";
        showPopUp = true;

    }
    /*
* Returns   : Nothing
* Takes     : Nothing
* Purpose   : this is the onclick for the signout button
            : it will simply sign the user out of the application
            : by sending a signout request
*/
    public void Signout_Click()
    {
        //issue command to sign out of the server


        toggleUI(true);
        Button signOut = GameObject.Find("Sign Out").GetComponent<Button>();
        signOut.interactable = false;

    }
    /*
* Returns   : Nothing
* Takes     : Nothing
* Purpose   : this is the onclick for the play game button
            : it tells the server it wants to play a new game and then 
            : once the server confirms, it will send its credentials
            : and be put into a new game instance
*/
    public void PlayGame_Click()
    {

        if (true)//if the server says we are in a game
        {
            SceneManager.LoadScene("SuperBlackJack");
        }
        else
        {
            //display error joining game
        }
        
    }
    /*
    * Returns   : Nothing
    * Takes     : Nothing
    * Purpose   : This is what creates the acutal window
                : once called, a box will show up allowing the user to enter
                : some details to the program (signup or login)
    */
    void ShowGUI(int windowID)
    {
        Credentials cred = new Credentials();
        string pass = "", userName = "";
        toggleUI(false);
        //label showing what action the user is performing
        GUI.Label(new Rect(50, 0, 200, 30), commandText);

        //Enter Username text input field
        GUI.Label(new Rect(50, 20, 200, 30), "Enter Username");
        userName = GUI.TextField(new Rect(50, 40, 200, 30), userName, 40);

        //Enter Password text input field
        GUI.Label(new Rect(50, 80, 200, 30), "Enter Password");
        pass = GUI.TextField(new Rect(50, 100, 200, 30), pass, 40);

        //check for when the button is pressed.
        if (GUI.Button(new Rect(50, 150, 75, 30), "OK"))
        {
            //SEND LOGIN REQUEST

            //encrpyt the details
            if (commandText == "Login")
            {
            }
            
            
            else
            {
                //if there was an error, display a message at the bottom of the box displaying what went wrong
                //if (commandText == "Login" && uservalid == null)
               // {

               // }
                if (commandText == "Login")//if the user is trying to login, they entered the password/username wrong or it timed out
                {
                    GUI.Label(new Rect(100, 0, 200, 30), "Username or Password is incorrect");
                }
                else //if the user is trying to sign up, they were rejected... bummer
                {

                    GUI.Label(new Rect(100, 0, 200, 30), "Server rejected account creation: please try again");
                }
               
            }
        }

    }
    /*
    * Returns   : Nothing
    * Takes     : Nothing
    * Purpose   : this method shows a gui when the flag is changed
                : it will invoke the Shopgui with the size of the window
                : and the showGUi will fill in the rest of the details
    */
    void OnGUI()
    {
        if (showPopUp)
        {
            //create a new window that is a fraction of the screens size
            GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
                   , 300, 250), ShowGUI, loginBackground);

        }
    }

    /*
* Returns   : Nothing
* Takes     : Nothing
* Purpose   : this just toggles the UI from all on to all off for easy mass manipulation
*/
    void toggleUI(bool toggle)
    {
        //deactivate all controls on the main menu scene
        Button signOut = GameObject.Find("Sign Out").GetComponent<Button>();
        signOut.interactable = toggle;
        Button signUp = GameObject.Find("Sign Up").GetComponent<Button>();
        signUp.interactable = toggle;
        Button login = GameObject.Find("Login Button").GetComponent<Button>();
        login.interactable = toggle;
        Button exit = GameObject.Find("Exit Button").GetComponent<Button>();
        exit.interactable = toggle;
        Button play = GameObject.Find("Play Game").GetComponent<Button>();
        play.interactable = toggle;
    }

}
