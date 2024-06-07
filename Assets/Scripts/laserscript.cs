using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using UnityEngine;

public class laserscript : MonoBehaviour
{
    public LayerMask layerMask,player;
     int noOfReflections = 2;
    private LineRenderer lineRenderer;
    private Ray ray;
    private RaycastHit hit;
    public Transform startPoint;

    private Vector3 direction;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = noOfReflections + 1;
    }

    void Update()
    {
        ReflectLaser();
    }

    void ReflectLaser()
    {
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, startPoint.position);
        Debug.Log("Start Point: " + startPoint.position);

        Ray ray = new Ray(startPoint.position, startPoint.forward);
        RaycastHit hit;

        for (int i = 0; i < noOfReflections; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 50,layerMask))
            {
                
                    lineRenderer.positionCount += 1;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
                    Debug.Log("Hit Point: " + hit.point);

               

                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                    Debug.Log($"Reflected Direction {i}: {ray.direction}");
                
               
            }
            else if (Physics.Raycast(ray.origin,ray.direction,out hit,50,player))
            {
                GameManager.instance.ShowLosePanel(); // Call the method to show the lose panel
                break;
            }
            else
            {
                lineRenderer.positionCount += 1;
                Vector3 endPosition = ray.origin + ray.direction * 50;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, endPosition);
                Debug.Log("End Point: " + endPosition);
                break;
            }
        }
        lineRenderer.enabled = true;
    }
   

}
