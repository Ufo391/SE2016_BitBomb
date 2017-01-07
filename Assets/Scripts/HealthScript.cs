using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

    public int hp = 5;
    public bool isEnemy = false;

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D collider) {
        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        if(shot != null)
        {
            if (shot.isEnemyShoot != isEnemy)
            {
                hp -= shot.damage;
                Destroy(shot.gameObject);
                if(hp <= 0)
                {
                    Destroy(gameObject);
                    
                }
            }
        }
	}

}
