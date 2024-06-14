using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box0612 : MonoBehaviour, IInteractable
{
    private bool possible = false;
    private bool carry = false;
    private Transform playerPos;


    void Update()
    {
        if (possible && Input.GetKeyDown(KeyCode.F))
        {
            Use();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( 1 << other.gameObject.layer != 1 << LayerMask.NameToLayer("Player"))
        {
            return;
        }

        playerPos = other.gameObject.transform;
        possible = true;
    }

    private void OnTriggerExit(Collider other)
    {
        possible = false;
    }

    public void Use()
    {
        if(!carry)
        {
            gameObject.transform.SetParent(playerPos);
            carry = true;
        }
        else
        {
            gameObject.transform.SetParent(null);
            carry = false;
        }
        
        //Destroy(gameObject);
    }
}
