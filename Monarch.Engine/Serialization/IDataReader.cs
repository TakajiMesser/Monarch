using Monarch.Engine.Maths;
using System;

namespace SpiceEngine.Core.Serialization
{
    public interface IDataReader
    {
        short ReadShort();
        int ReadInt();
        long ReadLong();

        ushort ReadUShort();
        uint ReadUInt();
        ulong ReadULong();

        float ReadSingle();
        double ReadDouble();

        char ReadChar();
        string ReadString();

        bool ReadBoolean();
        byte ReadByte();
        T ReadEnum<T>() where T : Enum;
        Type ReadType();

        Vector2f ReadVector2();
        Vector3f ReadVector3();
        Vector4f ReadVector4();
        Quaternion ReadQuaternion();
        Matrix4 ReadMatrix4();
        Color4 ReadColor4();

        int[] ReadIntArray();
        string[] ReadStringArray();
        Vector3f[] ReadVector3Array();
        Matrix4[] ReadMatrix4Array();
        T[] ReadDataArray<T>() where T : IGameData, new();
    }
}