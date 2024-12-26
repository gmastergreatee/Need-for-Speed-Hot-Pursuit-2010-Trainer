using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Core.Models
{
    public interface ICheat
    {
        string Name { get; set; }
        bool InitializeCheat(Memory memory);
        bool ApplyCheat();
    }
}
