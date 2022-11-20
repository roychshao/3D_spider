using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //SceneManager

public class nestController : MonoBehaviour
{
    public GameObject spider;
    public GameObject player;
    private float Timer;
    private float spiderGenerateFreq;
    private float period;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 5f;
        spiderGenerateFreq = 3f;
        period = 20f;
        // 在city scene中才開始產商spider
        if(SceneManager.GetActiveScene().buildIndex == 1) {
            var tmp = Instantiate(spider, this.transform.position, this.transform.rotation) as GameObject;
            tmp.GetComponent<spiderController>().player = player;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // generate spiders
        if(Time.time > Timer && SceneManager.GetActiveScene().buildIndex == 1) {
            var tmp = Instantiate(spider, this.transform.position, this.transform.rotation) as GameObject;
            tmp.GetComponent<spiderController>().player = player;
            Timer += spiderGenerateFreq;
        }
        if(Time.time > period && spiderGenerateFreq > 1f) {
            spiderGenerateFreq -= 0.5f;
            period += period;
        }
    }
}
