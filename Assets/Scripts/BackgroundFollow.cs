using System;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
   public Transform[] backgrounds;
   public Transform middleBackground;
   public Transform currentBackground;

   private Camera cam;
   public float TOLERANCE = 2f;
   public float offset = 29.911f;

   private void Start()
   {
  
      cam = Camera.main;
   }


   private void Update()
   {
      SetBackground();
   }
   
   

   private void SetBackground()
   {
      if (currentBackground != null)
      {
         currentBackground.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 10f);
      }
      else
      {
         foreach (var t in backgrounds)
         {
            if (Math.Abs(cam.transform.position.x - t.position.x) < TOLERANCE)
            {
               currentBackground = t;
            }
         }
      }

      if (currentBackground == null) return;
   
      if (cam.transform.position.x < middleBackground.position.x)
      {
         if (Math.Abs(cam.transform.position.x - (middleBackground.position.x - offset)) < TOLERANCE) //|| Math.Abs(cam.transform.position.x - (middleBackground.position.x + offset)) < TOLERANCE)
         {
            currentBackground = null;
         }
      }
      else if (cam.transform.position.x > middleBackground.position.x)
      {
         if (Math.Abs(cam.transform.position.x - (middleBackground.position.x - offset)) < TOLERANCE) //|| Math.Abs(cam.transform.position.x - (middleBackground.position.x + offset)) < TOLERANCE)
         {
            currentBackground = null;
         }
      }
   }
}


/*


   /*
   *
   * if (currentBackground == null) return;
   
   if (cam.transform.position.x < middleBackground.position.x)
   {
   if (Math.Abs(cam.transform.position.x - (middleBackground.position.x + offset)) < TOLERANCE) //|| Math.Abs(cam.transform.position.x - (middleBackground.position.x + offset)) < TOLERANCE)
   {
   currentBackground = null;
   
   }
   }
   else if (cam.transform.position.x > middleBackground.position.x)
   {
   if (Math.Abs(cam.transform.position.x - (middleBackground.position.x - offset)) < TOLERANCE) //|| Math.Abs(cam.transform.position.x - (middleBackground.position.x + offset)) < TOLERANCE)
   {
   currentBackground = null;
   }
   }
   * / 
 if (currentBackground == backgrounds[0])
   {
   if (Math.Abs(cam.transform.position.x - (middleBackground.position.x - offset)) <TOLERANCE) //|| Math.Abs(cam.transform.position.x - (middleBackground.position.x + offset)) < TOLERANCE)
   {
   currentBackground = null;
   }
   }
   else if (currentBackground == backgrounds[1])
   {
   if (Math.Abs(cam.transform.position.x - (middleBackground.position.x + offset)) < TOLERANCE) //|| Math.Abs(cam.transform.position.x - (middleBackground.position.x + offset)) < TOLERANCE)
   {
   currentBackground = null;
   }
   }
 
using System;
   using UnityEngine;
   
   public class BackgroundFollow : MonoBehaviour
   {
   public Transform[] backgrounds;
   public Transform middleBackground;
   public Transform currentBackground;
   
   public Vector2[] startPosition;
   
   private Camera cam;
   public float TOLERANCE = 0.1f;
   public float offset = 29.911f;
   
   private void Start()
   {
   for (int i = 0; i < backgrounds.Length-1; i++)
   {
   startPosition[i] = backgrounds[i].position;
   }
   cam = Camera.main;
   }
   
   
   private void Update()
   {
   SetBackground();
   }
   
   
   
   private void SetBackground()
   {
   if (currentBackground != null)
   {
   currentBackground.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 10f);
   }
   else
   {
   foreach (var t in backgrounds)
   {
   if (Math.Abs(cam.transform.position.x - t.position.x) < TOLERANCE)
   {
   currentBackground = t;
   }
   }
   }
   
   if (currentBackground == null) return;
   
   if (currentBackground == backgrounds[0])
   {
   if (Math.Abs(cam.transform.position.x - (middleBackground.position.x - offset)) < TOLERANCE) //|| Math.Abs(cam.transform.position.x - (middleBackground.position.x + offset)) < TOLERANCE)
   {
   currentBackground = null;
   }
   }
   else if (currentBackground == backgrounds[1])
   {
   if (Math.Abs(cam.transform.position.x - (middleBackground.position.x - offset)) < TOLERANCE) //|| Math.Abs(cam.transform.position.x - (middleBackground.position.x + offset)) < TOLERANCE)
   {
   currentBackground = null;
   }
   }
   }
   }
   
   
   
if (Math.Abs(cam.transform.position.x - (middleBackground.position.x - offset)) < TOLERANCE || Math.Abs(cam.transform.position.x - (middleBackground.position.x + offset)) < TOLERANCE)
{
   currentBackground = null;
}
*/