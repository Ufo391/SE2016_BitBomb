using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public Vector2 speed = new Vector2(50, 50);
    private float inputX = 0;
    private float inputY = 0;
    private Vector3 movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        move();
        attack();
    }

    private void move()
    {
        this.inputX = Input.GetAxis("Horizontal");
        this.inputY = Input.GetAxis("Vertical");
        movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }

    private void attack()
    {
        if(Input.GetButtonDown("Fire1") == true || Input.GetButtonDown("Fire2"))
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if(weapon != null)
            {
                weapon.Attack(false);
            }
        }
    }
}
