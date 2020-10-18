using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroy : MonoBehaviour
{
    public GameManager gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            if(collision.gameObject.GetComponent<Box>().weight <= 4.5f)
            {
                gameManager.reputation -= 10;
            }
            Destroy(collision.gameObject);
        }
    }
}
