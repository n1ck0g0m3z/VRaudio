using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;

public class Socket : MonoBehaviour
{

    WebSocket ws;
    GameObject userController;
    public GUIScript guiContoller;

    void Start()
    {
        string _token = guiContoller.token;
        ws = new WebSocket("ws://192.168.200.203:4000/socket/websocket?token=" + _token);

        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("WebSocket Open");
            ws.Send("{\"topic\":\"rooms: vr_presentation\",\"ref\":1, \"payload\":{},\"event\":\"phx_join\"}");
        };

        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("WebSocket Message Data: " + e.Data);
        };

        ws.OnError += (sender, e) =>
        {
            Debug.Log("WebSocket Error Message: " + e.Message);
        };

        ws.OnClose += (sender, e) =>
        {
            Debug.Log("WebSocket Close");
        };

        ws.Connect();
    }

    void Update()
    {

        if (Input.GetKeyUp("d"))
        {
            string stream = "{\"topic\":\"rooms: vr_presentation\", \"ref\":1, \"payload\":{\"user\":\"a @a\",\"body\":\"chat - message\"}, \"event\":\"new:message\"}";
            
            ws.Send(stream);
        }

    }

    void OnDestroy()
    {
        ws.Close();
        ws = null;
    }

    enum Type
    {
        REGISTER = 1,
        SEND_DATA = 2,


    }

}
