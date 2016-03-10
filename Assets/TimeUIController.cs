using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeUIController : MonoBehaviour {
    public Text timeText;
    public int lastTime = 0;
    public int thisTime = 0;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {


        GameObject thePlayer = GameObject.Find("Player");
        PlayerController playerScript = thePlayer.GetComponent<PlayerController>();
        thisTime = (int)Time.realtimeSinceStartup - lastTime;
        timeText.text = "Survived : " + thisTime;


        //Debug.Log("gamestatus = " +  playerScript.gamestatus);

        if (playerScript.gamestatus == 0)
        {
            lastTime = (int)Time.realtimeSinceStartup;
            playerScript.gamestatus = 1;
        }

    }

   
}
