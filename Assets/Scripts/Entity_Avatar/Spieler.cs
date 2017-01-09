using UnityEngine;
using System.Collections;

public class Spieler : Avatar {
	
	// Update is called once per frame
	void Update () {
        inputHandler();
    }

    private void inputHandler()
    {
        // Bewegung des Spielers
        move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
