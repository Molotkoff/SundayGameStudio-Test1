using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molotkoff.Test1App
{
    public class ContentURLFactory
    {
        private string url;

        private int maxImageCount;
        private int imageIndex;

        public ContentURLFactory(string url)
        {
            this.url = url;
            this.maxImageCount = 64;
            this.imageIndex = 0;
        }

        public string Create()
        {
            return ++imageIndex <= maxImageCount ? url + imageIndex + ".jpg"
                                                 : string.Empty;
        }
    }
}