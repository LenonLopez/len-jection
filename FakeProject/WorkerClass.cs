using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeProject
{
    public class WorkerClass
    {
        private IHelper _helper;
        public delegate void OnWorkDonehandlerDelegate(object source, EventArgs args);
        public event OnWorkDonehandlerDelegate WorkDone;
        public event EventHandler OnWorkDoneHandler;
        public WorkerClass(IHelper helper)
        {
            _helper = helper;
        }

        public void DoWork()
        {

            _helper.help("work");
            OnWorkDone();
        }

        private void OnWorkDone()
        {
            //if (OnWorkDoneHandler != null)
            //    OnWorkDoneHandler(this, EventArgs.Empty);
            if (WorkDone != null)
                WorkDone(this, EventArgs.Empty);

            OnWorkDoneHandler?.Invoke(this, EventArgs.Empty);
        }
    }
}
