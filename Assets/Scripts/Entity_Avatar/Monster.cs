using UnityEngine;
using System.Collections;

public class Monster : Avatar {

    public float debug_value = 0;
    private GameObject current_Target;
	
	// Update is called once per frame
	void Update () {
        if (current_Target == null)
        {
            findTarget();
        }
        else
        {
            movetoTarget();
        }        
	}

    private void findTarget()
    {
        foreach (Transform avatar in avatar_object.transform.parent.transform)
        {
            // iteriert im Avatar layer um einen Spieler zu finden und als Ziel zu setzten
            // dies funktioniert indem nachgeschaut wird ob das Gameobject mit dem Spieler.cs ausgestattet ist
            if(avatar.GetComponent<Spieler>() != null)
            {
                this.current_Target = avatar.gameObject;
                break;
            }
        }
    }

    private void movetoTarget()
    {        
        if(Vector2.Distance(this.avatar_object.transform.position,this.current_Target.transform.position) > 0.32f)
        {
            Vector2 movement = new Vector2(0f, 0f);
            float target_angle = calculate_angle(this.avatar_object.transform, this.current_Target.transform);
            this.debug_value = target_angle;

            //if ((target_angle < 180 && target_angle > 160) || (target_angle > -180 && target_angle < -160))
            //{
            //    // BUG FIX wenn target rechts vom Monster ist soll NIX gemacht werden!
            //    // Ansonsten schüttelt der Gute seine Birne bis die CPU explodiert :)
            //}
            //else if (target_angle < 0)
            //{
            //    // nach oben gehen
            //    movement.y = 1;
            //}
            //else if (target_angle > 0)
            //{
            //    // nach unten gehen
            //    movement.y = -1;
            //}


            //if (target_angle < 90)
            //{
            //    // nach links gehen
            //    movement.x = -1;
            //}
            //else if (target_angle > 90)
            //{
            //    // nach rechts gehen
            //    movement.x = 1;
            //}

            //move(movement.x/180, movement.y/180);
            move(target_angle / 180 * -1, target_angle / 180 * -1);
        }        
    }

    private float calculate_angle(Transform first, Transform secound)
    {       
        Vector3 dir = first.position - secound.position;
        dir = secound.transform.InverseTransformDirection(dir);        
        return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }
}
