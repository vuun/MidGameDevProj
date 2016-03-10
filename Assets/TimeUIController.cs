using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeUIController : MonoBehaviour {
    public Text timeText;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeText.text = "Survived : " + (int)Time.realtimeSinceStartup;
    }

   
}
