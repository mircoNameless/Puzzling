using System;
using UnityEngine;

namespace Common
{
    public class LoadingPage : MonoBehaviour
    {
        public delegate void SceneEvent();
        public SceneEvent sceneOpenEvent;
        public SceneEvent sceneCloseEvent;
        public void LoadingCloseGo()
        {
            sceneCloseEvent?.Invoke();
        }
        public void LoadingOpenGo()
        {
            sceneOpenEvent?.Invoke();
        }
    }
}
