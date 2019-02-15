using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitchPatrol : MonoBehaviour
{
    public float speed;

    private float waitTime;
    public float startWaitTime;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    public Transform moveSpot;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        waitTime = startWaitTime;
        timeBtwShots = startTimeBtwShots;

        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
