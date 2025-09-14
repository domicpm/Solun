using UnityEngine;

public class JumpTouch : MonoBehaviour
{
    public float doubleTapMaxDelay = 0.3f; // maximal erlaubte Zeit zwischen zwei Taps
    private float lastTapTime = 0;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (Time.time - lastTapTime < doubleTapMaxDelay)
                {
                    // Doppel-Tap erkannt!
                    Debug.Log("Double Tap!");
                }

                lastTapTime = Time.time;
            }
        }
    }
}
