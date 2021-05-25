using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool open;
    Animator mater;
    public Chest chest;


    // Start is called before the first frame update
    void Start()
    {
        //chest = GameObject.Find("Chest").GetComponent<Chest>();

        mater = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //mater.SetBool("open", true);

        //if (chest.open)
        //{
        //    mater.SetBool("open", true);
        //    Debug.Log("chest is open");
        //}
        //if (!chest.open)
        //{
        //    Debug.Log("chest is closed");
        //    mater.SetBool("open", false);
        //    
        //}
    }
}
