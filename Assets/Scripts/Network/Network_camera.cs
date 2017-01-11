using UnityEngine;
using System.Collections;

public class Network_camera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GetComponent<NetworkView>().isMine)
        {
            GetComponent(Camera).enabled = true;
        }
        else
        {
            GetComponent(Camera).enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
