using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskUI : MonoBehaviour
{
    public GameObject maskBadgeGrid;
    public MaskBadgeSlot badgeSlot;
    public GameObject firstSlot;
    public int nbBadgeRow = 5;
    public int nbBadgeColumn = 5;

    private void Awake()
    {
        float badgeSize = firstSlot.GetComponent<RectTransform>().rect.width;
        float badgeGridWidth = maskBadgeGrid.GetComponent<RectTransform>().rect.width;
        badgeSize = badgeGridWidth / nbBadgeRow;

        for(int col = 0; col < nbBadgeColumn; col++)
        {
            for(int row = 0; row < nbBadgeRow; row++)
            {
                MaskBadgeSlot newBadgeSlot = Instantiate(badgeSlot, firstSlot.transform.position, firstSlot.transform.rotation);
                newBadgeSlot.transform.SetParent(maskBadgeGrid.transform);
                newBadgeSlot.transform.position = new Vector3(firstSlot.transform.position.x + badgeSize * row,
                                                              firstSlot.transform.position.y - badgeSize * col,
                                                              badgeSlot.transform.position.z);
            }
        }
        Destroy(firstSlot);
    }
}
