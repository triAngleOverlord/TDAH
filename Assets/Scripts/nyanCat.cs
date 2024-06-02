using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class nyanCat : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.timeRate -= 0.1f;
        int x = Random.Range(-1, 1);
        int y = Random.Range(-1, 1);

        if (x == 0 || y == 0)
        {
            x = 1;
            y = 1;
        }

        GetComponent<RectTransform>().localPosition = new Vector3(x*1090, y*640, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float step = 100 * Time.deltaTime;
        Vector2 target = new Vector2(0, 0);

        // move sprite towards the target location
        GetComponent<RectTransform>().localPosition = Vector2.MoveTowards(transform.localPosition, target, step);
        
    }

    public void goAway()
    {
        Destroy(gameObject);
    }
}
