using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class UserPosition : MonoBehaviour {

    [SerializeField]private static List<GameObject> userList = new List<GameObject>();
    [SerializeField]private int numUsers;
    [SerializeField]private GameObject expoUser;
    public List<int> userSeat = new List<int>();
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
        numUsers = guiContoller.seat;

        GameObject.Find("ExpoCyber").SetActive(true);

        if (numUsers == 0)
        {
            GameObject.Find("ExpoCyber").transform.FindChild("MainCamera").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("EndButton").gameObject.SetActive(true);
        }else
        {
            GameObject.Find("Canvas").transform.Find("OutButton").gameObject.SetActive(true);
        }
        
	    if(numUsers > 0)
        {
            int rowAux = 0;
            do
            {
                if (numUsers / 10 < 1)
                {
                    limit = numUsers % 10;
                    limit++;
                    cont = false;
                }
                int aux = 0;
                for (int i = 1; i < limit ; i++)
                {
                    int seat = (rowAux != 0) ? rowAux * 10 + i : i;
                    GameObject user = (GameObject)Instantiate(prefab);
                    user.name = "user" + seat;

                    if (i % 2 == 0)
                    {
                        user.transform.position = userPos[0] + new Vector3((float)0.9 * -aux, (float)0.487 * rowAux, (float)-0.979 * rowAux);
                    }
                    else
                    {
                        user.transform.position = userPos[0] + new Vector3((float)0.9 * aux, (float)0.487 * rowAux, (float)-0.979 * rowAux);
                        aux++;
                    }
                    userSeat.Add(seat);
                    userList.Add(user);
                }
                rowAux++;
                numUsers -= 9;
            } while (cont);

            GameObject.Find("user"+guiContoller.seat).transform.FindChild("MainCamera").gameObject.SetActive(true);
        }
	}

    public void DeleteRoom()
    {
        string deleteUri = "http://" + guiContoller.net + ":4000/api/room-delete";
        StartCoroutine(delRoom(deleteUri));
    }

    public void ChangeRoom()
    {
        socket.outMessage();
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

    public void CreateUser(int seat)
    {
        int limit = 10;
        bool cont = true;
        int rowAux = 0;
        int numRest = seat;
        GameObject user = null;

        do{
            if (numRest / 10 < 1)
            {
                limit = numRest % 10;
                limit++;
                cont = false;
            }
            int aux = 0;
            for (int i = 1; i < limit; i++)
            {
                int position = (rowAux != 0) ? rowAux * 10 + i : i;
                
                if (i % 2 == 0 && position == seat)
                {
                    user = (GameObject)Instantiate(prefab);
                    user.name = "user" + position;
                    user.transform.position = userPos[0] + new Vector3((float)0.9 * -aux, (float)0.487 * rowAux, (float)-0.979 * rowAux);
                    userSeat.Add(position);
                    userList.Add(user);
                }
                else if(position == seat)
                {
                    user = (GameObject)Instantiate(prefab);
                    user.name = "user" + position;
                    user.transform.position = userPos[0] + new Vector3((float)0.9 * aux, (float)0.487 * rowAux, (float)-0.979 * rowAux);
                    userSeat.Add(position);
                    userList.Add(user);
                }
                else
                {
                    Debug.Log("nadaaaaaa " + seat);
                    aux++;
                }
            }
            rowAux++;
            numRest -= 9;
        } while (cont);
    }

    public void DeleteUser(int seat)
    {

    }
}
