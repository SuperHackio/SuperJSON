// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var material = Material.FromJson(jsonString);

namespace QuickType
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Material
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Flag")]
        public long Flag { get; set; }

        [JsonProperty("ColorChannelControlsCount")]
        public long ColorChannelControlsCount { get; set; }

        [JsonProperty("NumTexGensCount")]
        public long NumTexGensCount { get; set; }

        [JsonProperty("NumTevStagesCount")]
        public long NumTevStagesCount { get; set; }

        [JsonProperty("Textures")]
        public string[] TextureInfo { get; set; }

        [JsonIgnore]
        public TextureInfo[] Textures { get; set; }

        [JsonProperty("IndTexEntry")]
        public IndTexEntry IndTexEntry { get; set; }

        [JsonProperty("CullMode")]
        public string CullMode { get; set; }

        [JsonProperty("MaterialColors")]
        public AmbientColor[] MaterialColors { get; set; }

        [JsonProperty("ChannelControls")]
        public ChannelControl[] ChannelControls { get; set; }

        [JsonProperty("AmbientColors")]
        public AmbientColor[] AmbientColors { get; set; }

        [JsonProperty("LightingColors")]
        public object[] LightingColors { get; set; }

        [JsonProperty("TexCoord1Gens")]
        public TexCoord1Gen[] TexCoord1Gens { get; set; }

        [JsonProperty("PostTexCoordGens")]
        public object[] PostTexCoordGens { get; set; }

        [JsonProperty("TexMatrix1")]
        public TexMatrix1[] TexMatrix1 { get; set; }

        [JsonProperty("PostTexMatrix")]
        public object[] PostTexMatrix { get; set; }

        [JsonProperty("TevOrders")]
        public MaterialTevOrder[] TevOrders { get; set; }

        [JsonProperty("ColorSels")]
        public string[] ColorSels { get; set; }

        [JsonProperty("AlphaSels")]
        public string[] AlphaSels { get; set; }

        [JsonProperty("TevColors")]
        public TEVColor[] TevColors { get; set; }

        [JsonProperty("KonstColors")]
        public AmbientColor[] KonstColors { get; set; }

        [JsonProperty("TevStages")]
        public MaterialTevStage[] TevStages { get; set; }

        [JsonProperty("SwapModes")]
        public SwapMode[] SwapModes { get; set; }

        [JsonProperty("SwapTables")]
        public SwapTable[] SwapTables { get; set; }

        [JsonProperty("FogInfo")]
        public FogInfo FogInfo { get; set; }

        [JsonProperty("AlphCompare")]
        public AlphCompare AlphCompare { get; set; }

        [JsonProperty("BMode")]
        public BMode BMode { get; set; }

        [JsonProperty("ZMode")]
        public ZMode ZMode { get; set; }

        [JsonProperty("ZCompLoc")]
        public bool ZCompLoc { get; set; }

        [JsonProperty("Dither")]
        public bool Dither { get; set; }

        [JsonProperty("NBTScale")]
        public NbtScale NbtScale { get; set; }
    }

    public partial class AlphCompare
    {
        [JsonProperty("Comp0")]
        public string Comp0 { get; set; }

        [JsonProperty("Reference0")]
        public long Reference0 { get; set; }

        [JsonProperty("Operation")]
        public string Operation { get; set; }

        [JsonProperty("Comp1")]
        public string Comp1 { get; set; }

        [JsonProperty("Reference1")]
        public long Reference1 { get; set; }
    }

    public partial class AmbientColor
    {
        [JsonProperty("R")]
        public double R { get; set; }

        [JsonProperty("G")]
        public double G { get; set; }

        [JsonProperty("B")]
        public double B { get; set; }

        [JsonProperty("A")]
        public double A { get; set; }
    }

    public partial class TEVColor
    {
        [JsonProperty("R")]
        public double R { get ; set; }

        [JsonProperty("G")]
        public double G { get; set; }

        [JsonProperty("B")]
        public double B { get; set; }

        [JsonProperty("A")]
        public double A { get; set; }
    }

    public partial class SwapTable
    {
        [JsonProperty("R")]
        public int R { get; set; }

        [JsonProperty("G")]
        public int G { get; set; }

        [JsonProperty("B")]
        public int B { get; set; }

        [JsonProperty("A")]
        public int A { get; set; }
    }

    public partial class BMode
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("SourceFact")]
        public string SourceFact { get; set; }

        [JsonProperty("DestinationFact")]
        public string DestinationFact { get; set; }

        [JsonProperty("Operation")]
        public string Operation { get; set; }
    }

    public partial class ChannelControl
    {
        [JsonProperty("Enable")]
        public bool Enable { get; set; }

        [JsonProperty("MaterialSrcColor")]
        public string MaterialSrcColor { get; set; }

        [JsonProperty("LitMask")]
        public string LitMask { get; set; }

        [JsonProperty("DiffuseFunction")]
        public string DiffuseFunction { get; set; }

        [JsonProperty("AttenuationFunction")]
        public string AttenuationFunction { get; set; }

        [JsonProperty("AmbientSrcColor")]
        public string AmbientSrcColor { get; set; }
    }

    public partial class FogInfo
    {
        [JsonProperty("Type")]
        public long Type { get; set; }

        [JsonProperty("Enable")]
        public bool Enable { get; set; }

        [JsonProperty("Center")]
        public long Center { get; set; }

        [JsonProperty("StartZ")]
        public double StartZ { get; set; }

        [JsonProperty("EndZ")]
        public double EndZ { get; set; }

        [JsonProperty("NearZ")]
        public double NearZ { get; set; }

        [JsonProperty("FarZ")]
        public double FarZ { get; set; }

        [JsonProperty("Color")]
        public AmbientColor Color { get; set; }

        [JsonProperty("RangeAdjustmentTable")]
        public double[] RangeAdjustmentTable { get; set; }
    }

    public partial class IndTexEntry
    {
        [JsonProperty("HasLookup")]
        public bool HasLookup { get; set; }

        [JsonProperty("IndTexStageNum")]
        public long IndTexStageNum { get; set; }

        [JsonProperty("TevOrders")]
        public TevOrderElement[] TevOrders { get; set; }

        [JsonProperty("Matrices")]
        public Matrix[] Matrices { get; set; }

        [JsonProperty("Scales")]
        public Scale[] Scales { get; set; }

        [JsonProperty("TevStages")]
        public TevStageElement[] TevStages { get; set; }
    }

    public partial class Matrix
    {
        [JsonProperty("Matrix")]
        public double[][] MatrixMatrix { get; set; }

        [JsonProperty("Exponent")]
        public long Exponent { get; set; }
    }

    public partial class Scale
    {
        [JsonProperty("ScaleS")]
        public string ScaleS { get; set; }

        [JsonProperty("ScaleT")]
        public string ScaleT { get; set; }
    }

    public partial class TevOrderElement
    {
        [JsonProperty("TexCoord")]
        public string TexCoord { get; set; }

        [JsonProperty("TexMap")]
        public string TexMap { get; set; }
    }

    public partial class TevStageElement
    {
        [JsonProperty("TevStage")]
        public string TevStage { get; set; }

        [JsonProperty("IndTexFormat")]
        public string IndTexFormat { get; set; }

        [JsonProperty("IndTexBiasSel")]
        public string IndTexBiasSel { get; set; }

        [JsonProperty("IndTexMtxId")]
        public string IndTexMtxId { get; set; }

        [JsonProperty("IndTexWrapS")]
        public string IndTexWrapS { get; set; }

        [JsonProperty("IndTexWrapT")]
        public string IndTexWrapT { get; set; }

        [JsonProperty("AddPrev")]
        public bool AddPrev { get; set; }

        [JsonProperty("UtcLod")]
        public bool UtcLod { get; set; }

        [JsonProperty("AlphaSel")]
        public string AlphaSel { get; set; }
    }

    public partial class NbtScale
    {
        [JsonProperty("Unknown1")]
        public long Unknown1 { get; set; }
    }

    public partial class SwapMode
    {
        [JsonProperty("RasSel")]
        public long RasSel { get; set; }

        [JsonProperty("TexSel")]
        public long TexSel { get; set; }
    }

    public partial class MaterialTevOrder
    {
        [JsonProperty("TexCoord")]
        public string TexCoord { get; set; }

        [JsonProperty("TexMap")]
        public string TexMap { get; set; }

        [JsonProperty("ChannelId")]
        public string ChannelId { get; set; }
    }

    public partial class MaterialTevStage
    {
        [JsonProperty("ColorInA")]
        public string ColorInA { get; set; }

        [JsonProperty("ColorInB")]
        public string ColorInB { get; set; }

        [JsonProperty("ColorInC")]
        public string ColorInC { get; set; }

        [JsonProperty("ColorInD")]
        public string ColorInD { get; set; }

        [JsonProperty("ColorOp")]
        public string ColorOp { get; set; }

        [JsonProperty("ColorBias")]
        public string ColorBias { get; set; }

        [JsonProperty("ColorScale")]
        public string ColorScale { get; set; }

        [JsonProperty("ColorClamp")]
        public bool ColorClamp { get; set; }

        [JsonProperty("ColorRegId")]
        public string ColorRegId { get; set; }

        [JsonProperty("AlphaInA")]
        public string AlphaInA { get; set; }

        [JsonProperty("AlphaInB")]
        public string AlphaInB { get; set; }

        [JsonProperty("AlphaInC")]
        public string AlphaInC { get; set; }

        [JsonProperty("AlphaInD")]
        public string AlphaInD { get; set; }

        [JsonProperty("AlphaOp")]
        public string AlphaOp { get; set; }

        [JsonProperty("AlphaBias")]
        public string AlphaBias { get; set; }

        [JsonProperty("AlphaScale")]
        public string AlphaScale { get; set; }

        [JsonProperty("AlphaClamp")]
        public bool AlphaClamp { get; set; }

        [JsonProperty("AlphaRegId")]
        public string AlphaRegId { get; set; }
    }

    public partial class TexCoord1Gen
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("TexMatrixSource")]
        public string TexMatrixSource { get; set; }
    }

    public partial class TexMatrix1
    {
        [JsonProperty("Projection")]
        public string Projection { get; set; }

        [JsonProperty("Type")]
        public long Type { get; set; }

        [JsonProperty("EffectTranslation")]
        public double[] EffectTranslation { get; set; }

        [JsonProperty("Scale")]
        public double[] Scale { get; set; }

        [JsonProperty("Rotation")]
        public double Rotation { get; set; }

        [JsonProperty("Translation")]
        public double[] Translation { get; set; }

        [JsonProperty("ProjectionMatrix")]
        public double[][] ProjectionMatrix { get; set; }
    }

    public partial class ZMode
    {
        [JsonProperty("Enable")]
        public bool Enable { get; set; }

        [JsonProperty("Function")]
        public string Function { get; set; }

        [JsonProperty("UpdateEnable")]
        public bool UpdateEnable { get; set; }
    }

    public partial class TextureInfo
    {
        [JsonIgnore]
        public string Name { get; set; }

        [JsonIgnore]
        public int TextureHeaderID { get; set; }
    }

    public enum AlphaSelElement {
        KASel_1,     // Constant 1.0
        KASel_7_8,   // Constant 7/8
        KASel_3_4,   // Constant 3/4
        KASel_5_8,   // Constant 5/8
        KASel_1_2,   // Constant 1/2
        KASel_3_8,   // Constant 3/8
        KASel_1_4,   // Constant 1/4
        KASel_1_8,   // Constant 1/8
        KASel_K0_R,  // K0[R] Register
        KASel_K1_R,  // K1[R] Register
        KASel_K2_R,  // K2[R] Register
        KASel_K3_R,  // K3[R] Register
        KASel_K0_G,  // K0[G] Register
        KASel_K1_G,  // K1[G] Register
        KASel_K2_G,  // K2[G] Register
        KASel_K3_G,  // K3[G] Register
        KASel_K0_B,  // K0[B] Register
        KASel_K1_B,  // K1[B] Register
        KASel_K2_B,  // K2[B] Register
        KASel_K3_B,  // K3[B] Register
        KASel_K0_A,  // K0[A] Register
        KASel_K1_A,  // K1[A] Register
        KASel_K2_A,  // K2[A] Register
        KASel_K3_A   // K3[A] Register
    };

    public enum ColorSel {
        KCSel_1,     // Constant 1.0
        KCSel_7_8,   // Constant 7/8
        KCSel_3_4,   // Constant 3/4
        KCSel_5_8,   // Constant 5/8
        KCSel_1_2,   // Constant 1/2
        KCSel_3_8,   // Constant 3/8
        KCSel_1_4,   // Constant 1/4
        KCSel_1_8,   // Constant 1/8
        KCSel_K0,    // K0[RGB] Register
        KCSel_K1,    // K1[RGB] Register
        KCSel_K2,    // K2[RGB] Register
        KCSel_K3,    // K3[RGB] Register
        KCSel_K0_R,  // K0[RRR] Register
        KCSel_K1_R,  // K1[RRR] Register
        KCSel_K2_R,  // K2[RRR] Register
        KCSel_K3_R,  // K3[RRR] Register
        KCSel_K0_G,  // K0[GGG] Register
        KCSel_K1_G,  // K1[GGG] Register
        KCSel_K2_G,  // K2[GGG] Register
        KCSel_K3_G,  // K3[GGG] Register
        KCSel_K0_B,  // K0[BBB] Register
        KCSel_K1_B,  // K1[BBB] Register
        KCSel_K2_B,  // K2[BBB] Register
        KCSel_K3_B,  // K3[BBB] Register
        KCSel_K0_A,  // K0[AAA] Register
        KCSel_K1_A,  // K1[AAA] Register
        KCSel_K2_A,  // K2[AAA] Register
        KCSel_K3_A   // K3[AAA] Register
    };

    public enum TexCoord { Null, TexCoord0, TexCoord1, TexCoord2, TexCoord3, TexCoord4, TexCoord5, TexCoord6, TexCoord7 };

    public enum TexMap { Null, TexMap0, TexMap1, TexMap2, TexMap3, TexMap4, TexMap5, TexMap6, TexMap7 };

    public enum TexMatrix { Normal, Identity, TexMtx0, TexMtx1, TexMtx2, TexMtx3, TexMtx4, TexMtx5, TexMtx6, TexMtx7, TexMtx8, TexMtx9 }

    public enum TexGenType { Matrix3x4, Matrix2x4, Bump0, Bump1, Bump2, Bump3, Bump4, Bump5, Bump6, Bump7, SRTG }

    public enum TevStageAlphaSel { ITBA_OFF, ITBA_S, ITBA_T, ITBA_U };

    public enum IndTexBiasSel { ITB_S, ITB_T, ITB_ST, ITB_U, ITB_SU, ITB_TU, ITB_STU };

    public enum IndTexFormat { ITF_8, ITF_5, ITF_4, ITF_3 };

    public enum IndTexMtxId  { ITM_OFF, ITM_0, ITM_1, ITM_2, ITM_S0, ITM_S1, ITM_S2, ITM_T0, ITM_T1, ITM_T2 };

    public enum IndTexWrap { ITW_OFF, ITW_256, ITW_128, ITW_64, ITW_32, ITW_16, ITW_0 };

    public enum IndScale { ITS_1, ITS_2, ITS_4, ITS_8, ITS_16, ITS_32, ITS_64, ITS_128, ITS_256 }

    public enum TevStageEnum {TevStage0, TevStage1, TevStage2, TevStage3, TevStage4, TevStage5, TevStage6, TevStage7, TevStage8, TevStage9, TevStage10, TevStage11, TevStage12, TevStage13, TevStage14, TevStage15};

    public enum TevScale { Scale_1, Scale_2, Scale_4, Divide_2 }

    public partial class Material
    {
        public static Material[] FromJson(string json) => JsonConvert.DeserializeObject<Material[]>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Material[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                AlphaSelElementConverter.Singleton,
                ColorSelConverter.Singleton,
                TexCoordConverter.Singleton,
                TexMapConverter.Singleton,
                TevStageAlphaSelConverter.Singleton,
                IndTexBiasSelConverter.Singleton,
                IndTexFormatConverter.Singleton,
                IndTexMtxIdConverter.Singleton,
                IndTexWrapConverter.Singleton,
                TevStageEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class AlphaSelElementConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AlphaSelElement) || t == typeof(AlphaSelElement?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "KASel_K0_A")
            {
                return AlphaSelElement.KASel_K0_A;
            }
            throw new Exception("Cannot unmarshal type AlphaSelElement");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (AlphaSelElement)untypedValue;
            if (value == AlphaSelElement.KASel_K0_A)
            {
                serializer.Serialize(writer, "KASel_K0_A");
                return;
            }
            throw new Exception("Cannot marshal type AlphaSelElement");
        }

        public static readonly AlphaSelElementConverter Singleton = new AlphaSelElementConverter();
    }

    internal class ColorSelConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ColorSel) || t == typeof(ColorSel?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "KCSel_K0")
            {
                return ColorSel.KCSel_K0;
            }
            throw new Exception("Cannot unmarshal type ColorSel");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ColorSel)untypedValue;
            if (value == ColorSel.KCSel_K0)
            {
                serializer.Serialize(writer, "KCSel_K0");
                return;
            }
            throw new Exception("Cannot marshal type ColorSel");
        }

        public static readonly ColorSelConverter Singleton = new ColorSelConverter();
    }

    internal class TexCoordConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TexCoord) || t == typeof(TexCoord?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Null":
                    return TexCoord.Null;
                case "TexCoord0":
                    return TexCoord.TexCoord0;
            }
            throw new Exception("Cannot unmarshal type TexCoord");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TexCoord)untypedValue;
            switch (value)
            {
                case TexCoord.Null:
                    serializer.Serialize(writer, "Null");
                    return;
                case TexCoord.TexCoord0:
                    serializer.Serialize(writer, "TexCoord0");
                    return;
            }
            throw new Exception("Cannot marshal type TexCoord");
        }

        public static readonly TexCoordConverter Singleton = new TexCoordConverter();
    }

    internal class TexMapConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TexMap) || t == typeof(TexMap?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Null":
                    return TexMap.Null;
                case "TexMap0":
                    return TexMap.TexMap0;
            }
            throw new Exception("Cannot unmarshal type TexMap");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TexMap)untypedValue;
            switch (value)
            {
                case TexMap.Null:
                    serializer.Serialize(writer, "Null");
                    return;
                case TexMap.TexMap0:
                    serializer.Serialize(writer, "TexMap0");
                    return;
            }
            throw new Exception("Cannot marshal type TexMap");
        }

        public static readonly TexMapConverter Singleton = new TexMapConverter();
    }

    internal class TevStageAlphaSelConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TevStageAlphaSel) || t == typeof(TevStageAlphaSel?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "ITBA_OFF")
            {
                return TevStageAlphaSel.ITBA_OFF;
            }
            throw new Exception("Cannot unmarshal type TevStageAlphaSel");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TevStageAlphaSel)untypedValue;
            if (value == TevStageAlphaSel.ITBA_OFF)
            {
                serializer.Serialize(writer, "ITBA_OFF");
                return;
            }
            throw new Exception("Cannot marshal type TevStageAlphaSel");
        }

        public static readonly TevStageAlphaSelConverter Singleton = new TevStageAlphaSelConverter();
    }

    internal class IndTexBiasSelConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(IndTexBiasSel) || t == typeof(IndTexBiasSel?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "ITB_S")
            {
                return IndTexBiasSel.ITB_S;
            }
            throw new Exception("Cannot unmarshal type IndTexBiasSel");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (IndTexBiasSel)untypedValue;
            if (value == IndTexBiasSel.ITB_S)
            {
                serializer.Serialize(writer, "ITB_S");
                return;
            }
            throw new Exception("Cannot marshal type IndTexBiasSel");
        }

        public static readonly IndTexBiasSelConverter Singleton = new IndTexBiasSelConverter();
    }

    internal class IndTexFormatConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(IndTexFormat) || t == typeof(IndTexFormat?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "ITF_8")
            {
                return IndTexFormat.ITF_8;
            }
            throw new Exception("Cannot unmarshal type IndTexFormat");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (IndTexFormat)untypedValue;
            if (value == IndTexFormat.ITF_8)
            {
                serializer.Serialize(writer, "ITF_8");
                return;
            }
            throw new Exception("Cannot marshal type IndTexFormat");
        }

        public static readonly IndTexFormatConverter Singleton = new IndTexFormatConverter();
    }

    internal class IndTexMtxIdConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(IndTexMtxId) || t == typeof(IndTexMtxId?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "ITM_OFF")
            {
                return IndTexMtxId.ITM_OFF;
            }
            throw new Exception("Cannot unmarshal type IndTexMtxId");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (IndTexMtxId)untypedValue;
            if (value == IndTexMtxId.ITM_OFF)
            {
                serializer.Serialize(writer, "ITM_OFF");
                return;
            }
            throw new Exception("Cannot marshal type IndTexMtxId");
        }

        public static readonly IndTexMtxIdConverter Singleton = new IndTexMtxIdConverter();
    }

    internal class IndTexWrapConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(IndTexWrap) || t == typeof(IndTexWrap?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "ITW_OFF")
            {
                return IndTexWrap.ITW_OFF;
            }
            throw new Exception("Cannot unmarshal type IndTexWrap");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (IndTexWrap)untypedValue;
            if (value == IndTexWrap.ITW_OFF)
            {
                serializer.Serialize(writer, "ITW_OFF");
                return;
            }
            throw new Exception("Cannot marshal type IndTexWrap");
        }

        public static readonly IndTexWrapConverter Singleton = new IndTexWrapConverter();
    }

    internal class TevStageEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TevStageEnum) || t == typeof(TevStageEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "TevStage0")
            {
                return TevStageEnum.TevStage0;
            }
            throw new Exception("Cannot unmarshal type TevStageEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TevStageEnum)untypedValue;
            if (value == TevStageEnum.TevStage0)
            {
                serializer.Serialize(writer, "TevStage0");
                return;
            }
            throw new Exception("Cannot marshal type TevStageEnum");
        }

        public static readonly TevStageEnumConverter Singleton = new TevStageEnumConverter();
    }
}
