using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {
    public GameObject player;
    Vector3 rotate = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RotateCamera();
		this.transform.position = player.transform.position;
		this.transform.rotation = player.transform.rotation;
		this.transform.Rotate(rotate);
	
	}

	void RotateCamera()
	{
		if (Input.GetKey("j"))
		{
			rotate = new Vector3(0,90,0);
		}
		else if (Input.GetKey("k"))
		{
			rotate = new Vector3(270,0,0);
		}
		else if (Input.GetKey("l"))
		{
			rotate = new Vector3(0,270,0);
		}
		else if (Input.GetKey("i"))
		{
			rotate = new Vector3(90,0,0);
		}
		else
		{
			rotate = new Vector3(0,0,0);
		}
	}
}
