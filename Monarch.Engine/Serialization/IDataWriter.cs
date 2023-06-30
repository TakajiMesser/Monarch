using Monarch.Engine.Maths;
using System;

namespace SpiceEngine.Core.Serialization
{
    public interface IDataWriter
    {
        void WriteShort(short value);
        void WriteInt(int value);
        void WriteLong(long value);

        void WriteUShort(ushort value);
        void WriteUInt(uint value);
        void WriteULong(ulong value);

        void WriteSingle(float value);
        void WriteDouble(double value);

        void WriteChar(char value);
        void WriteString(string value);

        void WriteBoolean(bool value);
        void WriteByte(byte value);
        void WriteEnum<T>(T value) where T : Enum;
        void WriteType(Type type);

        void WriteVector2(Vector2f value);
        void WriteVector3(Vector3f value);
        void WriteVector4(Vector4f value);
        void WriteQuaternion(Quaternion value);
        void WriteMatrix4(Matrix4 value);
        void WriteColor4(Color4 value);

        void WriteIntArray(int[] value);
        void WriteStringArray(string[] value);
        void WriteVector3Array(Vector3f[] value);
        void WriteMatrix4Array(Matrix4[] value);
        void WriteDataArray<T>(T[] value) where T : IGameData, new();
    }
}