using UnityEngine;
using System.Collections;

public class MeteorController : MonoBehaviour {
    Vector3 size =new Vector3(50,40,50);
    //public GameObject met;
    public Rigidbody rb;
    //public GameObject Player;
    //PlayerController PlayerController;
    // Use this for initialization
    void Start ()
    {
        //PlayerController = Player.GetComponent<PlayerController>();
        Vector3 pos = new Vector3(Random.Range(-180, 600), Random.Range(400, 500), Random.Range(-550, 200));
        transform.position = pos;
        transform.localScale = size;
        rb.velocity = new Vector3(0,Random.Range(-100,-50),0);
	}
	
	// Update is called once per frame
	void Update () {
        checkheight();
	
	}
    void checkheight()
    {
        if(transform.position.y <-20)
         {
            /*Debug.Log(PlayerController.gamestatus);
            if(PlayerController.gamestatus==1)
            {
                Instantiate(met);
                Instantiate(met);
            }*/
            Object.Destroy(this.gameObject);
        }
    }
}
