using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using JetBrains.Annotations;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
	
	public Text PatternDisplay;
	public string[] Items;
	public string[] Colors;
	public ArrayList ColorItem;
	public int OrderNumber;
	int m = 0;

	// Use this for initialization
	void Start()
	{
		Items = new string[4];
		Colors = new string[4];
		Items[0] = "shirt";
		Items[1] = "pants";
		Items[2] = "underwear";
		Items[3] = "shoes";

		Colors[0] = "red";
		Colors[1] = "blue";
		Colors[2] = "green";
		Colors[3] = "purple";

		int check = 0;
		ColorItem = new ArrayList();
		for (int i = 0; i < OrderNumber; i++)
		{
			ColorItem.Add("");
		}
		bool test = false;
		
		String item = Colors[Random.Range(0, 4)] + "_" + Items[Random.Range(0, 4)];
		while (test == false)
		{
			if (ColorItem.Contains(item))
			{
				item = Colors[Random.Range(0, 4)] + "_" + Items[Random.Range(0, 4)];
			}
			else
			{
				if (check == OrderNumber)
				{
					test = true;
				}
				else
				{
					ColorItem[check] = item;
					check++;
				}
			}
		}
		String passMe = "";
		for (int i = 0; i < OrderNumber; i++)
		{
			if (i != OrderNumber - 1)
			{
				passMe += ColorItem[i] + ",";
			}
			else
			{
				passMe += ColorItem[i];
			}
		}
		PlayerPrefs.SetString("order", passMe);
		Debug.Log(ColorItem[0]);

	}
	
	// Update is called once per frame
	void Update()
	{
		if (m == 0)
		{
			PatternDisplay.text = ("The pattern is: ");
		}
		
		if (Input.GetKeyDown(KeyCode.Space) && m != OrderNumber)
		{
			PatternDisplay.text = ColorItem[m].ToString();
			m++;
		}
	}
}
	
	

