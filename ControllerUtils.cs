using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiverPortApp
{
    class ControllerUtils
    {
        public static bool checkFillFields(TextBox a1,
                                       TextBox a2,
                                       TextBox a3,
                                       TextBox a4,
                                       TextBox a5,
                                       TextBox a6,
                                       TextBox a7)
        {
            return a1.Text.Length > 0 &&
                   a2.Text.Length > 0 &&
                   a3.Text.Length > 0 &&
                   a4.Text.Length > 0 &&
                   a5.Text.Length > 0 &&
                   a6.Text.Length > 0 &&
                   a7.Text.Length > 0;
        }
    }
}
