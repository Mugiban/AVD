using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Gem,
    Cherry
}
public class PickUp : MonoBehaviour
{
    public static event Action<int> OnPickUp;
    private Animator anim;
    private BoxCollider2D col;
    public ItemType itemType = ItemType.Gem;
    private AudioSource source;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        source = GetComponent<AudioSource>();
        col.enabled = true;
        RandomizeItem();
        String item = "";
        switch (itemType)
        {
            case ItemType.Gem:
                item = "gem";
                break;
            case ItemType.Cherry:
                item = "cherry";
                break;
        }
        anim.SetTrigger(item);
    }

    private void RandomizeItem()
    {
        float chance = UnityEngine.Random.Range(0, 100);
        if (chance <= 50)
        {
            itemType = ItemType.Gem;
        }
        else
        {
            itemType = ItemType.Cherry;
        }
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
            source.Play();
            switch (itemType)
            {
                case ItemType.Gem:
                    OnPickUp?.Invoke(1);
                    break;
                case ItemType.Cherry:
                    OnPickUp?.Invoke(2);
                    break;
            }
            Destroy(gameObject, 0.267f);
        }
    }
}






