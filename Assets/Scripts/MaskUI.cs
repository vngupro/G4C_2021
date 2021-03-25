using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskUI : MonoBehaviour
{
    public GameObject maskBadgeGrid;
    public BadgeSlot badgeSlot;
    public GameObject firstSlot;
    public int nbBadgeRow = 5;
    public int nbBadgeColumn = 5;

    private BadgePool badgePool;
    private void Awake()
    {
        badgePool = GetComponent<BadgePool>();
        float badgeSize = firstSlot.GetComponent<RectTransform>().rect.width;
        float badgeGridWidth = maskBadgeGrid.GetComponent<RectTransform>().rect.width;
        badgeSize = badgeGridWidth / nbBadgeRow;
        float badgePoolCount = badgePool.badges.Count;
        int col = 0;
        int row = 0;
        int count = 0;

        while(count < badgePoolCount && row < nbBadgeRow)
        {
            BadgeSlot newBadgeSlot = Instantiate(badgeSlot, firstSlot.transform.position, firstSlot.transform.rotation);
            newBadgeSlot.transform.SetParent(maskBadgeGrid.transform);
            newBadgeSlot.transform.position = new Vector3(firstSlot.transform.position.x + badgeSize * col,
                                                            firstSlot.transform.position.y - badgeSize * row,
                                                            badgeSlot.transform.position.z);
            newBadgeSlot.badge = badgePool.badges[count];
            count++;
            if ((col % nbBadgeColumn) == 4)
            {
                row++;
                col = -1;
            }
            col++;
        }
        Destroy(firstSlot);
    }
}
