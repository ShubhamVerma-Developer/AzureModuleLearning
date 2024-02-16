# PI.ps1
$PI = 3.14
Write-Host "The value of `$PI is $PI"
Write-Host "The value of 3 and 4 is"$(3 + 4)

Param(
  [Parameter(Mandatory, HelpMessage = "Please provide a valid path")]
  $Path
)
New-Item $Path
Write-Host "File created at path $Path"