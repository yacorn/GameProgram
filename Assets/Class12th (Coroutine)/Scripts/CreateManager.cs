using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CreateManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    // private GameObject instance;
    // [SerializeField] private float timer;
    [SerializeField] private float interval = 5f;

    void Start()
    {
        // instance = Instantiate(prefab);
        // instance.transform.rotation *= Quaternion.Euler(0f, 180f, 0f);
        StartCoroutine(Coroutine());
    }

    void Update()
    {
        // timer += Time.deltaTime;

        // if(timer >= 5f)
        // {
        //     GameObject newObject = Instantiate(prefab);
        //     newObject.transform.position = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
        //     timer = 0f;
        // }
        
    }

    IEnumerator Coroutine()
    {
        var wait = new WaitForSeconds(interval);
        float lastInterval = interval;

        while (true)
        {
            if(lastInterval != interval)
            {
                wait = new WaitForSeconds(interval);
                lastInterval = interval;
                Debug.Log($"시간이{interval}초로 변경되었습니다.");
            }
            yield return wait; // 5초 대기
            Debug.Log(interval + "초 경과");
            GameObject newObject = Instantiate(prefab, gameObject.transform);
            newObject.transform.position = new Vector3(Random.Range(-2f, 2f), 0f, 0f);        
            newObject.transform.rotation *= Quaternion.Euler(0f, 180.0f, 0f);
        }
        
    }
}
