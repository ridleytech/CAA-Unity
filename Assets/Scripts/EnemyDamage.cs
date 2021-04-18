using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter (Collider other) {

        print("hit enemy");
        anim.SetTrigger("damage");
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
