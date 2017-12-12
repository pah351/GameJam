using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suitcase : MonoBehaviour
{

	private string[] arrOrder;
	private ArrayList currentlyHolding;

	private int sizeOfOrder;
	// Use this for initialization
	void Start ()
	{
		PlayerPrefs.SetString("order", "blue_shirt,green_shirt,purple_shirt");
		currentlyHolding = new ArrayList();
		string order = PlayerPrefs.GetString("order");
		Debug.Log(order);
		arrOrder = order.Split(',');
		//PROOF
		sizeOfOrder = arrOrder.Length;
		Debug.Log(sizeOfOrder + "<- size of order");
	}
	
	// Update is called once per frame
	void Update () 
	{
		PrettyPrint(currentlyHolding);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		currentlyHolding.Add(other.gameObject.name);
		Debug.Log(currentlyHolding.Count);
		Debug.Log("ADDED");
		if (CheckIfFinished())
		{
			Debug.Log("YOU WIN");
		}
		else
		{
			Debug.Log("YOU FUCKED UP");
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("REMOVE");
		currentlyHolding.Remove(other.gameObject.name);
		Debug.Log(currentlyHolding.Count);
	}

	bool CheckIfFinished()
	{
		bool returnMe = false;
		if (currentlyHolding.Count > sizeOfOrder || currentlyHolding.Count < sizeOfOrder)
		{
			return false;
		}
		else
		{
			for (int i = 0; i < sizeOfOrder; i++)
			{
				Debug.Log("Checking if" + arrOrder[i] + " is in the currentlyHolding.");
				if (currentlyHolding.Contains(arrOrder[i]))
				{
					returnMe = true;
				}
				else
				{
					return false;
				}
			}
			return returnMe;
		}
	}

	void PrettyPrint(ArrayList arr)
	{
		Debug.Log("PRETTY PRINT");
		String s = "";
		for (int i = 0; i < arr.Count; i++)
		{
			s += (arr[i]) + ", ";
		}
		Debug.Log(s);
	}
}
