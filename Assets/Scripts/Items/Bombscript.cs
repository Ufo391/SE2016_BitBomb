using UnityEngine;
using System.Collections;

public class Bombscript : MonoBehaviour {

    public GameObject bomb_transform;

    public void drop()
    {
        if(bomb_transform == null)
        {
            throw new System.Exception("KEINE bomb_transform");
        }
        StartCoroutine(wait_drop());
    }

    protected IEnumerator wait_drop()
    {
        yield return new WaitForSeconds(1.5f);
        // Create a new shot        
        var shotTransform = Instantiate(bomb_transform) as GameObject;
        shotTransform.transform.parent = GameObject.Find("/Level/1-Foreground/Bomb/").transform;
        

        // Assign position
        shotTransform.transform.position = transform.position;
    }
}
