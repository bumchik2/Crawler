using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float offset;

    public float smooth_speed = 0.125f;
    public float smooth_rotation = 0.125f;

    private Transform player_transform;

    private void Start()
    {
        player_transform = GameObject.FindWithTag("Player").transform;
    }

    private void MoveCamera()
    {
        Vector3 desired_position = player_transform.position + player_transform.up * offset;
        desired_position.z = gameObject.transform.position.z;
        Vector3 new_position = Vector3.Lerp(gameObject.transform.position, desired_position, smooth_speed);
        gameObject.transform.position = new_position;

        Vector3 real_up = Vector3.Lerp(gameObject.transform.up, player_transform.up, smooth_rotation);
        gameObject.transform.up = real_up;
    }

    private void Update()
    {
        MoveCamera();
    }
}
