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
    public Sprite sprite_standard;
    public Sprite sprite_action;
    protected SpriteRenderer avatar_sprite = null;
    public Camera camera_object = null;
    public int camera_treshholdRatio = 2;
    private float blocktexturesize = 0f;
    private Map_Builder config;
    protected bool isBusy = false;

    // Use this for initialization
    void Start()
    {       
        if(sprite_standard == null || sprite_action == null)
        {
            throw new System.Exception("Sprite Attribute nicht belegt!");
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

    protected IEnumerator wait_reset_sprite()
    {
        yield return new WaitForSeconds(1.5f);
        avatar_sprite.sprite = sprite_standard;

        isBusy = false;
    }

    private void initialization()
    {
        this.avatar_object = transform.gameObject;
        avatar_object.transform.parent = GameObject.Find("/Level/1-Foreground/Avatar/").transform;    

        //sprite
        GameObject layer = GameObject.Find("/Level/1-Foreground/Avatar/" + avatar_object.name);
        avatar_sprite = layer.GetComponent<SpriteRenderer>();
        if (avatar_sprite == null) { throw new System.Exception("FEHLER: SpriteRenderer nicht gefunden NULL"); }

        //MAP Builder
        layer = GameObject.Find("/Scripts/MAP/");
        config = layer.GetComponent<Map_Builder>();
        if (config == null) { throw new System.Exception("FEHLER: MapBuilder Objekt nicht gefunden NULL"); }
        this.blocktexturesize = config.blockSize_inUnity;

        //Cameraobjekt
        layer = GameObject.Find("/Renderer/Main Camera/");
        this.camera_object = layer.GetComponent<Camera>();
        if (camera_object == null) { throw new System.Exception("FEHLER: Kamera-Main Objekt nicht gefunden NULL"); }
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
        //this.curBlock_position = calculate_blockCoordinate();
        //getCurrent_block();       
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
        this.camera_scopeRadius_min.x = config.mapOffsetX * this.blocktexturesize + this.camera_treshholdRatio * this.blocktexturesize;
        this.camera_scopeRadius_min.y = config.mapOffsetY * this.blocktexturesize + this.camera_treshholdRatio * this.blocktexturesize;
        this.camera_scopeRadius_max.x = config.mapOffsetX + config.mapSizeX *this.blocktexturesize - this.camera_treshholdRatio * this.blocktexturesize;
        this.camera_scopeRadius_max.y = config.mapOffsetY + config.mapSizeY * this.blocktexturesize - this.camera_treshholdRatio * this.blocktexturesize;
    }

    private void cameraHandler()
    {
        this.camera_object.transform.position = new Vector3(Mathf.Clamp(this.avatar_object.transform.position.x, this.camera_scopeRadius_min.x, this.camera_scopeRadius_max.x),
            Mathf.Clamp(this.avatar_object.transform.position.y, this.camera_scopeRadius_min.y, this.camera_scopeRadius_max.y), this.camera_object.transform.position.z);
    }

}
