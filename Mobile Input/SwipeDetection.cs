using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;

    [SerializeField]
    private float minimumDistance = .2f;
    [SerializeField]
    private float maximumTIme = 1f;
    [SerializeField]
    private float directionThreshhold = .9f;

    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;

    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if(Vector3.Distance(startPosition, endPosition)>= minimumDistance && (endTime - startTime) <= maximumTIme)
        {
            Debug.DrawLine(startPosition, endPosition, Color.red,5f);
            Vector3 direction = endPosition - startPosition; 
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if(Vector2.Dot(Vector2.up, direction) > directionThreshhold)
        {
            Debug.Log("swipe up");
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshhold)
        {
            Debug.Log("swipe down");
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshhold)
        {
            Debug.Log("swipe left");
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshhold)
        {
            Debug.Log("swipe right");
        }
    }
}
