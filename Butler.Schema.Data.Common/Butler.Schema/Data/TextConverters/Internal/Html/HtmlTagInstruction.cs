﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Exchange.Data.TextConverters.Internal.Html.HtmlTagInstruction
// Assembly: Microsoft.Exchange.Data.Common, Version=15.0.1040.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 60AF4FF7-547F-476B-8FAC-6C80D63CB41A
// Assembly location: C:\Users\Thomas\Downloads\Microsoft.Exchange.Data.Common.dll

using System;
using System.Linq;

namespace Butler.Schema.Data.TextConverters.Internal.Html
{
  internal struct HtmlTagInstruction
  {
    private Format.FormatContainerType containerType;
    private int defaultStyle;
    private int inheritanceMaskIndex;
    private HtmlAttributeInstruction[] attributeInstructions;

    public Format.FormatContainerType ContainerType
    {
      get
      {
        return this.containerType;
      }
    }

    public int DefaultStyle
    {
      get
      {
        return this.defaultStyle;
      }
    }

    public int InheritanceMaskIndex
    {
      get
      {
        return this.inheritanceMaskIndex;
      }
    }

    public HtmlAttributeInstruction[] AttributeInstructions
    {
      get
      {
        return this.attributeInstructions;
      }
    }

    public HtmlTagInstruction(Format.FormatContainerType containerType, int defaultStyle, int inheritanceMaskIndex, HtmlAttributeInstruction[] attributeInstructions)
    {
      this.containerType = containerType;
      this.defaultStyle = defaultStyle;
      this.inheritanceMaskIndex = inheritanceMaskIndex;
      this.attributeInstructions = attributeInstructions;
    }
  }
}
