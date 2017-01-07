using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

    public Vector2 speed = new Vector2(10, 10);
    public string follow_target = "";
    public Vector2 direction = new Vector2(0, 0);
    private Vector3 movement;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(follow_target.Length > 0) {
            direction_calc(GameObject.Find(follow_target).transform.position);
        }
        move();
	}

    private void move()
    {
        movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }

    private void direction_calc(Vector3 player_pos)
    {
        if (player_pos != null)
        {
            // X - Axis
            if (player_pos.x > this.transform.position.x && (player_pos.x - this.transform.position.x > 1))
            {
                this.direction.x = 1;
            }
            else if (player_pos.x < this.transform.position.x && (this.transform.position.x - player_pos.x > 1))
            {
                this.direction.x = -1;
            }
            else
            {
                this.direction.x = 0;
            }

            // Y - Axis
            if (player_pos.y > this.transform.position.y && (player_pos.y - this.transform.position.y > 1))
            {
                this.direction.y = 1;
            }
            else if (player_pos.y < this.transform.position.y && (this.transform.position.y - player_pos.y > 1))
            {
                this.direction.y = -1;
            }
            else
            {
                this.direction.y = 0;
            }
        }
    }
}
