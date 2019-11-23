using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGthemeScript : MonoBehaviour
{

    private static BGthemeScript instance = null;

    public static BGthemeScript Instance
    {
        get
        {
            return instance;
        }
    }
    
    void Awake()
    {
        if(instance !=null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }


}
