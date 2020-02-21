using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PickUp : MonoBehaviour
{

    public static event Action OnPickUp;
    private Animator anim;
    private BoxCollider2D col;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        col.enabled = true;
    }

    private void Start()
    {
        anim.speed = UnityEngine.Random.Range(0.8f, 1.2f);
    }

    private bool collided;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (collided) return;
            collided = true;
            col.enabled = false;
            anim.SetTrigger("pickUp");
            OnPickUp?.Invoke();
            Destroy(gameObject, 0.267f);
        }
    }
}
