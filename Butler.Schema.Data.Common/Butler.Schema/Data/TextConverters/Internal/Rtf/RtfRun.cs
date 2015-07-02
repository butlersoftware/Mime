﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Exchange.Data.TextConverters.Internal.Rtf.RtfRun
// Assembly: Microsoft.Exchange.Data.Common, Version=15.0.1040.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 60AF4FF7-547F-476B-8FAC-6C80D63CB41A
// Assembly location: C:\Users\Thomas\Downloads\Microsoft.Exchange.Data.Common.dll

using System;
using System.Diagnostics;
using System.Linq;

namespace Butler.Schema.Data.TextConverters.Internal.Rtf
{
  internal struct RtfRun
  {
    private RtfToken token;

    public byte[] Buffer
    {
      get
      {
        return this.token.Buffer;
      }
    }

    public int Offset
    {
      get
      {
        return this.token.CurrentRunOffset;
      }
    }

    public int Length
    {
      get
      {
        return (int) this.token.RunQueue[this.token.CurrentRun].Length;
      }
    }

    public RtfRunKind Kind
    {
      get
      {
        return this.token.RunQueue[this.token.CurrentRun].Kind;
      }
    }

    public short KeywordId
    {
      get
      {
        return this.token.RunQueue[this.token.CurrentRun].KeywordId;
      }
    }

    public int Value
    {
      get
      {
        return this.token.RunQueue[this.token.CurrentRun].Value;
      }
    }

    public bool Skip
    {
      get
      {
        return this.token.RunQueue[this.token.CurrentRun].Skip;
      }
    }

    public bool Lead
    {
      get
      {
        return this.token.RunQueue[this.token.CurrentRun].Lead;
      }
    }

    internal RtfRun(RtfToken token)
    {
      this.token = token;
    }

    [Conditional("DEBUG")]
    private void AssertCurrent()
    {
    }
  }
}
