using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroy : MonoBehaviour
{
    public GameManager gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (gameManager.mode == 0)
        {
            if (collision.gameObject.CompareTag("Box"))
            {
                if (collision.gameObject.GetComponent<Box>().weight <= 4.5f)
                {
                    gameManager.reputation -= 10;
                }
                Destroy(collision.gameObject);
            }
        }
        else if (gameManager.mode == 1)
        {
            if (collision.gameObject.CompareTag("Box"))
            {
                gameManager.reputation -= 10;
                Destroy(collision.gameObject);
            }
        }
    }
}
