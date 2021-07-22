using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Ball ball;
    public GameObject cam, ballGround;
    public string camPos = "straight";
    public LevelEnd level;
    public Vector3 rightSide, leftSide, CamPos, BallPos, BallEulerAngles;

    void Start()
    {
        rightSide = new Vector3(5.4f + LevelEnd.level * 0.6f, 0, 1.8f + LevelEnd.level * 0.2f);
        leftSide = new Vector3(-(5.4f + LevelEnd.level * 0.6f), 0, 1.8f + LevelEnd.level * 0.2f);
        CamPos = new Vector3(0, 0, 0);
        BallPos = new Vector3(0, -1f, 2.5f);
    }

    public void MoveCamera()
    {
        if (Ball.isShooted || specialBall.isShooted)
        {
            if (camPos == "straight")
            {
                //each level camPos.x increases by 0.6 and camPos.y increases by 0.2 to maintain same distance
                cam.transform.position = CamPos = rightSide;

                BallPos = new Vector3(CamPos.x - 1.5f, -1f, CamPos.z + 2f);

                ballGround.transform.position = new Vector3(CamPos.x-1.5f, 0, CamPos.z+2f);
                ballGround.transform.eulerAngles = new Vector3(0, -36.87f, 0);

                camPos = "rightside";
                cam.transform.eulerAngles = new Vector3(0, -36.87f, 0);
                return;
            }

            if (camPos == "leftside")
            {
                //each level camPos.x increases by 0.6 and camPos.y increases by 0.2 to maintain same distance
                cam.transform.position = CamPos = Vector3.zero;

                BallPos = new Vector3(0, -1f, 2.5f);

                ballGround.transform.position = new Vector3(0,0,2.5f);
                ballGround.transform.eulerAngles = Vector3.zero;

                camPos = "straight";
                cam.transform.eulerAngles = Vector3.zero;
                return;
            }

            if (camPos == "rightside")
            {
                //each level camPos.x increases by 0.6 and camPos.y increases by 0.2 to maintain same distance
                cam.transform.position = CamPos = leftSide;

                BallPos = new Vector3(CamPos.x + 1.5f, -1f, CamPos.z + 2f);
               
                ballGround.transform.position = new Vector3(CamPos.x + 1.5f, 0, CamPos.z + 2f);
                ballGround.transform.eulerAngles = new Vector3(0, 36.87f, 0);

                camPos = "leftside";
                cam.transform.eulerAngles = new Vector3(0, 36.87f, 0);
                return;
            }
        }

    }
}
