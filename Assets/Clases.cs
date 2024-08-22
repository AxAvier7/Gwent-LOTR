using UnityEngine;

public class Clases : MonoBehaviour
{
    public class BaseCard
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Turn { get; set; }
        public string Faction { get; set; }
    }

    public class LeaderCard : BaseCard { }

    public class ClimateNUnitsCards : BaseCard
    {
        public string Fringe { get; set; }
        public bool SauronSurrendered { get; set; }
        public bool AragornSurrendered { get; set; }
        public bool AlreadyPlayed { get; set; }
    }

    public class ClimateCard : ClimateNUnitsCards
    {
        public string AffectedFringe { get; set; }
    }

    public class Unit : ClimateNUnitsCards
    {
        public int Power { get; set; }
        public int OriginalPower { get; set; }
        public string Rank { get; set; }
        public bool IsClimateAffected { get; set; }
        public bool IsPUAffected { get; set; }
    }

    public interface ISkill
    {
        void Skill();
    }
}