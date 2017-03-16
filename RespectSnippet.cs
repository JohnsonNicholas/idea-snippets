namespace RespectProject
{
    public class Respect
    {
        /// <summary>
        /// This contains a value from 0 - 2, and is a percetnage value
        /// </summary>
        public double Trust { get; private set; }

        /// <summary>
        /// Determins effort multiplier
        /// </summary>
        private double EffortRewards { get; set; }

        /// <summary>
        /// Determins the death chance
        /// </summary>
        private double DeathChance { get; set; }


        /// <summary>
        /// Default Constructor, for a generic officer
        /// </summary>
        public Respect()
        {
            Trust = .65;
            EffortRewards = .8;
            DeathChance = .1;
        }

        /// <summary>
        /// This alters the Trust value within limits.
        /// </summary>
        /// <param name="chgValue">The amount to alter the Truth</param>
        public void ChangeTrust(double chgValue)
        {
            if (Trust + chgValue > 2)
                Trust = 2;
            else if (Trust + chgValue < 0)
                Trust = 0;
            else
                Trust += chgValue;
        }

        /// <summary>
        /// Paramaterized constructor
        /// </summary>
        /// <param name="trust">starting trust value</param>
        /// <param name="effort">starting effort reward</param>
        /// <param name="death">the death chance</param>
        public Respect(double trust, double effort, double death)
        {
            Trust = trust;
            EffortRewards = effort;
            DeathChance = death;
        }

        /// <summary>
        /// This will return the effort rewards. 
        /// </summary>
        /// <returns>The current effective effort reward</returns>
        public double GetEffortRewards()
        {
            double value = 0.05;
            //General rule, if the set value is over the generated one, 
            // return the set value

            if (Trust <= .25)
                value = (EffortRewards > .3) ? EffortRewards : .3;
            if (Trust > .25 && Trust <= .5)
                value = (EffortRewards > .6) ? EffortRewards : .6;
            if (Trust > .5 && Trust <= .75)
                value = (EffortRewards > .8) ? EffortRewards : .8;
            if (Trust > .75 && Trust <= .85)
                value = (EffortRewards > 1) ? EffortRewards : 1;
            if (Trust > .85 && Trust <= .92)
                value = (EffortRewards > 1.2) ? EffortRewards : 1.2;
            if (Trust > .92 && Trust <= 1)
                value = (EffortRewards > 1.3) ? EffortRewards : 1.3;
            if (Trust > 1)
                value = 1.3 + ((Trust - 1) * 1.05);

            return value;
        }

        /// <summary>
        /// This will get the chance of failure.
        /// </summary>
        /// <returns>The chance of failure</returns>
        public double GetFailureChance()
        {
            if (Trust > 1)
                return 0.0001; //.01% chance minimum.
            else if (Trust > .8 && Trust <= 1)
                return 0.05; //5% chance
            else if (Trust > .6 && Trust <= .8)
                return 0.15; //15% chance
            else if (Trust > .4 && Trust <= .6)
                return 0.30; //30% chance
            else if (Trust > .2 && Trust <= .4)
                return .5; //50% chance
            else if (Trust > 0)
                return .75; //75 Chance
            else if (Trust == 0)
                return .945; //94.5% chance. 

            return .945;
        }
    }
}
