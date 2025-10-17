// Copyright (c) Stéphane ANDRE. All Right Reserved.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MyNet.Xaml.Html;

public static class XamlToImageFileService
{
    public static void SaveImage(string xamlFilePath, string filePath) => SaveImage(XamlToBitmapConverter.ToBitmapSource(xamlFilePath), filePath);

    public static void SaveImage(FrameworkElement frameworkElement, string filePath) => SaveImage(XamlToBitmapConverter.ToBitmapSource(frameworkElement), filePath);

    public static void SaveImage(Visual visual, Size size, string filePath) => SaveImage(XamlToBitmapConverter.ToBitmapSource(visual, size), filePath);

    private static void SaveImage(BitmapSource bitmap, string filePath)
    {
        var fullPath = Path.GetFullPath(filePath);

        var encoder = CreateBitmapEncoder(fullPath);
        encoder.Frames.Add(BitmapFrame.Create(bitmap));

        using var stream = File.Create(fullPath);
        encoder.Save(stream);
    }

    public static void SaveIcon(string xamlFilePath, string filePath) => SaveIcon(XamlToBitmapConverter.ToBitmapSource(xamlFilePath), filePath);

    public static void SaveIcon(FrameworkElement frameworkElement, string filePath) => SaveIcon(XamlToBitmapConverter.ToBitmapSource(frameworkElement), filePath);

    public static void SaveIcon(Visual visual, Size size, string filePath) => SaveIcon(XamlToBitmapConverter.ToBitmapSource(visual, size), filePath);

    private static void SaveIcon(BitmapSource bitmap, string filePath)
    {
        using var input = ToStream(bitmap);
        SaveIcon(input, filePath);
    }

    public static void SaveIcon(Stream input, string outputFilePath)
    {
        var fullPath = Path.GetFullPath(outputFilePath);

        using var stream = File.Create(fullPath);
        SaveIcon(input, stream);
    }

    private static void SaveIcon(Stream input, Stream output)
    {
        // Reset stream position to the beginning
        input.Position = 0;

        // Decode the bitmap from the input stream
        var decoder = BitmapDecoder.Create(input, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
        var frame = decoder.Frames[0];

        // Create a PNG encoder to write the icon
        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(frame));

        // Write ICO header
        using var writer = new BinaryWriter(output);
        
        // ICO header (6 bytes)
        writer.Write((short)0); // Reserved (must be 0)
        writer.Write((short)1); // Image type (1 = ICO)
        writer.Write((short)1); // Number of images

        // Image directory entry (16 bytes)
        var width = frame.PixelWidth > 255 ? 0 : (byte)frame.PixelWidth;
        var height = frame.PixelHeight > 255 ? 0 : (byte)frame.PixelHeight;
        
        writer.Write(width);    // Width
        writer.Write(height);   // Height
        writer.Write((byte)0);  // Color palette
        writer.Write((byte)0);  // Reserved
        writer.Write((short)1); // Color planes
        writer.Write((short)32); // Bits per pixel
        
        // Get PNG data
        using var pngStream = new MemoryStream();
        encoder.Save(pngStream);
        var pngData = pngStream.ToArray();
        
        writer.Write((int)pngData.Length); // Size of image data
        writer.Write((int)22); // Offset of image data (6 + 16 = 22)
        
        // Write PNG data
        writer.Write(pngData);
    }

    private static MemoryStream ToStream(BitmapSource bitmap)
    {
        var memory = new MemoryStream();

        var encoder = new BmpBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(bitmap));
        encoder.Save(memory);

        return memory;
    }

    private static BitmapEncoder CreateBitmapEncoder(string filePath) => Path.GetExtension(filePath).ToLowerInvariant() switch
    {
        ".bmp" => new BmpBitmapEncoder(),
        ".gif" => new GifBitmapEncoder(),
        ".jpeg" or ".jpg" or ".jpe" => new JpegBitmapEncoder(),
        ".png" => new PngBitmapEncoder(),
        ".tiff" or ".tif" => new TiffBitmapEncoder(),
        ".wdp" or ".hdp" => new WmpBitmapEncoder(),
        _ => throw new ArgumentException("Can not encode bitmaps for the specified file extension.", nameof(filePath)),
    };

}
