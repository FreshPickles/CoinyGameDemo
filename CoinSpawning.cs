using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawning : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;

    bool isSpawning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // spawning at intervals
        if(!isSpawning)
        {
            float timer = Random.Range(0.5f, 3.0f);
            Invoke("InstantiateCoin", timer);
            isSpawning = true;
        }
    }

    private void InstantiateCoin()
    {
        // finding a position inside our camera
        Vector3 coinPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width - 5), Random.Range(0, Screen.height - 5), 14f));
        Instantiate(coin, coinPosition, Quaternion.identity);
        isSpawning = false;
    }
}
