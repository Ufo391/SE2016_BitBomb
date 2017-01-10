using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    private ArrayList blocklist_inside;
    private ArrayList blocklist_edges;

    public Map()
    {
        blocklist_inside = new ArrayList();
        blocklist_edges = new ArrayList();
    }

    public void addBlock_inside(GameObject block)
    {
        // Alle blöcke in der Spielfläche
        this.blocklist_inside.Add(block);
    }

    public void addBlock_edge(GameObject block)
    {
        // enthält die Map Grenzen
        // muss getrennt werden da sonst die "Arraylistformel" nicht aufgeht
        this.blocklist_edges.Add(block);
    }

    public ArrayList getBlockList_inside()
    {
        return this.blocklist_inside;
    }

    public ArrayList getBlockList_edges()
    {
        return this.blocklist_edges;
    }

    public GameObject getInsideBlockAt(Vector2 pos, Map_Builder config)
    {
        // Gibt nach Arrayformellogik den gesuchten Block zurück
        // ACHTUNG pos müssen ganzzahlen sein
        int index = ((int)pos.x * (config.mapSizeX-1)) + (int)pos.y;
        return (GameObject)blocklist_inside[index];
    }
}
