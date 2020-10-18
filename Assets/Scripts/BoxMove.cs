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
            collision.gameObject.transform.Translate((edge_1.transform.position - edge_2.transform.position) * Time.deltaTime * 0.4f, Space.World);
        }
    }
}
