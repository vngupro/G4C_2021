using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListen : MonoBehaviour
{
    CapsuleCollider capsule;
    SphereCollider sphere;
    Mask mask;

    private void Start()
    {
        capsule = GetComponent<CapsuleCollider>();
        sphere = GetComponent<SphereCollider>();
        mask = GetComponent<Mask>();
    }

    private void Update()
    {
        Collider[] hitSphereColliders = Physics.OverlapSphere(transform.position, sphere.radius);
        foreach (var hitSphereCollider in hitSphereColliders)
        {
            if (hitSphereCollider.CompareTag("npc"))
            {
                hitSphereCollider.SendMessage("ChangeDialogue", mask.state);
            }
        }

        Collider[] hitCapsuleColliders = Physics.OverlapSphere(transform.position, capsule.radius);
        foreach (var hitCapsuleCollider in hitCapsuleColliders)
        {
            if (hitCapsuleCollider.CompareTag("npc"))
            {
                hitCapsuleCollider.SendMessage("CanGetLastDialogue", true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("npc"))
        {
            
        }
    }
}
