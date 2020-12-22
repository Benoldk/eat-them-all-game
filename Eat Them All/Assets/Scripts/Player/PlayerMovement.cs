﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 20f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 point = LookAtMouse();
        if (Input.GetMouseButton(0))
        {
            Vector3 dir = (point - transform.position).normalized;
            transform.position += dir * Speed * Time.deltaTime;
        }
    }

    private Vector3 LookAtMouse()
    {
        Vector3 point = Vector3.zero;
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit hit, 10000))
        {
            point = hit.point;
            point.y = transform.position.y;
            transform.LookAt(point);
        }
        return point;
    }
}