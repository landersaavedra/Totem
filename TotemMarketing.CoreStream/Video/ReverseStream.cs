using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TotemMarketing.CoreStream.Video
{
    class ReverseStream : Stream
    {

        FileStream inStream;
        internal ReverseStream(string filePath)
        {
            //opens the file and places a StreamReader around it
            inStream = File.OpenRead(filePath);
        }
        public override bool CanRead
        {
            get { return inStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void Flush()
        {
            throw new Exception("This stream does not support writing.");
        }

        public override long Length
        {
            get { throw new Exception("This stream does not support the Length property."); }
        }

        public override long Position
        {
            get
            {
                return inStream.Position;
            }
            set
            {
                throw new Exception("This stream does not support setting the Position property.");
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int countRead = inStream.Read(buffer, offset, count);
            ReverseBuffer(buffer, offset, countRead);
            return countRead;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new Exception("This stream does not support seeking.");
        }

        public override void SetLength(long value)
        {
            throw new Exception("This stream does not support setting the Length.");
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new Exception("This stream does not support writing.");
        }
        public override void Close()
        {
            inStream.Close();
            base.Close();
        }
        protected override void Dispose(bool disposing)
        {
            inStream.Dispose();
            base.Dispose(disposing);
        }
        void ReverseBuffer(byte[] buffer, int offset, int count)
        {

            int i, j;

            for (i = offset, j = offset + count - 1; i < j; i++, j--)
            {
                byte currenti = buffer[i];
                buffer[i] = buffer[j];
                buffer[j] = currenti;
            }

        }
    }
}