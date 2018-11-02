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

        [JsonProperty("MipMap")]
        public int MipMap { get; set; }

        [JsonProperty("EdgeLOD")]
        public bool EdgeLOD { get; set; }

        [JsonProperty("BiasClamp")]
        public bool BiasClamp { get; set; }

        [JsonProperty("MaxAniso")]
        public int MaxAniso { get; set; }

        [JsonProperty("MinFilter")]
        public string MinFilter { get; set; }

        [JsonProperty("MagFilter")]
        public string MagFilter { get; set; }

        [JsonProperty("MinLOD")]
        public decimal MinLod { get; set; }

        [JsonProperty("MaxLOD")]
        public decimal MaxLod { get; set; }

        [JsonProperty("LodBias")]
        public decimal LodBias { get; set; }
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
