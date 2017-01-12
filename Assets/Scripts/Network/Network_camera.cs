using UnityEngine;
using System.Collections;

public class Network_camera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Camera cam = GetComponent<Camera>();
        if (GetComponent<NetworkView>().isMine)
        {
            cam.enabled = true;
        }
        else
        {            
            cam.enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
