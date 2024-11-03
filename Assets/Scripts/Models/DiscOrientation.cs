namespace Assets.Scripts.Models
{
    public class DiscOrientation
    {
        // Hyzer angle (-90f for absolutely vertical hyzer, +90f for vertical anhyzer)
        public float DiscRoll { get; set; }
        // Nose Angle (-90f for absolutely vertical node down, +90f for vertical nose up)
        public float DiscPitch { get; set; }
    }
}
