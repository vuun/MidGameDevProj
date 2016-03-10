using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GameObject Player;
    Vector3 up = new Vector3(0, 0,1f);
    public int gamestatus = 1;
    float maxspeed = 40f;

    public GameObject Bomb;
    public GameObject Booster;

    public GameObject Text1;

    private ParticleSystem ps;

    public Camera frontCam;
    public Camera backCam;

    float textTime = 0;

    void Start () {
        ps = Booster.gameObject.GetComponent<ParticleSystem>();
        this.transform.position = new Vector3(173, 157, -424);

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
        gamestatus = 0;
        //Object.Destroy(this.gameObject);
        if (other.tag == "Terrain")
        {
        Debug.Log(this.gameObject + " speed = " + this.speed);
        Instantiate(Bomb,this.gameObject.transform.position, this.transform.rotation);
        this.transform.position = new Vector3(173, 157, -424);
        this.transform.rotation = Quaternion.identity;
        }
        
        if (other.tag == "wall")
        {
            Text1.gameObject.SetActive(true);
            textTime = Time.realtimeSinceStartup;
        }

    }
    void speedcheck()
    {
        if (speed >= maxspeed)
        {
            speed = maxspeed;
        }
        if (speed <= 5f)
        {
            speed = 5f;
        }
    }
    void Update()
    {

        if (Time.realtimeSinceStartup >= textTime + 3.5)
        {
            Text1.gameObject.SetActive(false);
        }


        float transAmount = speed * Time.deltaTime;
        float rotateAmount = rotateSpeed * Time.deltaTime;

        speedcheck();

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
            
                speed -= 0.25f;
        }

        if (Input.GetKey("up"))
        {
                speed += 0.09f;

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
