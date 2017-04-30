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
        const float bulletVelocity = 0.8F;
        Vector2 direction;
        int timeToLive;
        public bool isProjectileDead { get; set; }
        public CharacterEntityShootableProjectile(Vector2 bulletStartPos, Vector2 mousePos,Texture2D projectile)
        {
            this.bulletStartPos = new Vector2(960, 540);
            this.mousePos = mousePos;
            this.projectile = projectile;
            this.bulletPosition = bulletStartPos;
            direction = this.mousePos - this.bulletStartPos;
            if (direction != Vector2.Zero) 
                direction.Normalize();

            isProjectileDead = false;
        }
        public void Update(GameTime gameTime)
        {

            bulletPosition += direction * bulletVelocity*(float)gameTime.ElapsedGameTime.Milliseconds; // multiply by delta seconds to keep a consistent speed on all computers
            timeToLive += 16;
            if(timeToLive > 1600)
            {
                isProjectileDead = true;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(projectile, bulletPosition, Color.White);
        }

        public void Collision(Tile tile)
        {
            Rectangle newRectangle = tile.CollisionRectangle;
            Rectangle rect = new Rectangle(projectile.Height, pro;

            if (rect.TouchTopOf(newRectangle))
            {
                Y = newRectangle.Top - rect.Height;
            }

            if (rect.TouchBottomOf(newRectangle))
            {
                Y = newRectangle.Bottom + 2;
            }

            if (rect.TouchRightOf(newRectangle))
            {
                X = newRectangle.Right + 2;
            }
            if (rect.TouchLeftOf(newRectangle))
            {
                X = newRectangle.Left - rect.Width;
            }
        }
    }
}
