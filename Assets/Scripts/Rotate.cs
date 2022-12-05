using UnityEngine;

public class Rotate : MonoBehaviour
{
    public int speed;
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * speed, 0, Space.Self);
    }
}
