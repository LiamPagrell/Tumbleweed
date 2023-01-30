using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Transform movePoint;
    public GameObject MovePoint;

    public LayerMask StopMovement;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) == 0f)
        {


            if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, StopMovement))
                {

                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * 2, 0f);
                    MovePoint.SetActive(false);
                    Invoke("MovePointActive", 1f);
                }
            }

            //float Vertical = Input.GetAxisRaw("Vertical") * speed;
            //Vertical *= Time.deltaTime;
            //transform.Translate(0, Vertical, 0);
        }
    }

    public void MovePointActive()
    {
        MovePoint.SetActive(true);
    }

}
