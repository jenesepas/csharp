using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using Tao.FreeGlut;

namespace grafico
{
    class MainWindow : OpenTK.GameWindow
    {
        float fTranslate = 0;
        float fRotate = 0;
        float fScale = 1;
        int sube = 0;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.Aquamarine);
            
        }

        void Draw_Triangle()
        {
            //GL.Enable(EnableCap.DepthTest);
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(Color.Red);
            GL.Vertex3(0.0f, 0.2f, 0.0f);
            GL.Vertex3(-0.2f, -0.2f, 0.0f);
            GL.Vertex3(0.2f, -0.2f, 0.0f);
            GL.End();
        }

        void Draw_Pyramid()
        {
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(Color.Red);//front
            GL.Vertex3(0.2f, 0.0f, 0.2f);
            GL.Vertex3(-0.2f, -0.0f, 0.2f);
            GL.Vertex3(0.0f, 0.4f, 0.0f);

            GL.Color3(Color.Purple);//back
            GL.Vertex3(0.2f, 0.0f, -0.2f);
            GL.Vertex3(-0.2f, -0.0f, -0.2f);
            GL.Vertex3(0.0f, 0.4f, 0.0f);

            GL.Color3(Color.Silver);//left
            GL.Vertex3(0.2f, 0.0f, 0.2f);
            GL.Vertex3(0.2f, 0.0f, -0.2f);
            GL.Vertex3(0.0f, 0.4f, 0.0f);

            GL.Color3(Color.Navy);//right
            GL.Vertex3(-0.2f, -0.0f, 0.2f);
            GL.Vertex3(-0.2f, -0.0f, -0.2f);
            GL.Vertex3(0.0f, 0.4f, 0.0f);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.LimeGreen);//bottom
            GL.Vertex3(0.2f, 0.0f, 0.2f);
            GL.Vertex3(-0.2f, 0.0f, 0.2f);
            GL.Vertex3(-0.2f, 0.0f, -0.2f);
            GL.Vertex3(0.2f, 0.0f, -0.2f);
            GL.End();
        }

        void Draw_Cube()
        {
            ////cubo
            //GL.Enable(EnableCap.DepthTest);                      
            GL.Begin(PrimitiveType.Quads);            

            GL.Color3(Color.Blue);	// Color Blue
            GL.Vertex3(0.3f, 0.4f, -0.3f);	// Top Right Of The Quad (Top)
            GL.Vertex3(-0.3f, 0.4f, -0.3f);	// Top Left Of The Quad (Top)
            GL.Vertex3(-0.3f, 0.4f, 0.3f);	// Bottom Left Of The Quad (Top)
            GL.Vertex3(0.3f, 0.4f, 0.3f);	// Bottom Right Of The Quad (Top)
            
            GL.Color3(Color.Orange);	// Color Orange
            GL.Vertex3(0.3f, -0.4f, 0.3f);	// Top Right Of The Quad (Bottom)
            GL.Vertex3(-0.3f, -0.4f, 0.3f);	// Top Left Of The Quad (Bottom)
            GL.Vertex3(-0.3f, -0.4f, -0.3f);	// Bottom Left Of The Quad (Bottom)
            GL.Vertex3(0.3f, -0.4f, -0.3f);	// Bottom Right Of The Quad (Bottom)
            
            GL.Color3(Color.Red);	// Color Red	
            GL.Vertex3(0.3f, 0.3f, 0.4f);	// Top Right Of The Quad (Front)
            GL.Vertex3(-0.3f, 0.3f, 0.4f);	// Top Left Of The Quad (Front)
            GL.Vertex3(-0.3f, -0.3f, 0.4f);	// Bottom Left Of The Quad (Front)
            GL.Vertex3(0.3f, -0.3f, 0.4f);	// Bottom Right Of The Quad (Front)
            
            GL.Color3(Color.Yellow);	// Color Yellow
            GL.Vertex3(0.3f, -0.3f, -0.4f);	// Top Right Of The Quad (Back)
            GL.Vertex3(-0.3f, -0.3f, -0.4f);	// Top Left Of The Quad (Back)
            GL.Vertex3(-0.3f, 0.3f, -0.4f);	// Bottom Left Of The Quad (Back)
            GL.Vertex3(0.3f, 0.3f, -0.4f);	// Bottom Right Of The Quad (Back)
            
            GL.Color3(Color.Green);	// Color Green
            GL.Vertex3(-0.3f, 0.3f, 0.3f);	// Top Right Of The Quad (Left)
            GL.Vertex3(-0.3f, 0.3f, -0.3f);	// Top Left Of The Quad (Left)
            GL.Vertex3(-0.3f, -0.3f, -0.3f);	// Bottom Left Of The Quad (Left)
            GL.Vertex3(-0.3f, -0.3f, 0.3f);	// Bottom Right Of The Quad (Left)
            
            GL.Color3(Color.Violet);	// Color Violet
            GL.Vertex3(0.3f, 0.3f, -0.3f);	// Top Right Of The Quad (Right)
            GL.Vertex3(0.3f, 0.3f, 0.3f);	// Top Left Of The Quad (Right)
            GL.Vertex3(0.3f, -0.3f, 0.3f);	// Bottom Left Of The Quad (Right)
            GL.Vertex3(0.3f, -0.3f, -0.3f);	// Bottom Right Of The Quad (Right)
            GL.End();


        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);            
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Enable(EnableCap.DepthTest);
            

            ////punto
            //GL.Begin(PrimitiveType.LineLoop);
            //GL.Color3(Color.Black);
            //GL.Vertex3(-0.02f, 0.02f, 0.0f);
            //GL.Vertex3(-0.02f, -0.02f, 0.0f);
            //GL.Vertex3(0.02f, -0.02f, 0.0f);
            //GL.Vertex3(0.02f, 0.02f, 0.0f);

            //GL.Begin(PrimitiveType.Quads);
            //// rotar culo
            //GL.Color3(Color.Yellow);
            //GL.Vertex3(-0.0f, -0.0f, -0.0f);
            //GL.Vertex3(-0.2f, -0.2f, 0.0f);
            //GL.Vertex3(0.2f, -0.2f, 0.0f);
            //GL.Vertex3(0.4f, -0.0f, 0.0f);

                                                      
            //traslate
            GL.PushMatrix();
            GL.Translate(-0.7f, 0.0f, -0.0f);		// Place the triangle Left         
            GL.Translate(0.0f, fTranslate, 0.0f);	// Translate in Y direction
            //Draw_Triangle();
            //Draw_Cube();
            Draw_Pyramid();
            GL.PopMatrix();

            ////rotate
            GL.PushMatrix();
            GL.Translate(0.0f, 0.0f, -0.2f);		// Place the triangle Left         
            GL.Rotate(fRotate, 0.0f, 1.0f, 0.0f); // Rotate 90 Degrees
            GL.Rotate(fRotate, 1.0f, 1.0f, 1.0f); // Rotate 90 Degrees
            //Draw_Triangle();
            //Draw_Cube();
            Draw_Pyramid();
            GL.PopMatrix();

            //scale
            GL.PushMatrix();
            GL.Translate(0.7f, 0.0f, -0.5f);		// Place the triangle Left            
            GL.Scale(fScale, fScale, fScale); // Rotate 90 Degrees
            //Draw_Triangle();
            //Draw_Cube();
            Draw_Pyramid();
            GL.PopMatrix();

            

            SwapBuffers();

            fTranslate += 0.00005f; 	// Speed Of The  Translation
            fRotate += 0.05f;   	// Speed Of The Rotation
            if (sube == 0)
                fScale += 0.0003f; 	// Speed Of The Scaling
            else
                fScale -= 0.0003f; 	// Speed Of The Scaling

            if (fTranslate > 0.5f) fTranslate = 0.0f;   // Reset Translation
            if (fScale > 1.5f) sube = 1;   // Reset Scaling to 1.0f
            if (fScale < 1.0f) sube = 0;   // Reset Scaling to 1.0f
        }
    }
}
