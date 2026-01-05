using System.Collections.Generic;
using UnityEngine;

public enum AnimationState
{
    Idle,
    Move,
    Attack,
    Die,
    Count
}

public class Unit : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] int index = 0;
    [SerializeField] AnimationState state;

    private Dictionary<AnimationState, AudioClip> soundCache = new Dictionary<AnimationState, AudioClip>();
    
    private void Awake()
    {
        state = AnimationState.Idle;
        animator = GetComponent<Animator>();

        for(int i = 0; i < (int)AnimationState.Count; i++)
        {
            AnimationState animState = (AnimationState)i;
            AudioClip clip = Resources.Load<AudioClip>(animState.ToString());
            if(clip != null) soundCache.Add(animState, clip);
        }
    }
    public void Transition(int count)
    {
        index += count;
        Debug.Log("Current State: " + state + ", Index: " + index);
        if(state == AnimationState.Die)
        {
            // State 변경
            state = AnimationState.Idle;
            index = 0;
        }
        else if(index >= 3)
        {
            // State 변경
            state = (AnimationState)(((int)state + 1) % (int)AnimationState.Count);
            index = 0;
        }
    }
    public void PlaySound()
    {
        // audioSource.clip = Resources.Load<AudioClip>(state.ToString());
        // Debug.Log("현재 재생중인 사운드: " + audioSource.clip.name);
        // audioSource.Play();
        if(soundCache.TryGetValue(state, out AudioClip clip))
        {
            audioSource.clip = clip;
            Debug.Log("현재 재생중인 사운드: " + audioSource.clip.name);
            audioSource.Play();
        }
    }
}
