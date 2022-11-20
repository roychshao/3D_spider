using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class spiderController : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent nav;
    private Rigidbody rbody;
    private float speed = 2.5f; 
    private float layback = 10f;
    private int bloodVolume = 2;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        nav.speed = speed;
        animator.SetInteger("state", 0);
    }

    // Update is called once per frame
    void Update()
    {
        // 血量歸零 摧毀蜘蛛
        if(bloodVolume == 0) {
            Destroy(this.gameObject);
        }
        // 如果到達目標點(玩家)
        float disToPlayer = (player.transform.position - this.transform.position).magnitude;
        if(disToPlayer < 2.8f) {
            animator.SetInteger("state", 2);
        }
        else if(rbody.velocity != new Vector3(0f, 0f, 0f)) {
            animator.SetInteger("state", 1);
        } else {
            animator.SetInteger("state", 0);
        }
        /*
        Vector3 nowLocation = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
        nav.Warp(nowLocation);
        */
        nav.SetDestination(player.transform.position);
    }

    private void OnCollisionEnter(Collision collision) {
        // if the collision is bullet, then lay back
        if(collision.collider.tag == "bullet") {
            rbody.MovePosition(this.transform.position - this.transform.forward * Time.deltaTime * layback);
            bloodVolume--;
        }
    }
}
