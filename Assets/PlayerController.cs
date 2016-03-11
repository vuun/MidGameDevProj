using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public GameObject Player;
    public GameObject starwar;
    Vector3 up = new Vector3(0, 0,1f);
    public int gamestatus = 1;
    float maxspeed = 40f;



    public GameObject Bomb;
    public GameObject Booster;

    public GameObject shield;
    public GameObject shieldTextObject;
    public Text shieldText;
    int shieldtime = 0;
    int shieldCooldown = 0;
    int isShield = 2;

    public GameObject warningText;
    public GameObject retryText;

    private ParticleSystem ps;

    public Camera frontCam;
    public Camera backCam;
    public Camera FreeCam;

    float textTime = 0;

    void Start () {
        ps = Booster.gameObject.GetComponent<ParticleSystem>();
        this.transform.position = new Vector3(173, 80, -380);

        isShield = 1;
        shield.gameObject.SetActive(true);
        shieldCooldown = (int)(Time.realtimeSinceStartup) + 15;
        shieldtime = (int)(Time.realtimeSinceStartup);

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
    float speed = 20;

    void OnTriggerEnter(Collider other)
    {

        //Object.Destroy(this.gameObject);
        if ((other.tag == "Obstacle" && isShield != 1 )||(other.tag == "Terrain"))
        {
            gamestatus = 0;
            retryText.gameObject.SetActive(true);
            Debug.Log(this.gameObject + " speed = " + this.speed + "gamestatus = " + gamestatus);
            Instantiate(Bomb, this.gameObject.transform.position, this.transform.rotation);
            this.transform.position = new Vector3(0, 0, 0);
            this.transform.rotation = Quaternion.identity;
            speed = 0;
            isShield = 0;
            
        }

        if (other.tag == "wall")
        {
            warningText.gameObject.SetActive(true);
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
    void retrycheck()
    {
        if (Input.GetKey("x") && gamestatus == 0)
        {
            gamestatus = 2;
            isShield = 1;

            shield.gameObject.SetActive(true);
            shieldCooldown = (int)(Time.realtimeSinceStartup) + 15;
            shieldtime = (int)(Time.realtimeSinceStartup);

            this.transform.position = new Vector3(173, 80, -380);
            this.transform.rotation = Quaternion.identity;
            retryText.gameObject.SetActive(false);
        }
    }

    void soundcheck()
    {
        if(gamestatus == 0)
        {
            starwar.gameObject.SetActive(false);
        }
        else if(gamestatus == 1)
        {
            starwar.gameObject.SetActive(true);
        }
    }
    void shieldcheck()
    {
        //Debug.Log("status " + isShield);
        if (Input.GetKeyDown("space") && isShield == 2 && ((shieldCooldown - (int)Time.realtimeSinceStartup <= 0)))
        {
            isShield = 1;
            shield.gameObject.SetActive(true);
            shieldtime = (int)(Time.realtimeSinceStartup);
            shieldCooldown = (int)(Time.realtimeSinceStartup) + 15;
            //shieldTextObject.gameObject.SetActive(true);
        }

        //Debug.Log("shieldCooldownnow : "+(shieldCooldown - (int)Time.realtimeSinceStartup));
        if (isShield == 1)
        {
            shieldText.text = "Shield On!! : " + (4 - ((int)(Time.realtimeSinceStartup) - shieldtime));
        }

        else if ((isShield == 0 && (shieldCooldown - (int)Time.realtimeSinceStartup) <= 0) || isShield == 2)
        {
            isShield = 2;
            shieldText.text = "      Shield Up";
        }

        if ((shieldtime + 4.5 <= Time.realtimeSinceStartup && isShield != 2) || isShield == 0)
        {
            isShield = 0;
            shieldText.text = "Shield CoolDown : " + (shieldCooldown - (int)Time.realtimeSinceStartup);
            Debug.Log("NOTICE ME SENPAI");
            shield.gameObject.SetActive(false);
            //shieldTextObject.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        soundcheck();
        retrycheck();
        if (Time.realtimeSinceStartup >= textTime + 3.5)
        {
            warningText.gameObject.SetActive(false);
        }


        float transAmount = speed * Time.deltaTime;
        float rotateAmount = rotateSpeed * Time.deltaTime;

        speedcheck();
        shieldcheck();

        transform.Translate(0, 0, (transAmount * 2));
        


        if (gamestatus == 1)
        {
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
                transform.Rotate(0, -rotateAmount / 20f, 0);
            }
            if (Input.GetKey("e"))
            {
                transform.Rotate(0, rotateAmount / 20f, 0);
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
                Booster.gameObject.SetActive(false);
            }

            if (Input.GetKey("up"))
            {
                speed += 0.09f;
                Booster.gameObject.SetActive(true);

            }

            if (Input.GetKey("f"))
            {
                frontCam.gameObject.SetActive(false);
                backCam.gameObject.SetActive(true);
                FreeCam.gameObject.SetActive(false);
            }
            else if(Input.GetKey("j") || Input.GetKey("k") || Input.GetKey("l") || Input.GetKey("i"))
            {
                backCam.gameObject.SetActive(false);
                frontCam.gameObject.SetActive(false);
                FreeCam.gameObject.SetActive(true);
            }
            else 
            {
                backCam.gameObject.SetActive(false);
                frontCam.gameObject.SetActive(true);
                FreeCam.gameObject.SetActive(false);
            }
        }
    }
}
