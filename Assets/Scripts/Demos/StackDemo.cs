using UnityEngine;
using System.Collections.Generic;

public class StackDemo : MonoBehaviour
{

    public GameObject myPrefab;
    public Stack<GameObject> myStack = new Stack<GameObject>();

    GameObject tempObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            tempObject = Instantiate(myPrefab, transform);
            tempObject.transform.position = new Vector2(0, myStack.Count);
            tempObject.name = "STACKED_" + myStack.Count;
            tempObject.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

            myStack.Push(tempObject);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject removedObject = myStack.Pop();
            Destroy(removedObject);
        }
    }
}
