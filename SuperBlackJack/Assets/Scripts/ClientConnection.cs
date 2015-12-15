/*************
*Programmers    : Connor McQuade & Brandon Erb
*Professor      : Ed Barsalou
*Date           : 12/15/2015
*
*FILE           : ClientConnection.cs
**************/
using UnityEngine;
using System.Collections;
using System;
using System.Net.Sockets;
using System.IO;

public class ClientConnection : MonoBehaviour {

    internal Boolean socketReady = false;
    public static TcpClient mySocket;
    public static NetworkStream theStream;
    public static StreamWriter theWriter;
    public static StreamReader theReader;
    String Host = "10.192.140.173";
    Int32 Port = 3001;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /*
    * Returns   : Nothing
    * Takes     : Nothing
    * Purpose   : sets up a connection to the game server given the server's IP and a port
    */
    public void setupSocket()
    {
        try
        {
            mySocket = new TcpClient(Host, Port);
            theStream = mySocket.GetStream();
            theWriter = new StreamWriter(theStream);
            theReader = new StreamReader(theStream);
            socketReady = true;
        }
        catch (Exception e)
        {
            Debug.Log("Socket error: " + e);
        }
    }

    /*
    * Returns   : Nothing
    * Takes     : a string of data that will be sent
    * Purpose   : writes data to the socket previously declared in setup
    */

    public void writeSocket(string theLine)
    {
        if (!socketReady)
        {
            return;
        }
        String foo = theLine + "\r\n";
        theWriter.Write(foo);
        theWriter.Flush();
    }
    /*
    * Returns   : Nothing
    * Takes     : Nothing
    * Purpose   : reads data from the socket previously declared in setup
    */
    public String readSocket()
    {
        if (!socketReady)
        {
            return "";
        }
        if (theStream.DataAvailable)
        {
            return theReader.ReadLine();
        }
        return "";
    }
    /*
    * Returns   : Nothing
    * Takes     : Nothing
    * Purpose   : closes the connection to the game server
    */
    public void closeSocket()
    {
        if (!socketReady)
        {
            return;
        }
        theWriter.Close();
        theReader.Close();
        mySocket.Close();
        socketReady = false;
    }
}
