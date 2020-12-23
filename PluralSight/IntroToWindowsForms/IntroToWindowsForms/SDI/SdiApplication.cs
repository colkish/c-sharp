using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.ApplicationServices;
using MDI;

namespace SDI
{
    public class SdiApplication : WindowsFormsApplicationBase
    {
        private static SdiApplication _instance = null;

        public SdiApplication()
        {
            this.IsSingleInstance = true;
            this.ShutdownStyle = ShutdownMode.AfterAllFormsClose;
        }

        public static SdiApplication Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new SdiApplication();
                }

                return _instance;

            }

        }

        protected override void OnCreateMainForm()
        {
            docForm.CreateForm();
        }

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            docForm.CreateForm();
        }

    }
}
