using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rig;
    private GameObject player;
    Vector3 lookDirection;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        lookDirection = (player.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        rig.AddForce(lookDirection * speed);
        if(transform.position.y < -10)
            Destroy(gameObject);
    }
}
