using UnityEngine;
using System.Collections;

public class MeteorSpawner : MonoBehaviour {
    public GameObject met;
    double delay = 0.1;
	double sec = 0;
	// Use this for initialization
	void Start () {
		Instantiate(met);
	
	}
	
	/*IEnumerator Example() 
	{
		Instantiate(met);
        yield return new WaitForSeconds(1);
    }*/
	// Update is called once per frame
	void Update () 
	{
		if(Time.time > sec)
		{
			sec = sec+delay;
			Instantiate(met);
		}
	}
}
