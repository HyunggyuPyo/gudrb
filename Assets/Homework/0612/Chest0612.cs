using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest0612 : MonoBehaviour, IInteractable
{
    Animator animator;
    public LayerMask targetLayer;

    private bool possible = false; 

    void Start()
    {
        animator = GetComponent<Animator>();
        possible = false;
    }

    void Update()
    {
        if (possible && Input.GetKeyDown(KeyCode.F))
        {
            Use();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (1 << other.gameObject.layer != 1 << LayerMask.NameToLayer("Player"))
        {
            return;
        }

        possible = true;
    }

    private void OnTriggerExit(Collider other)
    {
        possible = false;
    }

    public void Use()
    {
        animator.SetTrigger("open");
    }
}
