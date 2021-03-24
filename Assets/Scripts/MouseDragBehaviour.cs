using UnityEngine;
using UnityEngine.EventSystems;

public class MouseDragBehaviour : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public MaskSlot[] maskSlots = new MaskSlot[4];
    private float maskSlotHalfWidth;
    private float maskSlotHalfHeight;
    
    private Vector2 lastMousePosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        maskSlotHalfWidth = maskSlots[0].GetComponent<RectTransform>().rect.width / 2;
        maskSlotHalfHeight = maskSlots[0].GetComponent<RectTransform>().rect.height / 2;
        lastMousePosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentMousePosition = eventData.position;
        Vector2 diff = currentMousePosition - lastMousePosition;
        RectTransform rect = GetComponent<RectTransform>();

        Vector3 newPosition = rect.position + new Vector3(diff.x, diff.y, transform.position.z);
        Vector3 oldPos = rect.position;
        rect.position = newPosition;
        if (!IsRectTransformInsideSreen(rect))
        {
            rect.position = oldPos;
        }
        lastMousePosition = currentMousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 currentMousePos = eventData.position;
        int count = 0;
        bool isOnMaskSlot = false;
        while(count < 4 && !isOnMaskSlot)
        {
            float minXBound = maskSlots[count].transform.position.x - maskSlotHalfWidth;
            float maxXBound = maskSlots[count].transform.position.x + maskSlotHalfWidth;
            float maxYBound = maskSlots[count].transform.position.y + maskSlotHalfHeight;
            float minYBound = maskSlots[count].transform.position.y - maskSlotHalfHeight;

            if (currentMousePos.x > minXBound 
                && currentMousePos.x < maxXBound
                && currentMousePos.y > minYBound 
                && currentMousePos.y < maxYBound)
            {
                transform.position = maskSlots[count].transform.position;
                isOnMaskSlot = true;
                maskSlots[count].hasBadge = true;
                maskSlots[count].badge = GetComponent<BadgeSlot>().badge;
            }
            count++;
        }

        if (!isOnMaskSlot)
        {
            transform.position = GetComponent<BadgeSlot>().originPos;
            foreach(MaskSlot maskSlot in maskSlots)
            {
                maskSlot.hasBadge = false;
            }
        }
    }

    private bool IsRectTransformInsideSreen(RectTransform rectTransform)
    {
        bool isInside = false;
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        int visibleCorners = 0;
        Rect rect = new Rect(0, 0, Screen.width, Screen.height);
        foreach (Vector3 corner in corners)
        {
            if (rect.Contains(corner))
            {
                visibleCorners++;
            }
        }
        if (visibleCorners == 4)
        {
            isInside = true;
        }
        return isInside;
    }
}
