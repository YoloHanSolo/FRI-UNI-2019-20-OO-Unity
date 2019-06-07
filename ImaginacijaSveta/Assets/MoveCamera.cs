using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject maincamera;
    public GameObject[] nodes;
    Transform[] look;
    public float speed;
    public float slowSpeed;
    public float damping;
    public int size;
    int p = 0;

    void Start()
    {
        look = new Transform[size];
        for ( int k = 0; k<size; k++)
        {
            foreach (Transform child in nodes[k].transform)
            {
                look[k] = child;
            }
        }
    }

    void Update()
    {

        float step;
        if ( p == 2 || p == 3 || p == 6 || p == 9 || p == 10 || p == 13 || p == 14 || p == 17) {
            step = slowSpeed * Time.deltaTime;
        } else {
            step = speed * Time.deltaTime;
        }
		maincamera.transform.position = Vector3.MoveTowards(maincamera.transform.position, new Vector3(nodes[p].transform.position.x, nodes[p].transform.position.y, nodes[p].transform.position.z), step);
		Quaternion rotation = Quaternion.LookRotation(look[p].position - maincamera.transform.position);
		maincamera.transform.rotation = Quaternion.Slerp(maincamera.transform.rotation, rotation, Time.deltaTime * damping);

		if (Vector3.Distance(maincamera.transform.position, nodes[p].transform.position) < 0.001f)
		{
			p++;
			if( p >= size)
			{
				p = 0;
			}
		}
		
    }
	
}
