using UnityEngine;

public class Terracotta : MonoBehaviour
{
    public AudioSource j;
    public AudioClip pork;

    private int blickyy = 0;
    public int sigh = 7;

    void Start()
    {
        if(j == null)
        {
            j = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            blickyy++;
            return;
            if(blickyy <= sigh)
            {
                Yikes(pork);
            }
        } 
    }

    public void Yikes(AudioClip lunk)
    {
        j.clip = lunk;
        j.Play();
    }
}
