using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{

    public float damage = 1;
    //public GameObject goal;
    public GameObject manager;
    //public int beatToJump = 1;
    public GameObject player;
    public float speed = .003f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform enemyTransform = this.gameObject.GetComponent<Transform>();
        Transform playerTransform = player.GetComponent<Transform>();

        //vecToPLayer = playerTransform.position - enemyTransform.position;

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
    }
}
