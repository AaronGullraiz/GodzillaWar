using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Transform enemy;
    public Animator anim;
    public Rigidbody rigidBody;
    public float speed;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 movement = new Vector3(
            Input.GetAxis("P1KeyboardHorizontal"),
            0,
            Input.GetAxis("P1KeyboardVertical")
            );

        rigidBody.velocity = movement * speed;

        anim.SetFloat("Walk", Mathf.Clamp01(rigidBody.velocity.magnitude));

        transform.LookAt(enemy.position);
        var rot = transform.localEulerAngles;
        rot.x = rot.z = 0;
        transform.localEulerAngles = rot;
    }
}