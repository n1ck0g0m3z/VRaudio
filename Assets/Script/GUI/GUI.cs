using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GUI : MonoBehaviour {

    public static GUI Instance;

    public string username;
    public string password;
    public string room;
    public string file;
    public string token;
    public GameObject canvas;
    public GameObject panel;

    void Awake ()
    {
        if (Instance == null)
        {
            panel = canvas.transform.Find("SignIn").gameObject;
            panel.SetActive(true);
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
        }
    }

	public void Join () {
        SceneManager.LoadScene("BattleScene");
    }

    public void SignIn()
    {
        username = GameObject.Find("UserField").GetComponent<InputField>().text.ToString();
        password = GameObject.Find("PwdField").GetComponent<InputField>().text.ToString();
        WWWForm form = new WWWForm();
        form.AddField("user_name",username);
        form.AddField("password",password);
        WWW www = new WWW("http://192.168.200.168:4000/login", form);
        StartCoroutine(LogIn(www));
        panel.SetActive(false);
        panel = canvas.transform.Find("Menu").gameObject;
        panel.SetActive(true);
    }

    public void SignUp()
    {
        panel.SetActive(false);
        panel = canvas.transform.Find("SignUp").gameObject;
        panel.SetActive(true);
    }

    public void Back()
    {
        panel.SetActive(false);
        panel = canvas.transform.Find("SignIn").gameObject;
        panel.SetActive(true);
    }

    public void SignOut()
    {
        username = "";
        password = "";
        room = "";
        file = "";
        token = "";
        Back();
    }
	
    IEnumerator LogIn(WWW www)
    {
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
            yield break;
        }
        JSONObject json = new JSONObject(www.text);
        Debug.Log(json);
    }
}
