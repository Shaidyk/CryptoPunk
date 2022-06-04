using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDor : MonoBehaviour
{
    private Animator anim;
    public bool isOpen;
    public KeyCode keyAnim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOpen)
        {
            if (Input.GetKeyUp (keyAnim))
            {
                anim.SetBool("isOpen", true);
            }
        }
    }

    
}
