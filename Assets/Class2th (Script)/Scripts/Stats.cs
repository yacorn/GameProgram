using UnityEngine;

public class Stats : MonoBehaviour
{
    public int strength = 5;
    public int wisdom = 1;
    public int dexterity = 0;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Strength:" + strength);
        Debug.Log("Wisdom:" + wisdom);
        Debug.Log("Dexterity:" + dexterity);
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
