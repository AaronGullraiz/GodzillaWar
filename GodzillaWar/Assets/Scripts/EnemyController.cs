using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(player);
        var rot = transform.localEulerAngles;
        rot.x = rot.z = 0;
        transform.localEulerAngles = rot;
    }
}