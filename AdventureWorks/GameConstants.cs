using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AdventureWorks
{
    class GameConstants
    {
        public const int WindowWidth = 800;
        public const int WindowHight = 600;

        public static readonly Rectangle MapArea = new Rectangle(8, 8, 784, 368);
        public static readonly Rectangle TextArea = new Rectangle(8,384,748,208);
        public static readonly Rectangle ScrollBarArea = new Rectangle(760,384,32,208);

        public static readonly Rectangle VDecoScrollbarUpNormal = new Rectangle(19, 354, 14, 15);
        public static readonly Rectangle VDecoScrollbarUpHover = new Rectangle(19, 370, 14, 15);
        public static readonly Rectangle VDecoScrollbarUpPushed = new Rectangle(19, 386, 14, 15);
        public static readonly Rectangle VDecoScrollbarUpDisabled = new Rectangle(19, 402, 14, 15);
        public static readonly Rectangle VDecoScrollbarDownNormal = new Rectangle(36, 354, 14, 15);
        public static readonly Rectangle VDecoScrollbarDownHover = new Rectangle(36, 370, 14, 15);
        public static readonly Rectangle VDecoScrollbarDownPushed = new Rectangle(36, 386, 14, 15);
        public static readonly Rectangle VDecoScrollbarDownDisabled = new Rectangle(36, 402, 14, 15);
        public static readonly Rectangle VDecoScrollbarBarEnabled = new Rectangle(0, 400, 4, 1);
        public static readonly Rectangle VDecoScrollbarBarDisabled = new Rectangle(6, 400, 4, 1);
        public static readonly Rectangle VDecoScrollbarBarThumbNormal = new Rectangle(0, 354, 14, 10);
        public static readonly Rectangle VDecoScrollbarBarThumbHover = new Rectangle(0, 365, 14, 10);
        public static readonly Rectangle VDecoScrollbarBarThumbPushed = new Rectangle(0, 376, 14, 10);
        public static readonly Rectangle VDecoScrollbarBarThumbDisabled = new Rectangle(0, 387, 14, 10);


    }
}
