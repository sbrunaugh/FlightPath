namespace Assets.Scripts.Models
{
    internal class DiscOrientation
    {
        // Hyzer angle (-90f for absolutely vertical hyzer, +90f for vertical anhyzer)
        internal float DiscRoll { get; set; }
        // Nose Angle (-90f for absolutely vertical node down, +90f for vertical nose up)
        internal float DiscPitch { get; set; }
    }
}
