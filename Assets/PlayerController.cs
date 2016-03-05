using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    Vector3 up = new Vector3(0, 0,1f);
    public int gamestatus = 1;

    public Camera frontCam;
    public Camera backCam;

    void Start () {
	
	}

    // Update is called once per frame
    /*void Update () {
        PlayerControl();
        GunControl();

    }
    void PlayerControl()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            this.gameObject.GetComponent<Transform>().position += Input.GetAxisRaw("Horizontal") * Vector3.right * Time.deltaTime * 5f;
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            this.gameObject.GetComponent<Transform>().position += Input.GetAxisRaw("Vertical") * up * Time.deltaTime * 5f;
        }
    }
    void GunControl()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(Bullets, this.transform.position)
        }
    }*/
    float rotateSpeed = 100;
    float speed = 8;

    void OnTriggerEnter(Collider other)
    {
        //gamestatus = 0;
        //Object.Destroy(this.gameObject);
        
    }

    void Update()
    {
        float transAmount = speed * Time.deltaTime;
        float rotateAmount = rotateSpeed * Time.deltaTime;

        transform.Translate(0, 0, (transAmount * 2));

        if (Input.GetKey("w"))
        {
            transform.Rotate(rotateAmount, 0, 0);

        }
        if (Input.GetKey("s"))
        {
            transform.Rotate(-rotateAmount, 0, 0);
        }
        if (Input.GetKey("q"))
        {
            transform.Rotate(0, -rotateAmount/20f, 0);
        }
        if (Input.GetKey("e"))
        {
            transform.Rotate(0, rotateAmount/20f, 0);
        }

        if (Input.GetKey("a"))
        {
            transform.Rotate(0, 0, rotateAmount);
        }

        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 0, -rotateAmount);
        }

        if (Input.GetKey("down"))
        {
            if (speed >= 30f)
            {
                speed -= 0.75f;
            }
        }

        if (Input.GetKey("up"))
        {
            if (speed <= 45f) { 
                speed += 0.25f;
            }
        }

        if (Input.GetKey("f"))
        {
            frontCam.gameObject.SetActive(false);
            backCam.gameObject.SetActive(true);
        }
        else
        {
            backCam.gameObject.SetActive(false);
            frontCam.gameObject.SetActive(true);
        }

    }
}
