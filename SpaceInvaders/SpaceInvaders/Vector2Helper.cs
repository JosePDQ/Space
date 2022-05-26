using Microsoft.Xna.Framework;

namespace SpaceInvaders
{
    public static class Vector2Helper
    {
        public static float Pos(this Vector2 a, int i)
        {
            return i == 0 ? a.X : a.Y;
        }
    }
}
