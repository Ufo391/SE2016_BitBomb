using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    private ArrayList block_list;

    public Map()
    {
        block_list = new ArrayList();
    }

    public void addBlock(GameObject block)
    {
        this.block_list.Add(block);
    }

    public ArrayList getBlockList()
    {
        return this.block_list;
    }

    public void setBlockList(ArrayList value)
    {
        this.block_list = value;
    }

}
