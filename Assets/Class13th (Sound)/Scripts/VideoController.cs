using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public double currentTime;
    public double totalTime;
    public float progressPercent;

    private VideoPlayer vp;
    void Start()
    {
        vp = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if(vp != null && vp.isPrepared)
        {
            currentTime = vp.time;
            totalTime = vp.length;
            progressPercent = (float)(currentTime / totalTime) * 100f;
        }
    }
}
