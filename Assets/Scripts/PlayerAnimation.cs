using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator player_animator;
    private PlayerController player_controller;

    private void Start()
    {
        player_animator = GetComponent<Animator>();
        player_controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        player_animator.speed = player_controller.GetCurrentSpeedRate();
    }
}
