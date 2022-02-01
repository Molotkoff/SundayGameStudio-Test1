using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Test1App
{
    public class ToFilterWindow : MonoBehaviour
    {
        [SerializeField]
        private FilterImagesWindow filterWindow;
        [SerializeField]
        private ImageViewerWindow viewerWindow;
        
        public void ToFilter()
        {
            viewerWindow.Hide();
            filterWindow.Show();
        }
    }
}