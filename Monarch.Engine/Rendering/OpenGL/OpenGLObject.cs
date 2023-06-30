using Silk.NET.OpenGL;

namespace Monarch.Engine.Rendering.OpenGL
{
    public enum GLObjectStates
    {
        None,
        Created,
        Deleted
    }
    
    public abstract class OpenGLObject : IDisposable
    {
        protected readonly GL _gl;

        public OpenGLObject(GL gl) => _gl = gl;

        public uint Handle { get; protected set; }
        public GLObjectStates State { get; protected set; }

        public virtual void Load()
        {
            if (State != GLObjectStates.Created)
            {
                Handle = Create();
                State = GLObjectStates.Created;

                if (Handle == 0)
                {
                    throw new Exception("Failed to generate texture: " + _gl.GetError());//GL.GetShaderInfoLog(_handle));
                }
            }
        }

        public virtual void Unload()
        {
            if (State == GLObjectStates.Created)
            {
                Delete();
                State = GLObjectStates.Deleted;
            }
        }

        protected abstract uint Create();
        protected abstract void Delete();

        public abstract void Bind();
        public abstract void Unbind();

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    Unload();
                }

                //Unload();
                disposedValue = true;
            }
        }

        ~OpenGLObject()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
