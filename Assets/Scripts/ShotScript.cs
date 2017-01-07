using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

    public int damage = 1;
    public int exsists_time = 5;
    public bool isEnemyShoot = false;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, exsists_time);
	}
}
