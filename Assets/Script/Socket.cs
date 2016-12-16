using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;

public class Socket : MonoBehaviour
{

    WebSocket ws;
    GameObject userController;
    public GUIScript guiContoller;
    private string _token;
    private bool send;
    private int pageNumber;
    private ApiPdf api;
    private string ImgUri;
    private bool init;
    private bool act;

    void Start()
    {
        init = false;
        act = false;
        pageNumber = -1;
        send = false;
        _token = guiContoller.token;
        ws = new WebSocket("ws://192.168.200.203:4000/socket/websocket?token=" + _token);

        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("WebSocket Open");
            ws.Send("{\"topic\":\"rooms:vr_presentation\",\"ref\":1, \"payload\":{},\"event\":\"phx_join\"}");
            send = true;
        };

        ws.OnMessage += (sender, e) =>
        {
            JSONObject json = new JSONObject(e.Data);
            JSONObject data = json.getJSONObject("payload");
            if (data.has("screen_url"))
            {
                act = true;
                ImgUri = data.getString("screen_url");
            }
            Debug.Log("WebSocket Message Data: " + e.Data);
        };

        ws.OnError += (sender, e) =>
        {
            Debug.Log("WebSocket Error Message: " + e.Message);
        };

        ws.OnClose += (sender, e) =>
        {
            Debug.Log("WebSocket Close");
            send = false;
        };

        ws.Connect();
    }

    void SetImgUri()
    {
        api.SetUrl(ImgUri);
    }

    public void ClickAction(string clickEvent)
    {
        pageNumber++;
        string data = "{\"topic\": \"rooms:vr_presentation\",\"ref\": 1,\"payload\":{\"token\":\""+
            _token + "\",\"seat_position\": 0,\"document_id\": 1,\"page\":"+pageNumber+
            ",\"page_action\": \""+clickEvent+"\"},\"event\": \"presenter:page_action\"}";

        ws.Send(data);
    }

    void Update()
    {
        if (!init && act)
        {
            api = (ApiPdf)FindObjectOfType(typeof(ApiPdf));
            init = true;

            SetImgUri();
        }
        string data = "{ \"topic\":\"rooms:vr_presentation\", \"ref\":1, \"payload\":{ \"token\":\""+
                _token +"\", \"seat_position\":3, \"head_position\": { \"x\": 0, \"y\": 0, \"z\""+
                ": 0 }, \"angle\": { \"x\": 0, \"y\": 0, \"z\": 0 }},\"event\":\"presenter:motion\"}";

        if(send) ws.Send(data);

        if (Input.GetKeyUp("s") && send)
        {
            string stream = "{\"topic\":\"rooms:vr_presentation\", \"ref\":1, \"payload\":{\"user\":\"a @a\",\"body\":\"chat - message\"}, \"event\":\"new:message\"}";

            //ClickAction("next");
            
            ws.Send(stream);
        }

    }

    void OnDestroy()
    {
        ws.Close();
        ws = null;
    }

}
