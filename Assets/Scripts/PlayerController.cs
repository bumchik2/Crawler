using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float max_speed;
    public float rotation_speed;

    public float GetCurrentSpeedRate()
    {
        float input_move = Math.Max(Input.GetAxis("Vertical"), 0);
        return input_move;
    }

    private void MovePlayer()
    {
        float speed = GetCurrentSpeedRate() * max_speed;
        gameObject.transform.position += gameObject.transform.up * speed * Time.deltaTime;

        float input_rotation = Input.GetAxis("Horizontal");
        float angle = -input_rotation * rotation_speed * Time.deltaTime * GetCurrentSpeedRate();
        gameObject.transform.Rotate(new Vector3(0, 0, angle));
    }

    private void Update()
    {
        MovePlayer();
    }
}
