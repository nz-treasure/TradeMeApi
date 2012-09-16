using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BadgerSoft.TradeMe.Api.Helpers
{
    public class StringWriterWithEncoding : StringWriter
    {
        Encoding encoding;

        public StringWriterWithEncoding(Encoding encoding)
        {
            this.encoding = encoding;
        }

        public StringWriterWithEncoding(StringBuilder builder, Encoding encoding)
            : base(builder)
        {
            this.encoding = encoding;
        }

        public override Encoding Encoding
        {
            get { return encoding; }
        }
    }
}
