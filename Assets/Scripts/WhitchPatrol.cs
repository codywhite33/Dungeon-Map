using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitchPatrol : MonoBehaviour
{
    public float speed;

    private bool movingRight = true;

    public Transform collisionDetection;

    void Update(){

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D collisioninfo = Physics2D.Raycast(collisionDetection.position, Vector2.down, 2f);
        if(collisioninfo.collider == false){
            if(movingRight == true){
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;

            }
        }
    }
}
