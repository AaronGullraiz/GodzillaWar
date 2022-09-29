using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player, enemy;
    public Vector3 offset;

    public Transform centerObj;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 center = Vector3.Lerp(player.position, enemy.position, 0.5f);
        centerObj.position = center+offset;
        centerObj.LookAt(enemy);


        var dist = Mathf.Clamp(Vector3.Distance(player.position, enemy.position)*0.8f,10,float.PositiveInfinity);
        //transform.position = center + offset;
        transform.position = centerObj.position + (centerObj.right*dist);


        transform.forward = -centerObj.right;
    }
}