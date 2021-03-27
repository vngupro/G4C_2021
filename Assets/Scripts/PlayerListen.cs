using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListen : MonoBehaviour
{
    public LayerMask layer;
    private float minDistToTalk = 8.0f;
    private Collider npc;
    public MaskManager mask;
    private SetMouseCursor cursor;
    private int count = 0;
    private void Awake()
    {
        cursor = GetComponent<SetMouseCursor>();
        //mask.cs
        LevelEvent.onChangeMask.AddListener(ListenAgain);
    }

    // Update is called once per frame
    void Update()
    {
        Ray rayHover = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hoverHitInfo;
        if (Physics.Raycast(rayHover, out hoverHitInfo, 500, layer))
        {
            cursor.ChangeCursorOnNPC();
        }
        else
        {
            cursor.SetInitialCursor();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
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
                    switch (count)
                    {
                        case 0:
                            FindObjectOfType<SoundManager>().PlaySound("Pop1");
                            break;
                        case 1:
                            FindObjectOfType<SoundManager>().PlaySound("Pop2");
                            break;
                        case 2:
                            FindObjectOfType<SoundManager>().PlaySound("Pop3");
                            break;
                        default:
                            FindObjectOfType<SoundManager>().PlaySound("Pop1");
                            break;
                    }
                    count++;
                    if(count >= 3)
                    {
                        count = 0;
                    }
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
