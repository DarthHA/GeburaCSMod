using Microsoft.Xna.Framework;
using Terraria;

namespace GeburaCSMod
{
    public static class DrawUtils
    {
        public static float MirrorAngle(float r)
        {
            Vector2 vec = r.ToRotationVector2();
            vec.X = -vec.X;
            return vec.ToRotation();
        }
    }
}