using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowTopMostController.Models
{
    public class WindowInfo
    {
        public IntPtr Handle { get; set; }
        public string Title { get; set; }
        
        public WindowInfo(IntPtr handle, string title)
        {
            Handle = handle;
            Title = title;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
