using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeInputs : MonoBehaviour
{
    private bool isTouching;
    private Vector2 startTouch, swipeDist;

    public Camera cam;
    public bool check;
    public Vector3 checkVector;

    void Update()
    {
        #region Mouse
        if (Input.GetMouseButtonDown(0))
        {
            isTouching = true;
            startTouch = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isTouching = false;
            Reset();

        }
        #endregion

        #region Phone
        if(Input.touches.Length != 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                isTouching = true;
                startTouch = Input.touches[0].position;
            }else if(Input.touches[0].phase == TouchPhase.Canceled || Input.touches[0].phase == TouchPhase.Ended)
            {
                Reset();
                isTouching = false;
            }
        }

        #endregion

        if (isTouching)
        {
            if (Input.GetMouseButton(0))
            {
                swipeDist = (Vector2)Input.mousePosition - startTouch;
            }
            if (Input.touches.Length > 0) swipeDist = Input.touches[0].position - startTouch;
        }

        if (swipeDist.magnitude > 120)
        {
            check = true;
            if(cam.camPos=="straight")  checkVector = new Vector3(swipeDist.x, swipeDist.y * 3, swipeDist.y);
            else if(cam.camPos == "rightside")
            {
                checkVector = Quaternion.Euler(0, -36.7f, 0)*new Vector3(swipeDist.x, swipeDist.y * 3, swipeDist.y);

            }
            else
            {
                checkVector = Quaternion.Euler(0, 36.7f, 0)*new Vector3(swipeDist.x, swipeDist.y * 3, swipeDist.y);
            }
        }

    }

    private void Reset()
    {
        startTouch = swipeDist = Vector2.zero;
        check = false;
        checkVector = Vector3.zero;
    }
}