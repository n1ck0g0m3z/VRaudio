using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;

public class Socket : MonoBehaviour
{

    [SerializeField]public WebSocket ws;
    GameObject userController;
    public GUIScript guiContoller;
    [SerializeField]private string _token;
    private bool send;
    private static int pageNumber;
    private ApiPdf api;
    private string ImgUri;
    private bool init;
    private bool act;
    private int _seat;
    private HeadMovement head;
    private GameObject neck;

    public void startSocket()
    {
        init = false;
        act = false;
        pageNumber = 0;
        send = false;
        _seat = guiContoller.seat;
        _token = guiContoller.token;
        ws = new WebSocket("ws://"+guiContoller.net + ":4000/socket/websocket?token=" + _token);

        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("WebSocket Open");
            ws.Send("{\"topic\":\"rooms:vr_presentation\",\"ref\":1, \"payload\":{\"room_name\":\""+ guiContoller.room +"\"},\"event\":\"phx_join\"}");
            send = true;
        };

        ws.OnMessage += (sender, e) =>
        {
            JSONObject json = new JSONObject(e.Data);
            JSONObject data = json.getJSONObject("payload");

            if(data.has("response"))
            {
                if(data.getJSONObject("response").getInt("result") == 1)
                {
                    ImgUri = data.getJSONObject("response").getString("url");
                    act = true;
                }
            }

            if (data.has("screen_url"))
            {
                if (data.getString("screen_url") != "")
                {
                    act = true;
                    ImgUri = data.getString("screen_url");
                }
            }

            if (data.has("seat_position"))
            {
                if (data.getInt("seat_position") != _seat)
                {
                    Debug.Log("WebSocket Message Data: " + e.Data);
                }
            }
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
        act = false;
    }

    public void ClickAction(string clickEvent)
    {
        if (_seat == 0)
        {
            string data = "{\"topic\": \"rooms:vr_presentation\",\"ref\": 1,\"payload\":{\"token\":\"" +
                _token + "\",\"seat_position\": " + _seat + ",\"document_id\": 1,\"page\":" + pageNumber +
                ",\"page_action\": \"" + clickEvent + "\"},\"event\": \"presenter:page_action\"}";

            ws.Send(data);

            if (clickEvent == "next")
            {
                pageNumber++;
            }
            else if (pageNumber > 0)
            {
                pageNumber--;
            }
            Debug.Log(pageNumber);
        }
    }

    void Update()
    {
        if (!init && act)
        {
            head = (HeadMovement)FindObjectOfType(typeof(HeadMovement));
            neck = head.neck;
            api = (ApiPdf)FindObjectOfType(typeof(ApiPdf));
            init = true;

            SetImgUri();
        }
        else if (act) {
            SetImgUri();
        }
        
        string data = "{ \"topic\":\"rooms:vr_presentation\", \"ref\":1, \"payload\":{ \"token\":\""+
                _token +"\", \"seat_position\": "+_seat+", \"head_position\": { \"x\": 0, \"y\": 0, \"z\""+
                ": 0 }, \"angle\": { \"x\": "+ neck.transform.localEulerAngles.x +
                ", \"y\": "+ neck.transform.localEulerAngles.y + ", \"z\": "+ neck.transform.localEulerAngles.z + 
                " },\"name\":\""+guiContoller.username+"\"},\"event\":\"presenter:motion\"}";

        if(send) ws.Send(data);

        if (Input.GetKeyUp("s") && send)
        {
            string stream = "{\"topic\":\"rooms:vr_presentation\", \"ref\":1, \"payload\":{\"user\":\""+guiContoller.username+"\",\"body\":\"chat - message\"}, \"event\":\"new:message\"}";
            
            ws.Send(stream);
        }

    }

    void OnDestroy()
    {
        if (ws != null)
        {
            ws.Close();
            ws = null;
        }
    }
}
