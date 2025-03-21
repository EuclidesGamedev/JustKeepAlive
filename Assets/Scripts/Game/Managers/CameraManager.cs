using UnityEngine;

namespace Game.Managers
{
    public class CameraManager : MonoBehaviour
    {
        private void Awake()
        {
            GameManager.CameraManager = this;
        }
    }
}
