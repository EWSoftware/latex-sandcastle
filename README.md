## This project has been retired and no longer supported

Requirements:
Sandcastle Help File Builder v2021.10.23.0 or later

Instructions

1. Set the CPU platform for the mimetex project to match your platform.
2. Build the LatexBuildComponent project.
3. From the *source\out\\* folder, copy the two DLLs into the Sandcastle Help File Builder (SHFB) Components and Plug-Ins directory.  This directory differs depending on your OS.

   Windows Vista, 7, & 8: *%ProgramData%\EWSoftware\Sandcastle Help File Builder\Components and Plug-Ins*

   Windows XP: *%ALLUSERSPROFILE%\Application Data\EWSoftware\Sandcastle Help File Builder\Components and Plug-Ins*

4. In your SHFB project file, add the "LaTeX Build Component" to the project in the *Components* project property category.
5. Add `<latex>` tags to your XML comments.  The `<latex>` tag must be placed inside regular XML comment tags.

   Example: `///<summary><latex>f(x)=x^2</latex></summary>`

   For complex LaTeX code, it should be placed in a CDATA tag, i.e. `<latex><!CDATA[f(x)=x^2]]></latex>`

   The LaTeX code can be inside the latex tag, or in an "expr" attribute of the latex tag.

   Example: `///<summary><latex expr="f(x)=x^2"/></summary>`

   If code is in both the expr attribute and the tag body, the code in the attribute is used and the body code is discarded.

6. Run SHFB as usual.

Notes

1. This component uses mimeTeX 1.7.4 (http://www.forkosh.com/mimetex.html) to parse LaTeX code.
2. mimeTeX uses "large" for the default font size (see the mimeTeX quick start guide). You can change the default font size in the build component's configuration.  To do so:
   1. In SHFB, select the *Components* project property category and then add the "LaTeX Build Component" to the project.
   2. Click Configure to change the settings.
   3. Set the new default font size and click OK.
