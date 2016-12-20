using UnityEngine;
using System.Collections;

public class HeadMovement : MonoBehaviour {

    [SerializeField]public GameObject neck;

	// Use this for initialization
	void Start () {
        neck.transform.rotation = Quaternion.Euler(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
	}
	
	// Update is called once per frame
	void Update () {
        neck.transform.rotation = Quaternion.Euler(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
    }
}
