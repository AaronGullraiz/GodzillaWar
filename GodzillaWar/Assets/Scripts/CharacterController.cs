using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Transform enemy;
    public Animator anim;
    public Rigidbody rigidBody;
    public float speed;
    public float speedRot;
    public float speedMove;
    public ParticleSystem particle;

    public AudioClip[] hitClips;
    public AudioClip[] strafClips;

    private bool isAttacking;

    private float attackDelay = 0;

    private EnemyController enemyController;

    private AudioSource source;

    void Start()
    {
        enemyController = enemy.GetComponent<EnemyController>();
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        float y = Input.GetAxis("P1KeyboardHorizontal");
        float x = Input.GetAxis("P1KeyboardVertical");
        Move(x, y);
        Attack();

        if (isAttacking)
        {
            if (attackDelay < 0)
            {
                isAttacking = false;
            }
            attackDelay -= Time.deltaTime;
        }
    }

    private void Move(float x, float y)
    {
        if (!isAttacking)
        {
            var rot = enemy.localEulerAngles;
            rot.y += x * speedRot / Vector3.Distance(transform.position, enemy.position);
            enemy.localEulerAngles = rot;

            rigidBody.velocity = transform.forward * y * speedMove;

            anim.SetFloat("Walk", Mathf.Clamp01(Mathf.Abs(x) + Mathf.Abs(y)));
        }
    }

    private void Attack()
    {
        if (!isAttacking)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                isAttacking = true;
                attackDelay = 1;
                anim.SetTrigger("Punch1");
                enemyController.Straf();
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                isAttacking = true;
                attackDelay = 1;
                anim.SetTrigger("Punch2");
                enemyController.Straf();
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                isAttacking = true;
                attackDelay = 1;
                anim.SetTrigger("Kick1");
                enemyController.Straf();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                isAttacking = true;
                attackDelay = 1;
                anim.SetTrigger("Kick2");
                enemyController.Straf();
            }
        }
    }

    private void OldControls()
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

    public void PlayHitEffect()
    {
        var dist = Vector3.Distance(enemy.position, transform.position);
        if (dist < 8)
        {
            source.PlayOneShot(hitClips[Random.Range(0, hitClips.Length)]);
            particle.Play();
        }
        else
        {
            source.PlayOneShot(strafClips[Random.Range(0, strafClips.Length)]);
        }
    }
}