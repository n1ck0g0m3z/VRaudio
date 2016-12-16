using UnityEngine;
using System.Collections;
using MiniJSON;

public class ApiPdf : MonoBehaviour
{
    [SerializeField]
    protected Material material;
    public string urlImg;
    private Socket socketController;

    public static string keyWord;

    void Start()
    {
        socketController = (Socket)FindObjectOfType(typeof(Socket));
    }

    public void SetUrl(string url)
    {
        urlImg = url;

        StartCoroutine(GetJson());
    }

    IEnumerator GetJson()
    {
        WWW www;

        if (urlImg == "")
        {
            www = new WWW("http://api.gnavi.co.jp/RestSearchAPI/20150630/?keyid=dc11c74cfb148842d8ed57894c4cb57e&format=json&freeword=コロンビア");
            yield return www;

            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(string.Format("Fail!\n{0}", www.error));
                yield break;
            }
            JSONObject json = new JSONObject(www.text);
            //JSONObject jsonAr = json.getJSONObject("rest");
            JSONArray ja2 = json.getJSONArray("rest");
            Debug.Log(ja2);

            /* IList search = (IList)Json.Deserialize('['+jsonAr.ToString()+']');

             //IList stores = (IList)search["rest"];

             foreach (IDictionary shop in search)
             {
                 Debug.Log(string.Format("tweet: {0} : {1}", shop["name"], shop["url"]));
              }
              */
            for (int i = 0; i < ja2.length(); i++)
            {
                //string message = ja2.getJSONObject(i).getString("name");

                JSONArray jPic = new JSONArray("[" + ja2.getJSONObject(i).getString("image_url").ToString() + "]");
                string imgUrl = jPic.getJSONObject(0).getString("shop_image1");

                if (imgUrl != ("{}"))
                {
                    StartCoroutine(getImg(jPic.getJSONObject(0).getString("shop_image1")));

                    Debug.Log(jPic.getJSONObject(0).getString("shop_image1"));
                }
            }
        }
        else
        {
            www = new WWW(urlImg);
            yield return www;
            material.mainTexture = www.texture;
        }

    }
    IEnumerator getImg(string url)
    {
        WWW www2 = new WWW(url);
        yield return www2;
        material.mainTexture = www2.texture;
    }

    void Update()
    {
        #if UNITY_EDITOR
        if (OVRInput.GetUp(OVRInput.Button.DpadRight))
        {
            socketController.ClickAction("next");
        }
        else if (OVRInput.GetUp(OVRInput.Button.DpadLeft))
        {
            socketController.ClickAction("before");
        }
        #endif
    }
}