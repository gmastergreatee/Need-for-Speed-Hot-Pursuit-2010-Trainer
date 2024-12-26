using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Core.Models.Cheats
{
    public abstract class Cheat : ICheat
    {
        public bool Enabled { get; set; } = false;

        public required string Name { get; set; }

        public abstract bool InitializeCheat();

        public abstract bool ApplyCheat();
    }
}
