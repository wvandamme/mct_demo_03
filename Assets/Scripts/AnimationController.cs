using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class AnimationController : MonoBehaviour
{

    public Animation anim;
    public GameObject root;

    public void Wait()
    {
        anim.Play("sj001_wait");
    }

    public void Run()
    {
        anim.Play("sj001_run");
    }

    public void Die()
    {
        anim.Play("sj001_die");
        GameObject.Destroy(root, 1.0f);
    }


}
