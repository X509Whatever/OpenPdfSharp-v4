iTextSharp (LGPL, Bouncy Castle)
================================

This project is a fork of [iTextSharp (LGPL / MPL) 4.1.6](https://github.com/schourode/iTextSharp-LGPL) that includes [Bouncy Castle](https://www.nuget.org/packages/BouncyCastle/) as a NuGet package instead of directly including the source code.

The idea is adding patches and backports from OpenPDF (itext LGPL fork from Java) to iTextSharp LGPL, as well as maintaining more recent BouncyCastle versions.

NuGet package
--------------

The [iTextSharp (LGPL / MPL), Bouncy Castle](https://www.nuget.org/packages/iTextSharp-LGPL-BouncyCastle-1.8/) NuGet package can be installed by running the following command in the Package Manager Console:

    Install-Package iTextSharp-LGPL-BouncyCastle-1.8
