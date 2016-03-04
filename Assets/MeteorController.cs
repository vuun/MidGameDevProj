using UnityEngine;
using System.Collections;

public class MeteorController : MonoBehaviour {
    Vector3 size =new Vector3(20,20,20);
    public GameObject met;
    public Rigidbody rb;
    public GameObject Player;
    PlayerController PlayerController;
    // Use this for initialization
    void Start ()
    {
        PlayerController = Player.GetComponent<PlayerController>();
        Vector3 pos = new Vector3(Random.Range(0, 300), Random.Range(200, 300), Random.Range(-300, 0));
        transform.position = pos;
        transform.localScale = size;
        rb.velocity = new Vector3(0,Random.Range(-80,-30),0);
	}
	
	// Update is called once per frame
	void Update () {
        checkheight();
	
	}
    void checkheight()
    {
        if(transform.position.y <30)
         {
            Debug.Log(PlayerController.gamestatus);
            if(PlayerController.gamestatus==1)
            {
                Instantiate(met);
                Instantiate(met);
            }
            Object.Destroy(this.gameObject);
        }
    }
}
