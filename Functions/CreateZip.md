# Create Zip File

### Overview

This piece of code creates a zip file of the specified folder in the same directory as the folder.<br>
The function can be easily modified to return the zip path by adding `public string CreateZip` & `return endPath;`

### Code
``` csharp
public void CreateZip(string filePath)
        {
            bool slashAtEnd = false;
            if (filePath[filePath.Length - 1] == '\\') { slashAtEnd = true; } else { slashAtEnd = false; }

            string endPath = "";
            string startPath = filePath;

            if (slashAtEnd == true)
            {
                endPath = filePath.Substring(0, filePath.Length - 1);
                string[] split = endPath.Split('\\');
                endPath = "";
                
                for (int i = 0; i < split.Length - 1; i++) { endPath += split[i] + "\\"; }

                endPath += "result.zip";
            }

            if (slashAtEnd == false)
            {
                startPath += "\\";
            }

            ZipFile.CreateFromDirectory(startPath, endPath);
        }
```

### Testing

#### Tests
#### Screenshots
