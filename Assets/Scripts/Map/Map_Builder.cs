using UnityEngine;

public class Map_Builder : MonoBehaviour {

    public int mapSizeX = 32;
    public int mapSizeY = 32;
    public int z_background = 0;
    public int z_foreground = 5;
    public GameObject prefab_Block_Walk;
    public GameObject prefab_Block_Desctructable;
    public GameObject prefab_Block_Undesctrutalbe;
    public GameObject prefab_Block_Hole;
    private const float fixSizeSprite = 1.28f;
    private Map map;

    // Use this for initialization
    void Start () {        
        build();
	}

    private void build()
    {
        map = new Map();

        for(int x = 0; x < this.mapSizeX; x++)
        {
            for(int y = 0; y < this.mapSizeY; y++)
            {
                
                if(x == 0 || y == 0 || x+1 == this.mapSizeX || y+1 == this.mapSizeY)
                {
                    //Ränder der Map
                    createBlock(this.prefab_Block_Undesctrutalbe, new Vector3(x, y, z_background));
                }else if (x % 2 == 0 && y % 2 == 0)
                {
                    //"Säulen"
                    createBlock(this.prefab_Block_Undesctrutalbe, new Vector3(x, y, z_background));
                }
                else
                {
                    //normaler Boden
                    createBlock(this.prefab_Block_Walk, new Vector3(x, y, z_background));
                }          
            }
        }

    }

    private void createBlock(GameObject block, Vector3 vec)
    {
        GameObject tmp = Instantiate(block, transform.position, Quaternion.identity) as GameObject;
        Vector3 tmp_pos = new Vector3(vec.x * (fixSizeSprite), vec.y * (fixSizeSprite), vec.z);
        tmp.transform.position = tmp_pos;
        map.addBlock(tmp);
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
