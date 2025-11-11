using System;
using System.Security.Cryptography.X509Certificates;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType)
        {
            return (swallowType == SwallowType.African) ? new AfricanSwallow() : new EuropeanSwallow();
        }
    }

    public class AfricanSwallow : Swallow
    {
        public AfricanSwallow(): base(SwallowType.African)
        {
            base.AirspeedVelocity = 22;
        }

        public override void ApplyLoad(SwallowLoad load)
        {
            Load = load;

            base.AirspeedVelocity = (Load == SwallowLoad.Coconut) ? 18 : 22;

        }
        
    }

    public class EuropeanSwallow : Swallow
    {
        public EuropeanSwallow() : base(SwallowType.European)
        {
            base.AirspeedVelocity = 20;
        }

        public override void ApplyLoad(SwallowLoad load)
        {
            Load = load;

            AirspeedVelocity = (Load == SwallowLoad.Coconut) ? 16 : 20;

        }

    }

    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; protected set; }
        
        public int AirspeedVelocity { get; set; }
        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
            Load = SwallowLoad.None;
            AirspeedVelocity = 0;
        }
        public virtual void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            return AirspeedVelocity;
        }
    }
}