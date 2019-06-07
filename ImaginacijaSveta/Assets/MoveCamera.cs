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
    public float damping;
    public int size;
    int p = 0;
	
	public double timer = 4.0;
	public double timerMax = 4.0;

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
		timer += Time.deltaTime;
		float step;
		
		if (timer >= timerMax) {
			if (p % 2 == 0) {
				step = speed * Time.deltaTime;
			} else {
				step = speed * Time.deltaTime / 2;
			}
			maincamera.transform.position = Vector3.MoveTowards(maincamera.transform.position, new Vector3(nodes[p].transform.position.x, nodes[p].transform.position.y, nodes[p].transform.position.z), step);
			Quaternion rotation = Quaternion.LookRotation(look[p].position - maincamera.transform.position);
			maincamera.transform.rotation = Quaternion.Slerp(maincamera.transform.rotation, rotation, Time.deltaTime * damping);

			if (Vector3.Distance(maincamera.transform.position, nodes[p].transform.position) < 0.001f)
			{
				//timer = 0.0;
				p++;
				if( p >= size)
				{
					p = 0;
				}
			}
		}
    }
	
}
