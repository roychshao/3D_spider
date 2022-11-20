using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class gunController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject firePre;
    public Transform bulletPoint;
    public GameObject bulletPre;
    private AudioSource gunPlayer;
    public AudioClip clip;
    public AudioClip check;
    public RawImage bullet05;
    public RawImage bullet610;
    public Texture bullet0;
    public Texture bullet1;
    public Texture bullet2;
    public Texture bullet3;
    public Texture bullet4;
    public Texture bullet5;
    // 子彈個數
    public static int bulletCount = 10;
    // 開火間隔
    private float cd = 0.2f;
    // 計時器
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        gunPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // 冷卻時間過了 && 按下左鍵 && 有子彈
        if(timer > cd && Input.GetMouseButton(0) && bulletCount > 0) {
            // 重製timer
            timer = 0;
            
            // create fire
            Instantiate(firePre, firePoint.position, firePoint.rotation);
            // create bullet
            Instantiate(bulletPre, bulletPoint.position, bulletPoint.rotation);
            
            // decrease bullet num
            bulletCount--;
            changeTexture();
            // play the gun audio
            gunPlayer.PlayOneShot(clip);
            if(bulletCount == 0) {
                GetComponent<Animator>().SetTrigger("Reload");
                gunPlayer.PlayOneShot(check);
                // get full bullets after 3 seconds
                Invoke("Reload", 1.5f);
            }
        }
        // 或按R鍵換子彈
        if(Input.GetKeyDown(KeyCode.R)) {
            // clear bullets
            bulletCount = 0;
            GetComponent<Animator>().SetTrigger("Reload");
            gunPlayer.PlayOneShot(check);
            // get full bullets after 3 seconds
            Invoke("Reload", 1.5f);
        }
    }

    void Reload() {
        bulletCount = 10;
        changeTexture();
    }

    void changeTexture() {
        if(bulletCount <=5) {
            bullet610.texture = (Texture)bullet0;
            switch(bulletCount) {
                case 0:
                    bullet05.texture = (Texture)bullet0;
                    break;
                case 1:
                    bullet05.texture = (Texture)bullet1;
                    break;
                case 2:
                    bullet05.texture = (Texture)bullet2;
                    break;
                case 3:
                    bullet05.texture = (Texture)bullet3;
                    break;
                case 4:
                    bullet05.texture = (Texture)bullet4;
                    break;
                case 5:
                    bullet05.texture = (Texture)bullet5;
                    break;
            }
        }
        else if(bulletCount > 5) {
            bullet05.texture = (Texture)bullet5;
            switch(bulletCount) {
                case 5:
                    bullet610.texture = (Texture)bullet0;
                    break;
                case 6:
                    bullet610.texture = (Texture)bullet1;
                    break;
                case 7:
                    bullet610.texture = (Texture)bullet2;
                    break;
                case 8:
                    bullet610.texture = (Texture)bullet3;
                    break;
                case 9:
                    bullet610.texture = (Texture)bullet4;
                    break;
                case 10:
                    bullet610.texture = (Texture)bullet5;
                    break;
            }
        }
    }
}
