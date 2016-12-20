using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class UserPosition : MonoBehaviour {

    [SerializeField]private static List<GameObject> userList = new List<GameObject>();
    [SerializeField]private int numUsers;
    [SerializeField]private GameObject expoUser;
    private Socket socket;
    private GUIScript guiContoller;

    public GameObject prefab;
    
    private static Vector3[] userPos = {
        new Vector3(0,(float)-0.007,(float)7.338),
    };

    private static Vector3[] userRot = {
        new Vector3(0,90,0),
    };

	// Use this for initialization
	void Start () {
        socket = (Socket)FindObjectOfType(typeof(Socket));
        guiContoller = (GUIScript)FindObjectOfType(typeof(GUIScript));
        expoUser.SetActive(true);
        userList.Add(expoUser);
        bool cont = true;
        int limit = 10;

        if(guiContoller.seat == 0)
        {
            GameObject.Find("Canvas").transform.Find("EndButton").gameObject.SetActive(true);
        }else
        {
            GameObject.Find("Canvas").transform.Find("OutButton").gameObject.SetActive(true);
        }
        
	    if(numUsers > 1)
        {
            int rowAux = 0;
            do
            {
                if (numUsers / 10 < 1)
                {
                    limit = numUsers % 10;
                    cont = false;
                }
                int aux = 0;
                for (int i = 1; i < limit ; i++)
                {
                    GameObject user = (GameObject)Instantiate(prefab);
                    user.name = "user" + i;
                    if (i % 2 == 0)
                    {
                        user.transform.position = userPos[0] + new Vector3((float)0.9 * -aux, (float)0.487 * rowAux, (float)-0.979 * rowAux);
                    }
                    else
                    {
                        user.transform.position = userPos[0] + new Vector3((float)0.9 * aux, (float)0.487 * rowAux, (float)-0.979 * rowAux);
                        aux++;
                    }
                    userList.Add(user);
                }
                rowAux++;
                numUsers -= 10;
            } while (cont);
        }
	}

    public void DeleteRoom()
    {
        string deleteUri = "http://" + guiContoller.net + ":4000/api/room-delete";
        StartCoroutine(delRoom(deleteUri));
    }

    public void ChangeRoom()
    {
        socket.ws.Close();
        socket.enabled = false;
        SceneManager.LoadScene("logIn");
    }

    // Update is called once per frame
    void Update () {
	
	}

    IEnumerator delRoom(string uri)
    {
        WWWForm form = new WWWForm();
        form.AddField("token", guiContoller.token);
        form.AddField("room_name", guiContoller.room);
        WWW www = new WWW(uri, form);
        yield return www;

        JSONObject json = new JSONObject(www.text);

        Debug.Log(json);

        if (json.getInt("result")==1)
        {
            socket.ws.Close();
            socket.enabled = false;
            SceneManager.LoadScene("logIn");
        }
    }
}
