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
		currentlyHolding = new ArrayList();
		
		//PROOF
		arrOrder = new string[4];
		sizeOfOrder = 4;
		arrOrder[0] = "blue_shirt";
		arrOrder[1] = "blue_pants";
		arrOrder[2] = "blue_shoes";
		arrOrder[3] = "blue_underwear";
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < currentlyHolding.Count; i++)
		{
			Debug.Log(currentlyHolding[i]);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		currentlyHolding.Add(other.gameObject.name);
		Debug.Log("ADDED");
		if (CheckIfFinished())
		{
			Debug.Log("DONE");
		}
		else
		{
			Debug.Log("YOU FUCKED UP");
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		currentlyHolding.Remove(other.gameObject.name);
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
}
