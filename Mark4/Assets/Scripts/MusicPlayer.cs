using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    void Awake()
    {
        int count = FindObjectsOfType<MusicPlayer>().Length;
        if (count > 1)
        {
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }
}
