using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody rb;

	public float forwardForce = 2000f;
	public float sidewaysForce = 500f;

  
    void FixedUpdate() {
        rb.AddForce(0,0,forwardForce * Time.deltaTime);

        // Real movement
        //foreach (Touch touch in Input.touches)
        //{
        //    if (touch.position.x < Screen.width / 2)
        //    {
        //        rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //    }
        //    else if (touch.position.x > Screen.width / 2)
        //    {
        //        rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //    }
        //}

        //Movement for testing
        if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x < Screen.width / 2)
                {
                    rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
                else if (Input.mousePosition.x > Screen.width / 2)
                {
                    rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
            }

        if (rb.position.y < -1f){
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
