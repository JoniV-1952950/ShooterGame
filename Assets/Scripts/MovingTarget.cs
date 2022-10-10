using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform destinationTrans;

    private Vector3 start;
    private Vector3 destination;

    private bool towards = true;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        destination = destinationTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (towards)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, destination) <= 0.001f)
                towards = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, start, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, start) <= 0.001f)
                towards = true;
        }
    }
}
