using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverPortApp
{
    class Roadstead: IVessel
    {
        private Queue<Vessel> queue = new Queue<Vessel>();

        public Vessel getVessel()
        {
            throw new NotImplementedException();
        }

        public void pushVessel(Vessel vessel)
        {
            queue.Enqueue(vessel);
        }

        public void popVessel(Vessel vessel)
        {
            queue.Dequeue();
        }

        public Vessel getPeekVessel()
        {
            return queue.Peek();
        }
    }
}
