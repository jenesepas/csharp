using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace Grafico_Teo
{
    public partial class Form1 : Form
    {
        static double imagehalfaspect;
        float fTranslate = 0;
        float fRotate = 0;
        float fScale = 1;
        int sube = 0;

        public Form1()
        {
            InitializeComponent();

            simpleOpenGlControl1.InitializeContexts();

            InitOpenGL();
        }

        private void InitOpenGL()
        {
            int width = simpleOpenGlControl1.Width;
            int height = simpleOpenGlControl1.Height;
            imagehalfaspect = ((double)width) / ((double)height) * 0.5;
            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            //glOrtho(limiteIzquierdo, limiteDerecho, limiteAbajo, limiteArriba, znear, zfar)
            Gl.glOrtho(-imagehalfaspect * 1.1, imagehalfaspect * 1.1, -0.6, 0.6, -1f, 10.0f);

            //Glu.gluPerspective(45.0f, imagehalfaspect * 1.1, 0.01f, 5000.0f);

            Gl.glEnable(Gl.GL_DEPTH_TEST);
        }

        private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
        {
            InitOpenGL();
        }

        private void Draw_Triangle()
        {            
            Gl.glBegin(Gl.GL_TRIANGLES);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);
            Gl.glVertex3f(-0.1f, -0.1f, -0.1f);
            Gl.glVertex3f(0.1f, -0.1f, -0.1f);
            Gl.glVertex3f(0.0f, 0.1f, -0.1f);
            Gl.glEnd();
        }

        void Draw_Pyramid()
        {
            Gl.glBegin(Gl.GL_TRIANGLES);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);//front
            Gl.glVertex3f(0.1f, 0.0f, 0.1f);
            Gl.glVertex3f(-0.1f, -0.0f, 0.1f);
            Gl.glVertex3f(0.0f, 0.2f, 0.0f);

            Gl.glColor3f(1.0f, 0.0f, 0.0f);//back
            Gl.glVertex3f(0.1f, 0.0f, -0.1f);
            Gl.glVertex3f(-0.1f, -0.0f, -0.1f);
            Gl.glVertex3f(0.0f, 0.2f, 0.0f);

            Gl.glColor3f(0.0f, 0.0f, 1.0f);//left
            Gl.glVertex3f(0.1f, 0.0f, 0.1f);
            Gl.glVertex3f(0.1f, 0.0f, -0.1f);
            Gl.glVertex3f(0.0f, 0.2f, 0.0f);

            Gl.glColor3f(1.0f, 1.0f, 0.0f);//right
            Gl.glVertex3f(-0.1f, -0.0f, 0.1f);
            Gl.glVertex3f(-0.1f, -0.0f, -0.1f);
            Gl.glVertex3f(0.0f, 0.2f, 0.0f);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3f(0.0f, 1.0f, 1.0f);//bottom
            Gl.glVertex3f(0.1f, 0.0f, 0.1f);
            Gl.glVertex3f(-0.1f, 0.0f, 0.1f);
            Gl.glVertex3f(-0.1f, 0.0f, -0.1f);
            Gl.glVertex3f(0.1f, 0.0f, -0.1f);
            Gl.glEnd();
        }

        void Draw_Cube()
        {
            ////cubo                               
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);	// Color Blue
            Gl.glVertex3f(0.1f, 0.1f, -0.1f);	// Top Right Of The Quad (Top)
            Gl.glVertex3f(-0.1f, 0.1f, -0.1f);	// Top Left Of The Quad (Top) 
            Gl.glVertex3f(-0.1f, 0.1f, 0.1f);	// Bottom Left Of The Quad (Top)
            Gl.glVertex3f(0.1f, 0.1f, 0.1f);	// Bottom Right Of The Quad (Top)
                                                          
            Gl.glColor3f(0.0f, 0.0f, 1.0f);	// Color Orange
            Gl.glVertex3f(0.1f, -0.1f, 0.1f);	// Top Right Of The Quad (Bottom)
            Gl.glVertex3f(-0.1f, -0.1f, 0.1f);	// Top Left Of The Quad (Bottom)
            Gl.glVertex3f(-0.1f, -0.1f, -0.1f);	// Bottom Left Of The Quad (Bottom)
            Gl.glVertex3f(0.1f, -0.1f, -0.1f);	// Bottom Right Of The Quad (Bottom)
          
            Gl.glColor3f(1.0f, 0.0f, 0.0f);	// Color Red	
            Gl.glVertex3f(0.1f, 0.1f, 0.1f);	// Top Right Of The Quad (Front)
            Gl.glVertex3f(-0.1f, 0.1f, 0.1f);	// Top Left Of The Quad (Front)
            Gl.glVertex3f(-0.1f, -0.1f, 0.1f);	// Bottom Left Of The Quad (Front)
            Gl.glVertex3f(0.1f, -0.1f, 0.1f);	// Bottom Right Of The Quad (Front)

            Gl.glColor3f(0.0f, 1.0f, 1.0f);	// Color Yellow
            Gl.glVertex3f(0.1f, -0.1f, -0.1f);	// Top Right Of The Quad (Back)
            Gl.glVertex3f(-0.1f, -0.1f, -0.1f);	// Top Left Of The Quad (Back)
            Gl.glVertex3f(-0.1f, 0.1f, -0.1f);	// Bottom Left Of The Quad (Back)
            Gl.glVertex3f(0.1f, 0.1f, -0.1f);	// Bottom Right Of The Quad (Back)

            Gl.glColor3f(1.0f, 1.0f, 0.0f);	// Color Green
            Gl.glVertex3f(-0.1f, 0.1f, 0.1f);	// Top Right Of The Quad (Left)
            Gl.glVertex3f(-0.1f, 0.1f, -0.1f);	// Top Left Of The Quad (Left)
            Gl.glVertex3f(-0.1f, -0.1f, -0.1f);	// Bottom Left Of The Quad (Left)
            Gl.glVertex3f(-0.1f, -0.1f, 0.1f);	// Bottom Right Of The Quad (Left)

            Gl.glColor3f(1.0f, 0.0f, 1.0f);	// Color Violet
            Gl.glVertex3f(0.1f, 0.1f, -0.1f);	// Top Right Of The Quad (Right)
            Gl.glVertex3f(0.1f, 0.1f, 0.1f);	// Top Left Of The Quad (Right)
            Gl.glVertex3f(0.1f, -0.1f, 0.1f);	// Bottom Left Of The Quad (Right)
            Gl.glVertex3f(0.1f, -0.1f, -0.1f);	// Bottom Right Of The Quad (Right)
            Gl.glEnd();


        }

        void Draw_Cube_Open()
        {
            ////cubo                           
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glColor3f(0.0f, 1.0f, 0.0f);	// Color Blue
            Gl.glVertex3f(0.1f, 0.15f, -0.1f);	// Top Right Of The Quad (Top)
            Gl.glVertex3f(-0.1f, 0.15f, -0.1f);	// Top Left Of The Quad (Top)
            Gl.glVertex3f(-0.1f, 0.15f, 0.1f);	// Bottom Left Of The Quad (Top)
            Gl.glVertex3f(0.1f, 0.15f, 0.1f);	// Bottom Right Of The Quad (Top)

            Gl.glColor3f(0.0f, 0.0f, 1.0f);	// Color Orange
            Gl.glVertex3f(0.1f, -0.15f, 0.1f);	// Top Right Of The Quad (Bottom)
            Gl.glVertex3f(-0.1f, -0.15f, 0.1f);	// Top Left Of The Quad (Bottom)
            Gl.glVertex3f(-0.1f, -0.15f, -0.1f);	// Bottom Left Of The Quad (Bottom)
            Gl.glVertex3f(0.1f, -0.15f, -0.1f);	// Bottom Right Of The Quad (Bottom)

            Gl.glColor3f(1.0f, 0.0f, 0.0f);	// Color Red	
            Gl.glVertex3f(0.1f, 0.1f, 0.15f);	// Top Right Of The Quad (Front)
            Gl.glVertex3f(-0.1f, 0.1f, 0.15f);	// Top Left Of The Quad (Front)
            Gl.glVertex3f(-0.1f, -0.1f, 0.15f);	// Bottom Left Of The Quad (Front)
            Gl.glVertex3f(0.1f, -0.1f, 0.15f);	// Bottom Right Of The Quad (Front)

            Gl.glColor3f(0.0f, 1.0f, 1.0f);	// Color Yellow
            Gl.glVertex3f(0.1f, -0.1f, -0.15f);	// Top Right Of The Quad (Back)
            Gl.glVertex3f(-0.1f, -0.1f, -0.15f);	// Top Left Of The Quad (Back)
            Gl.glVertex3f(-0.1f, 0.1f, -0.15f);	// Bottom Left Of The Quad (Back)
            Gl.glVertex3f(0.1f, 0.1f, -0.15f);	// Bottom Right Of The Quad (Back)

            Gl.glColor3f(1.0f, 1.0f, 0.0f);	// Color Green
            Gl.glVertex3f(-0.1f, 0.1f, 0.1f);	// Top Right Of The Quad (Left)
            Gl.glVertex3f(-0.1f, 0.1f, -0.1f);	// Top Left Of The Quad (Left)
            Gl.glVertex3f(-0.1f, -0.1f, -0.1f);	// Bottom Left Of The Quad (Left)
            Gl.glVertex3f(-0.1f, -0.1f, 0.1f);	// Bottom Right Of The Quad (Left)

            Gl.glColor3f(1.0f, 0.0f, 1.0f);	// Color Violet
            Gl.glVertex3f(0.1f, 0.1f, -0.1f);	// Top Right Of The Quad (Right)
            Gl.glVertex3f(0.1f, 0.1f, 0.1f);	// Top Left Of The Quad (Right)
            Gl.glVertex3f(0.1f, -0.1f, 0.1f);	// Bottom Left Of The Quad (Right)
            Gl.glVertex3f(0.1f, -0.1f, -0.1f);	// Bottom Right Of The Quad (Right)
            Gl.glEnd();


        }

        void Draw_Cube_ll()
        {
            //cubo           
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);	// Color Green
            Gl.glVertex3f(0.1f, 0.1f, -0.02f);	// Top Right Of The Quad (Top)
            Gl.glVertex3f(0.1f, 0.1f, 0.02f);	// Bottom Right Of The Quad (Top)
            Gl.glVertex3f(-0.1f, 0.1f, 0.02f);	// Bottom Left Of The Quad (Top)
            Gl.glVertex3f(-0.1f, 0.1f, -0.02f);	// Top Left Of The Quad (Top)                       
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);
            //Gl.glColor3f(0.0f, 0.0f, 1.0f);	// Color Blue
            Gl.glVertex3f(0.1f, -0.1f, 0.02f);	// Top Right Of The Quad (Bottom)
            Gl.glVertex3f(-0.1f, -0.1f, 0.02f);	// Top Left Of The Quad (Bottom)
            Gl.glVertex3f(-0.1f, -0.1f, -0.02f);	// Bottom Left Of The Quad (Bottom)
            Gl.glVertex3f(0.1f, -0.1f, -0.02f);	// Bottom Right Of The Quad (Bottom)
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);
            //Gl.glColor3f(1.0f, 0.0f, 0.0f);	// Color Red	
            Gl.glVertex3f(0.1f, 0.1f, 0.02f);	// Top Right Of The Quad (Front)
            Gl.glVertex3f(-0.1f, 0.1f, 0.02f);	// Top Left Of The Quad (Front)
            Gl.glVertex3f(-0.1f, -0.1f, 0.02f);	// Bottom Left Of The Quad (Front)
            Gl.glVertex3f(0.1f, -0.1f, 0.02f);	// Bottom Right Of The Quad (Front)
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);
            //Gl.glColor3f(0.0f, 1.0f, 1.0f);	// Color light blue 
            Gl.glVertex3f(0.1f, -0.1f, -0.02f);	// Top Right Of The Quad (Back)
            Gl.glVertex3f(-0.1f, -0.1f, -0.02f);	// Top Left Of The Quad (Back)
            Gl.glVertex3f(-0.1f, 0.1f, -0.02f);	// Bottom Left Of The Quad (Back)
            Gl.glVertex3f(0.1f, 0.1f, -0.02f);	// Bottom Right Of The Quad (Back)
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);
            //Gl.glColor3f(1.0f, 1.0f, 0.0f);	// Color Yellow
            Gl.glVertex3f(-0.1f, 0.1f, 0.02f);	// Top Right Of The Quad (Left)
            Gl.glVertex3f(-0.1f, 0.1f, -0.02f);	// Top Left Of The Quad (Left)
            Gl.glVertex3f(-0.1f, -0.1f, -0.02f);	// Bottom Left Of The Quad (Left)
            Gl.glVertex3f(-0.1f, -0.1f, 0.02f);	// Bottom Right Of The Quad (Left)
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);
            //Gl.glColor3f(1.0f, 0.0f, 1.0f);	// Color Violet
            Gl.glVertex3f(0.1f, 0.1f, -0.02f);	// Top Right Of The Quad (Right)
            Gl.glVertex3f(0.1f, 0.1f, 0.02f);	// Top Left Of The Quad (Right)
            Gl.glVertex3f(0.1f, -0.1f, 0.02f);	// Bottom Left Of The Quad (Right)
            Gl.glVertex3f(0.1f, -0.1f, -0.02f);	// Bottom Right Of The Quad (Right)
            Gl.glEnd();


        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {            
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT); //Limpiamos el buffer de color (borramos el anterior dibujo de la memoria             
            Gl.glMatrixMode(Gl.GL_MODELVIEW);  //Activamos la matriz de modelado
            //Gl.glLoadIdentity(); //Ponemos la matriz a 1
            Glu.gluLookAt(0, 0, 10, 0, 0, 0, 0, 1, 0); //Hacia donde mira la camara

            Gl.glLoadIdentity(); //Ponemos la matriz a 1
            ////traslate
            Gl.glPushMatrix();
            Gl.glTranslatef(-0.5f, 0.0f, -0.0f);
            Gl.glTranslatef(-0.0f, fTranslate, -0.0f);
            //Draw_Triangle();
            //Draw_Pyramid();
            Draw_Cube();
            
            Gl.glPopMatrix();

            Gl.glLoadIdentity(); //Ponemos la matriz a 1

            ////rotate
            Gl.glPushMatrix();
            Gl.glTranslatef(-0.0f, -0.2f, -0.2f);
            Gl.glRotatef(fRotate, 0.0f, 1.0f, 0.0f); // Rotate 90 Degrees
            Gl.glRotatef(fRotate, 1.0f, 1.0f, 1.0f); // Rotate 90 Degrees
            //Draw_Triangle();
            //Draw_Pyramid();
            Draw_Cube_ll();
            Gl.glPopMatrix();

            Gl.glLoadIdentity(); //Ponemos la matriz a 1

            ////rotate2
            Gl.glPushMatrix();
            Gl.glTranslatef(-0.0f, 0.3f, -0.2f);
            Gl.glRotatef(fRotate, 0.0f, 1.0f, 0.0f); // Rotate 90 Degrees
            Gl.glRotatef(fRotate, 1.0f, 1.0f, 1.0f); // Rotate 90 Degrees
            //Draw_Triangle();
            //Draw_Pyramid();
            Draw_Cube_Open();
            Gl.glPopMatrix();

            Gl.glLoadIdentity(); //Ponemos la matriz a 1

            //scale
            Gl.glPushMatrix();
            Gl.glTranslatef(0.5f, 0.0f, -0.0f);
            Gl.glScalef(fScale,fScale,fScale);        
            //Draw_Triangle();
            //Draw_Pyramid();
            Draw_Cube();
            Gl.glPopMatrix();
                       
            
            simpleOpenGlControl1.Refresh();

            fTranslate += 0.00005f; 	// Speed Of The  Translation
            fRotate += 0.02f;   	// Speed Of The Rotation
            if (sube == 0)
                fScale += 0.0003f; 	// Speed Of The Scaling
            else
                fScale -= 0.0003f; 	// Speed Of The Scaling

            if (fTranslate > 0.4f) fTranslate = 0.0f;   // Reset Translation
            if (fScale > 1.5f) sube = 1;   // Reset Scaling to 1.0f
            if (fScale < 1.0f) sube = 0;   // Reset Scaling to 1.0f
        }
        
    }
}
