using System;

namespace LifeOfAnts_v2
{
    public abstract class Ant
    {
        public abstract char Symbol
        {
            get;
        }

        public abstract Position Coordinates
        {
            get;
            set;
        }

        public virtual void Move()
        {
        }

        protected virtual void Act()
        {
        }
    }
}