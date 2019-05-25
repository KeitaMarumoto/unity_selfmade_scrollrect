using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyScrollRect : UIBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	[SerializeField]
	RectTransform contentRect;

	[SerializeField]
	bool canHorizontal = false;

	[SerializeField]
	bool canVertical = true;

	[SerializeField]
	RectTransform viewPortRect;

	Vector2 startLocalCursor;
	Vector2 startPositon;

	public void OnBeginDrag(PointerEventData eventData)
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(this.viewPortRect, eventData.position, eventData.pressEventCamera, out startLocalCursor);
		startPositon = contentRect.anchoredPosition;
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector2 localPoint;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(viewPortRect, eventData.position, eventData.pressEventCamera, out localPoint);

		Vector2 delta = localPoint - startLocalCursor;
		if (!canHorizontal) delta.x = 0;
		if (!canVertical) delta.y = 0;

		contentRect.anchoredPosition = startPositon + delta;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
	}
}
