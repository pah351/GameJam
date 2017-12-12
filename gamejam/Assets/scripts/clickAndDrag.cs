using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickAndDrag : MonoBehaviour
{
	//SCRIPT FROM
	//http://unity.grogansoft.com/drag-and-drop/
	private bool draggingItem = false;

	private GameObject draggedObject;

	private Vector2 touchOffset;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (HasInput)
		{
			DragOrPickUp();
		}
		else
		{
			if (draggingItem)
			{
				DropItem();
			}
		}
	}

	private Vector2 CurrentTouchPosition
	{
		get
		{
			Vector2 inputPos;
			inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			return inputPos;
		}
	}
	
	private bool HasInput
	{
		get { return Input.GetMouseButton(0); }
	}
	private void DragOrPickUp()
	{
		var inputPosition = CurrentTouchPosition;
		if (draggingItem)
		{
			draggedObject.transform.position = inputPosition + touchOffset;
		}
		else
		{
			RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
			if (touches.Length > 0)
			{
				var hit = touches[0];
				if (hit.transform != null && hit.transform.tag == "drag")
				{
					draggingItem = true;
					draggedObject = hit.transform.gameObject;
					touchOffset = (Vector2)hit.transform.position - inputPosition;
					draggedObject.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
				}
 
			}
		} 
	}
	void DropItem()
	{
		draggingItem = false;
		draggedObject.transform.localScale = new Vector3(1f,1f,1f);
	}
	
}
