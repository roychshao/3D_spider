using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    // Start is called before the first frame update
    private int speed = 800;
    private float timer = 0f;
    void Start()
    {
        // give a speed to the rigidbody
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // 5秒後刪除子彈
        if(timer > 5) {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        Destroy(this.gameObject);
    }
}
