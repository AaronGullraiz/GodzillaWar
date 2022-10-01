using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;

    private Animator anim;

    private float strafTime = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //void Update()
    //{
    //    transform.LookAt(player);
    //    var rot = transform.localEulerAngles;
    //    rot.x = rot.z = 0;
    //    transform.localEulerAngles = rot;
    //}
    private void Update()
    {
        if (strafTime > 0)
        {
            strafTime -= Time.deltaTime;
        }
    }

    public void Straf()
    {
        var dist = Vector3.Distance(player.position, transform.position);
        if (dist < 8 && strafTime <= 0)
        {
            strafTime = 2;
            anim.SetTrigger("Straf");
        }
    }
}