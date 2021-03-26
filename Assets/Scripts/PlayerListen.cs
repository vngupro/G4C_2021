using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListen : MonoBehaviour
{
    SphereCollider sphere;
    Mask mask;
    List<Collider> savedFarNpcs = new List<Collider>();
    List<Collider> savedNearNpcs = new List<Collider>();

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
                    farNpc.SendMessage("CanShowDialogue", true);
                    farNpc.SendMessage("ChangeDialogue", mask.state);
                    savedFarNpcs.Add(farNpc);
                }
            }

            Collider[] hitNearNpcs = Physics.OverlapSphere(transform.position, sphere.radius / 2);
            savedNearNpcs.Clear();
            foreach (var nearNpc in hitNearNpcs)
            {
                if (nearNpc.CompareTag("npc"))
                {
                    nearNpc.SendMessage("CanGetLastDialogue", true);
                    savedNearNpcs.Add(nearNpc);
                }
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Collider[] hitFarNpc = Physics.OverlapSphere(transform.position, sphere.radius);
        List<Collider> temps = new List<Collider>();
        int count = 0;
        bool isEmpty = true;
        foreach (var savedNpc in savedFarNpcs)
        {
           
            if (savedNpc.CompareTag("npc"))
            {
                Debug.Log(savedNpc.name);
                foreach (var farNpc in hitFarNpc)
                {
                    if (farNpc.CompareTag("npc"))
                    {
                        if (farNpc == savedNpc)
                        {
                            temps.Add(savedNpc);
                            Debug.Log("What remove ? " + temps[count]);
                            isEmpty = false;
                            count++;
                        }

                        Debug.Log(savedNpc.name);
                        Debug.Log(farNpc.name);
                    }
                }
            }

        }
        if(!isEmpty)
        {
            foreach (var temp in temps)
            {
                if (temp.CompareTag("npc"))
                {
                    temp.SendMessage("CanShowDialogue", false);
                }
            }
        }

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, sphere.radius / 2);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("npc"))
            {
                hitCollider.SendMessage("CanGetLastDialogue", false);
                Debug.Log("cannot have last dialogue");
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

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, sphere.radius / 2);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("npc"))
            {
                hitCollider.SendMessage("CanGetLastDialogue", true);
            }
        }
    }
}
