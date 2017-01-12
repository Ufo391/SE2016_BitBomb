using UnityEngine;
using System.Collections;

public class BombObject : MonoBehaviour {

    public int explodeing_range = 5;
    public int strength = 1;
    public bool holeBomb = false;
    public float detonation_wait = 5;

    // Use this for initialization
    void Start () {
        Destroy(gameObject, detonation_wait);
	}
	
}
