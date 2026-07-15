using UnityEngine;
using System.Collections.Generic;

public class QueueDemo : MonoBehaviour
{

    public GameObject myPrefab;
    public Queue<GameObject> myQueue = new Queue<GameObject>();

    GameObject tempObject;
    Vector3 lastQueuedPosition = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            tempObject = Instantiate(myPrefab, transform);
            tempObject.transform.position = new Vector2(lastQueuedPosition.x + 1, 0);
            tempObject.name = "QUEUED_" + myQueue.Count;
            tempObject.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

            myQueue.Enqueue(tempObject);
            lastQueuedPosition = tempObject.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject removedObject = myQueue.Dequeue();
            Destroy(removedObject);
        }
    }
}
