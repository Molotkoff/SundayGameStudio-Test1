using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Test1App
{
    public class MainWindow : MonoBehaviour, IWindow
    {
        public void Show() {}

        public void Hide() {}

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Menu) || Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}