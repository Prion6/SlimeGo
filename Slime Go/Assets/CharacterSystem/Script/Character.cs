using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Vector3 lastPos;

    public GameObject player;
    public float deltaMovement = 5;
    public Animator characterAnimator;
    //public float timer;

    public int move = 0;


    // Start is called before the first frame update
    void Start()
    {
        characterAnimator = GetComponent<Animator>();
        //timer = Time.time;
        lastPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.transform.position, lastPos) > deltaMovement)
        {
            move = 1;
            lastPos = player.transform.position;
        } else move = 0;

        characterAnimator.SetInteger("Speed", move);

        /*if(Input.GetKeyDown(KeyCode.W))
        {
            move = 1;
            characterAnimator.SetInteger("Speed", move);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            move = 0;
            characterAnimator.SetInteger("Speed", move);
        }*/

    }



}
