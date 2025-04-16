using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    public void TriggerAttackAnimation()
    {
        // Trigger the attack animation
        animator.SetTrigger("attack");
    }
}
