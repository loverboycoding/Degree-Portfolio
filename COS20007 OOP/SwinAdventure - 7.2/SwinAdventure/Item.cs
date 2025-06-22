using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Item : GameObject
    {
        public Item(string[] idents, string name, string GetFullDescription) : base(idents, name, GetFullDescription) { }
        public override string GetFullDescription()
        {
          { return base.GetFullDescription(); } 
        }
    }
}
