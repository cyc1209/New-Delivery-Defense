using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    public GameObject edge_1;
    public GameObject edge_2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
             collision.gameObject.transform.position = Vector3.MoveTowards(collision.gameObject.transform.position, edge_1.transform.position,0.05f);
        }
    }
}
