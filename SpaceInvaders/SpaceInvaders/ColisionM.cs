using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{

    class ColisionM
    {
        List<Alien> al;
        List<Bullet> bul;

        public ColisionM(List<Alien> aliens,List<Bullet> bullet)
        {
            al = aliens;
            bul = bullet;
        }
        public void colision()
        {
            foreach(Bullet b in bul.ToArray())
            {
                foreach(Alien a in al.ToArray())
                {
                    if (b.colisao(a.gethitbox()))
                    {
                        bul.Remove(b);
                        al.Remove(a);
                    }

                }
            }
        }
    }
}
