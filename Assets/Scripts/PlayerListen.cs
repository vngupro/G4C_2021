using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListen : MonoBehaviour
{
    List<Collider> savedFarNpcs = new List<Collider>();
    public LayerMask layer;
    private float minDistToTalk = 8.0f;
    private Collider npc;

    SphereCollider sphere;
    Mask mask;
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (npc != null)
            {
                npc.SendMessage("CanShowDialogue", false);
            }
            if (Physics.Raycast(ray, out hitInfo, 500, layer))
            {
                Vector3 playerPos = transform.position;
                Vector3 npcPos = hitInfo.transform.position;
                Vector3 player2npc = npcPos - playerPos;
                float mPlayer2npc = player2npc.magnitude;

                if(mPlayer2npc < minDistToTalk)
                {
                    hitInfo.collider.SendMessage("CanShowDialogue", true);
                    hitInfo.collider.SendMessage("ChangeDialogue", mask.state);
                    npc = hitInfo.collider;
                }
            }
        }
    }
    public void ListenAgain(State _state)
    {
        if(npc != null)
        {
            npc.SendMessage("ChangeDialogue", mask.state);
        }
    }
}
