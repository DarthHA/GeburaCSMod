

namespace GeburaCSMod.Structure
{
    public struct Animinator
    {
        public float LocalAI1;
        public float LocalAI2;
        public float Timer;
        public float MaxTime;
        public bool IsEnd()
        {
            return Timer >= MaxTime;
        }
    }
}