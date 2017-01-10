using UnityEngine;
using System.Collections;

public class Monster : Avatar {

    public float debug_value = 0;
    private bool isOnTheWay = false;
    private Vector2 target_block = new Vector2();
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
        Vector2 movement = new Vector2(0f, 0f);
        move(movement.x, movement.y);
    }

    private void ki()
    {
        // Kann nur in bestimmte Richtung gucken links rechts unten oben
        // Checkt ob er in die Richtung gehen kann in der er grade schaut
        // Checkt wie weit er gehen kann und setzt sich maximal das ende der begehbaren Blockweg als Ziel
        // fängt an richtung Zielblock zu bewegen und schaut währenddessen um sich ob Spieler da ist 
        // Wenn Spieler endeckt wird währenddessen dann wird der Zielblock auf die letzte bekante Position des Spielers gesetzt
        // Wenn nicht geht das Monster zum normalen Zielblock und fängt bei Schritt eins an

        float rnd = Random.value;
        if(rnd <= 0.25f)
        {
            // oben


        }
        else if(rnd <= 0.5f)
        {
            // unten
        }
        else if (rnd <= 0.75f)
        {
            // links
        }else
        {
            // rechts
        }

    }
    
}
