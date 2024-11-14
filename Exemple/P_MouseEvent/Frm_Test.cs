using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P_MouseEvent
{
    public partial class Frm_Test : Form
    {
        private GlobalMouseHook _mouseHook;
        public Frm_Test()
        {
            InitializeComponent();
            _mouseHook = new GlobalMouseHook();
            _mouseHook.GlobalMouseClick += MouseHook_GlobalMouseClick;
        }
        private void MouseHook_GlobalMouseClick(string button, Point position)
        {
            Console.WriteLine(_mouseHook.IsKeepingLeftDown() && _mouseHook.IsKeepingRightDown() ? "Left and right" : $"only {button}");
            lblBtn.Text = button + " at " + position.X + " " + position.Y;
        }

        ~Frm_Test()
        {
            _mouseHook.Unhook(); // Unhook to release resources when the form is closing
        }
    }
}
