using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator anim;
    private TimelineController timelineController;
    private float stayTimer = 0;
    [SerializeField] private float stayTime = 1f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        timelineController = GetComponent<TimelineController>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            stayTimer = 0;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            stayTimer += Time.deltaTime;
            if (stayTimer >= stayTime)
            {
                OpenChest();
            }
        }
    }

    void OpenChest()
    {
        //anim.SetTrigger("open");
       timelineController.Play();
    }
}
