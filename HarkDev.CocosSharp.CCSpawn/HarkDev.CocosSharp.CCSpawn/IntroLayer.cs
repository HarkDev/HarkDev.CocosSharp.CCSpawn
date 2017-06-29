//
//THE SAMPLE CODE IS PROVIDED "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, 
//INCLUDING THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
//IN NO EVENT SHALL THE CREATOR OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
//OR CONSEQUENTIAL DAMAGES(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; 
//OR BUSINESS INTERRUPTION) SUSTAINED BY YOU OR A THIRD PARTY, HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, 
//OR TORT ARISING IN ANY WAY OUT OF THE USE OF THIS SAMPLE CODE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// 
// http://harkdev.blogspot.com/
using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;

namespace HarkDev.CocosSharp.CCSpawn
{
    public class IntroLayer : CCLayerColor
    {

        // Define a label variable
        CCLabel label;

        public IntroLayer()
            : base(CCColor4B.Blue)
        {

            // create and initialize a Label
            label = new CCLabel("Tocame para ejecutar Muchas Acciones a la vez!", "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);

            // add the label as a child to this Layer
            AddChild(label);

        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            // Use the bounds to layout the positioning of our drawable assets
            var bounds = VisibleBoundsWorldspace;

            // position the label on the center of the screen
            label.Position = bounds.Center;

            // Register for touch events
            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesEnded = OnTouchesEnded;
            AddEventListener(touchListener, this);
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                // Establezco los valores iniciales por si se ejecuta mas de una vez!
                label.Scale = 1;
                label.Rotation = 0;
                
                float duracion = 3; // variable que indica cuanto tiempo dura la animacion.

                // Animacion que hace crecer mi nodo por el tiempo definido, a un Scale de 3 veces su tamaño original.
                CCScaleBy escalar = new CCScaleBy(duracion, 3);

                // Animacion que hace rotar mi nodo por el tiempo definido, a un angulo de 360 grados.
                CCRotateBy rotacion = new CCRotateBy(duracion, 360);

                // Objeto que ejecuta ambias animaciones a la vez.

                // El uso de global permite que mi compilador no se confunda entre el namespace de mi proyecto y el de CocosSharp
                // Creo el objeto CCSpawn, pasandole las animaciones que quiero ejecutar.
                global::CocosSharp.CCSpawn spawn = new global::CocosSharp.CCSpawn(escalar, rotacion);

                //Ejecuto las animaciones en el label.
                label.RunAction(spawn);
            }
        }
    }
}

