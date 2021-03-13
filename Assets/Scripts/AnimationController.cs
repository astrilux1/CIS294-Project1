using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            {
            myAnimator.SetBool("WalkingL", true);
            }

        myAnimator.SetBool("WalkingL", Input.GetKey(KeyCode.A));
        myAnimator.SetBool("WalkingR", Input.GetKey(KeyCode.D));
    }
}
