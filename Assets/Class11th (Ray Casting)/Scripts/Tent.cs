using UnityEngine;
using System;
using Unity.VisualScripting;

public class Tent : Equipment
{
    public event Action OnReset;

    [SerializeField] float sacleStep = 0.25f;
    [SerializeField] float roatateStep = 15f;
    [SerializeField] Vector3 defaultScale = Vector3.one;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        OnReset += Reset;
    }

    void OnDisable()
    {
        OnReset -= Reset;        
    }

    void Reset()
    {
        transform.localScale = Vector3.one;
        transform.rotation = Quaternion.identity;
    }

    public override void OnHit()
    {
        Debug.Log("Tent Hit");
        // 최소 크기 제한
        transform.localScale -= Vector3.one * 0.25f;
        transform.rotation *= Quaternion.Euler(0f, 15f, 0f);

        // if(transform.localScale.x <= 0f)
        // {   
        //     transform.localScale = Vector3.one;
        // }

        if(transform.localScale.x <= 0f)
        {
            OnReset?.Invoke();
        }
        
        
    }


}
