﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Exchange.Data.TextConverters.RtfToHtml
// Assembly: Microsoft.Exchange.Data.Common, Version=15.0.1040.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 60AF4FF7-547F-476B-8FAC-6C80D63CB41A
// Assembly location: C:\Users\Thomas\Downloads\Microsoft.Exchange.Data.Common.dll

using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Butler.Schema.Data.TextConverters
{
  public class RtfToHtml : TextConverter
  {
    private bool outputEncodingSameAsInput = true;
    private bool enableHtmlDeencapsulation = true;
    private bool testTruncateForCallback = true;
    private bool testTraceShowTokenNum = true;
    private bool testHtmlTraceShowTokenNum = true;
    private bool testNormalizerTraceShowTokenNum = true;
    private int testMaxTokenRuns = 512;
    private int maxHtmlTagSize = 32768;
    private int testMaxHtmlTagAttributes = 64;
    private int testMaxHtmlNormalizerNesting = 4096;
    private int smallCssBlockThreshold = -1;
    private Encoding outputEncoding;
    private bool normalizeInputHtml;
    private bool filterHtml;
    private HtmlTagCallback htmlCallback;
    private HeaderFooterFormat injectionFormat;
    private string injectHead;
    private string injectTail;
    private bool outputFragment;
    private RtfEncapsulation rtfEncapsulation;
    private Stream testTraceStream;
    private int testTraceStopOnTokenNum;
    private Stream testFormatTraceStream;
    private Stream testFormatOutputTraceStream;
    private Stream testFormatConverterTraceStream;
    private Stream testHtmlTraceStream;
    private int testHtmlTraceStopOnTokenNum;
    private Stream testNormalizerTraceStream;
    private int testNormalizerTraceStopOnTokenNum;
    private bool testNoNewLines;
    private bool preserveDisplayNoneStyle;
    private ReportBytes reportBytes;
    private int expansionSizeLimit;
    private int expansionSizeMultiple;

    public bool EncapsulatedHtml
    {
      get
      {
        return this.rtfEncapsulation == RtfEncapsulation.Html;
      }
    }

    public bool ConvertedFromText
    {
      get
      {
        return this.rtfEncapsulation == RtfEncapsulation.Text;
      }
    }

    public Encoding OutputEncoding
    {
      get
      {
        return this.outputEncoding;
      }
      set
      {
        this.AssertNotLocked();
        this.outputEncoding = value;
        this.outputEncodingSameAsInput = value == null;
      }
    }

    public bool EnableHtmlDeencapsulation
    {
      get
      {
        return this.enableHtmlDeencapsulation;
      }
      set
      {
        this.AssertNotLocked();
        this.enableHtmlDeencapsulation = value;
      }
    }

    public bool OutputHtmlFragment
    {
      get
      {
        return this.outputFragment;
      }
      set
      {
        this.AssertNotLocked();
        this.outputFragment = value;
      }
    }

    public bool NormalizeHtml
    {
      get
      {
        return this.normalizeInputHtml;
      }
      set
      {
        this.AssertNotLocked();
        this.normalizeInputHtml = value;
      }
    }

    public bool FilterHtml
    {
      get
      {
        return this.filterHtml;
      }
      set
      {
        this.AssertNotLocked();
        this.filterHtml = value;
      }
    }

    public HtmlTagCallback HtmlTagCallback
    {
      get
      {
        return this.htmlCallback;
      }
      set
      {
        this.AssertNotLocked();
        this.htmlCallback = value;
      }
    }

    public int MaxCallbackTagLength
    {
      get
      {
        return this.maxHtmlTagSize;
      }
      set
      {
        this.AssertNotLocked();
        this.maxHtmlTagSize = value;
      }
    }

    public HeaderFooterFormat HeaderFooterFormat
    {
      get
      {
        return this.injectionFormat;
      }
      set
      {
        this.AssertNotLocked();
        this.injectionFormat = value;
      }
    }

    public string Header
    {
      get
      {
        return this.injectHead;
      }
      set
      {
        this.AssertNotLocked();
        this.injectHead = value;
      }
    }

    public string Footer
    {
      get
      {
        return this.injectTail;
      }
      set
      {
        this.AssertNotLocked();
        this.injectTail = value;
      }
    }

    internal RtfToHtml SetOutputEncoding(Encoding value)
    {
      this.OutputEncoding = value;
      return this;
    }

    internal RtfToHtml SetNormalizeHtml(bool value)
    {
      this.NormalizeHtml = value;
      return this;
    }

    internal RtfToHtml SetFilterHtml(bool value)
    {
      this.FilterHtml = value;
      return this;
    }

    internal RtfToHtml SetHtmlTagCallback(HtmlTagCallback value)
    {
      this.HtmlTagCallback = value;
      return this;
    }

    internal RtfToHtml SetTestTruncateForCallback(bool value)
    {
      this.testTruncateForCallback = value;
      return this;
    }

    internal RtfToHtml SetMaxCallbackTagLength(int value)
    {
      this.maxHtmlTagSize = value;
      return this;
    }

    internal RtfToHtml SetHeaderFooterFormat(HeaderFooterFormat value)
    {
      this.HeaderFooterFormat = value;
      return this;
    }

    internal RtfToHtml SetHeader(string value)
    {
      this.Header = value;
      return this;
    }

    internal RtfToHtml SetFooter(string value)
    {
      this.Footer = value;
      return this;
    }

    internal RtfToHtml SetInputStreamBufferSize(int value)
    {
      this.InputStreamBufferSize = value;
      return this;
    }

    internal RtfToHtml SetTestBoundaryConditions(bool value)
    {
      this.testBoundaryConditions = value;
      if (value)
      {
        this.maxHtmlTagSize = 123;
        this.testMaxHtmlTagAttributes = 5;
        this.testMaxHtmlNormalizerNesting = 10;
      }
      return this;
    }

    internal RtfToHtml SetTestTraceStream(Stream value)
    {
      this.testTraceStream = value;
      return this;
    }

    internal RtfToHtml SetTestTraceShowTokenNum(bool value)
    {
      this.testTraceShowTokenNum = value;
      return this;
    }

    internal RtfToHtml SetTestTraceStopOnTokenNum(int value)
    {
      this.testTraceStopOnTokenNum = value;
      return this;
    }

    internal RtfToHtml SetTestFormatTraceStream(Stream value)
    {
      this.testFormatTraceStream = value;
      return this;
    }

    internal RtfToHtml SetTestFormatOutputTraceStream(Stream value)
    {
      this.testFormatOutputTraceStream = value;
      return this;
    }

    internal RtfToHtml SetTestFormatConverterTraceStream(Stream value)
    {
      this.testFormatConverterTraceStream = value;
      return this;
    }

    internal RtfToHtml SetTestHtmlTraceStream(Stream value)
    {
      this.testHtmlTraceStream = value;
      return this;
    }

    internal RtfToHtml SetTestHtmlTraceShowTokenNum(bool value)
    {
      this.testHtmlTraceShowTokenNum = value;
      return this;
    }

    internal RtfToHtml SetTestHtmlTraceStopOnTokenNum(int value)
    {
      this.testHtmlTraceStopOnTokenNum = value;
      return this;
    }

    internal RtfToHtml SetTestNormalizerTraceStream(Stream value)
    {
      this.testNormalizerTraceStream = value;
      return this;
    }

    internal RtfToHtml SetTestNormalizerTraceShowTokenNum(bool value)
    {
      this.testNormalizerTraceShowTokenNum = value;
      return this;
    }

    internal RtfToHtml SetTestNormalizerTraceStopOnTokenNum(int value)
    {
      this.testNormalizerTraceStopOnTokenNum = value;
      return this;
    }

    internal RtfToHtml SetTestMaxTokenRuns(int value)
    {
      this.testMaxTokenRuns = value;
      return this;
    }

    internal RtfToHtml SetTestMaxHtmlTagAttributes(int value)
    {
      this.testMaxHtmlTagAttributes = value;
      return this;
    }

    internal RtfToHtml SetTestMaxHtmlNormalizerNesting(int value)
    {
      this.testMaxHtmlNormalizerNesting = value;
      return this;
    }

    internal RtfToHtml SetTestNoNewLines(bool value)
    {
      this.testNoNewLines = value;
      return this;
    }

    internal RtfToHtml SetSmallCssBlockThreshold(int value)
    {
      this.smallCssBlockThreshold = value;
      return this;
    }

    internal RtfToHtml SetPreserveDisplayNoneStyle(bool value)
    {
      this.preserveDisplayNoneStyle = value;
      return this;
    }

    internal RtfToHtml SetExpansionSizeLimit(int value)
    {
      this.expansionSizeLimit = value;
      return this;
    }

    internal RtfToHtml SetExpansionSizeMultiple(int value)
    {
      this.expansionSizeMultiple = value;
      return this;
    }

    internal override IProducerConsumer CreatePushChain(ConverterStream converterStream, Stream output)
    {
      ConverterOutput output1 = (ConverterOutput) new ConverterEncodingOutput(output, true, false, this.outputEncodingSameAsInput ? Encoding.GetEncoding("Windows-1252") : this.outputEncoding, this.outputEncodingSameAsInput, this.testBoundaryConditions, (IResultsFeedback) this);
      return this.CreateChain((Stream) converterStream, true, output1, (IProgressMonitor) converterStream);
    }

    internal override IProducerConsumer CreatePushChain(ConverterStream converterStream, TextWriter output)
    {
      ConverterOutput output1 = (ConverterOutput) new ConverterUnicodeOutput((object) output, true, false);
      return this.CreateChain((Stream) converterStream, true, output1, (IProgressMonitor) converterStream);
    }

    internal override IProducerConsumer CreatePushChain(ConverterWriter converterWriter, Stream output)
    {
      throw new NotSupportedException(CtsResources.TextConvertersStrings.CannotUseConverterWriter);
    }

    internal override IProducerConsumer CreatePushChain(ConverterWriter converterWriter, TextWriter output)
    {
      throw new NotSupportedException(CtsResources.TextConvertersStrings.CannotUseConverterWriter);
    }

    internal override IProducerConsumer CreatePullChain(Stream input, ConverterStream converterStream)
    {
      ConverterOutput output = (ConverterOutput) new ConverterEncodingOutput((Stream) converterStream, false, false, this.outputEncodingSameAsInput ? Encoding.GetEncoding("Windows-1252") : this.outputEncoding, this.outputEncodingSameAsInput, this.testBoundaryConditions, (IResultsFeedback) this);
      return this.CreateChain(input, false, output, (IProgressMonitor) converterStream);
    }

    internal override IProducerConsumer CreatePullChain(System.IO.TextReader input, ConverterStream converterStream)
    {
      throw new NotSupportedException(CtsResources.TextConvertersStrings.TextReaderUnsupported);
    }

    internal override IProducerConsumer CreatePullChain(Stream input, ConverterReader converterReader)
    {
      ConverterOutput output = (ConverterOutput) new ConverterUnicodeOutput((object) converterReader, false, false);
      return this.CreateChain(input, false, output, (IProgressMonitor) converterReader);
    }

    internal override IProducerConsumer CreatePullChain(System.IO.TextReader input, ConverterReader converterReader)
    {
      throw new NotSupportedException(CtsResources.TextConvertersStrings.TextReaderUnsupported);
    }

    private IProducerConsumer CreateChain(Stream input, bool push, ConverterOutput output, IProgressMonitor progressMonitor)
    {
      this.locked = true;
      this.reportBytes = new ReportBytes(this.expansionSizeLimit, this.expansionSizeMultiple);
      output.ReportBytes = (IReportBytes) this.reportBytes;
      if (this.enableHtmlDeencapsulation)
      {
        RtfPreviewStream rtfPreviewStream = input as RtfPreviewStream;
        if (push || rtfPreviewStream == null || (rtfPreviewStream.Parser == null || rtfPreviewStream.InternalPosition != 0) || rtfPreviewStream.InputRtfStream == null)
          return (IProducerConsumer) new Internal.Rtf.RtfToHtmlAdapter(new Internal.Rtf.RtfParser(input, push, this.InputStreamBufferSize, this.testBoundaryConditions, push ? (IProgressMonitor) null : progressMonitor, (IReportBytes) this.reportBytes), output, this, progressMonitor);
        rtfPreviewStream.InternalPosition = int.MaxValue;
        Internal.Rtf.RtfParser parser = new Internal.Rtf.RtfParser(rtfPreviewStream.InputRtfStream, this.InputStreamBufferSize, this.testBoundaryConditions, push ? (IProgressMonitor) null : progressMonitor, rtfPreviewStream.Parser, (IReportBytes) this.reportBytes);
        return this.CreateChain(rtfPreviewStream.Encapsulation, parser, output, progressMonitor);
      }
      Internal.Rtf.RtfParser parser1 = new Internal.Rtf.RtfParser(input, push, this.InputStreamBufferSize, this.testBoundaryConditions, push ? (IProgressMonitor) null : progressMonitor, (IReportBytes) this.reportBytes);
      HtmlInjection injection = (HtmlInjection) null;
      if (this.injectHead != null || this.injectTail != null)
        injection = new HtmlInjection(this.injectHead, this.injectTail, this.injectionFormat, this.filterHtml, this.htmlCallback, this.testBoundaryConditions, (Stream) null, progressMonitor);
      Internal.Format.FormatOutput output1 = (Internal.Format.FormatOutput) new Internal.Html.HtmlFormatOutput(new HtmlWriter(output, this.filterHtml, !this.testNoNewLines), injection, this.outputFragment, this.testFormatTraceStream, this.testFormatOutputTraceStream, this.filterHtml, this.htmlCallback, true);
      return (IProducerConsumer) new Internal.Rtf.RtfFormatConverter(parser1, output1, (Injection) null, false, this.testTraceStream, this.testTraceShowTokenNum, this.testTraceStopOnTokenNum, this.testFormatConverterTraceStream);
    }

    internal IProducerConsumer CreateChain(RtfEncapsulation encapsulation, Internal.Rtf.RtfParser parser, ConverterOutput output, IProgressMonitor progressMonitor)
    {
      this.rtfEncapsulation = encapsulation;
      if (this.reportBytes == null)
        throw new InvalidOperationException("I have an RtfParser but no ReportBytes.");
      output.ReportBytes = (IReportBytes) this.reportBytes;
      if (encapsulation != RtfEncapsulation.Html)
      {
        HtmlInjection injection = (HtmlInjection) null;
        if (this.injectHead != null || this.injectTail != null)
          injection = new HtmlInjection(this.injectHead, this.injectTail, this.injectionFormat, this.filterHtml, this.htmlCallback, this.testBoundaryConditions, (Stream) null, progressMonitor);
        Internal.Format.FormatOutput output1 = (Internal.Format.FormatOutput) new Internal.Html.HtmlFormatOutput(new HtmlWriter(output, this.filterHtml, !this.testNoNewLines), injection, this.outputFragment, this.testFormatTraceStream, this.testFormatOutputTraceStream, this.filterHtml, this.htmlCallback, true);
        return (IProducerConsumer) new Internal.Rtf.RtfFormatConverter(parser, output1, (Injection) null, false, this.testTraceStream, this.testTraceShowTokenNum, this.testTraceStopOnTokenNum, this.testFormatConverterTraceStream);
      }
      HtmlInjection injection1 = (HtmlInjection) null;
      HtmlInjection htmlInjection = (HtmlInjection) null;
      try
      {
        if (this.injectHead != null || this.injectTail != null)
        {
          htmlInjection = new HtmlInjection(this.injectHead, this.injectTail, this.injectionFormat, this.filterHtml, this.htmlCallback, this.testBoundaryConditions, (Stream) null, progressMonitor);
          injection1 = htmlInjection;
          this.normalizeInputHtml = true;
        }
        if (this.filterHtml || this.outputFragment || this.htmlCallback != null)
          this.normalizeInputHtml = true;
        Internal.Rtf.HtmlInRtfExtractingInput rtfExtractingInput = new Internal.Rtf.HtmlInRtfExtractingInput(parser, this.maxHtmlTagSize, this.testBoundaryConditions, this.testTraceStream, this.testTraceShowTokenNum, this.testTraceStopOnTokenNum);
        Internal.Html.IHtmlParser parser1;
        if (this.normalizeInputHtml)
        {
          parser1 = (Internal.Html.IHtmlParser) new Internal.Html.HtmlNormalizingParser(new Internal.Html.HtmlParser((ConverterInput) rtfExtractingInput, false, false, this.testMaxTokenRuns, this.testMaxHtmlTagAttributes, this.testBoundaryConditions), injection1, this.htmlCallback != null, this.testMaxHtmlNormalizerNesting, this.testBoundaryConditions, this.testNormalizerTraceStream, this.testNormalizerTraceShowTokenNum, this.testNormalizerTraceStopOnTokenNum);
          htmlInjection = (HtmlInjection) null;
        }
        else
          parser1 = (Internal.Html.IHtmlParser) new Internal.Html.HtmlParser((ConverterInput) rtfExtractingInput, false, false, this.testMaxTokenRuns, this.testMaxHtmlTagAttributes, this.testBoundaryConditions);
        HtmlWriter writer = new HtmlWriter(output, this.filterHtml, this.normalizeInputHtml && !this.testNoNewLines);
        return (IProducerConsumer) new Internal.Html.HtmlToHtmlConverter(parser1, writer, false, this.outputFragment, this.filterHtml, this.htmlCallback, this.testTruncateForCallback, injection1 != null && injection1.HaveTail, this.testHtmlTraceStream, this.testHtmlTraceShowTokenNum, this.testHtmlTraceStopOnTokenNum, this.smallCssBlockThreshold, this.preserveDisplayNoneStyle, progressMonitor);
      }
      finally
      {
        IDisposable disposable = (IDisposable) htmlInjection;
        if (disposable != null)
          disposable.Dispose();
      }
    }

    internal override void SetResult(ConfigParameter parameterId, object val)
    {
      switch (parameterId)
      {
        case ConfigParameter.OutputEncoding:
          this.outputEncoding = (Encoding) val;
          break;
        case ConfigParameter.RtfEncapsulation:
          this.rtfEncapsulation = (RtfEncapsulation) val;
          break;
      }
      base.SetResult(parameterId, val);
    }
  }
}
