using System.Collections;
using System.Collections.Generic;
using System;

namespace AgaiEngine
{

    /// <summary>
    /// Ranks S, A, B, C D, E
    /// </summary>
    public enum RankType
    {
        None = 1,
        E = 7,
        D = 10,
        C = 15,
        B = 17,
        A = 20,
        S = 25,
    }
    /// This contains ranks like S, A, B, C... and their value (for calculations)
    public enum Ranks
    {
        S = 25, A = 20, B = 17, C = 15, D = 10, E = 7
    };


    public class Attribute<T> where T : struct, 
          IComparable,
              IComparable<T>,
              IConvertible,
              IEquatable<T>,
              IFormattable
    {
        public T Value;

        public RankType Rank;

        //public Attribute(const YAML::Node& data){
        //    LoadData(data);
        //}

        //public virtual void LoadData(const YAML::Node& data){
        //    const YAML::Node* temp = data.FindValue("Value");
        //    if(temp)
        //        Value = temp->to<T>();
        //    else
        //        std::cout << "Failed to load Attribute Value:" << temp << std::endl;
        //    temp = data.FindValue("Rank");
        //    if(temp)
        //        Rank = RankType(temp->to<UInt32>());
        //    else
        //        std::cout << "Failed to load Attribute Rank:" << temp << std::endl;
        //}

        //public virtual void LoadData(const YAML::Node* data){
        //    if(data) // to make the data optional
        //        LoadData(*data);
        //}

        //public virtual YAML::Emitter& Serialize(YAML::Emitter& out) const {
        //    out << YAML::BeginMap;
        //    out << YAML::Key << "Value" << YAML::Value << Value;
        //    out << YAML::Key << "Rank" << YAML::Value << Rank;
        //    return out;
        //}

        //public int operator *(int val) { return (int)(Value*val); }
        //public UInt32 operator *(UInt32 val) { return (UInt32)(Value*val); }
        //public float operator *(float val) { return (float)(Value*val); }
        //public double operator *(double val) { return (double)Value*val; }

        //public int operator /(int val) { return (int)(Value / val); }
        //public UInt32 operator /(UInt32 val) { return (UInt32)(Value / val); }
        //public float operator /(float val) { return (float)(Value/val); }
        //public double operator /(double val) { return Value/val; }

        //public int operator +(int val) { return (int)(Value + val); }
        //public UInt32 operator +(UInt32 val) { return (UInt32)(Value + val); }
        //public float operator +(float val) { return (float)(Value + val); }
        //public double operator +(double val) { return Value + val; }

        //public T operator +(Attribute<UInt32>& attr) { return (T)(Value + attr.Value); }
        //public T operator +(Attribute<int>& attr) { return (T)(Value + attr.Value); }
        //public T operator +(Attribute<float>& attr) { return (T)(Value + attr.Value); }
        //public T operator +(Attribute<double>& attr) { return (T)(Value + attr.Value); }

        //public int operator -(Attribute<UInt32>& attr) { return (int)(Value - attr.Value); }
        //public int operator -(Attribute<int>& attr) { return (int)(Value - attr.Value); }
        //public float operator -(Attribute<float>& attr) { return (float)(Value - attr.Value); }
        //public double operator -(Attribute<double>& attr) { return (double)(Value - attr.Value); }
    }
}