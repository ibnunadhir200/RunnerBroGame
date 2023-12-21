using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    static public bool canMove = true;

    private Vector2 touchStartPos;
    public bool isJumping = false;
    public bool comingDown = false;
    public bool isColliding = false;
    public GameObject playerObject;

    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

        HandleTouchInput();

        if (isJumping)
        {
            if (comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 8, Space.World);
            }
            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -8, Space.World);
            }
        }
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;


        if (!isColliding)
        {
            playerObject.GetComponent<Animator>().Play("Standard Run");
        }
    }

    void HandleTouchInput()
    {
        if (canMove)
        {

            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                switch (touch.phase)
                {
                    case TouchPhase.Began:

                        touchStartPos = touch.position;
                        break;

                    case TouchPhase.Moved:

                        float swipeDeltaX = touch.position.x - touchStartPos.x;


                        float swipeThreshold = Screen.width * 0.1f;


                        if (swipeDeltaX < -swipeThreshold)
                        {

                            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
                        }

                        else if (swipeDeltaX > swipeThreshold)
                        {

                            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
                        }
                        break;

                    case TouchPhase.Ended:

                        float touchDeltaY = touch.position.y - touchStartPos.y;
                        float tapThreshold = Screen.height * 0.05f;

                        if (Mathf.Abs(touchDeltaY) < tapThreshold)
                        {
                            if (!isJumping && !isColliding)
                            {
                                isJumping = true;
                                playerObject.GetComponent<Animator>().Play("Jump");
                                StartCoroutine(JumpSequence());
                            }
                        }
                        break;
                }
            }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            isColliding = true;


            if (isJumping)
            {
                playerObject.GetComponent<Animator>().Play("Backward");
                playerObject.GetComponent<Animator>().StopPlayback();
            }
        }
    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            isColliding = false;
        }
    }
}
