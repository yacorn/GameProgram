using UnityEngine;
using UnityEngine.InputSystem;

public class CreateManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    // private GameObject instance;
    [SerializeField] private float timer;

    void Start()
    {
        // instance = Instantiate(prefab);
        // instance.transform.rotation *= Quaternion.Euler(0f, 180f, 0f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 5f)
        {
            GameObject newObject = Instantiate(prefab);
            newObject.transform.position = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
            timer = 0f;
        }
        
    }

}
