using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {

    public byte healthpoints = 100;
    protected enum direction_move { UP,DOWN,LEFT,RIGHT};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void move(direction_move dm)
    {
        // HIER MUSS NICH DIE EIGENTLICHE BEWEGUNG IMPLEMENTIERT WERDEN!!!
        switch (dm)
        {
            case direction_move.UP:
                {
                    break;
                }
            case direction_move.DOWN:
                {
                    break;
                }
            case direction_move.LEFT:
                {
                    break;
                }
            case direction_move.RIGHT:
                {
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

}
