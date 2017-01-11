using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button_ServerStart_click : MonoBehaviour {

    public void onClick()
    {
        GameHandler.Gamemode_Server = true;
        GameObject child = GameObject.Find("InputField/Text/");
        Text t = child.GetComponent<Text>();
        GameHandler.ip_adress = t.text;
        UnityEngine.SceneManagement.SceneManager.LoadScene("1-Stage", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }


}
