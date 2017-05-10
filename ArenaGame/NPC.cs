using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    class NPC
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;
        public Rectangle npcBounds;

        public bool isVisible = true;
        public bool isMoving;

        Random random = new Random();
        int randX, randY, randM;


        Animation walkDown;
        Animation walkUp;
        Animation walkLeft;
        Animation walkRight;

        Animation standDown;
        Animation standUp;
        Animation standLeft;
        Animation standRight;

        Animation currentAnimation;
        private int timeToMove;
        private int moveTime;
        private int timeMoving;
        private Vector2 prevVelocity;
        private Vector2 initialVelocity;
        private int moveCount;

        private void initAnimations()
        {
            walkDown = new Animation();
            walkDown.AddFrame(new Rectangle(0, 324, 64, 64), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(64, 324, 64, 64), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(0, 324, 64, 64), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(128, 324, 64, 64), TimeSpan.FromSeconds(.25));

            walkUp = new Animation();
            walkUp.AddFrame(new Rectangle(576, 324, 64, 64), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(640, 324, 64, 64), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(576, 324, 64, 64), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(704, 324, 64, 64), TimeSpan.FromSeconds(.25));

            walkLeft = new Animation();
            walkLeft.AddFrame(new Rectangle(192, 324, 64, 64), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(256, 324, 64, 64), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(192, 324, 64, 64), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(320, 324, 64, 64), TimeSpan.FromSeconds(.25));

            walkRight = new Animation();
            walkRight.AddFrame(new Rectangle(384, 324, 64, 64), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(448, 324, 64, 64), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(384, 324, 64, 64), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(512, 324, 64, 64), TimeSpan.FromSeconds(.25));

            // Standing animations only have a single frame of animation:
            standDown = new Animation();
            standDown.AddFrame(new Rectangle(0, 324, 64, 64), TimeSpan.FromSeconds(.25));

            standUp = new Animation();
            standUp.AddFrame(new Rectangle(576, 324, 64, 64), TimeSpan.FromSeconds(.25));

            standLeft = new Animation();
            standLeft.AddFrame(new Rectangle(192, 324, 64, 64), TimeSpan.FromSeconds(.25));

            standRight = new Animation();
            standRight.AddFrame(new Rectangle(384, 324, 64, 64), TimeSpan.FromSeconds(.25));
        }

        public NPC(Texture2D newTexture, Vector2 newPosition, Rectangle newNpcBounds)
        {
            texture = newTexture;
            position = newPosition;
            npcBounds = newNpcBounds;

            randY = random.Next(-2, 2);
            randX = random.Next(-2, 2);

            initialVelocity = new Vector2(randX, randY);
            velocity = initialVelocity;

            initAnimations();

            currentAnimation = standDown;
            
        }

        public void checkMovement()
        {
            bool isMoving = velocity != Vector2.Zero;
            if (isMoving)
            {
                bool isMovingHorizontally = Math.Abs(velocity.X) > Math.Abs(velocity.Y);
                if (isMovingHorizontally)
                {
                    if (velocity.X > 0)
                    {
                        currentAnimation = walkRight;
                    }
                    else
                    {
                        currentAnimation = walkLeft;
                    }
                }
                else
                {
                    if (velocity.Y > 0)
                    {
                        currentAnimation = walkDown;
                    }
                    else
                    {
                        currentAnimation = walkUp;
                    }
                }
            }
            else
            {

                if (currentAnimation == walkRight)
                {
                    currentAnimation = standRight;
                }
                else if (currentAnimation == walkLeft)
                {
                    currentAnimation = standLeft;
                }
                else if (currentAnimation == walkUp)
                {
                    currentAnimation = standUp;
                }
                else if (currentAnimation == walkDown)
                {
                    currentAnimation = standDown;
                }

                else if (currentAnimation == null)
                {
                    currentAnimation = standDown;
                }
            }
        }
        public void Update(GameTime gameTime)
        {
            timeToMove += 16;
            if (timeToMove > 1600)
            {
                velocity = new Vector2(0, 0);
                isMoving = false;

                if (timeToMove > 5600)
                {
                    velocity = initialVelocity;
                    isMoving = true;
                    timeToMove = 0;
                    moveCount += 1;
                }
                else
                {
                    timeToMove += 16;
                }
            }
            if(isMoving)
            {
                position += velocity;

                currentAnimation.Update(gameTime);
                        
                if (position.Y <= npcBounds.Y || position.Y >= npcBounds.Y + npcBounds.Height || position.X <= npcBounds.X || position.X >= npcBounds.X + npcBounds.Width)
                {
                    velocity.Y = -velocity.Y;
                }

                if (position.X <= npcBounds.X || position.X >= npcBounds.X + npcBounds.Width)
                {
                    velocity.X = -velocity.X;
                }
            }


            checkMovement();

            if(moveCount >= 2)
            {
                initialVelocity = new Vector2(random.Next(-2, 2), random.Next(-2, 2));
                moveCount = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, currentAnimation.CurrentRectangle, Color.White);
        }
    }
}
