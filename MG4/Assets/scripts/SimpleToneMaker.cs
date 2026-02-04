using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleToneMaker : MonoBehaviour
{
    public static AudioClip MakeSine (float frequencyHz, float durationSec, int sampleRate = 44100)
    {
        int samples = Mathf.CeilToInt(sampleRate * durationSec); 
        float[] data = new float[samples];

        float increment = 2f * Mathf.PI * frequencyHz / sampleRate;
        float phase = 0f; 
        for (int i = 0; i < samples; i++)
        {
            data[i] = Mathf.Sin(phase) * 0.2f; //volume
            phase += increment;

        }
        AudioClip Clip = AudioClip.Create($"tone_{frequencyHz}", samples, 1, sampleRate, false); 
        Clip.SetData(data, 0);
        return Clip;
    }
   
}
