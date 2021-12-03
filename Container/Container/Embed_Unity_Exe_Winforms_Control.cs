using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
//using LVD.CSSystemLib;

namespace Container
{
    public partial class LVD_Steelplying_Embed_Unity_Exe_Winforms_Control : Form, IDisposable
    {
        #region Fields

        private Process movProcess;
        private IntPtr unityHWND = IntPtr.Zero;

        private const int WM_ACTIVATE = 0x0006;
        private readonly IntPtr WA_ACTIVE = new IntPtr(1);
        private readonly IntPtr WA_INACTIVE = new IntPtr(0);


        private const int WM_CLOSE = 0x10;

        private const string UNITY_EXE_NAME = "Project Manus";
        private const string EMBEDD_EXE_NAME = "Container";

        #endregion Fields

        #region Properties

        [DllImport("User32.dll")]
        private static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool redraw);

        internal delegate int WindowEnumProc(IntPtr hwnd, IntPtr lparam);

        [DllImport("user32.dll")]
        internal static extern bool EnumChildWindows(IntPtr hwnd, WindowEnumProc func, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int SetParent(IntPtr hWnd, IntPtr hWndNewParent);


        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, long dwNewLong);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);


        #endregion Properties

        #region Constructors

        public LVD_Steelplying_Embed_Unity_Exe_Winforms_Control()
        {
            InitializeComponent();

            TopLevel = false;

            try
            {
                movProcess = new Process();
                movProcess.StartInfo.FileName = $"{UNITY_EXE_NAME}.exe";
                movProcess.StartInfo.Arguments = "-parentHWND " + panel1.Handle.ToInt32();
                movProcess.StartInfo.UseShellExecute = true;
                movProcess.StartInfo.CreateNoWindow = true;
                movProcess.Start();

                movProcess.WaitForInputIdle();
                EnumChildWindows(panel1.Handle, WindowEnum, IntPtr.Zero);

                //unityHWND =movProcess.MainWindowHandle;

                unityHWNDLabel.Text = "Unity HWND: 0x" + unityHWND.ToString("X8");
            }
            catch (Exception lovException)
            {
                MessageBox.Show(lovException.Message + $".\nCheck if {EMBEDD_EXE_NAME}.exe is placed next to {UNITY_EXE_NAME}.exe.");
            }
        }

        #endregion Constructors

        #region Methods

        public void ActivateUnityWindow()
        {
            //Removed Win.32
            SendMessage(unityHWND, WM_ACTIVATE, WA_ACTIVE, IntPtr.Zero);
            SetForegroundWindow(unityHWND);

        }

        private void DeactivateUnityWindow()
        {

            SendMessage(unityHWND, WM_ACTIVATE, WA_INACTIVE, IntPtr.Zero);


        }

        private int WindowEnum(IntPtr hwnd, IntPtr lparam)
        {
            unityHWND = hwnd;
            ActivateUnityWindow();
            return 0;
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            MoveWindow(unityHWND, 0, 0, panel1.Width, panel1.Height, true);
            ActivateUnityWindow();
        }

        protected override void OnClosing(CancelEventArgs e)
        {

            /*
            CSWin32.SetParent(unityHWND, IntPtr.Zero);
            CSWin32.SetWindowLong(unityHWND, CSWin32.GWL_STYLE, CSWin32.WS_VISIBLE);
            CSWin32.MoveWindow(unityHWND, 0, 0, 800, 600, true);
            CSWin32.SetForegroundWindow(unityHWND);
            CSWin32.ShowWindow(unityHWND, 2);
            Thread.Sleep(100);

            CSWin32.PostMessage(unityHWND, CSWin32.WM_CLOSE, 0, 0);
            */


            //Work in progress
            //SetParent(unityHWND, IntPtr.Zero);
            //SetForegroundWindow(unityHWND);
            //ShowWindow(unityHWND, 2);
            //Thread.Sleep(100);

            //PostMessage(unityHWND, WM_CLOSE, WA_INACTIVE, IntPtr.Zero);


            base.OnClosing(e);
        }
       

        #endregion Methods

        #region Event Handlers

        // Close Unity application
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                movProcess.CloseMainWindow();

                Thread.Sleep(1000);
                while (movProcess.HasExited == false)
                    movProcess.Kill();
            }
            catch (Exception)
            {
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            ActivateUnityWindow();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            DeactivateUnityWindow();
        }

        #endregion Event Handlers
    }
}