using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    //Prefab for instantiating apples
    public GameObject applePrefab;

    // Speed that the tree moves
    public float speed = 1f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    //Seconds between Apples instantiations
    public float appleDropDelay = 1f;

    public float nonAppleDropDelay = 1f;

    
    // Start is called before the first frame update
    void Start()
    {
        Invoke ("DropApple", 2f);
        Invoke ("DropNonApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);

    }
    // Update is called once per frame
    void Update()
    {
        //Basic Movements
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //change directions

        //Changing Directions
        if (pos.x <   -leftAndRightEdge) 
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        // else if (Random.value < changeDirChance)
        // {
        //     speed *= -1;
        // }
    }

        void FixedUpdate() {
            if(Random.value < changeDirChance)
            {
                speed *= -1;
            }
        
    }
}
