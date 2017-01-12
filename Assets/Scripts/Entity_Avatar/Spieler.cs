using UnityEngine;
using System.Collections;

public class Spieler : Avatar {

    private float wait_secounds = 100f;

	// Update is called once per frame
	void Update () {
        inputHandler();
    }

    private void inputHandler()
    {        
        if (!isBusy)
        {
            if (Input.GetButtonDown("Fire1") == true)
            {
                isBusy = true;
                dropBomb();
            }

            move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }        
    }

    private void dropBomb()
   {
        dropBomb_animation();
        GetComponent<Bombscript>().drop();
    }

    private void dropBomb_animation()
    {
        avatar_sprite.sprite = sprite_action;
        StartCoroutine(wait_reset_sprite());
    }

}
