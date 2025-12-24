using Unity.VisualScripting;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField] private Controll controll;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter: " + other.name);
        if(other.tag == "Ball")
        {
            other.GetComponent<Controll>().Soar();    
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay: " + other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit: " + other.name);
        if(other.tag == "Ball"){
            other.GetComponent<Controll>().Initialize();
        }
    }

}
