using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float moveSpeed = 4f;
    Rigidbody rigid;
    public GameObject putF; 

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.F))
            putF.SetActive(false);

        UILookAt();
    }

    void Move()
    {
        float rotate = Input.GetAxisRaw("Horizontal");
        float move = Input.GetAxisRaw("Vertical");

        rotate = rotate * 75f * Time.deltaTime;
        move = move * moveSpeed * Time.deltaTime;

        rigid.transform.Rotate(Vector3.up * rotate);
        rigid.transform.Translate(Vector3.forward * move);
    }

    private void OnTriggerEnter(Collider other)
    {   
        putF.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        putF.SetActive(false);
    }

    void UILookAt()
    {
        putF.transform.LookAt(Camera.main.transform);
    }
}
