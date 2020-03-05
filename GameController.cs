using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform playerTransform;
    private Camera cam;
    
    public Transform limit_Left, limit_Right, limit_Top, limit_Bot;
    public float speedCam;

    void CamController()
    {
        float posCamX = playerTransform.position.x;
        float posCamY = playerTransform.position.y;

        if (cam.transform.position.x < limit_Left.position.x && playerTransform.position.x < limit_Left.position.x)
        {
            posCamX = limit_Left.position.x;
        }
        else if (cam.transform.position.x > limit_Right.position.x && playerTransform.position.x > limit_Right.position.x)
        {
            posCamX = limit_Right.position.x;
        }
        if (cam.transform.position.y < limit_Bot.position.y && playerTransform.position.y < limit_Bot.position.y)
        {
            posCamY = limit_Bot.position.y;
        }
        else if (cam.transform.position.y > limit_Top.position.y && playerTransform.position.y > limit_Top.position.y)
        {
            posCamY = limit_Top.position.y;
        }

        Vector3 posCam = new Vector3(posCamX, posCamY, cam.transform.position.z);

        cam.transform.position = Vector3.Lerp(cam.transform.position, posCam, speedCam * Time.deltaTime);

    }


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        CamController();    
    }

    
}
