using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace ArenaGame
{
    public class CharacterEntity
    {
        static Texture2D characterSheetTexture;
        static private Texture2D characterBorder;

        private const float desiredSpeed = 200;

        Animation walkDown;
        Animation walkUp;
        Animation walkLeft;
        Animation walkRight;

        Animation standDown;
        Animation standUp;
        Animation standLeft;
        Animation standRight;

        Animation currentAnimation;

        KeyboardState previousState;

        public static ContentManager Content { get; set; }
        public static float X{ get; set; }
        public static float Y { get; set; }
        private Vector2 velocity { get; set; }
        public static Rectangle CharacterBounds { get; set; }

        public CharacterEntity(GraphicsDevice graphicsDevice)
        {
            previousState = Keyboard.GetState();

            if (characterSheetTexture == null)
            {
                characterSheetTexture = Content.Load<Texture2D>("charactersheet64");
            }
            if (characterBorder == null)
            {
                characterBorder = new Texture2D(graphicsDevice, 64, 64);
                characterBorder.CreateBorder(1, Color.Red);
                
            }

            walkDown = new Animation();
            walkDown.AddFrame(new Rectangle(0, 322, 64, 64), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(64, 322, 64, 64), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(0, 322, 64, 64), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(128, 322, 64, 64), TimeSpan.FromSeconds(.25));

            walkUp = new Animation();
            walkUp.AddFrame(new Rectangle(576, 322, 64, 64), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(640, 322, 64, 64), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(576, 322, 64, 64), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(704, 322, 64, 64), TimeSpan.FromSeconds(.25));

            walkLeft = new Animation();
            walkLeft.AddFrame(new Rectangle(192, 322, 64, 64), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(256, 322, 64, 64), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(192, 322, 64, 64), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(320, 322, 64, 64), TimeSpan.FromSeconds(.25));

            walkRight = new Animation();
            walkRight.AddFrame(new Rectangle(384, 322, 64, 64), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(448, 322, 64, 64), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(384, 322, 64, 64), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(512, 322, 64, 64), TimeSpan.FromSeconds(.25));

            // Standing animations only have a single frame of animation:
            standDown = new Animation();
            standDown.AddFrame(new Rectangle(0, 322, 64, 64), TimeSpan.FromSeconds(.25));

            standUp = new Animation();
            standUp.AddFrame(new Rectangle(576, 322, 64, 64), TimeSpan.FromSeconds(.25));

            standLeft = new Animation();
            standLeft.AddFrame(new Rectangle(192, 322, 64, 64), TimeSpan.FromSeconds(.25));

            standRight = new Animation();
            standRight.AddFrame(new Rectangle(384, 322, 64, 64), TimeSpan.FromSeconds(.25));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 topLeftOfSprite = new Vector2(X, Y);
            
            spriteBatch.Draw(characterSheetTexture, topLeftOfSprite, currentAnimation.CurrentRectangle, Color.White);
            //spriteBatch.Draw(characterBorder, topLeftOfSprite, Color.White);
        }

        public void Update(GameTime gameTime)
        {

            checkKeyInputs(gameTime);
            currentAnimation.Update(gameTime);
        }
        void checkKeyInputs(GameTime gameTime)
        {
            velocity = GetDesiredVelocityFromInput();

            X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Y += velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            CharacterBounds = new Rectangle((int)X, (int)Y, characterSheetTexture.Width, characterSheetTexture.Height);

            // We can use the velocity variable to determine if the 
            // character is moving or standing still
            bool isMoving = velocity != Vector2.Zero;
            if (isMoving)
            {
                // If the absolute value of the X component
                // is larger than the absolute value of the Y
                // component, then that means the character is
                // moving horizontally:
                bool isMovingHorizontally = Math.Abs(velocity.X) > Math.Abs(velocity.Y);
                if (isMovingHorizontally)
                {
                    // No that we know the character is moving horizontally 
                    // we can check if the velocity is positive (moving right)
                    // or negative (moving left)
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
                    // If the character is not moving horizontally
                    // then it must be moving vertically. The SpriteBatch
                    // class treats positive Y as down, so this defines the
                    // coordinate system for our game. Therefore if
                    // Y is positive then the character is moving down.
                    // Otherwise, the character is moving up.
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
                // This else statement contains logic for if the
                // character is standing still.
                // First we are going to check if the character
                // is currently playing any walking animations.
                // If so, then we want to switch to a standing animation.
                // We want to preserve the direction that the character
                // is facing so we'll set the corresponding standing
                // animation according to the walking animation being played.
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
                // If the character is standing still but is not showing
                // any animation at all then we'll default to facing down.
                else if (currentAnimation == null)
                {
                    currentAnimation = standDown;
                }
            }
        }

        Vector2 GetDesiredVelocityFromInput()
        {
            Vector2 velocity = new Vector2();

            KeyboardState keyBoardState = Keyboard.GetState();


            if (keyBoardState.IsKeyDown(Keys.W) && !previousState.IsKeyDown(Keys.S))
            {
                velocity.Y = -3;
                velocity.Normalize();
            }
            if (keyBoardState.IsKeyDown(Keys.S) && !previousState.IsKeyDown(Keys.W))
            {
                velocity.Y = 3;
                velocity.Normalize();
            }
            if (keyBoardState.IsKeyDown(Keys.A) && !previousState.IsKeyDown(Keys.D))
            {
                velocity.X = -3;
                velocity.Normalize();
            }
            if (keyBoardState.IsKeyDown(Keys.D) && !previousState.IsKeyDown(Keys.A))
            {
                velocity.X = 3;
                velocity.Normalize();
            }
            if (keyBoardState.IsKeyDown(Keys.D) && keyBoardState.IsKeyDown(Keys.W))
            {
                velocity.X = 3;
                velocity.Y = -3;
                velocity.Normalize();
            }

            if (keyBoardState.IsKeyDown(Keys.A) && keyBoardState.IsKeyDown(Keys.S))
            {
                velocity.X = -3;
                velocity.Y = 3;
                velocity.Normalize();
            }

            if (keyBoardState.IsKeyDown(Keys.D) && keyBoardState.IsKeyDown(Keys.S))
            {
                velocity.X = 3;
                velocity.Y = 3;
                velocity.Normalize();
            }
            if (keyBoardState.IsKeyDown(Keys.A) && keyBoardState.IsKeyDown(Keys.W))
            {
                velocity.X = -3;
                velocity.Y = -3;
                velocity.Normalize();
            }
            if (keyBoardState.IsKeyDown(Keys.A) && keyBoardState.IsKeyDown(Keys.W) && keyBoardState.IsKeyDown(Keys.D))
            {
                velocity.Y = -3;
                velocity.X = 0;
                velocity.Normalize();
            }
            if (keyBoardState.IsKeyDown(Keys.S) && keyBoardState.IsKeyDown(Keys.A) && keyBoardState.IsKeyDown(Keys.D))
            {
                velocity.Y = 3;
                velocity.X = 0;
                velocity.Normalize();
            }
            if (keyBoardState.IsKeyDown(Keys.S) && keyBoardState.IsKeyDown(Keys.W) && keyBoardState.IsKeyDown(Keys.A))
            {
                velocity.Y = 0;
                velocity.X = -3;
                velocity.Normalize();
            }
            if (keyBoardState.IsKeyDown(Keys.S) && keyBoardState.IsKeyDown(Keys.W) && keyBoardState.IsKeyDown(Keys.D))
            {
                velocity.Y = 0;
                velocity.X = 3;
                velocity.Normalize();
            }
            if (keyBoardState.IsKeyDown(Keys.S) && keyBoardState.IsKeyDown(Keys.W) && keyBoardState.IsKeyDown(Keys.A) && keyBoardState.IsKeyDown(Keys.D))
            {
                velocity.Y = 0;
                velocity.X = 0;
            }
            velocity *= desiredSpeed;
            previousState = keyBoardState;
            return velocity;
        }
        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {

            Rectangle rect = new Rectangle((int)X, (int)Y, 66, 66);

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
            
            //SCREEN EDGES
            if (X < 0)
            {
                X = 0;
            }

            if(X + 64 > 1920)
            {
                X = 1920 - 64;
            }

            if (Y + 64> 1080)
            {
                Y = 1080 - 64;
            }

            if (Y < 0)
            {
                Y = 0;
            }
        }
    }
    static class Utilities
    {
        public static void CreateBorder(this Texture2D texture, int borderWidth, Color borderColor)
        {
            Color[] colors = new Color[texture.Width * texture.Height];

            for (int x = 0; x < texture.Width; x++)
            {
                for (int y = 0; y < texture.Height; y++)
                {
                    bool colored = false;
                    for (int i = 0; i <= borderWidth; i++)
                    {
                        if (x == i || y == i || x == texture.Width - 1 - i || y == texture.Height - 1 - i)
                        {
                            colors[x + y * texture.Width] = borderColor;
                            colored = true;
                            break;
                        }
                    }

                    if (colored == false)
                        colors[x + y * texture.Width] = Color.Transparent;
                }
            }

            texture.SetData(colors);
        }
    }
}