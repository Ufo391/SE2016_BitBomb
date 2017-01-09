using UnityEngine;

public class Map_Builder : MonoBehaviour {

    public int mapSizeX = 32;
    public int mapSizeY = 32;
    public int mapOffsetX = 0;
    public int mapOffsetY = 0;
    public GameObject prefab_Block_Walk;
    public GameObject prefab_Block_Desctructable;
    public GameObject prefab_Block_Undesctrutalbe;
    public GameObject prefab_Block_Hole;
    private const float fixSizeSprite = 1.28f; // entspricht Pixelgröße Texture / 100
    private const int minimumMapSize = 8;
    private Map map;

    // Use this for initialization
    void Start () {
        buildMap();
	}

    private void buildMap()
    {
        //Fehler abfangen
        if (mapSizeX < minimumMapSize || mapSizeY < minimumMapSize) { throw new System.Exception("FEHLER: Karte muss mindestens " + minimumMapSize + " Einheiten gross sein! (X und Y Werte)"); }
        if(mapOffsetX < 0 || mapOffsetY < 0) { throw new System.Exception("Fehler: MapOffset muss größer sein als 0!"); }
        if(mapOffsetX % 2 == 1) { mapOffsetX++; }
        if(mapOffsetY % 2 == 1) { mapOffsetY++; }
        if (mapSizeX % 2 == 1) { mapSizeX++; }
        if (mapSizeY % 2 == 1) { mapSizeY++; }
                
        GameObject foreground_layer = GameObject.Find("/Level/1-Foreground/MAP"); // MÜSSEN KONSTANT BLEIBEN WEIL SONST BUG
        GameObject background_layer = GameObject.Find("/Level/0-Background/MAP"); // Die Klassen Strings bleiben bei Start() immer leer ""
        if( foreground_layer == null || background_layer == null) { throw new System.Exception("FEHLER: Ungültiger foreground oder background Pfad!"); }

        map = new Map();
        
        //Karte bauen    
        for (int x = mapOffsetX - 1; x < this.mapOffsetX + this.mapSizeX; x++)
        {
            for(int y = mapOffsetY - 1; y < this.mapOffsetY + this.mapSizeY; y++)
            {                
                if(x == mapOffsetX - 1 || y == mapOffsetY - 1 || x+1 == this.mapOffsetX + this.mapSizeX || y+1 == this.mapOffsetY + this.mapSizeY)
                {
                    //Ränder der Karte
                    createBlock(this.prefab_Block_Undesctrutalbe,foreground_layer, new Vector3(x, y));
                }else if (x % 2 == 1 && y % 2 == 1)
                {
                    //"Säulen"
                    createBlock(this.prefab_Block_Undesctrutalbe,foreground_layer, new Vector3(x, y));
                }
                else
                {
                    //normaler Boden
                    createBlock(this.prefab_Block_Walk,background_layer, new Vector3(x, y));
                }          
            }
        }

        //fixe background Z
        fixZAxis(background_layer);
    }

    private void createBlock(GameObject block, GameObject parentlayer, Vector3 vec)
    {
        //Clont das Prefab und Positioniert den Block und hängt diesen dann in den richtigen Elternlayer
        GameObject tmp = Instantiate(block, transform.position, Quaternion.identity) as GameObject;
        tmp.transform.parent = parentlayer.transform;
        tmp.transform.position = new Vector3(vec.x * (fixSizeSprite), vec.y * (fixSizeSprite));           
        map.addBlock(tmp);
    }

    private void fixZAxis(GameObject layer)
    {
        // Die Z Achse wird ständig falsch überschrieben in den Layer sodass foreground und background auf einer Z Achse sind
        // hiermit wird dies gefixt
        float fixZ = layer.transform.position.z;
        foreach (Transform child in layer.transform)
        {
            child.position = new Vector3(child.position.x, child.position.y, fixZ );
        }
    }

    //GET SET
    public void setMap(Map value)
    {
        this.map = value;
    }

    public Map getMap()
    {
        return this.map;
    }
}
