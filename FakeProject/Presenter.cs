using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeProject
{
    class Presenter
    {
        private WorkerClass _worker;
        private IMessager _messager;
        public Presenter(WorkerClass worker, IMessager messager)
        {
            this._worker = worker;
            this._messager = messager;

            this._worker.OnWorkDoneHandler += this._messager.WorKDoneHandler;
            this._worker.WorkDone += this._messager.WorKDoneHandler;
        }
        public void present()
        {
            _worker.DoWork();
        }
    }
}
