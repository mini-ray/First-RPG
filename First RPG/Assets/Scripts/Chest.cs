using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    //public GameObject player;

    public bool open;
    Animator mater;
    public Chest chest;

    
    
    public GameObject CanvasObject;

    // Start is called before the first frame update
    void Start()
    {
    
    //chest = GameObject.Find("Chest").GetComponent<Chest>();

    mater = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject character = GameObject.Find("Player");
        //float distance = Vector3.Distance(character.transform.position, transform.position);
        //Debug.Log(distance);
        mater.SetBool("open", true);

        if (chest.open)
        {
            mater.SetBool("open", true);
            CanvasObject.GetComponent<Canvas>().enabled = true;
            //Debug.Log("chest is open");
        }
        else if (!chest.open)
        {
            //Debug.Log("chest is closed");
            mater.SetBool("open", false);
            CanvasObject.GetComponent<Canvas>().enabled = false;

        }
    }

    public void Open()
    {
        GameObject character = GameObject.Find("Player");
        float distance = Vector3.Distance(character.transform.position, transform.position);
        Debug.Log(distance);

        if (distance <= 5 && Input.GetButtonDown("Fire2"))
            mater.SetBool("open", true);
    }
}
