using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float cooldown;

    public Transform movePoint;

    public LayerMask StopMovement;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) == 0f)
        {


            if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f && cooldown >= 0.25f)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, StopMovement))
                {

                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * 2, 0f);
                    cooldown = 0f;
                }
            }

            //float Vertical = Input.GetAxisRaw("Vertical") * speed;
            //Vertical *= Time.deltaTime;
            //transform.Translate(0, Vertical, 0);
        }
    }

}
