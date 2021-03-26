using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListen : MonoBehaviour
{
    SphereCollider sphere;
    Mask mask;
    List<Collider> savedFarNpcs = new List<Collider>();

    private void Awake()
    {
        //mask.cs
        LevelEvent.onChangeMask.AddListener(ListenAgain);
    }
    private void Start()
    {
        sphere = GetComponent<SphereCollider>();
        mask = GetComponent<Mask>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("npc"))
        {
            Collider[] hitFarNpcs = Physics.OverlapSphere(transform.position, sphere.radius);
            savedFarNpcs.Clear();
            foreach (var farNpc in hitFarNpcs)
            {
                if (farNpc.CompareTag("npc"))
                {
                    farNpc.SendMessage("ChangeDialogue", mask.state);
                    savedFarNpcs.Add(farNpc);
                }
            }
        }
    }

    public void ListenAgain(State _state)
    {
        Collider[] hitSphereColliders = Physics.OverlapSphere(transform.position, sphere.radius);
        foreach (var hitSphereCollider in hitSphereColliders)
        {
            if (hitSphereCollider.CompareTag("npc"))
            {
                hitSphereCollider.SendMessage("ChangeDialogue", _state);
            }
        }
    }
}
