using UnityEngine;
using System.Collections;

namespace GMnameSpace
{
    public class CheckPoint
    {
        public int CheckPointNum { get; set; }
        public Vector3 PlayerPosition { get; set; }

        public CheckPoint()
        {
            CheckPointNum = -1;
        }
        public void nextCheckPoint()
        {
            PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            CheckPointNum++;
        }
    } 
}
