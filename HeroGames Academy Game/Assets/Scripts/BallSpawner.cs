using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour
{
    public Camera cam;
    public Score score;

    ObjectPooler objectPooler;

    Vector3 camPos;

    public bool isShooted, _isShooted;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        camPos = cam.CamPos;
        isShooted = true;
        StartCoroutine(Spawner());        
    }

    void Update()
    {
        if (cam.camPos != "straight")
        {
            camPos = cam.CamPos;
        }

        if (Ball.isShooted)
        {
            isShooted = true;
        }
            

        if(specialBall.isShooted && score.specialBallCount >= 0)
        {
            isShooted = true;
            if (score.specialBallCount == 0)
            {
                score.specialBallCount--;
            }
        }

    }

    IEnumerator Spawner()
    {
        while (score.ballCounter != 0)
        {
            yield return new WaitForSeconds(.1f);

            if(LevelEnd.level ==3 || LevelEnd.level == 7)
            {
                if (isShooted && LevelEnd.isStarted && score.specialBallCount >= 0)
                {
                    yield return new WaitForSeconds(1.5f);
                    objectPooler.SpawnObject("specialBall", cam.BallPos, Quaternion.identity);
                    isShooted = false;
                    
                }
                else if (isShooted && LevelEnd.isStarted && score.ballCounter != 0)
                {
                    yield return new WaitForSeconds(1.5f);
                    objectPooler.SpawnObject("ball", cam.BallPos, Quaternion.identity);
                    isShooted = false;
                }

            }

            else if(isShooted && LevelEnd.isStarted && score.ballCounter != 0)
            {
              	 yield return new WaitForSeconds(1.5f);
              	 objectPooler.SpawnObject("ball", cam.BallPos, Quaternion.identity);
              	 isShooted = false;
            }


        }
    }
}