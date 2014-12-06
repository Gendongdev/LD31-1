using UnityEngine;
using System.Collections;

namespace GMnameSpace
{
    public class CheckPoint
    {
        public int CheckPointNum { get; set; }
        public Vector3 PlayerPosition { get; set; }
        public Vector3 PrizePosition { get; set; }

        public CheckPoint()
        {
            CheckPointNum = 0;
        }
        public void nextCheckPoint()
        {
            PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            CheckPointNum++;
        }
    }


    



}
