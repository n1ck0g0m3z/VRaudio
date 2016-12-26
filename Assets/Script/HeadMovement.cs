using UnityEngine;
using System.Collections;

public class HeadMovement : MonoBehaviour {

    [SerializeField]public GameObject neck;
    private GUIScript guiController;
    private GameObject userObject;
	// Use this for initialization
	void Start () {
        if (neck == null)
        {
            guiController = (GUIScript)FindObjectOfType(typeof(GUIScript));
            userObject = GameObject.Find("user" + guiController.seat);
            neck = userObject.transform.Find("Armature").gameObject.transform.Find("Hips").gameObject;
            neck = neck.transform.Find("Spine").gameObject.transform.Find("Chest").gameObject;
            neck = neck.transform.Find("Neck").gameObject.transform.Find("Head").gameObject;
        }
        neck.transform.rotation = Quaternion.Euler(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
	}
	
	// Update is called once per frame
	void Update () {
        neck.transform.rotation = Quaternion.Euler(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
        this.transform.position = neck.transform.position;
        this.transform.position = new Vector3(neck.transform.position.x, neck.transform.position.y + (float)0.12, neck.transform.position.z);
    }
}
