using QuickType;
using Newtonsoft.Json;

namespace Presets
{
    public class Presets
    {
        public enum CombineColorInput
        {
            ColorPrev = 0,  // ! < Use Color Value from previous TEV stage
            AlphaPrev = 1,  // ! < Use Alpha Value from previous TEV stage
            C0 = 2,         // ! < Use the Color Value from the Color/Output Register 0
            A0 = 3,         // ! < Use the Alpha value from the Color/Output Register 0
            C1 = 4,         // ! < Use the Color Value from the Color/Output Register 1
            A1 = 5,         // ! < Use the Alpha value from the Color/Output Register 1
            C2 = 6,         // ! < Use the Color Value from the Color/Output Register 2
            A2 = 7,         // ! < Use the Alpha value from the Color/Output Register 2
            TexColor = 8,   // ! < Use the Color value from Texture
            TexAlpha = 9,   // ! < Use the Alpha value from Texture
            RasColor = 10,  // ! < Use the color value from rasterizer
            RasAlpha = 11,  // ! < Use the alpha value from rasterizer
            One = 12,
            Half = 13,
            Konst = 14,
            Zero = 15       // 
        }

        public enum CombineAlphaInput
        {
            AlphaPrev = 0,  // Use the Alpha value form the previous TEV stage
            A0 = 1,         // Use the Alpha value from the Color/Output Register 0
            A1 = 2,         // Use the Alpha value from the Color/Output Register 1
            A2 = 3,         // Use the Alpha value from the Color/Output Register 2
            TexAlpha = 4,   // Use the Alpha value from the Texture
            RasAlpha = 5,   // Use the Alpha value from the rasterizer
            Konst = 6,
            Zero = 7
        }

        public enum ColourOperator { Add, Sub, Comp_R8_GT, Comp_R8_EQ, Comp_GR16_GT, Comp_GR16_EQ, Comp_BGR24_GT, Comp_BGR24_EQ, Comp_RGB8_GT, Comp_RGB8_EQ}

        public enum AlphaOperator { Add, Sub, Comp_A8_EQ, Comp_A8_GT }

        public enum TevBias { Zero, AddHalf, SubHalf }

        public enum TevRegisterId { TevPrev, TevReg0, TevReg1, TevReg2 }
    }
}
