using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeUIController : MonoBehaviour {
    public static TimeUIController instance;
    public GameObject highMenu;
    public Text timeText;
    public Text HighText;
    public int lastTime = 0;
    public int thisTime = 0;
    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {


        GameObject thePlayer = GameObject.Find("Player");
        PlayerController playerScript = thePlayer.GetComponent<PlayerController>();
        
        if (playerScript.gamestatus == 1)
        {
            timeText.text = "Survived : " + thisTime;
        }
        else{
            timeText.text = "          DEAD";
        }
        

        //Debug.Log("gamestatus = " +  playerScript.gamestatus);

            if (playerScript.gamestatus == 2)
        {
            lastTime = (int)Time.realtimeSinceStartup;
            playerScript.gamestatus = 1;
        }
        thisTime = (int)Time.realtimeSinceStartup - lastTime;
        if (thisTime >= PlayerPrefs.GetInt("HighScore") && playerScript.gamestatus == 1)
        {
            PlayerPrefs.SetInt("HighScore", thisTime);
        }
        HighText.text = "Most Survived " + PlayerPrefs.GetInt("HighScore") + " Second";

       
        
        if (Input.GetKey("c")){
            highMenu.gameObject.SetActive(true);

        }
        else
        {
            highMenu.gameObject.SetActive(false);
        }
        //reset HighSCORE
        //PlayerPrefs.SetInt("HighScore", 0);

    }

   
}
