using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    
    public abstract class GameObject : IdentifiableObject
    {
        private string _description;
        private string _name;

       
        public GameObject(string[] ids, string name, string description) : base(ids)
        {
            _name = name;
            _description = description;
        }

        
        public string Name
        {
            get { return _name; }
        }

       
        public string ShortDescription
        {
            get { return _description; }
        }

        public virtual string GetFullDescription()
        { return $"{_name}: {_description}"; }
    }
}
