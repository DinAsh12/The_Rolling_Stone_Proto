using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform player;
        public void Update()
        {
            this.transform.position = new Vector3(player.position.x, player.position.y, -10);
        }
    }
}
