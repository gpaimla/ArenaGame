using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ArenaGame
{
    public class CharacterEntityShootableProjectile
    {
        Vector2 bulletStartPos;
        Vector2 mousePos;
        Vector2 bulletPosition;
        Texture2D projectile;
        const float bulletVelocity = 1.0F;
        Vector2 direction;
        public CharacterEntityShootableProjectile(Vector2 bulletStartPos, Vector2 mousePos,Texture2D projectile)
        {
            this.bulletStartPos = new Vector2(820, 590);
            this.mousePos = mousePos;
            this.projectile = projectile;
            bulletPosition = bulletStartPos;
            direction = mousePos - this.bulletStartPos;
            if (direction != Vector2.Zero) 
                direction.Normalize();


        }
        public void Update(GameTime gameTime)
        {

            bulletPosition += direction * bulletVelocity; // multiply by delta seconds to keep a consistent speed on all computers

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(projectile, bulletPosition, Color.White);
        }
    }
}
