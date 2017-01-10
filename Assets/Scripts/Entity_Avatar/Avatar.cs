using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {

    public Vector2 curBlock_position = new Vector2(0f,0f);
    public GameObject currentBlock = null;
    public byte healthpoints = 100;
    public Vector2 speed = new Vector2(12.8f, 12.8f);
    private Vector2 camera_scopeRadius_min;
    private Vector2 camera_scopeRadius_max;    
    protected GameObject avatar_object;
    private SpriteRenderer avatar_sprite = null;
    public GameObject camera_object = null;
    public int camera_treshholdRatio = 2;
    private float blocktexturesize = 0f;
    private Map_Builder config;

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

        //sprite
        GameObject sprite_layer = GameObject.Find("/Level/1-Foreground/Avatar/" + avatar_object.name);
        avatar_sprite = sprite_layer.GetComponent<SpriteRenderer>();
        if (avatar_sprite == null) { throw new System.Exception("FEHLER: SpriteRenderer nicht gefunden NULL"); }


        GameObject layer = GameObject.Find("Scripts");
        config = layer.GetComponent<Map_Builder>();
        if (config == null) { throw new System.Exception("FEHLER: MapBuilder Objekt nicht gefunden NULL"); }
        this.blocktexturesize = config.blockSize_inUnity;
        calculate_cameraRatio();        
    }

    protected Vector2 calculate_blockCoordinate()
    {
        Vector2 result = new Vector2();
        result.x = Mathf.Round((this.avatar_object.transform.position.x - config.mapOffsetX) / this.blocktexturesize);
        result.y = Mathf.Round((this.avatar_object.transform.position.y - config.mapOffsetY) / this.blocktexturesize);
        if(result.x < 0) { result.x = 0; }
        if(result.y < 0) { result.y = 0; }
        return result;
    }

    private void getCurrent_block()
    {
        this.currentBlock = config.getMap().getInsideBlockAt(curBlock_position, config);
    }

    protected void move(float inputX, float inputY)
    {
        //Avatar und Kamera werden bewegt
        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
        movement *= Time.deltaTime;
        this.avatar_object.transform.Translate(movement);
        calculate_spriteDirection(movement);
        this.curBlock_position = calculate_blockCoordinate();
        getCurrent_block();       
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

        this.camera_scopeRadius_min.x = mapbuilder.mapOffsetX * this.blocktexturesize + this.camera_treshholdRatio * this.blocktexturesize;
        this.camera_scopeRadius_min.y = mapbuilder.mapOffsetY * this.blocktexturesize + this.camera_treshholdRatio * this.blocktexturesize;
        this.camera_scopeRadius_max.x = mapbuilder.mapOffsetX + mapbuilder.mapSizeX *this.blocktexturesize - this.camera_treshholdRatio * this.blocktexturesize;
        this.camera_scopeRadius_max.y = mapbuilder.mapOffsetY + mapbuilder.mapSizeY * this.blocktexturesize - this.camera_treshholdRatio * this.blocktexturesize;
    }

    private void cameraHandler()
    {
        this.camera_object.transform.position = new Vector3(Mathf.Clamp(this.avatar_object.transform.position.x, this.camera_scopeRadius_min.x, this.camera_scopeRadius_max.x),
            Mathf.Clamp(this.avatar_object.transform.position.y, this.camera_scopeRadius_min.y, this.camera_scopeRadius_max.y), this.camera_object.transform.position.z);
    }

}
