using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public GameObject unequippedAx;
    public GameObject equippedAx;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void EquipWeapon() {

        //print("Ax equipped");
        unequippedAx.SetActive(false);
        equippedAx.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");

        //print("h: "+h);

        if(h > 0 || h < 0)
        {
            anim.SetBool("move",true);
        }
        else
        {
            anim.SetBool("move",false);
        }

        anim.SetFloat("horizontal",h);
        
    }
}
