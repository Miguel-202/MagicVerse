using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomAnimationSpeed : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        float randomSpeed = Random.Range(0.5f, 1.5f);
        animator.speed = randomSpeed;
    }
}
