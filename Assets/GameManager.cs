using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int reputation = 0; //명성
    public int level = 0; //레벨

    public int boxCount = 0;
    // Start is called before the first frame update

    public static GameManager instance;

    void Awake()
    {
        if (GameManager.instance == null)
            GameManager.instance = this;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
