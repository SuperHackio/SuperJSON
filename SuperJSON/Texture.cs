// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var textureHeader = TextureHeader.FromJson(jsonString);

namespace QuickType
{
    using System;
    using Newtonsoft.Json;

    public partial class TextureHeader
    {
        [JsonIgnore]
        public int ID { get; set; }

        [JsonProperty("AttachPalette")]
        public int AttachPalette { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Format")]
        public string Format { get; set; }

        [JsonProperty("AlphaSetting")]
        public int AlphaSetting { get; set; }

        [JsonProperty("WrapS")]
        public string WrapS { get; set; }

        [JsonProperty("WrapT")]
        public string WrapT { get; set; }

        [JsonProperty("MinFilter")]
        public string MinFilter { get; set; }

        [JsonProperty("MagFilter")]
        public string MagFilter { get; set; }

        [JsonProperty("MinLOD")]
        public int MinLod { get; set; }

        [JsonProperty("MaxLOD")]
        public int MaxLod { get; set; }

        [JsonProperty("LodBias")]
        public int LodBias { get; set; }
    }

    public enum TextureFormat { I4, I8, IA4, IA8, RGB565, RGB5A3, RGBA32, CMPR }

    public enum TextureWrap { ClampToEdge, Repeat, MirroredRepeat}

    public enum TextureMinFilter {
        Nearest,                  // Point Sampling, No Mipmap
        Linear,                   // Bilinear Filtering, No Mipmap
        NearestMipmapNearest,     // Point Sampling, Discrete Mipmap
        NearestMipmapLinear,      // Bilinear Filtering, Discrete Mipmap
        LinearMipmapNearest,      // Point Sampling, Linear MipMap
        LinearMipmapLinear
    }

    public enum TextureMagFilter {
        Nearest,                  // Point Sampling, No Mipmap
        Linear                    // Bilinear Filtering, No Mipmap
    }
}
