using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {

    public byte healthpoints = 100;
    public Vector2 speed = new Vector2(10, 10);
    private Vector2 camera_scopeRadius_min;
    private Vector2 camera_scopeRadius_max;    
    protected GameObject avatar_object;
    private SpriteRenderer avatar_sprite = null;
    public GameObject camera_object = null;

    // Use this for initialization
    void Start()
    {       
        if (this.camera_object == null)
        {
            Debug.Log("INFO: Avatar ("+ this.name +") wurde kein Kameraobjekt zugewiesen");
        }

        initialization();
    }
	
    void LateUpdate()
    {
        if(this.camera_object != null)
        {
            // nach jedem frame wird die kamera nachjustiert
            cameraHandler();
        }        
    }


    private void initialization()
    {
        this.avatar_object = transform.gameObject;
        calculate_cameraRatio();

        //sprite
        GameObject sprite_layer = GameObject.Find("/Level/1-Foreground/Avatar/Player");
        avatar_sprite = sprite_layer.GetComponent<SpriteRenderer>();
        if (avatar_sprite == null) { throw new System.Exception("FEHLER: SpriteRenderer nicht gefunden NULL"); }
    }

    protected void move(float inputX, float inputY)
    {
        //Avatar und Kamera werden bewegt
        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
        movement *= Time.deltaTime;
        this.avatar_object.transform.Translate(movement);
        calculate_spriteDirection(movement);        
    }

    private void calculate_spriteDirection(Vector3 _movement)
    {
        if(_movement.x > 0)
        {
            // bewegt sich nach rechts
            avatar_sprite.flipX = false;
        }else if(_movement.x < 0)
        {
            // bewegt sich nach links
            avatar_sprite.flipX = true;
        }
    }

    private void calculate_cameraRatio()
    {
        // Bereechnet bis wo die Kamera folgen soll
        GameObject scripts_layer = GameObject.Find("Scripts");
        Map_Builder mapbuilder = scripts_layer.GetComponent<Map_Builder>();

        this.camera_scopeRadius_min.x = mapbuilder.mapOffsetX; ;
        this.camera_scopeRadius_min.y = mapbuilder.mapOffsetY;
        this.camera_scopeRadius_max.x = mapbuilder.mapOffsetX + mapbuilder.mapSizeX;
        this.camera_scopeRadius_max.y = mapbuilder.mapOffsetY + mapbuilder.mapSizeY;
    }

    private void cameraHandler()
    {
        this.camera_object.transform.position = new Vector3(Mathf.Clamp(this.avatar_object.transform.position.x, this.camera_scopeRadius_min.x, this.camera_scopeRadius_max.x),
            Mathf.Clamp(this.avatar_object.transform.position.y, this.camera_scopeRadius_min.y, this.camera_scopeRadius_max.y), this.camera_object.transform.position.z);
    }

}
