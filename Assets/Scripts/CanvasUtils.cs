using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class CanvasUtils
    {
        public static void EnableCanvas(GameObject canvas)
        {
            if(canvas!=null)
            {
                canvas.GetComponent<Canvas>().enabled = true;
            }
            
        }
        public static void DisableCanvas(GameObject canvas)
        {            
            if (canvas!=null)
            {
                canvas.GetComponent<Canvas>().enabled = false;
            }            
        }
    }
}
