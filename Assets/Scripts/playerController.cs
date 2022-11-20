using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //SceneManager
using Text = TMPro.TextMeshProUGUI;

public class playerController : MonoBehaviour
{
    private int force = 200;
    // rigidbody component
    private Rigidbody rbody;
    private AudioSource playerAudio;
    public AudioClip footStep;
    public AudioClip jump;
    public AudioClip hurt;
    public RawImage blood;
    public Texture blood2;
    public Texture blood1;
    private int bloodVolume = 3;
    private bool canJump = false;
    private float unequalled = 0f;
    private float gameTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
        // 被碰到之後無敵時間1s
        unequalled += Time.deltaTime;
        if(bloodVolume == 0) {
            // 停止計時器且跳出遊戲結束(死亡) 畫面
            PlayerPrefs.SetFloat("surviveTime", gameTimer);
            SceneManager.LoadScene(2);
        }
        // give a up force to the rigidbody when press space buttom
        if(Input.GetKeyDown(KeyCode.Space) && canJump) {
            rbody.AddForce(Vector3.up * force);
            playerAudio.PlayOneShot(jump);
        }

        // judge is moving
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if((horizontal != 0.0 || vertical != 0.0) && canJump) {
            // moving with W || A || S || D
            // play foot voice
            if(!playerAudio.isPlaying) {
                playerAudio.PlayOneShot(footStep);
            }
        }
        /*
        else {
            // no moving, stop foot voice
            playerAudio.Stop();
        }
        */
    }

    // 
    private void OnCollisionEnter(Collision collision) {
        // if the collision is ground, it can jump
        if(collision.collider.tag == "ground") {
            canJump = true;
        }
        if(collision.collider.tag == "enemy" && unequalled > 1f) {
            bloodVolume--;
            playerAudio.PlayOneShot(hurt);
            if(bloodVolume == 2)
                blood.texture = (Texture)blood2;
            else if(bloodVolume == 1)
                blood.texture = (Texture)blood1;
            unequalled = 0f;
        }
        //Debug.Log(unequalled);
    }

    private void OnCollisionExit(Collision collision) {
        // if it is not collide with the ground, it can not jump
        if(collision.collider.tag == "ground") {
            canJump = false;
        }
    }
}
