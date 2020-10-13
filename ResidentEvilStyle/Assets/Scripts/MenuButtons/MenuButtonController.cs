using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour {

	// Use this for initialization
	public int index;
	[SerializeField] bool keyDown;
	[SerializeField] int maxIndex;
	public AudioSource audioSource;

	void Start () {
		
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
		{
			if(!keyDown)
			{
				if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) 
				{
					if(index < maxIndex)
					{
						index++;
					
					}
					else
					{
						index = 0;
					}
				} 
				else if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
				{
					if(index > 0)
					{
						index --; 
					}
					else
					{
						index = maxIndex;
					}
				}
				keyDown = true;
			}
		}
		else
		{
			keyDown = false;
		}
	}

}
