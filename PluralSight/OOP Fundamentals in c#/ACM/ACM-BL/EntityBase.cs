using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM_BL
{

    public enum EntityStateOption
    {
        Active,
        Deleted
    }

    //abstract class cant be inherited from
    public abstract class EntityBase
    {

        public EntityStateOption EntityState { get; set; }

        public bool IsNew { get; private set; }

        public bool HasChanges { get; set; }

        public bool IsValid => Validate();

        //abstract method has no implementation and MUST be implemented in the inherited class
        //must be defined in abstract class
        public abstract bool Validate();
        

    }
}
