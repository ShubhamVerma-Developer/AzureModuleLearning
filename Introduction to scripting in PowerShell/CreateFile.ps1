# CreateFile.ps1
Param (
  $Path
)
New-Item $Path # Creates a new file at $Path.
Write-Host "File $Path was created"


# ./CreateFile.ps1 -Path './newfile.txt'   -- run this script
