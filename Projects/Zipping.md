# Make Comp

### Overview

This Project is a CLI Interface for creating a basic competition

The project can add: Rounds, Groups & Races <br>
It can't add players.

In order for the ZipFile to appear, the System.IO.Compression.FileSystem reference must be added:
Project > Add Reference
### Code

``` csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace Zipping
{
    class Program
    {
        static void Main(string[] args)
        {
            string startPath = @".\start";
            string zipPath = @".\result.zip";
            string extractPath = @".\extract";

            ZipFile.CreateFromDirectory(startPath, zipPath);

            ZipFile.ExtractToDirectory(zipPath, extractPath);

        }
    }
}

```
