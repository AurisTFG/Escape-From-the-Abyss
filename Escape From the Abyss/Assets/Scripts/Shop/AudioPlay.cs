using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
	public AudioSource audio;

	public void playAudio()
	{
		audio.Play();
	}
}
