﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Exchange.Data.Globalization.RemapEncoding
// Assembly: Microsoft.Exchange.Data.Common, Version=15.0.1040.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 60AF4FF7-547F-476B-8FAC-6C80D63CB41A
// Assembly location: C:\Users\Thomas\Downloads\Microsoft.Exchange.Data.Common.dll

using System;
using System.Linq;
using System.Text;

namespace Butler.Schema.Data.Globalization
{
  [Serializable]
  internal class RemapEncoding : Encoding
  {
    private Encoding encodingEncoding;
    private Encoding decodingEncoding;

    public override int CodePage => this.encodingEncoding.CodePage;

      public override string BodyName => this.encodingEncoding.BodyName;

      public override string EncodingName => this.encodingEncoding.EncodingName;

      public override string HeaderName => this.encodingEncoding.HeaderName;

      public override string WebName => this.encodingEncoding.WebName;

      public override int WindowsCodePage => this.encodingEncoding.WindowsCodePage;

      public override bool IsBrowserDisplay => this.encodingEncoding.IsBrowserDisplay;

      public override bool IsBrowserSave => this.encodingEncoding.IsBrowserSave;

      public override bool IsMailNewsDisplay => this.encodingEncoding.IsMailNewsDisplay;

      public override bool IsMailNewsSave => this.encodingEncoding.IsMailNewsSave;

      public override bool IsSingleByte => this.encodingEncoding.IsSingleByte;

      public RemapEncoding(int codePage)
      : base(codePage)
    {
      if (codePage == 28591)
      {
        this.encodingEncoding = Encoding.GetEncoding(28591);
        this.decodingEncoding = Encoding.GetEncoding(1252);
      }
      else
      {
        if (codePage != 28599)
          throw new ArgumentException();
        this.encodingEncoding = Encoding.GetEncoding(28599);
        this.decodingEncoding = Encoding.GetEncoding(1254);
      }
    }

    public override byte[] GetPreamble()
    {
      return this.encodingEncoding.GetPreamble();
    }

    public override int GetMaxByteCount(int charCount)
    {
      return this.encodingEncoding.GetMaxByteCount(charCount);
    }

    public override int GetMaxCharCount(int byteCount)
    {
      return this.decodingEncoding.GetMaxCharCount(byteCount);
    }

    public override int GetByteCount(char[] chars, int index, int count)
    {
      return this.encodingEncoding.GetByteCount(chars, index, count);
    }

    public override int GetByteCount(string s)
    {
      return this.encodingEncoding.GetByteCount(s);
    }

    public override unsafe int GetByteCount(char* chars, int count)
    {
      return this.encodingEncoding.GetByteCount(chars, count);
    }

    public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
    {
      return this.encodingEncoding.GetBytes(s, charIndex, charCount, bytes, byteIndex);
    }

    public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
    {
      return this.encodingEncoding.GetBytes(chars, charIndex, charCount, bytes, byteIndex);
    }

    public override unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount)
    {
      return this.encodingEncoding.GetBytes(chars, charCount, bytes, byteCount);
    }

    public override int GetCharCount(byte[] bytes, int index, int count)
    {
      return this.decodingEncoding.GetCharCount(bytes, index, count);
    }

    public override unsafe int GetCharCount(byte* bytes, int count)
    {
      return this.decodingEncoding.GetCharCount(bytes, count);
    }

    public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
    {
      return this.decodingEncoding.GetChars(bytes, byteIndex, byteCount, chars, charIndex);
    }

    public override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount)
    {
      return this.decodingEncoding.GetChars(bytes, byteCount, chars, charCount);
    }

    public override string GetString(byte[] bytes, int index, int count)
    {
      return this.decodingEncoding.GetString(bytes, index, count);
    }

    public override Decoder GetDecoder()
    {
      return this.decodingEncoding.GetDecoder();
    }

    public override Encoder GetEncoder()
    {
      return this.encodingEncoding.GetEncoder();
    }

    public override object Clone()
    {
      return (object) (Encoding) this.MemberwiseClone();
    }
  }
}
